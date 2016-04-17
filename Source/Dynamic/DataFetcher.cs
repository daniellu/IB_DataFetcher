using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;
using IBApi;

namespace DynamicFetcher
{
    public class DataFetcher
    {
        public string Greeting(string name)
        {
            return "Hello " + name;
        }

        public IEnumerable<HistoricalDataMessage> History(string symbol, string endDate, string duration, string barSize)
        {
            var priceManager = new PriceDataManager();
            EWrapperImpl client = new EWrapperImpl(priceManager);

            int nextRequestId = 1;
            
            

            try
            {
                //connect
                client.ClientSocket.eConnect("127.0.0.1", 7496, 0);

                var stockContract = GetStockContract(symbol);
                client.ClientSocket.reqContractDetails(nextRequestId++, stockContract);

                //nextRequestId is the request Id appears in the response
                //program uses this id to match where the request comes from 

                client.ClientSocket.reqHistoricalData(nextRequestId, stockContract, endDate, duration, barSize, "TRADES", 1, 1, null);

                while (true)
                {
                    //wait for the download complete
                    if (priceManager.IsDownloadDone)
                    {
                        Console.WriteLine("Historical data download finishes...");
                        break;
                    }

                }
                

                var historicalData = priceManager.GetHistoricalData(nextRequestId);
                Console.WriteLine(historicalData.Count() + " data points in the downloaded data");

                Console.WriteLine("Disconnecting...");
                client.ClientSocket.eDisconnect();

                return historicalData;
            }
            catch(Exception)
            {
                throw new InvalidOperationException("Fetch historical data fail....");
            }
            
        
        }

        public static Contract GetStockContract(string symbol)
        {
            Contract contract = new Contract();
            //contract.Symbol = "TRI";
            contract.Symbol = symbol;
            contract.SecType = "STK";
            contract.Currency = "CAD";
            contract.Exchange = "SMART";
            return contract;
        }
    }
}
