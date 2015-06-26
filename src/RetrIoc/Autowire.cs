using System;
using System.Web;
using System.Web.UI;

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

        public void Dispose()
        {
        }

        public static void ConfigureWith(IContainerBinding binding)
        {
            AssertModuleInstalled();
            _aspxPageInjector = new AspxPageInjector(new RetrIocConfiguration(binding));
        }

        public static void ConfigureWith(RetrIocConfiguration config)
        {
            AssertModuleInstalled();
            _aspxPageInjector = new AspxPageInjector(config);
        }

        public static void AssertModuleInstalled()
        {
            var httpApps = HttpContext.Current.ApplicationInstance;
            var httpModuleCollections = httpApps.Modules;
            var found = false;
            foreach (var activeModule in httpModuleCollections.AllKeys)
            {
                if (activeModule.Contains("RetrIoc"))
                {
                    found = true;
                }
            }

            if (!found)
            {
                throw new RetrIocNotAddedException();
            }
        }
    }
}
