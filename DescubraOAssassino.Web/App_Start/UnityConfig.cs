using DescubraOAssassino.IoC.Unity;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace DescubraOAssassino.Web.App_Start
{
  public static class UnityConfig
  {
    public static void Register(HttpConfiguration config)
    {
      var container = new UnityContainer();
      DependencyResolver.Resolve(container);
      config.DependencyResolver = new UnityResolver(container);
    }
  }
}