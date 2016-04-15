using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace DynamicFetcher
{
    public class DynamicDataFetcher : DynamicObject
    {
        private DataFetcher _dataFetcher;

        public DynamicDataFetcher()
        {
            _dataFetcher = new DataFetcher();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            switch (binder.Name.ToLower())
            {
                case "history":
                    result = (Func<string, string, string, string, IEnumerable<HistoricalDataMessage>>)((string symbol, string endDate, string duration, string barSize)
                           => _dataFetcher.History(symbol, endDate, duration, barSize));
                    return true;
            }
            return false;
        }
    }
}
