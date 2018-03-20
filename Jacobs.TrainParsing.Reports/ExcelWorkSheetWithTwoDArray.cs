using System.Collections.Generic;

namespace Jacobs.TrainParsing.Reports
{
    public class ExcelWorkSheetWithIEnumerable
    {
        public IEnumerable<object> Data { get; set; }
        public string WorksheetName { get; set; }
    }
}
