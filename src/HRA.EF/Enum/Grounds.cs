using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRA.EF.Enum
{
    public enum Grounds
    {
      Turf,
      Dirt
    }

  public static partial class GroundsExtend 
  {
    public static string Name(this Grounds param) 
    {
      string ret = string.Empty;
      switch(param)
      {
        case Grounds.Turf:
          ret = "芝";
          break;
        case Grounds.Dirt:
          ret = "ダート";
          break;
      }
      return ret;
    }
  }
}


