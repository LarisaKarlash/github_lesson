using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Configurations
{
    public class FileConfiguration
    {
        public TimeAll TimeAll { get; set; }
    }
    public class TimeAll
    {
        public int Cache { get; set; }
        public int Delay { get; set; }
        public int Sliding { get; set; }
        public int DelayUpload { get; set; }
    }
}
