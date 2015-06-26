using System;
using NUnit.Framework;
using RetrIoc.Configuration;
using WebFormsApp;

namespace RetrIoc.Test.Unit.Configuration
{
    [TestFixture]
    public class RetrIocConfigurationTests
    {
        [Test]
        public void Ctor_GivenNull_Throws()
        {
            Assert.Throws<ArgumentNullException>(()=>new RetrIocConfiguration(null));
        }

        [Test]
        public void Ctor_GivenConfig_Constructs()
        {
            var instance = new RetrIocConfiguration(new ActivatorContainer());

            Assert.That(instance, Is.Not.Null);
        }
    }
}
