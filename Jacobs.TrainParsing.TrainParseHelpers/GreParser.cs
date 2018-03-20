using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Jacobs.TrainParsing.Common;

namespace Jacobs.TrainParsing.TrainParseHelpers
{
    public class GreParser
    {
        private readonly string _aoFileLocation;
        
        public GreParser(string aoFileLocation)
        {
            _aoFileLocation = aoFileLocation;
        }

        public List<Report> Parse()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Debug.WriteLine("GreParser: Starting parsing");

            var reports = new List<Report>();
            var aoFile = System.IO.File.ReadAllText(_aoFileLocation);
            var reportsText = aoFile.Split(new[] {(char) 12}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var reportText in reportsText)
            {
                if(string.IsNullOrWhiteSpace(reportText))
                    continue;

                var report = ParseReport(reportText);
                reports.Add(report);
            }

            stopWatch.Stop();
            Debug.WriteLine($"GreParser: Parsing completed in {stopWatch.ElapsedMilliseconds} milliseconds");

            return reports;
        }

        private static Report ParseReport(string aoReportText)
        {
            var aoSections = aoReportText.Split(new[] {KeyWords.SectionSeparator}, StringSplitOptions.RemoveEmptyEntries);


            if(aoSections.Length < 5)
                return new Report();

            
            var snapShotSection = aoSections[0].Trim();
            var voltageAcPortionSection = aoSections[1].Trim();
            var converterPortionSection = aoSections[2].Trim();
            var currentAtPositionSection = aoSections[3].Trim();
            var trainInformationSection = aoSections[4].Trim();
            
            var snapShotObj = SnapshotParser.Parse(snapShotSection);
            var voltageAcPortionObj = VoltageAcPortionParser.Parse(voltageAcPortionSection);
            var currentAtPositionObj = CurrentAtFixedPositionParser.Parse(currentAtPositionSection, snapShotObj);
            var converterPortionObj = ConverterPortionParser.Parse(converterPortionSection, snapShotObj);
            var trainInformationObj = TrainInformationParser.Parse(trainInformationSection, snapShotObj);

            var report = new Report
            {
                VoltageAcPortion = new List<VoltageAcPortion> {voltageAcPortionObj},
                ConverterPortion = converterPortionObj.ToList(),
                CurrentAtPosition = currentAtPositionObj.ToList(),
                TrainInformation = trainInformationObj.ToList()
            };

            return report;
        }
    }
}