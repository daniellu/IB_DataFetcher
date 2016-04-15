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
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                // Values are available here
                Console.WriteLine("Stock Symbol: {0}", options.Symbol);
                Console.WriteLine("End Date: {0}", options.EndDate);
                Console.WriteLine("Duration: {0}", options.Duration);
                Console.WriteLine("Bar Size: {0}", options.BarSize);
            }
            else
            {
                //Console.WriteLine(options.GetUsage());
                Console.WriteLine("Press enter to exist...");
                Console.ReadLine();
                return;
            }

            int nextRequestId = 1;
            var priceDataManager = new PriceDataManager();
            EWrapperImpl client = new EWrapperImpl(priceDataManager);

            //connect
            client.ClientSocket.eConnect("127.0.0.1", 7496, 0);

            var stockContract = GetStockContract(options.Symbol);
            client.ClientSocket.reqContractDetails(nextRequestId++, stockContract);

            //nextRequestId is the request Id appears in the response
            //program uses this id to match where the request comes from 
            client.ClientSocket.reqHistoricalData(nextRequestId++, stockContract, options.EndDate, options.Duration, options.BarSize, "TRADES", 1, 1, null);
            Thread.Sleep(10000);
            Console.WriteLine("Disconnecting...");
            client.ClientSocket.eDisconnect();
            
            //Console.WriteLine("Application finishes running, press enter to exist...");
            //Console.ReadLine();
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
