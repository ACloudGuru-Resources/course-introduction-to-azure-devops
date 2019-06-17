using System;
using Microsoft.Extensions.Configuration;
using Miniboard.Data;
using NUnit.Framework;

namespace Miniboard.UnitTest.Data
{
    public class Tests
    {
        [Test]
        public void WhenCreatingContextFactoryFromNullString_ThenThrow()
        {
            TestDelegate act = () =>
            {
                new ContextFactory((string) null);
            };

            Assert.Throws<ArgumentNullException>(act);
        }

        [Test]
        public void WhenCreatingContextFactoryFromNullConfiguration_ThenThrow()
        {
            TestDelegate act = () =>
            {
                new ContextFactory((IConfiguration) null);
            };

            Assert.Throws<ArgumentNullException>(act);
        }

        [Test]
        public void WhenCreatingContextFactoryFromConfigurationWithoutConfigruationString_ThenThrow()
        {
            TestDelegate act = () =>
            {
                new ContextFactory(new NullConfiguration());
            };

            Assert.Throws<InvalidOperationException>(act);
        }
    }
}