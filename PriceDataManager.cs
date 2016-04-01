using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB.PriceFetcher
{
    public class PriceDataManager
    {

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
                return true;
            }

            return false;
        }
    }
}
