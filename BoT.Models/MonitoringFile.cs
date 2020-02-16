using System;
using System.Collections.Generic;
using System.Text;

namespace BoT.Models
{
    public class MonitoringFile
    {
        public string MTCN { get; set; }
        public string SendpayIndicator { get; set; }
        public bool IsGoods { get; set; }
        public string SSenOtherReason { get; set; }
        public string PRecOtherReason { get; set; }
    }
}
