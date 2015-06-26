﻿using System;
using NUnit.Framework;
using RetrIoc.Test.Unit.Fakes;

namespace RetrIoc.Test.Unit
{
    [TestFixture]
    public class AspxPageInjectorTests
    {
        private RetrIocConfiguration _cfg;
        private AspxPageInjector _module;
        private TestPage _somePage;

        [SetUp]
        public void SetUp()
        {
            _cfg = new RetrIocConfiguration(new FakeContainer());
            _module = new AspxPageInjector(_cfg);
            _somePage = new TestPage();
        }

        [Test]
        public void Ctor_PassedNoConfig_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new AspxPageInjector(null));
        }

        [Test]
        public void InjectInto_WithWorkingContainer_Injects()
        {
            _module.InjectInto(_somePage);

            Assert.That(_somePage.Class, Is.Not.Null);
        }

        [Test]
        public void InjectInto_PageWithUserControl_InjectsIntoUserControl()
        {
            var pageWithUc = new PageWithControl();
            pageWithUc.Controls.Add(pageWithUc.Control);

            _module.InjectInto(pageWithUc);

            Assert.That(pageWithUc.Control.Class, Is.Not.Null);
        }

        [Test]
        public void InjectInto_WithNoContainer_Throws()
        {
            _cfg.ContainerBindings = null;
        
            var ex = Assert.Throws<InvalidOperationException>(() => _module.InjectInto(_somePage));

            Assert.That(ex.Message, Is.StringContaining("Please configure your container bindings."));
        }

    }
}
