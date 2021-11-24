using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HRA.Srcaping
{
    class Program
    {
        static void Main(string[] args)
        {
          var scraper = Scraper.Default();
          scraper.ApplyGetRaceResultHistoryActions();
          scraper.Execute();
        }
    }
}
