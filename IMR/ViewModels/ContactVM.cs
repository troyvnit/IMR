using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.ViewModels
{
    public class ContactVM
    {
        public string ContactPerson { get; set; }
        public string Firm { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public string Town { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool FreeTrial { get; set; }
        public bool Callback { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}