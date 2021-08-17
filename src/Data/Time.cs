using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRA.Data
{
    public class Time
    {
        [Key]
        [Column(Order = 1)]
        public string RaceID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string HorseName { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Range { get; set; }

        public DateTime RaceTime { get; set; }
        public DateTime SectionTime { get; set; }
    }
}

