using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Jacobs.TrainParsing.Common;
using Jacobs.TrainParsing.Common.AoSummary;
using Jacobs.TrainParsing.Common.PReport;
using Jacobs.TrainParsing.Common.TsdReport;
using Jacobs.TrainParsing.Reports;
using Jacobs.TrainParsing.TrainParseHelpers;

namespace Jacobs.TrainParsing.NewTrainFileParserForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            tssl.Text = string.Empty;
        }

        private void btnOpenAoFile_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog
            {
                Title = @"Open File Dialog",
                InitialDirectory = "C:\\",
                Filter = @"All files (*.*)|*.*|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (fd.ShowDialog() != DialogResult.OK)
                return;

            txtAoFilePath.Text = fd.FileName;

            var fileName = System.IO.Path.GetFileName(fd.FileName);
            tssl.Text = fileName != null && fileName.ToLower().StartsWith("ao") ?
                @"AO file successfully loaded" :
                @"Warning: filename doesn't start with AO";
        }

        private void btnOpenSummaryFile_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog
            {
                Title = @"Open File Dialog",
                InitialDirectory = "C:\\",
                Filter = @"All files (*.*)|*.*|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (fd.ShowDialog() != DialogResult.OK)
                return;

            txtSummaryFile.Text = fd.FileName;

            tssl.Text = @"AO file successfully loaded";
        }

        private void btnGenerateOriginal_Click(object sender, EventArgs e)
        {
            tssl.Text = @"Preparing to parse data...";

            // get selected file
            var aoInputFile = txtAoFilePath.Text;
            var summaryInputFile = txtSummaryFile.Text;
            if (string.IsNullOrEmpty(aoInputFile) || !System.IO.File.Exists(aoInputFile))
            {
                tssl.Text = @"Please select a valid AO file";
                return;
            }
            if (string.IsNullOrEmpty(summaryInputFile))
            {
                tssl.Text = @"Please select a valid summary file";
                return;
            }

            var directoryBase = System.IO.Path.GetDirectoryName(aoInputFile);
            var inputFileNameBase = System.IO.Path.GetFileNameWithoutExtension(aoInputFile);
            var ticOutputFile = $@"{directoryBase}\{inputFileNameBase}-traininfoconverter.xls";

            // make sure the files don't already exist
            try
            {
                if (System.IO.File.Exists(ticOutputFile))
                    System.IO.File.Delete(ticOutputFile);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                tssl.Text = $@"do not have write access to {directoryBase}";
            }

            var reports = new List<Report>();
            var summary = new List<AoSummaryPortion>();
            try
            {
                tssl.Text = $@"Now parsing {aoInputFile} and {summaryInputFile}.";

                var greParser = new GreParser(aoInputFile);
                reports = greParser.Parse();
                var summaryFile = System.IO.File.ReadAllText(summaryInputFile);
                summary = AoSummaryPortionParser.Parse(summaryFile).ToList();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                tssl.Text = @"Error parsing file";
            }

            try
            {
                tssl.Text = @"Creating excel reports";
                
                var wsTrainInfo = TrainInfoReport.GetTrainInfoWorksheet(reports, summary);
                var wsCurrentAtFixedPosition = ConverterReport.GetCurrentAtFixedPositionWorksheet(reports, summary);
                var wsConverter = ConverterReport.GetConverterWorksheets(reports, summary);

                TrainInfoConverterReport.CreateWorkBook(wsTrainInfo, wsCurrentAtFixedPosition, wsConverter, ticOutputFile);

                tssl.Text = @"Completed";
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                tssl.Text = @"Error generating reports";
            }
        }

        private void btnOpenTsdFile_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog
            {
                Title = @"Open File Dialog",
                InitialDirectory = "C:\\",
                Filter = @"All files (*.*)|*.*|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (fd.ShowDialog() != DialogResult.OK)
                return;

            txtTsdFilePath.Text = fd.FileName;

            var fileName = System.IO.Path.GetFileName(fd.FileName);
            tssl.Text = fileName != null && fileName.ToLower().StartsWith("tsd") ?
                @"TSD file successfully loaded" :
                @"Warning: filename doesn't start with TSD";
        }

        private void btnOpenPFile_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog
            {
                Title = @"Open File Dialog",
                InitialDirectory = "C:\\",
                Filter = @"All files (*.*)|*.*|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (fd.ShowDialog() != DialogResult.OK)
                return;

            txtPFilePath.Text = fd.FileName;

            var fileName = System.IO.Path.GetFileName(fd.FileName);
            tssl.Text = fileName != null && fileName.ToLower().StartsWith("p") ?
                @"P file successfully loaded" :
                @"Warning: filename doesn't start with P";
        }

        private void btnGenerateNew_Click(object sender, EventArgs e)
        {
            tssl.Text = @"Preparing to parse data...";

            // get selected file
            var tsdInputFile = txtTsdFilePath.Text;
            if (string.IsNullOrEmpty(tsdInputFile) || !System.IO.File.Exists(tsdInputFile))
            {
                tssl.Text = @"Please select a valid TSD file";
                return;
            }
            var pInputFile = txtPFilePath.Text;
            if (string.IsNullOrEmpty(pInputFile) || !System.IO.File.Exists(pInputFile))
            {
                tssl.Text = @"Please select a valid P file";
                return;
            }

            var directoryBase = System.IO.Path.GetDirectoryName(tsdInputFile);
            var inputFileNameBase = System.IO.Path.GetFileNameWithoutExtension(tsdInputFile);
            var ptsdOutputFile = $@"{directoryBase}\P{inputFileNameBase}.xls";

            // make sure the files don't already exist
            try
            {
                if (System.IO.File.Exists(ptsdOutputFile))
                    System.IO.File.Delete(ptsdOutputFile);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                tssl.Text = $@"do not have write access to {directoryBase}";
            }

            var tsdReport = Enumerable.Empty<TsdReportLine>();
            try
            {
                tssl.Text = $@"Now parsing {tsdInputFile}.";

                tsdReport = TsdFileParser.Parse(tsdInputFile).ToList();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                tssl.Text = @"Error parsing tsd file";
            }

            var pReport = Enumerable.Empty<PReportLine>();
            try
            {
                tssl.Text = $@"Now parsing {pInputFile}.";

                pReport = PFileParser.Parse(pInputFile).ToList();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                tssl.Text = @"Error parsing p file";
            }

            try
            {
                tssl.Text = @"Creating excel reports";

                PTsdReport.CreateWorkBook(tsdReport.ToList(), pReport.ToList(), ptsdOutputFile);

                tssl.Text = @"Completed";
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                tssl.Text = @"Error generating reports";
            }
        }

        
    }
}
