using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


using Common;

namespace DynamicFetcher
{
    public class PriceDataManager
    {
        private static string AppDataPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
        protected Dictionary<int, IList<HistoricalDataMessage>> HistoricalData { get; set; }

        private bool _isDownloadDone = false;

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

        public void MarkDownloadDone()
        {
            _isDownloadDone = true;
        }

        public bool IsDownloadDone
        {
            get {
                return _isDownloadDone;
            }
        }

        public HistoricalDataMessage[] GetHistoricalData(int requestId)
        {
            return HistoricalData[requestId].ToArray();
        }
    }
}
