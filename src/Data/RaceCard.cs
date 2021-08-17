using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HRA.Enum;

namespace HRA.Data
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
        public int HorseNo { get; set; }
        /// <summary>
        /// Horse Name
        /// </summary>
        public string HorseName { get; set; }
        /// <summary>
        /// Status is cancel and more.
        /// </summary>
        public string Status { get; set; }

        // SnapShot Data
        
        /// <summary>
        /// Favorite (0~18)
        /// </summary>
        public int Favorite { set; get; }
        /// <summary>
        /// RaceRecord (1.0.0.0)
        /// </summary>
        public string RaceRecord { set; get; }
        /// <summary>
        /// Owner
        /// </summary>
        public string Owner { set; get; }
        /// <summary>
        /// Trainer
        /// </summary>
        public string Trainer { set; get; } 
        /// <summary>
        /// Sex Type
        /// </summary>
        public SexTypes SexType { get; set; }
        /// <summary>
        /// Coat Color
        /// </summary>
        public string CoatColor { get; set; }
        /// <summary>
        /// Age
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// BurdenWeight is Seki ryou.
        /// </summary>
        public decimal BurdenWeight { get; set; }
        /// <summary>
        /// Weight
        /// </summary>
        public decimal Weight { set; get; }
        /// <summary>
        /// Fluctuation ( +- 0)
        /// </summary>
        public decimal Fluctuation { set; get; }
        /// <summary>
        /// Driver
        /// </summary>
        public string Driver { set; get; }

        
        public virtual Race Race { set; get; }
        public virtual Horse Horse { set; get; }
        public virtual RaceResult Result { set; get; }
    }
}


