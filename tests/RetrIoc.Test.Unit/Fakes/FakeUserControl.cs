using System.Web.UI;
using RetrIoc.Injection;

namespace RetrIoc.Test.Unit.Fakes
{
    public class FakeUserControl : UserControl
    {
        [Inject]
        public Dep Class { get; set; }
    }
}