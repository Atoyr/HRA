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
    // Target toppage url
    private const string URL = @"";

    // web driver
    private IWebDriver driver { get; set; }

    private IList<Action> actions { get; set; }

    // TODO races
    public List<Race> Races { get; private set; }

    // action wait second
    public int WaitSecond { get; set; }

    // TODO
    private List<string> openedDayResult { get; set; } = new ();
    // TODO
    private bool hasResult { get; set; } = true;

    // TODO
    private List<string> dayPlacesList { get; set; }

    // TODO
    private int dayPlacesIndex { get; set; }

    private Scraper() { }

    public Scraper(IWebDriver driver)
    {
      this.driver = driver;
      actions = new List<Action>();
      WaitSecond = 1;
      Races = new List<Race>();
    }

    public static Scraper Default()
    {
      return new Scraper(new OpenQA.Selenium.Chrome.ChromeDriver());
    }

    public void ApplyGetRaceResultHistoryActions()
    {
      actions.Add(OpenRaceResultFromTopPage);
      actions.Add(OpenRaceResultHistoryFromRaseResult);
      var l = LoopAction(() => hasResult, OpenDayRaceResultFromRaseResultHistory,OpenAllRacesFromDayPlace, GoBack, GoBack);
      actions.Add(l);
      // actions.Add(OpenDayRaceResultFromRaseResultHistory);
      // actions.Add(OpenAllRacesFromDayPlace);
      // actions.Add(GoBack);
      // actions.Add(GoBack);
    }

    public void ApplyGetRaceDayResultActons()
    {
      actions.Add(OpenRaceDaysFromTopPage);
      actions.Add(ReadDayPlacesFromRaceDays);
      actions.Add(OpenDayPlaceFromRaceDays);
      actions.Add(OpenAllRacesFromDayPlace);
      actions.Add(ReadRaceDataFromAllRaces);
    }

    public void Execute()
    {
      driver.Url = URL;
      execute(actions);
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

    // TOPから指定のテキストを検索して開く
    private void OpenFromTopPage(string aText)
    {
      var topPage_ATagElements = driver.FindElements(By.TagName("a"));
      bool find = false;
      foreach (var e in topPage_ATagElements)
      {
        var child = e.FindElements(By.TagName("div"));
        foreach(var c in child)
        {
          if (c.Text == aText)
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
    // TOPから出馬表を開く
    private void OpenRaceDaysFromTopPage()
    {
      OpenFromTopPage("出馬表");
    }

    // TOPからレース結果を開く
    private void OpenRaceResultFromTopPage()
    {
      OpenFromTopPage("レース結果");
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

    // レース結果画面から過去レース結果検索を開く
    private void OpenRaceResultHistoryFromRaseResult()
    {
      var raceResult_IdPastResult_AtagsElements = driver.FindElement(By.Id("past_result")).FindElements(By.TagName("a"));
      foreach(var e in raceResult_IdPastResult_AtagsElements)
      {
        if (e.Text == "過去レース結果検索")
        {
          e.Click();
          break;
        }
      }
    }

    // 過去レース結果から日程を開く
    private void OpenDayRaceResultFromRaseResultHistory()
    {
      var raceResult_IdPastResultLine_elements = driver.FindElement(By.Id("past_result"));
      var idPastResultLine_ul_elements = raceResult_IdPastResultLine_elements.FindElements(By.TagName("ul"));
      var ul_li_elements = idPastResultLine_ul_elements[0].FindElements(By.TagName("li"));
      foreach(var e in ul_li_elements)
      {
        // head
        var cell = e.FindElement(By.ClassName("kaisai"));
        foreach (var li in cell.FindElements(By.TagName("a")))
        {
          if (!openedDayResult.Any(x => x == e.Text))
          {
            Console.WriteLine(li.Text);
            openedDayResult.Add(li.Text);
            hasResult = true;
            li.Click();
            return;
          }
          hasResult = false;
        }
      }
    }

    // レース結果レース選択からすべてのレースを表示を開く
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


    private void ReadRaceDataFromAllRaces()
    {
      for (int i = 1 ; i < 12; i++)
      {
        var race = new Race();
        var allRacePage_Round = driver.FindElement(By.Id($"syutsuba_{i}R"));

        var caption = allRacePage_Round.FindElement(By.TagName("caption"));

        race.Round = i;
        race.Name = caption.FindElement(By.ClassName("race_name")).Text;
        // race.Date = ;
        race.Category = caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("category")).Text;
        race.Rule = caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("rule")).Text;
        race.WeightRule = caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("weight")).Text;
        race.Course = caption.FindElement(By.ClassName("detail")).Text.IndexOf("芝") < 0 ? Grounds.Dirt : Grounds.Turf;

        // Console.WriteLine($"Round {j}");
        // Console.WriteLine(caption.FindElements(By.TagName("span")).FirstOrDefault(x => x.FindElement(By.ClassName("race_name")).Displayed).Text);
        Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("category")).Text);
        Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("class")).Text);
        Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("rule")).Text);
        Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("weight")).Text);
        Console.WriteLine(caption.FindElement(By.ClassName("type")).FindElement(By.ClassName("course")).Text);


        // race.ID = race.GenerateID;


        var tbody = allRacePage_Round.FindElement(By.TagName("tbody"));
        var trs = tbody.FindElements(By.TagName("tr"));
        int count = 0;
        foreach(var tr in trs)
        {
          var raceCard = new RaceCard();
          raceCard.ID = Guid.NewGuid().ToString();
          raceCard.RaceID = race.ID;
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
          count++;
        }

        race.NumberOfHorse = count;
        Races.Add(race);
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

    private Action LoopAction(Func<bool> isLoop, params Action[] actions)
    {
      return () => {
      while(isLoop())
      {
        foreach(var a in actions)
        {
          Sleep(WaitSecond);
          a();
        }
      }
      };
    }
  }
}
