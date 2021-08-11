using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRA.Data
{
    public class Time
    {
        [Key]
        public string RaceID { get; set; }
        public int Range { get; set; }
        public DateTime RaceTime { get; set; }
        public DateTime SectionTime { get; set; }
    }
}

