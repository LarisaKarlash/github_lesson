using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ObjectBD.Configurations
{
    public class ObjectBDConfiguration 
    {        
        public EmailLevel EmailLevel { get; set; }
        public TwilioLevel TwilioLevel { get; set; }
    }
    public class EmailLevel
    {
        public string EmailAddressFrom { get; set; }
        public string EmailPasswordFrom { get; set; }
        public string EmailNameFrom { get; set; }

        public string EmailAddressTo { get; set; }
        public string EmailNameTo { get; set; }

    }

    public class TwilioLevel
    {
        public string TwilioAccountId { get; set; }
        public string TwilioAuthToken { get; set; }
        public string TwilioNumber { get; set; }
        public string MyNumber { get; set; }
    }


}
