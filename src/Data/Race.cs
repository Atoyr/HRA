using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRA.Data
{
    public class Race
    {
        [Key]
        public string ID { get; set; }
        public int No { get; set; }
        public int Day { get; set; }
        public int Round { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Grounds Course  { get; set; }
        public int Distance { get; set; }
        public int NumberOfHorse { get; set; }
    }
}
