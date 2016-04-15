using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using CsvHelper;

namespace IB.PriceFetcher
{
    public class PriceDataManager
    {
        private static string AppDataPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
        protected Dictionary<int, IList<HistoricalDataMessage>> HistoricalData { get; set; }

        public PriceDataManager()
        {
            HistoricalData = new Dictionary<int, IList<HistoricalDataMessage>>();
        }

        public void AddHistoricalData(int requestId, HistoricalDataMessage data)
        {
            if (HistoricalData.ContainsKey(requestId))
            {
                HistoricalData[requestId].Add(data);
            }
            else
            {
                HistoricalData.Add(requestId, new List<HistoricalDataMessage> { data });
            }
        }

        public bool ExportHistoricalData(int requestId)
        {
            var data = HistoricalData[requestId];

            if (data != null)
            {
                var csvGenerator = new CsvFileGenerator();
                csvGenerator.GenerateCsvFile(requestId, AppDataPath, data);

                var jsonGenerator = new JsonFileGenerator();
                jsonGenerator.GenerateJsonFile(requestId, AppDataPath, data);
                return true;
            }

            return false;
        }
    }
}
