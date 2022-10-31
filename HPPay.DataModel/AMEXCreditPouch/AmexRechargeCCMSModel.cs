using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AMEXCreditPouch
{
    public class PaymentSession
    {
        public PaymentSession()
        {
            order = new OrderStepp();
            session = new sessionStep2();
            device = new device();
        }
        public string apiOperation { get; set; }
        public OrderStepp order { get; set; }
        public sessionStep2 session { get; set; }
        public device device { get; set; }
    }
    public class PaymentSessionAuth
    {
        public PaymentSessionAuth()
        {
            order = new OrderStepp();
            session = new sessionStep2(); 
        }
        public string apiOperation { get; set; }
        public OrderStepp order { get; set; }
        public sessionStep2 session { get; set; }
        public device device { get; set; }
    }
    public class UpdateSession
    {
        public UpdateSession()
        {
            customer = new customer();
            sourceOfFunds = new sourceOfFunds();
            order = new Order();
            transaction = new transaction();
            authentication = new authentication();
        }
        public customer customer { get; set; }
        public sourceOfFunds sourceOfFunds { get; set; }
        public Order order { get; set; }
        public transaction transaction { get; set; }
        public authentication authentication { get; set; }


    }
    public class customer
    {
        public customer()
        {
            account = new account();
        }
        public account account { get; set; }
    }
    public class account
    {
        public account()
        {
            history = new history();
        }
        public string id { get; set; }
        public history history { get; set; }
    }
    public class history
    {
        public string creationDate { get; set; }
    }

    public class sourceOfFunds
    {
        public sourceOfFunds()
        {
            provided = new provided();
        }
        [JsonPropertyName("type")]
        public string type { get; set; }
        public provided provided { get; set; }
    }
    public class provided
    {
        public provided()
        {
            card = new card();
        }
        public card card { get; set; }
    }

    public class card
    {
        public card()
        {
            expiry = new expiry();
        }
        public string number { get; set; }
        public expiry expiry { get; set; }
    }
    public class expiry
    {
        public string month { get; set; }
        public string year { get; set; }

    }
    public class transaction
    {
        public string id { get; set; }
        //public string reference { get; set; }
    }
    public class PaymentResult
    {
        public Order order { get; set; }
    }
    
    public class PaymentResultOutput
    {
        public string redirectHtml { get; set; }
    }
    public class Order
    {
        public string id { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string authenticationStatus { get; set; }
        

    }

    public class OrderStepp
    {
        public string amount { get; set; }
        public string currency { get; set; }

    }

    public class authentication
    {
        public string redirectHtml { get; set; }
        public string channel { get; set; }
        public string purpose { get; set; }
        public string redirectResponseUrl { get; set; }
        public string challengePreference { get; set; }
    }

    public class apiOperation
    {
        public Order Order { get; set; }

        public session session { get; set; }

        public device device { get; set; }

    }

    public class device
    {

        public device()
        {
            browserDetails = new browserDetails();
        }
        public browserDetails browserDetails { get; set; }
        public string browser { get; set; }

    }
    public class getDataForSession
    {
        public session session { get; set; }
    }
    public class sessionStep2
    {
        public string id { get; set; }
    }
    public class session
    {
        public string id { get; set; }
        public string updateStatus { get; set; } 
    }


    public class browserDetails
    {
        public string javaEnabled { get; set; }
        public string language { get; set; }
        public string screenHeight { get; set; }
        public string screenWidth { get; set; }
        public string timeZone { get; set; }
        public string colorDepth { get; set; }
        public string acceptHeaders { get; set; }

        //[JsonPropertyName("3DSecureChallengeWindowSize")]

        [JsonProperty("3DSecureChallengeWindowSize")]
        public string The3DSecureChallengeWindowSize { get; set; }

    }




}
