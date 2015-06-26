using System;
using System.Web.UI;
using RetrIoc;

namespace WebFormsApp
{
    public partial class _Default : Page
    {
        [Inject]
        public MyClass Class { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    public class MyClass
    {
        
    }
}