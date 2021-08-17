using System;
using System.Collections.Generic;

namespace HRA.RssReader
{
  public class RssInfo
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public string LastBuildDate { get; set; }
    public IList<RssItemInfo> Items { get; set; }

    public RssInfo()
    {
      Items = new List<RssItemInfo>();
    }
  }
}
