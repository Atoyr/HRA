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
using HRA.RssReader;

namespace HRA.Pages
{
  public partial class Index : ComponentBase
  {
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected RssInfo rssInfo { get; set; }

    protected override void OnInitialized()
    {
      rssInfo = new Reader(@"https://www.jra.go.jp/rss/jra-info.rdf").Read();
      
    }

  }
}
