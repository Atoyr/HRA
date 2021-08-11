using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRA.Data
{
    public class Horse
    {
        [Key]
        public string Name { get; set; }
        public SexTypes SexType { get; set; }
        public DateTime BirthDay { get; set; }
        public string Father  { get; set; }
        public string Mother  { get; set; }
        public string OriginPlace { get; set; }
        public string OriginRanch { get; set; }
    }
}
