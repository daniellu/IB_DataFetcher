using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IBApi;

namespace IB.PriceFetcher
{
    class Program
    {
        static void Main(string[] args)
        {
            EWrapperImpl client = new EWrapperImpl();

            //connect
            client.ClientSocket.eConnect("127.0.0.1", 7496, 0);

            Console.WriteLine("Application finishes running, press enter to exist...");
            //Console.ReadLine();
        }
    }
}
