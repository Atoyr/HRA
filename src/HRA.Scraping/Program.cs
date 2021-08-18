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
          var driver = new OpenQA.Selenium.Chrome.ChromeDriver();

          driver.Url = @"";

          // WEBサイト負荷軽減のため
          Sleep(1);

          // 出馬表を開く
          var topPage_ATagElements = driver.FindElements(By.TagName("a"));
          bool find = false;
          foreach (var e in topPage_ATagElements)
          {
            var child = e.FindElements(By.TagName("div"));
            foreach(var c in child)
            {
              if (c.Text == "出馬表")
              {
                find = true;
                break;
              }
            }

            if (find)
            {
              e.Click();
              break;
            }
          }

          Sleep(1);


          var racePage_MainIdATabElements = driver.FindElement(By.Id("main")).FindElements(By.TagName("a"));
          int aCount = racePage_MainIdATabElements.Count();

          for(int i = 0; i < aCount; i++)
          {
              var e = driver.FindElement(By.Id("main")).FindElements(By.TagName("a"));
              Console.WriteLine(e[i].Text);
              Sleep(1);
              e[i].Click();
              Sleep(1);
              driver.Navigate().Back();
          }

        }

        static void Sleep(int second)
        {
          System.Threading.Thread.Sleep(second * 1000);
        }
    }
}
