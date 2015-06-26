using System.Web.UI;

namespace RetrIoc.Test.Unit.Fakes
{
    public class FakeUserControl : UserControl
    {
        [Inject]
        public Dep Class { get; set; }
    }
}