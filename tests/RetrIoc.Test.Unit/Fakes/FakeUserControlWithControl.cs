using System.Web.UI;

namespace RetrIoc.Test.Unit.Fakes
{
    public class FakeUserControlWithControl : UserControl
    {
        public FakeUserControl InnerControl { get; set; }

        public FakeUserControlWithControl()
        {
            InnerControl = new FakeUserControl();
            Controls.Add(InnerControl);
        }
    }
}