using System;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HRA.EF;
using HRA.EF.Enum;

namespace HRA.Srcaping
{
  public class Scraper
  {
    private const string URL = @"";

    private IWebDriver driver { get; set; }

    public List<Race> Races { get; private set; }

    public int WaitSecond { get; set; }

    private List<string> dayPlacesList { get; set; }

    private int dayPlacesIndex { get; set; }

    private Scraper() { }

    public Scraper(IWebDriver driver)
    {
      this.driver = driver;
      Races = new List<Race>();
      WaitSecond = 1;
    }

    public static Scraper Default()
    {
      return new Scraper(new OpenQA.Selenium.Chrome.ChromeDriver());
    }

    public void Execute()
    {
      driver.Url = URL;
      var actionList = new List<Action>();
      actionList.Add(OpenRaceDaysFromTopPage);
      actionList.Add(ReadDayPlacesFromRaceDays);
      actionList.Add(OpenDayPlaceFromRaceDays);
      actionList.Add(OpenAllRacesFromDayPlace);
      actionList.Add(ReadRaceDataFromAllRaces);

      execute(actionList);
    }

    private void execute(IEnumerable<Action> actions)
    {
      foreach(var a in actions)
      {
        // WEBサイト負荷軽減のため
        Sleep(WaitSecond);
        a();
      }
    }

    private void OpenRaceDaysFromTopPage()
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

    private void ReadDayPlacesFromRaceDays()
    {
      var raceDays_IdMain_AtagsElements = driver.FindElement(By.Id("main")).FindElements(By.TagName("a"));
      dayPlacesList = new List<string>();
      dayPlacesIndex = 0;
      foreach(var e in raceDays_IdMain_AtagsElements)
      {
        if (!string.IsNullOrEmpty(e.Text))
        {
          dayPlacesList.Add(e.Text);
        }
      }
    }


    private void OpenDayPlaceFromRaceDays()
    {
      var raceDays_IdMain_AtagsElements = driver.FindElement(By.Id("main")).FindElements(By.TagName("a"));
      string dayPlaceName = dayPlacesList[dayPlacesIndex];
      foreach(var e in raceDays_IdMain_AtagsElements)
      {
        if (e.Text == dayPlaceName)
        {
          e.Click();
          dayPlacesIndex++;
          break;
        }
      }
    }

    private void OpenAllRacesFromDayPlace()
    {
      // すべてのレースを表示
      foreach(var e in driver.FindElement(By.Id("race_list")).FindElements(By.TagName("a")))
      {
        if (e.Text == "全てのレースを表示")
        {
          e.Click();
          break;
        }
      }
    }

    private void ReadRaceDataFromAllRaces()
    {
      for (int j = 1 ; j < 2; j++)
      {
        var race = new Race();
        var allRacePage_Round = driver.FindElement(By.Id($"syutsuba_{j}R"));

        var caption = allRacePage_Round.FindElement(By.TagName("caption"));
        Console.WriteLine($"Round {j}");
        // Console.WriteLine(caption.FindElements(By.TagName("span")).FirstOrDefault(x => x.FindElement(By.ClassName("race_name")).Displayed).Text);
        Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("category")).Text);
        Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("class")).Text);
        Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("rule")).Text);
        Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("weight")).Text);
        Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("course")).Text);

        race.Category = caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("category")).Text;
        race.Rule = caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("rule")).Text;
        race.WeightRule = caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("weight")).Text;

        Races.Add(race);


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
    }

    private void GoBack()
    {
      driver.Navigate().Back();
    }

    private void Sleep(int second)
    {
      System.Threading.Thread.Sleep(second * 1000);
    }
  }
}
