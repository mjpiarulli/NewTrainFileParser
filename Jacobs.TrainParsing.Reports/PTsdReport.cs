using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Aspose.Cells;
using Jacobs.TrainParsing.Common.PReport;
using Jacobs.TrainParsing.Common.TsdReport;

namespace Jacobs.TrainParsing.Reports
{
    public static class PTsdReport
    {
        public static void CreateWorkBook(List<TsdReportLine> tsdReportLines, List<PReportLine> pReportLines, string outputName)
        {
            var asposeLicense = new License();
            asposeLicense.SetLicense("Aspose.Cells.lic");
            var wb = new Workbook();
            var ws = wb.Worksheets[0];
            var wsObj = tsdReportLines.Join(pReportLines,
                    tsdReportLines.IndexOf,
                    pReportLines.IndexOf,
                    (tsd, p) => new
                    {
                        tsd.Time,
                        SpResMph = decimal.Parse(tsd.SpResMph, NumberStyles.Float),
                        MilePost = decimal.Parse(tsd.MilePost, NumberStyles.Float),
                        SpeedMph = decimal.Parse(tsd.SpeedMph, NumberStyles.Float),
                        AccMphPs = decimal.Parse(tsd.AccMphPs, NumberStyles.Float),
                        GradePct = decimal.Parse(tsd.GradePct, NumberStyles.Float),
                        PwrOutW = decimal.Parse(tsd.PwrOutW, NumberStyles.Float),
                        PwrInW = decimal.Parse(tsd.PwrInW, NumberStyles.Float),
                        MBrakeW = decimal.Parse(tsd.MBrakeW, NumberStyles.Float),
                        EnerOutWh = decimal.Parse(tsd.EnerOutWh, NumberStyles.Float),
                        EnerInWh = decimal.Parse(tsd.EnerInWh, NumberStyles.Float),
                        p.Column8,
                        Column1 = Regex.Replace(p.Column1, @"[^0-9\.]", string.Empty)
                    })
                .ToList();
            ws.Cells.ImportCustomObjects(wsObj, 0, 0, new ImportTableOptions {IsFieldNameShown = true});

            wb.Save(outputName);
        }
    }
}
