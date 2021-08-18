using System;
using System.Text;

namespace HRA.Web.Util
{
  public class CssClassBuilder
  {

    public static CssClassBuilder Default() => new CssClassBuilder();
    private StringBuilder builder { set; get; }

    public CssClassBuilder()
    {
      builder = new StringBuilder();
    }

    public CssClassBuilder Add(string item)
    {
      builder.Append(item).Append(" ");
      return this;
    }

    public string Build() => builder.ToString().Trim();
  }
}
