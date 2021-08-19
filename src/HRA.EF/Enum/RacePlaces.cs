using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRA.EF.Enum
{
  public enum RacePlaces
  {
    Tokyo,
    Nakayama,
    Chukyo,
    Kyoto,
    Hanshin,
    Sapporo,
    Hakodate,
    Nigata,
    Fukushima,
    Ogura
  }

  public static partial class RacePlacesExtend 
  {
    public static string Name(this RacePlaces param) 
    {
      string ret = string.Empty;
      switch (param) {
        case RacePlaces.Tokyo:
          ret = "東京";
          break;
        case RacePlaces.Nakayama:
          ret = "中山";
          break;
        case RacePlaces.Chukyo:
          ret = "中京";
          break;
        case RacePlaces.Kyoto:
          ret = "京都";
          break;
        case RacePlaces.Hanshin:
          ret = "阪神";
          break;
        case RacePlaces.Sapporo:
          ret = "札幌";
          break;
        case RacePlaces.Hakodate:
          ret = "函館";
          break;
        case RacePlaces.Nigata:
          ret = "新潟";
          break;
        case RacePlaces.Fukushima:
          ret = "福島";
          break;
        case RacePlaces.Ogura:
          ret = "小倉";
          break;
      }
      return ret;
    }
  }
}


