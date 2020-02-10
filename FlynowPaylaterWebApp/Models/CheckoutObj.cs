using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlynowPaylaterWebApp.Models
{
    public class checkoutAuth
    {
        public class Rootobject
        {
            public Checkoutobj CheckoutObj { get; set; }
        }

        public class Checkoutobj
        {
            public string merchantReference { get; set; }
            public string checkoutToken { get; set; }
            public string accountToken { get; set; }
            public string applicationToken { get; set; }
            public Summary summary { get; set; }
            public Card card { get; set; }
        }

        public class Summary
        {
            public Currency currency { get; set; }
            public int amountRequested { get; set; }
            public int amountIssued { get; set; }
            public int amountAuthorised { get; set; }
        }

        public class Currency
        {
            public string name { get; set; }
            public string iso { get; set; }
            public string code { get; set; }
        }

        public class Card
        {
            public string scheme { get; set; }
            public string name { get; set; }
            public string pan { get; set; }
            public Expiry expiry { get; set; }
            public string cvv { get; set; }
            public Billingaddress billingAddress { get; set; }
            public int registrationTime { get; set; }
        }

        public class Expiry
        {
            public int month { get; set; }
            public int year { get; set; }
        }

        public class Billingaddress
        {
            public string line1 { get; set; }
            public string line2 { get; set; }
            public string line3 { get; set; }
            public string city { get; set; }
            public string county { get; set; }
            public string postcode { get; set; }
            public string country { get; set; }
        }

    }
}
