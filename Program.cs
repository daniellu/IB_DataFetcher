using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IBApi;
using System.Threading;

namespace IB.PriceFetcher
{
    class Program
    {
        static void Main(string[] args)
        {
            int nextRequestId = 1;
            var priceDataManager = new PriceDataManager();
            EWrapperImpl client = new EWrapperImpl(priceDataManager);

            //connect
            client.ClientSocket.eConnect("127.0.0.1", 7496, 0);

            var stockContract = GetStockContract();
            client.ClientSocket.reqContractDetails(nextRequestId++, stockContract);

            //nextRequestId is the request Id appears in the response
            //program uses this id to match where the request comes from 
            client.ClientSocket.reqHistoricalData(nextRequestId++, stockContract, "20131009 23:59:59", "10 D", "1 min", "TRADES", 1, 1, null);
            Thread.Sleep(10000);
            Console.WriteLine("Disconnecting...");
            client.ClientSocket.eDisconnect();
            
            //Console.WriteLine("Application finishes running, press enter to exist...");
            //Console.ReadLine();
        }

        public static Contract GetStockContract()
        {
            Contract contract = new Contract();
            contract.Symbol = "TRI";
            contract.SecType = "STK";
            contract.Currency = "CAD";
            contract.Exchange = "SMART";
            return contract;
        }
    }
}
