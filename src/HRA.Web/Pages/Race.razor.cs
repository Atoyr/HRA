using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using HRA.EF;
using HRA.EF.Enum;

namespace HRA.Web.Pages
{
  public partial class Race : ComponentBase
  {
    protected class RaceInfo
    {
      public RacePlaces Place { get; set; }
      public DateTime Date { get; set; }
    }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IDataService<HRA.EF.Race> RaceService { get; set; }

    [Parameter]
    public string RaceID { get; set; }

    protected IList<RaceInfo> racePlaces { get; set; }
    protected IList<HRA.EF.Race> races { get; set; }

    protected override void OnInitialized()
    {
      if ( RaceID is null)
      {
        races = RaceService.GetAll();
        // NavigationManager.NavigateTo("/");
      }
      else
      {
        races = RaceService.Get(x => x.ID == RaceID );
      }
      //racePlaces = races.GroupBy(x => new {x.Place, x.Date}).Select(x => new RaceInfo{Place = x.Key.Place, Date = x.Key.Date }).ToList();
    }
  }

}
