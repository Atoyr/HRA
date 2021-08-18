using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HRA.EF.Enum;

namespace HRA.EF
{
    public class RaceResult
    {
        [Key]
        [Column(Order = 1)]
        public string RaceID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string HorseName { get; set; }
        public int Ranking { get; set; }
        public Time Time { set; get; }
        public string Diff { set; get; }
        public string ThroughRanking { set; get; }
        public decimal Last3F { set; get; }
        public decimal Last4F { set; get; }
        public int Favorite { set; get; }
    }
}

