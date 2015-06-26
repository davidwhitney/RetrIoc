using System;

namespace RetrIoc
{
    public class RetrIocNotAddedException : Exception
    {
        public RetrIocNotAddedException() : base(
            "You're trying to configure RetrIoc.\r\n" +
            "We're throwing this error because you haven't added the Http Module " +
            "to your web.config - no dependencies will be injected.\r\n"
            +
            "Add:\r\n\r\n" +
            "     <add name=\"RetrIoc\" type=\"RetrIoc.Autowire, RetrIoc\"/>\r\n" +
            "\r\n" +
            "To your configuration at the following locations.\r\n\r\n" +
            "  Classic Pipeline   :  configuration/system.web/httpModules\r\n" +
            "  Integrated Pipeline:  configuration/system.webServer/modules")
        {

        }
    }
}