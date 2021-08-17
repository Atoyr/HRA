using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace HRA.RssReader
{
  public class Reader
  {
    private string rss { set; get; }
    private Reader() { }

    public Reader(string rss)
    {
      this.rss = rss;
    }


    public RssInfo Read()
    {    
        XElement element = XElement.Load(this.rss);
        int version = 0;
        Console.WriteLine(element.Name.LocalName.ToString().ToUpper());

        // channelを取得する・・・(1)
        if (element.Name.LocalName.ToString().ToUpper() == "RDF")
        {
          version = 1;
        }
        else if (element.Name.LocalName.ToString().ToUpper() == "RSS")
        {
          version = 2;
        }
        else
        {
          return null;
        }

        XElement channelElement = element.Descendants().Where(x => x.Name.LocalName == "channel").FirstOrDefault();

        RssInfo rssInfo = new RssInfo();
        rssInfo.Title = channelElement.Descendants().Where(x => x.Name.LocalName == "title").FirstOrDefault()?.Value;
        rssInfo.Description = channelElement.Descendants().Where(x => x.Name.LocalName == "description").FirstOrDefault()?.Value;
        rssInfo.Link = channelElement.Descendants().Where(x => x.Name.LocalName == "link").FirstOrDefault()?.Value;
        rssInfo.LastBuildDate = channelElement.Descendants().Where(x => x.Name.LocalName == "lastBuildDate").FirstOrDefault()?.Value;

        List<RssItemInfo> rssItemInfos = new List<RssItemInfo>();

        IEnumerable<XElement> elementItems;
        switch (version)
        {
          case 1:
            elementItems = element.Descendants().Where(x => x.Name.LocalName == "item").ToList();
            break;
          case 2:
            elementItems = channelElement.Descendants().Where(x => x.Name.LocalName == "item").ToList();
            break;
          default:
            return rssInfo;
        }

        foreach(XElement elmItem in elementItems)
        {
          RssItemInfo itemInfo = new RssItemInfo();
          itemInfo.Title = elmItem.Descendants().Where(x => x.Name.LocalName == "title").FirstOrDefault()?.Value;
          itemInfo.Link = elmItem.Descendants().Where(x => x.Name.LocalName == "link").FirstOrDefault()?.Value;
          itemInfo.Description = elmItem.Descendants().Where(x => x.Name.LocalName == "description").FirstOrDefault()?.Value;
          itemInfo.PubDate = elmItem.Descendants().Where(x => x.Name.LocalName == "pubDate").FirstOrDefault()?.Value;
          rssItemInfos.Add(itemInfo);
        }

        rssInfo.Items = rssItemInfos;

        Console.WriteLine($"RSS INFO Items {rssInfo.Items.Count()}");

        return rssInfo;
    }
  }
}

