using System.Web.UI;

namespace RetrIoc.Test.Unit.Fakes
{
    public class PageWithControlWithControl : Page
    {
        public FakeUserControlWithControl Control { get; set; }

        public PageWithControlWithControl()
        {
            Control = new FakeUserControlWithControl();
            Controls.Add(Control);
        }
    }
}