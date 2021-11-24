using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HRA.EF.Enum;

namespace HRA.EF
{
    /// <summary>
    /// Race Card is race card and snapshot
    /// </summary>
    public class RaceCard
    {
        [Key]
        /// <summary>
        /// Race Card ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Race ID (ForeingKey
        /// </summary>
        public string RaceID { get; set; }

        /// <summary>
        /// Gate No (1~8)
        /// </summary>
        public int GateNo { get; set; }

        /// <summary>
        /// Horse No (1~18)
        /// </summary>
        public int No { get; set; }

        /// <summary>
        /// Horse Name
        /// </summary>
        public string Name { get; set; }

        public string Type { get; set; }

        public bool Blinkers { get; set; }

        /// <summary>
        /// Sex Type
        /// </summary>
        public string SexType { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Jokey
        /// </summary>
        public string Jokey { set; get; }

        /// <summary>
        /// BurdenWeight is Seki ryou.
        /// </summary>
        public decimal BurdenWeight { get; set; }

        /// <summary>
        /// HorseWeight
        /// </summary>
        public decimal HorseWeight { set; get; }

        /// <summary>
        /// Fluctuation ( +- 0)
        /// </summary>
        public decimal Fluctuation { set; get; }

        /// <summary>
        /// Status is cancel and more.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Trainer
        /// </summary>
        public string Trainer { set; get; }

        /// <summary>
        /// Favorite (0~18)
        /// </summary>
        public int Favorite { set; get; }

        public int Ranking { set; get; }

        public decimal Time { set; get; }

        public string Margin {get; set;}

        /// <summary>
        /// RaceRecord (1.0.0.0)
        /// </summary>
        public string RaceRecord { set; get; }

        public decimal Last3F { get; set; }

        public string Remarks { get; set; }

        public string GenerateID()
        {
          StringBuilder sb = new StringBuilder();
          sb.Append(RaceID);
          sb.Append(string.Format("{0:D2}", GateNo));
          sb.Append(string.Format("{0:D2}", No));
          return sb.ToString();
        }
    }
}


