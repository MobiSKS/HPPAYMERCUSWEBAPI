using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.AMEXCreditPouch
{
    internal class AmexCPOutputModel
    {

    }

    public class _3ds1
    {
        public string veResEnrolled { get; set; }
    }

    public class Account
    {
        public History history { get; set; }
        public string id { get; set; }
    }

    public class Acquirer
    {
        public string merchantId { get; set; }
    }

    public class Authentication
    {
        public _3ds1 _3ds1 { get; set; }
        public string payerInteraction { get; set; }
        public Redirect redirect { get; set; }
        public string redirectHtml { get; set; }
        public string version { get; set; }
    }

    public class Card
    {
        public string brand { get; set; }
        public Expiry expiry { get; set; }
        public string fundingMethod { get; set; }
        public string issuer { get; set; }
        public string number { get; set; }
        public string scheme { get; set; }
    }

    public class Customer
    {
        public Account account { get; set; }
    }

    public class Device
    {
        public string browser { get; set; }
    }

    public class Expiry
    {
        public string month { get; set; }
        public string year { get; set; }
    }

    public class History
    {
        public string creationDate { get; set; }
    }

    public class OrderOutput
    {
        public double amount { get; set; }
        public string authenticationStatus { get; set; }
        public DateTime creationTime { get; set; }
        public string currency { get; set; }
        public string id { get; set; }
        public DateTime lastUpdatedTime { get; set; }
        public string merchantCategoryCode { get; set; }
        public string status { get; set; }
        public int totalAuthorizedAmount { get; set; }
        public int totalCapturedAmount { get; set; }
        public int totalRefundedAmount { get; set; }
        public ValueTransfer valueTransfer { get; set; }
    }

    public class Provided
    {
        public Card card { get; set; }
    }

    public class Redirect
    {
        public string domainName { get; set; }
    }

    public class Response
    {
        public string gatewayCode { get; set; }
        public string gatewayRecommendation { get; set; }
    }

    public class Root
    {
        public Authentication authentication { get; set; }
        public Customer customer { get; set; }
        public Device device { get; set; }
        public string merchant { get; set; }
        public OrderOutput order { get; set; }
        public Response response { get; set; }
        public string result { get; set; }
        public SourceOfFunds sourceOfFunds { get; set; }
        public DateTime timeOfLastUpdate { get; set; }
        public DateTime timeOfRecord { get; set; }
        public Transaction transaction { get; set; }
        public string version { get; set; }
    }

    public class SourceOfFunds
    {
        public Provided provided { get; set; }
        public string type { get; set; }
    }

    public class Transaction
    {
        public Acquirer acquirer { get; set; }
        public double amount { get; set; }
        public string authenticationStatus { get; set; }
        public string currency { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }

    public class ValueTransfer
    {
        public string accountType { get; set; }
    }

}
