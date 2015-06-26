using System.Web.UI;

namespace RetrIoc.Test.Unit.Fakes
{
    public class TestPage : Page
    {
        [Inject]
        public Dep Class { get; set; }
    }
}