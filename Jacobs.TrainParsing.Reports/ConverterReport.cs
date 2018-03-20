using Jacobs.TrainParsing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Cells;
using Jacobs.TrainParsing.Common.AoSummary;
using Jacobs.TrainParsing.Common.ConverterPortion;

namespace Jacobs.TrainParsing.Reports
{
    public static class ConverterReport
    {
        public static void CreateWorkBook(List<Report> reports, string outputName, IReadOnlyList<AoSummaryPortion> summary)
        {
            var asposeLicense = new License();
            asposeLicense.SetLicense("Aspose.Cells.lic");
            var wb = new Workbook();
            var converterWorksheets = GetConverterWorksheets(reports, summary);

            var i = 0;
            foreach (var worksheet in converterWorksheets)
            {
                var ws = wb.Worksheets[i];
                ws.Name = worksheet.WorksheetName;
                ws.Cells.ImportCustomObjects(worksheet.Data.ToList(), 0, 0, new ImportTableOptions { IsFieldNameShown = true, ConvertNumericData = true });
                wb.Worksheets.Add();
                i++;
            }

            var cafpws = GetCurrentAtFixedPositionWorksheetObject(reports, summary);

            var lastWs = wb.Worksheets[wb.Worksheets.Count - 1];
            lastWs.Name = "Meters";
            lastWs.Cells.ImportTwoDimensionArray(cafpws, 0, 0, true);

            wb.Save(outputName);
        }

        public static IEnumerable<ExcelWorkSheetWithTwoDArray> GetCurrentAtFixedPositionWorksheet(IEnumerable<Report> reports, IReadOnlyList<AoSummaryPortion> summary)
        {
            var cafpws = GetCurrentAtFixedPositionWorksheetObject(reports, summary);
            yield return new ExcelWorkSheetWithTwoDArray
            {
                Data = cafpws,
                WorksheetName = "Meters"
            };
        }

        public static IEnumerable<ExcelWorkSheetWithIEnumerable> GetConverterWorksheets(IEnumerable<Report> report, IReadOnlyCollection<AoSummaryPortion> summary)
        {
            var converterDict = GetConverterDictionary(report);

            return GetConverterWorksheets(converterDict, summary);
        }

        private static IEnumerable<ExcelWorkSheetWithIEnumerable> GetConverterWorksheets(Dictionary<string, IEnumerable<ConverterPortion>> converterDict, IReadOnlyCollection<AoSummaryPortion> summary)
        {
            var converterKeyArray = converterDict.Keys.ToArray();

            for (var i = 0; i < converterDict.Keys.Count; i++)
            {
                var converterType = converterKeyArray[i];
                var specificConverters = converterDict[converterType];
                var wsObj = specificConverters.Join(summary, cp => cp.Snapshot, s => s.Snapshot, (c, s) => new {c, s})
                    .Select(j => new
                {
                    Snapshot = j.c.Snapshot,
                    j.c.AcNodeName,
                    j.c.DcNodeName,
                    VoltsAcNode = double.TryParse(j.c.VoltsAcNode, out _) ? $"{Convert.ToDouble(j.c.VoltsAcNode):0.0##}" : "0.0",
                    VoltsDcNode = double.TryParse(j.c.VoltsDcNode, out _) ? $"{Convert.ToDouble(j.c.VoltsDcNode):0.0##}" : "0.0",
                    Drop = double.TryParse(j.c.Drop, out _) ? $"{Convert.ToDouble(j.c.Drop):0.0##}" : "0.0",
                    PerUnitImpedance = double.TryParse(j.c.PerUnitImpedance, out _) ?  $"{Convert.ToDouble(j.c.PerUnitImpedance):0.0##}" : "0.0",
                    Amps = double.TryParse(j.c.Amps, out _) ? $"{Convert.ToDouble(j.c.Amps):0.0##}" : "0.0",
                    Converge = j.s.Converge
                });

                yield return new ExcelWorkSheetWithIEnumerable
                {
                    WorksheetName = converterType,
                    Data = wsObj
                };
            }
        }

        private static Dictionary<string, IEnumerable<ConverterPortion>> GetConverterDictionary(IEnumerable<Report> reports)
        {
            return (from c in reports.SelectMany(r => r.ConverterPortion)
                    group c by c.AcNodeName
                    into groupedC
                    select groupedC)
                .ToDictionary(gc => gc.Key,
                    gc => gc.Where(gc2 => gc2.AcNodeName == gc.Key));
        }

        private static object[,] GetCurrentAtFixedPositionWorksheetObject(IEnumerable<Report> reports, IReadOnlyList<AoSummaryPortion> summary)
        {
            var currentAtFixedPositionList = (from cafp in reports.SelectMany(r => r.CurrentAtPosition)
                                              group cafp by cafp.Name
                    into groupedCafp
                                              select groupedCafp)
                .ToDictionary(g => g.Key, g => g.Where(g2 => g2.Name == g.Key)
                    .OrderBy(o => o.Name))
                .ToDictionary(g => g.Key, g => g.Value.ToList());

            var cafpKeys = currentAtFixedPositionList.Keys.ToArray();
            var i = cafpKeys.Length;
            var j = currentAtFixedPositionList.FirstOrDefault().Value.Count;
            var wsObj = new object[j + 1, i + 2];
            wsObj[0, 0] = "Snapshot";
            for (var k = 0; k < cafpKeys.Length; k++)
                wsObj[0, k + 1] = cafpKeys[k];
            wsObj[0, i + 1] = "Converge";
            for (var k = 1; k < j; k++)
            {
                var key = cafpKeys[0];
                wsObj[k, 0] = currentAtFixedPositionList[key][k-1].Snapshot;
                wsObj[k, i + 1] = summary[k - 1].Converge;
            }
                
            for (var k = 1; k < i + 1; k++)
            {
                var key = cafpKeys[k - 1];
                for (var l = 1; l < j + 1; l++)
                {
                    wsObj[l, k] = double.TryParse(currentAtFixedPositionList[key][l - 1].Amps, out var _) ?
                        $"{Convert.ToDouble(currentAtFixedPositionList[key][l - 1].Amps):0.0#}" :
                        "0.0";
                }
            }

            return wsObj;
        }
    }
}