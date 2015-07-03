using System.Web;

namespace RetrIoc.Configuration
{
    public class ConfigVerifier
    {
        public static void AssertModuleExists(HttpApplication application)
        {
            if (IsEnabled(application)) return;

            throw new RetrIocNotAddedException();
        }

        public static bool IsEnabled(HttpApplication application)
        {
            var httpModuleCollections = application.Modules;
            foreach (var activeModule in httpModuleCollections.AllKeys)
            {
                if (activeModule.Contains("RetrIoc"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}