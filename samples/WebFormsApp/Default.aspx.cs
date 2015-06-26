using System;
using System.Web.UI;
using RetrIoc;

namespace WebFormsApp
{
    public partial class _Default : Page
    {
        [Inject]
        public MyClass RandomDependency { get; set; }

        [Inject]
        public MyClass RandomDependency2 { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    public class MyClass
    {
        public string Id { get; set; }

        public MyClass()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}