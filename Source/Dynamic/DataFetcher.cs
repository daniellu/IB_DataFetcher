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
        public IEnumerable<HistoricalDataMessage> History(string symbol, string endDate, string duration, string barSize)
        {
            var priceManager = new PriceDataManager();
            var ibDataFetcher = new EWrapperImpl(priceManager);

            int nextRequestId = 1;
            var priceDataManager = new PriceDataManager();
            EWrapperImpl client = new EWrapperImpl(priceDataManager);

            //connect
            client.ClientSocket.eConnect("127.0.0.1", 7496, 0);

            var stockContract = GetStockContract(symbol);
            client.ClientSocket.reqContractDetails(nextRequestId++, stockContract);

            //nextRequestId is the request Id appears in the response
            //program uses this id to match where the request comes from 
            client.ClientSocket.reqHistoricalData(nextRequestId, stockContract, endDate, duration, barSize, "TRADES", 1, 1, null);

            while(!priceManager.IsDownloadDone)
            {
                //wait for the download complete
            }

            
            Console.WriteLine("Disconnecting...");
            client.ClientSocket.eDisconnect();

            var historicalData = priceManager.GetHistoricalData(nextRequestId);
            return historicalData;
        
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
