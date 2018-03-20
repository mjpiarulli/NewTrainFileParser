using System.Collections.Generic;
using System.Linq;
using Aspose.Cells;
using Jacobs.TrainParsing.Common;
using Jacobs.TrainParsing.Common.AoSummary;
using Jacobs.TrainParsing.Common.TrainInformation;

namespace Jacobs.TrainParsing.Reports
{
    public static class TrainInfoReport
    {
        public static void CreateWorkBook(IEnumerable<Report> reports, string outputName, List<AoSummaryPortion> summary)
        {
            var asposeLicense = new License();
            asposeLicense.SetLicense("Aspose.Cells.lic");
            var wb = new Workbook();

            var worksheets = GetTrainInfoWorksheet(reports, summary);

            var i = 0;
            foreach (var worksheet in worksheets)
            {
                var ws = wb.Worksheets[i];
                ws.Name = worksheet.WorksheetName;
                ws.Cells.ImportCustomObjects(worksheet.Data.ToList(), 0, 0, new ImportTableOptions {IsFieldNameShown = true, ConvertNumericData = true});
                wb.Worksheets.Add();
                i++;
            }
            
            wb.Save(outputName);
        }

        public static IEnumerable<ExcelWorkSheetWithIEnumerable> GetTrainInfoWorksheet(IEnumerable<Report> reports, List<AoSummaryPortion> summary)
        {
            var trainInfoDict = GetTrainInfoDict(reports);

            var keyArray = trainInfoDict.Keys.ToArray();
            for (var i = 0; i < trainInfoDict.Keys.Count; i++)
            {
                
                var trainType = keyArray[i];
                var specificTrainInfos = trainInfoDict[trainType];
                var wsObj = specificTrainInfos.Join(summary, ti => ti.Snapshot, s => s.Snapshot, (ti, aoS) => new {ti, aoS})
                    .Select(j => new
                {
                    Snapshot = j.ti.Snapshot,
                    j.ti.TrainNumber,
                    j.ti.TrainType,
                    j.ti.TrainPosition,
                    j.ti.TrackNumber,
                    j.ti.LineVolts,
                    j.ti.LineAmps,
                    j.ti.LinePower,
                    j.ti.AdjacentNodePosition,
                    j.ti.Current,
                    j.ti.FlowPosition,
                    j.aoS.Converge
                });

                yield return new ExcelWorkSheetWithIEnumerable
                {
                    WorksheetName = trainType,
                    Data = wsObj
                };
            }
        }

        private static Dictionary<string, IEnumerable<TrainInformation>> GetTrainInfoDict(IEnumerable<Report> reports)
        {
            var trainInfoDict = (from ti in reports.SelectMany(r => r.TrainInformation)
                                 group ti by ti.TrainType
                    into groupedTi
                    select groupedTi)
                .ToDictionary(gti => gti.Key,
                    gti => gti.Where(gti2 => gti2.TrainType == gti.Key));

            return trainInfoDict;
        }
    }
}