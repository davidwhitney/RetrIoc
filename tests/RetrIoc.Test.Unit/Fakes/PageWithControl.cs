using System.Web.UI;

namespace RetrIoc.Test.Unit.Fakes
{
    public class PageWithControl : Page
    {
        public FakeUserControl Control { get; set; }

        public PageWithControl()
        {
            Control = new FakeUserControl();
            Controls.Add(Control);

        }
    }
}