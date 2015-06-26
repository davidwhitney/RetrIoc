using System.Web.UI;
using RetrIoc.Injection;

namespace RetrIoc.Test.Unit.Fakes
{
    public class TestPage : Page
    {
        [Inject]
        public Dep Class { get; set; }

        [Inject]
        private Dep Class2 { get; set; }

        [Inject]
        private Dep _class3;
    }
}