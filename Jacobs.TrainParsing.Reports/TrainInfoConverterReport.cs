using System.Collections.Generic;
using System.Linq;
using Aspose.Cells;

namespace Jacobs.TrainParsing.Reports
{
    public static class TrainInfoConverterReport
    {
        public static void CreateWorkBook(IEnumerable<ExcelWorkSheetWithIEnumerable> trainInfoWorksheets,
            IEnumerable<ExcelWorkSheetWithTwoDArray> currentAtFixedPositionWorksheets,
            IEnumerable<ExcelWorkSheetWithIEnumerable> converterWorksheets,
            string outputName)
        {
            var asposeLicense = new License();
            asposeLicense.SetLicense("Aspose.Cells.lic");
            var wb = new Workbook();

            var i = 0;
            foreach (var worksheet in trainInfoWorksheets)
            {
                var ws = wb.Worksheets[i];
                ws.Name = worksheet.WorksheetName;
                ws.Cells.ImportCustomObjects(worksheet.Data.ToList(), 0, 0, new ImportTableOptions { IsFieldNameShown = true, ConvertNumericData = true });
                wb.Worksheets.Add();
                i++;
            }

            foreach (var worksheet in currentAtFixedPositionWorksheets)
            {
                var ws = wb.Worksheets[i];
                ws.Name = worksheet.WorksheetName;
                ws.Cells.ImportTwoDimensionArray(worksheet.Data, 0, 0, true);
                wb.Worksheets.Add();
                i++;
            }

            foreach (var worksheet in converterWorksheets)
            {
                var ws = wb.Worksheets[i];
                ws.Name = worksheet.WorksheetName;
                ws.Cells.ImportCustomObjects(worksheet.Data.ToList(), 0, 0, new ImportTableOptions { IsFieldNameShown = true, ConvertNumericData = true});
                wb.Worksheets.Add();
                i++;
            }

            wb.Save(outputName);
        }
    }
}
