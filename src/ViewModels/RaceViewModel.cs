using System;
using System.Collections.Generic;
using HRA.Data;
using HRA.Enum;

namespace HRA.ViewModels
{
  public class RaceCardViewModel
  {
    public int GateNo { get; set; }
    public int HorseNo { get; set; }
    public string HorseName { get; set; }
    public int Favorite { set; get; }

    public SexTypes SexType { get; set; }
    public int Age { get; set; }
    public decimal BurdenWeight { get; set; }
    public decimal Weight { set; get; }
    public decimal Fluctuation { set; get; }

    public string Driver { set; get; }
        
    public IList<RaceCardViewModel> BeforeResults { set; get; }
  }
  
}
