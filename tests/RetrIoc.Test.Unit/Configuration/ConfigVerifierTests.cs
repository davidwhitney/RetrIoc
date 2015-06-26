using System.Web;
using NUnit.Framework;
using RetrIoc.Configuration;

namespace RetrIoc.Test.Unit.Configuration
{
    [TestFixture]
    public class ConfigVerifierTests
    {
        [Test]
        public void AssertModuleExists_NoModuleExists_Throws()
        {
            Assert.Throws<RetrIocNotAddedException>(() => ConfigVerifier.AssertModuleExists(new HttpApplication()));
        }
    }
}
