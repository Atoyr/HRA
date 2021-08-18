using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HRA.Web.Components
{
  public class HRAComponentBase : ComponentBase
  {
    public void StateHasChangedInvoke()
    {
      _ = InvokeAsync(() => {
          StateHasChanged();

          });

    }
  }
}
