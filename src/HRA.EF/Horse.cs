using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HRA.EF.Enum;

namespace HRA.EF
{
    public class Horse
    {
        [Key]
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Father  { get; set; }
        public string Mother  { get; set; }
        public string MotherMother  { get; set; }
        public string MotherFather  { get; set; }

        public string Owner { get; set; }
        public string OriginRanch { get; set; }
    }
}
