using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HRA.Components
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
