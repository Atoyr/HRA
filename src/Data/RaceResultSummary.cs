
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRA.Data
{
    public class RaceResultSummary
    {
        [Key]
        public string ID { get; set; }
        public string RaceID { get; set; }
        public Time[] ThrohghTimes { set; get; }
    }
}


