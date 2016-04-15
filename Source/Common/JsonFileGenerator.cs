using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Common
{
    public class JsonFileGenerator
    {
        public void GenerateJsonFile(int requestId, string folderName, IEnumerable<HistoricalDataMessage> historicalData)
        {
            //production version
            //var fileName = System.IO.Path.Combine(folderName, requestId + ".json");

            //local hack version
            var fileName = System.IO.Path.Combine(folderName, requestId + ".js");
            var dataForJson = from data in historicalData
                              select new List<object>
                              {
                                  UnixTicks(DateTime.ParseExact(data.Date, "yyyyMMdd  HH:mm:ss", null)),//the date time format is 20130926  06:30:00
                                  data.Open,
                                  data.High,
                                  data.Low,
                                  data.Close
                              };

            string json = JsonConvert.SerializeObject(dataForJson.ToArray());

            //local hack, this line is not necessary in the production version
            json = string.Format("var testData = ({0});", json);
            //write string to file
            System.IO.File.WriteAllText(fileName, json);
        }

        public static double UnixTicks(DateTime dt)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = dt.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            return ts.TotalMilliseconds;
        }
    }
}
