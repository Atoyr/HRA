using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using HRA.EF;

namespace HRA.Web.Components
{
  public partial class RaceInfo : HRAComponentBase
  {
    [Parameter]
    public IList<Race> Races { get; set; }
  }
}

