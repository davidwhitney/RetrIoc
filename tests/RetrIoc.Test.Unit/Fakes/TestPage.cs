using System.Web.UI;
using RetrIoc.Injection;

namespace RetrIoc.Test.Unit.Fakes
{
    public class TestPage : Page
    {
        [Inject]
        public Dep Class { get; set; }
    }
}