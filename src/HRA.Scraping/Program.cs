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
          OpenHorseList(driver);

          Sleep(1);


          var racePage_MainIdATabElements = driver.FindElement(By.Id("main")).FindElements(By.TagName("a"));
          int aCount = racePage_MainIdATabElements.Count();

          for(int i = 0; i < aCount; i++)
          {
              var e = driver.FindElement(By.Id("main")).FindElements(By.TagName("a"));
              Console.WriteLine(e[i].Text);
              Sleep(1);
              e[i].Click();

              // すべてのレースを表示
              foreach(var e2 in driver.FindElement(By.Id("race_list")).FindElements(By.TagName("a")))
              {
                if (e2.Text == "全てのレースを表示")
                {
                  e2.Click();
                  break;
                }
              }


              for (int j = 1 ; j < 2; j++)
              {
                var allRacePage_Round = driver.FindElement(By.Id($"syutsuba_{j}R"));

                var caption = allRacePage_Round.FindElement(By.TagName("caption"));
                Console.WriteLine($"Round {j}");
                // Console.WriteLine(caption.FindElements(By.TagName("span")).FirstOrDefault(x => x.FindElement(By.ClassName("race_name")).Displayed).Text);
                Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("category")).Text);
                Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("class")).Text);
                Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("rule")).Text);
                Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("weight")).Text);
                Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("course")).Text);



                var tbody = allRacePage_Round.FindElement(By.TagName("tbody"));
                var trs = tbody.FindElements(By.TagName("tr"));
                foreach(var tr in trs)
                {
                  // var td = tr.FindElements(By.TagName("td"));
                  Console.Write("No ");
                  Console.WriteLine(tr.FindElement(By.ClassName("num")).Text);

                  Console.Write("Horse ");
                  Console.WriteLine(tr.FindElement(By.ClassName("horse")).FindElement(By.TagName("a")).Text);

                  Console.Write("Horse Weight ");
                  Console.WriteLine(tr.FindElement(By.ClassName("h_weight")).Text);

                  Console.Write("Age ");
                  Console.WriteLine(tr.FindElement(By.ClassName("age")).Text);

                  Console.Write("Weight ");
                  Console.WriteLine(tr.FindElement(By.ClassName("weight")).Text);
                  Console.Write("Jockey ");
                  Console.WriteLine(tr.FindElement(By.ClassName("jockey")).FindElement(By.TagName("a")).Text);
                  Console.Write("Trainer ");
                  Console.WriteLine(tr.FindElement(By.ClassName("trainer")).FindElement(By.TagName("a")).Text);
                }


              }

              Sleep(1);
              driver.Navigate().Back();
          }

        }

        static void OpenHorseList(IWebDriver driver)
        {
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
        }

        static void Sleep(int second)
        {
          System.Threading.Thread.Sleep(second * 1000);
        }
    }
}
