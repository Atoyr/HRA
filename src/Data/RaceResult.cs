using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRA.Data
{
    public class RaceResult
    {
        [Key]
        public string ID { get; set; }
        public string RaceID { get; set; }
        public int Ranking { get; set; }
        public int GateNo { get; set; }
        public int HorseNo { get; set; }
        public string HorseName { get; set; }
        public SexTypes SexType { get; set; }
        public int Age { get; set; }
        public decimal BurdenWeight { get; set; }
        public decimal Weight { set; get; }
        public decimal Fluctuation { set; get; }
        public string Driver { set; get; }
        public Time Time { set; get; }
        public string Diff { set; get; }
        public string ThroughRanking { set; get; }
        public decimal Last3F { set; get; }
        public int Favorite { set; get; }
    }
}

