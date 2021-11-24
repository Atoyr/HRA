using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HRA.EF.Enum;

namespace HRA.EF
{
    public class Race
    {
        /// <summary>
        /// Race ID
        /// </summary>
        [Key]
        public string ID { get; set; }

        /// <summary>
        /// Race Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Race Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Age Category (3歳上)
        /// </summary>
        public string AgeCategory { get; set; }

        /// <summary>
        /// Race Pattern (G1 G2 etc...)
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Race Class (Open
        /// </summary>
        public string Class { get; set; }

        public string Rule { get; set; }

        /// <summary>
        /// Weight Rule (馬齢 etc...)
        /// </summary>
        public string WeightRule { get; set; }

        /// <summary>
        /// Race No
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// Race Day
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Race Place
        /// </summary>
        public RacePlaces Place { get; set; }

        /// <summary>
        /// Race Round
        /// </summary>
        public int Round { get; set; }

        /// <summary>
        /// Race Distance
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Race Course
        /// </summary>
        public string Course { get; set; }

        public string Rotate { get; set; }

        public string Wether { get; set; }

        public string Baba { get; set; }

        public decimal Up4F {get; set;}
        public decimal Up3F {get; set;}
        public string FurlongTime { get; set; }
        /// <summary>
        /// Number of Horse
        /// </summary>
        public int NumberOfHorse { get; set; }

        public string Remarks { get; set; }

        public string GenerateID()
        {
          StringBuilder sb = new StringBuilder();
          sb.Append(Date.ToString("yyyyMMdd"));
          sb.Append(string.Format("{0:D2}", (int)Place));
          sb.Append(string.Format("{0:D2}", No));
          sb.Append(string.Format("{0:D2}", Day));
          sb.Append(string.Format("{0:D2}", Round));
          return sb.ToString();
        }
    }
}
