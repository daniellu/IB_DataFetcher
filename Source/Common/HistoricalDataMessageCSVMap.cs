using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class HistoricalDataMessageCSVMap : CsvClassMap<HistoricalDataMessage>
    {
        public HistoricalDataMessageCSVMap()
        {
            Map(x => x.RequestId).Ignore();//ignore the request Id field so the result is more clean
            Map(x => x.Date);//stupid csvhelper mapping, need to map the field explicitly
            Map(x => x.Open);
            Map(x => x.High);
            Map(x => x.Low);
            Map(x => x.Close);
            Map(x => x.Volume);
        }
    }
}
