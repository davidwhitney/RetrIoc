using System;
using System.Web;
using System.Web.UI;
using RetrIoc.Configuration;
using RetrIoc.Injection;

namespace RetrIoc
{
    public class Autowire : IHttpModule
    {
        private HttpApplication _context;
        private static AspxPageInjector _aspxPageInjector;

        public void Init(HttpApplication context)
        {
            _context = context;
            _context.PreRequestHandlerExecute += InjectProperties;
            _context.EndRequest += ReleaseComponents;
        }

        private void InjectProperties(object sender, EventArgs e)
        {
            var currentPage = _context.Context.CurrentHandler as Page;
            if (currentPage == null)
            {
                return;
            }

            currentPage.InitComplete += (s, args) => _aspxPageInjector.InjectInto(currentPage);
        }

        public void ReleaseComponents(object sender, EventArgs e)
        {
        }

        public static void ConfigureWith(IResolveTypes binding)
        {
            ConfigVerifier.AssertModuleExists(HttpContext.Current.ApplicationInstance);
            _aspxPageInjector = new AspxPageInjector(new RetrIocConfiguration(binding));
        }

        public static void ConfigureWith(RetrIocConfiguration config)
        {
            ConfigVerifier.AssertModuleExists(HttpContext.Current.ApplicationInstance);
            _aspxPageInjector = new AspxPageInjector(config);
        }

        public void Dispose()
        {
        }
    }
}
