using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HRA.EF.Enum;

namespace HRA.EF
{
    public interface IDataService<T> 
    {
      public IList<T> GetAll();
      public IList<T> Get(Func<T,bool> func);

      public bool Update(T item);
      public bool Update(IList<T> items);

      public bool Delete(T item);
    }
}

