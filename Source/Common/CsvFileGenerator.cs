﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using CsvHelper;

namespace Common
{
    public class CsvFileGenerator
    {
        public void GenerateCsvFile(int requestId, string folderName, IEnumerable<HistoricalDataMessage> historicalData)
        {
            var filePath = Path.Combine(folderName, requestId + ".csv");
            using (var textWriter = File.CreateText(filePath))
            {
                var csv = new CsvWriter(textWriter);
                csv.Configuration.RegisterClassMap(new HistoricalDataMessageCSVMap());
                csv.WriteRecords(historicalData);
            }
        }
    }
}
