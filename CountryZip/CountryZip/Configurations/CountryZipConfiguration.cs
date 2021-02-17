using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Configurations
{
    public class CountryZipConfiguration
    {
        public EmailLevel EmailLevel { get; set; }
    }
    public class EmailLevel
    {
        public string EmailAddressFrom { get; set; }
        public string EmailPasswordFrom { get; set; }
        public string EmailNameFrom { get; set; }

        public string EmailAddressTo { get; set; }
        public string EmailNameTo { get; set; }
        public string Subject { get; set; }
        public string TextBody { get; set; }
        public string EmailSmtp { get; set; }

    }

}
