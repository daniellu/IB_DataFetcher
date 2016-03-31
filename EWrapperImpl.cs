using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IBApi;

namespace IB.PriceFetcher
{
    /// <summary>
    /// Implementation of EWrapper
    /// Used to communicate with IB via socket
    /// https://www.interactivebrokers.com/en/software/api/apiguide/csharp/csharptutorial_implementewrapperinterface.htm
    /// </summary>
    public class EWrapperImpl : EWrapper
    {
        private EClientSocket clientSocket;
        private int nextOrderId;

        public EWrapperImpl()
        {            
            clientSocket = new EClientSocket(this);
        }

        public EClientSocket ClientSocket
        {
            get { return clientSocket; }
            set { clientSocket = value; }
        }

        public int NextOrderId
        {
            get { return nextOrderId; }
            set { nextOrderId = value; }
        }

        public void accountDownloadEnd(string account)
        {
            throw new NotImplementedException();
        }

        public void accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            throw new NotImplementedException();
        }

        public void accountSummaryEnd(int reqId)
        {
            throw new NotImplementedException();
        }

        public void bondContractDetails(int reqId, ContractDetails contract)
        {
            throw new NotImplementedException();
        }

        public void commissionReport(CommissionReport commissionReport)
        {
            throw new NotImplementedException();
        }

        public void connectionClosed()
        {
            Console.WriteLine("Connection closed.\n");
        }

        public void contractDetails(int reqId, ContractDetails contractDetails)
        {
            Console.WriteLine("/*******Incoming Contract Details - RequestId " + reqId + "************/");
            Console.WriteLine(contractDetails.Summary.Symbol + " " + contractDetails.Summary.SecType + " @ " + contractDetails.Summary.Exchange);
            Console.WriteLine("Expiry: " + contractDetails.Summary.Expiry + ", Right: " + contractDetails.Summary.Right);
            Console.WriteLine("Strike: " + contractDetails.Summary.Strike + ", Multiplier: " + contractDetails.Summary.Multiplier);
            Console.WriteLine("/*******     End     *************/\n");
        }

        public void contractDetailsEnd(int reqId)
        {
            Console.WriteLine("Finished receiving matching contracts.");
        }

        public void currentTime(long time)
        {
            Console.WriteLine("The current time is: " + time);            
        }

        public void deltaNeutralValidation(int reqId, UnderComp underComp)
        {
            throw new NotImplementedException();
        }

        public void displayGroupList(int reqId, string groups)
        {
            throw new NotImplementedException();
        }

        public void displayGroupUpdated(int reqId, string contractInfo)
        {
            throw new NotImplementedException();
        }

        public void error(string str)
        {
            throw new NotImplementedException();
        }

        public void error(Exception e)
        {
            Console.WriteLine(string.Format("Error occurs, Error message: {0}.", e.StackTrace));            
        }

        public void error(int id, int errorCode, string errorMsg)
        {
            Console.WriteLine(string.Format("Error Id: {0}, Error Code: {1}, Error Message: {2}", id, errorCode, errorMsg));
        }

        public void execDetails(int reqId, Contract contract, Execution execution)
        {
            throw new NotImplementedException();
        }

        public void execDetailsEnd(int reqId)
        {
            throw new NotImplementedException();
        }

        public void fundamentalData(int reqId, string data)
        {
            throw new NotImplementedException();
        }

        public virtual void historicalData(int reqId, string date, double open, double high, double low, double close, int volume, int count, double WAP, bool hasGaps)
        {
            Console.WriteLine("HistoricalData. " + reqId + " - Date: " + date + ", Open: " + open + ", High: " + high + ", Low: " + low + ", Close: " + close + ", Volume: " + volume + ", Count: " + count + ", WAP: " + WAP + ", HasGaps: " + hasGaps + "\n");
        }

        public void historicalDataEnd(int reqId, string start, string end)
        {
            Console.WriteLine("Historical data end - " + reqId + " from " + start + " to " + end);
        }

        public void managedAccounts(string accountsList)
        {
            Console.WriteLine("The accounts list is: " + accountsList);
        }

        public void marketDataType(int reqId, int marketDataType)
        {
            throw new NotImplementedException();
        }

        public void nextValidId(int orderId)
        {
            Console.WriteLine("The next order id is : " + orderId);
            NextOrderId = orderId;
        }

        public void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            throw new NotImplementedException();
        }

        public void openOrderEnd()
        {
            throw new NotImplementedException();
        }

        public void orderStatus(int orderId, string status, int filled, int remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld)
        {
            throw new NotImplementedException();
        }

        public void position(string account, Contract contract, int pos, double avgCost)
        {
            throw new NotImplementedException();
        }

        public void positionEnd()
        {
            throw new NotImplementedException();
        }

        public void realtimeBar(int reqId, long time, double open, double high, double low, double close, long volume, double WAP, int count)
        {
            throw new NotImplementedException();
        }

        public void receiveFA(int faDataType, string faXmlData)
        {
            throw new NotImplementedException();
        }

        public void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr)
        {
            throw new NotImplementedException();
        }

        public void scannerDataEnd(int reqId)
        {
            throw new NotImplementedException();
        }

        public void scannerParameters(string xml)
        {
            throw new NotImplementedException();
        }

        public void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureExpiry, double dividendImpact, double dividendsToExpiry)
        {
            throw new NotImplementedException();
        }

        public void tickGeneric(int tickerId, int field, double value)
        {
            throw new NotImplementedException();
        }

        public void tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            throw new NotImplementedException();
        }

        public void tickPrice(int tickerId, int field, double price, int canAutoExecute)
        {
            throw new NotImplementedException();
        }

        public void tickSize(int tickerId, int field, int size)
        {
            throw new NotImplementedException();
        }

        public void tickSnapshotEnd(int tickerId)
        {
            throw new NotImplementedException();
        }

        public void tickString(int tickerId, int field, string value)
        {
            throw new NotImplementedException();
        }

        public void updateAccountTime(string timestamp)
        {
            throw new NotImplementedException();
        }

        public void updateAccountValue(string key, string value, string currency, string accountName)
        {
            throw new NotImplementedException();
        }

        public void updateMktDepth(int tickerId, int position, int operation, int side, double price, int size)
        {
            throw new NotImplementedException();
        }

        public void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size)
        {
            throw new NotImplementedException();
        }

        public void updateNewsBulletin(int msgId, int msgType, string message, string origExchange)
        {
            throw new NotImplementedException();
        }

        public void updatePortfolio(Contract contract, int position, double marketPrice, double marketValue, double averageCost, double unrealisedPNL, double realisedPNL, string accountName)
        {
            throw new NotImplementedException();
        }

        public void verifyCompleted(bool isSuccessful, string errorText)
        {
            throw new NotImplementedException();
        }

        public void verifyMessageAPI(string apiData)
        {
            throw new NotImplementedException();
        }
    }
}
