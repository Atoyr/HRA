using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HRA.EF.Enum;
using HRA.EF;

namespace HRA.EF.Dummy
{
    public class RaceDummyService : IDataService<Race>
    {
      private List<Race> races { set; get; }

      public RaceDummyService()
      {
        races = new List<Race>();

        var rn4101 = new Race
        { No = 4, Year = 2021, Day = 1, Round = 1, Name = "2歳未勝利（混合）", Place = RacePlaces.Nigata, Date = new DateTime(2021, 8, 14), Course = Grounds.Dirt, Distance = 1200, NumberOfHorse = 15, RaceClass = RaceClasses.NoWin, MareOnly = false };
        rn4101.ID = rn4101.GenerateID();
        races.Add(rn4101);

        var rn4102 = new Race
        { No = 4, Year = 2021, Day = 1, Round = 2, Name = "2歳未勝利（混合）", Place = RacePlaces.Nigata, Date = new DateTime(2021, 8, 14), Course = Grounds.Grass, Distance = 1800, NumberOfHorse = 11, RaceClass = RaceClasses.NoWin, MareOnly = false };
        rn4102.ID = rn4102.GenerateID();
        races.Add(rn4102);

        var rn4103 = new Race
        { No = 4, Year = 2021, Day = 1, Round = 3, Name = "3歳未勝利", Place = RacePlaces.Nigata, Date = new DateTime(2021, 8, 14), Course = Grounds.Dirt, Distance = 1800, NumberOfHorse = 15, RaceClass = RaceClasses.NoWin, MareOnly = false };
        rn4103.ID = rn4103.GenerateID();
        races.Add(rn4103);

        var rn4104 = new Race
        { No = 4, Year = 2021, Day = 1, Round = 4, Name = "3歳未勝利雌", Place = RacePlaces.Nigata, Date = new DateTime(2021, 8, 14), Course = Grounds.Grass, Distance = 2000, NumberOfHorse = 14, RaceClass = RaceClasses.NoWin, MareOnly = true };
        rn4104.ID = rn4104.GenerateID();
        races.Add(rn4104);

        var rn4105 = new Race
        { No = 4, Year = 2021, Day = 1, Round = 5, Name = "メイクデビュー新潟", Place = RacePlaces.Nigata, Date = new DateTime(2021, 8, 14), Course = Grounds.Grass, Distance = 1600, NumberOfHorse = 17, RaceClass = RaceClasses.NoWin, MareOnly = false };
        rn4105.ID = rn4105.GenerateID();
        races.Add(rn4105);

        var ro4211 = new Race
        {
          No = 4,
          Year = 2021,
          Day = 2,
          Round = 11,
          Name = "小倉記念",
          Place = RacePlaces.Ogura,
          Date = new DateTime(2021, 8, 15),
          Course = Grounds.Grass,
          Distance = 2000,
          NumberOfHorse = 10,
          RaceClass = RaceClasses.G3,
          MareOnly = false
        };
        ro4211.ID = ro4211.GenerateID();
        races.Add(ro4211);
        var r2 = new Race
        {
          No = 4,
          Year = 2021,
          Day = 2,
          Round = 11,
          Name = "関屋記念",
          Place = RacePlaces.Nigata,
          Date = new DateTime(2021, 8, 15),
          Course = Grounds.Grass,
          Distance = 1600,
          NumberOfHorse = 18,
          RaceClass = RaceClasses.G3,
          MareOnly = false
        };
        r2.ID = r2.GenerateID();
        races.Add(r2);
      }

      public IList<Race> GetAll()
      {
        return races;
      }

      public IList<Race> Get(Func<Race,bool> func)
      {
        return races.Where(func).ToList();
      }

      public bool Update(Race item)
      {
        int index = races.FindIndex(x => x.ID == item.ID);
        if (index < 0)
        {
          races.Add(item);
        }
        else
        {
          races[index] = item;
        }
        return true;
      }

      public bool Update(IList<Race> items)
      {
        foreach(var i in items)
        {
          Update(i);
        }
        return true;
      }

      public bool Delete(Race item)
      {
        int index = races.FindIndex(x => x.ID == item.ID);
        if (index < 0)
        {
          return false;
        }
        else
        {
          races.Remove(races[index]);
          return true;
        }
      }
    }
}


