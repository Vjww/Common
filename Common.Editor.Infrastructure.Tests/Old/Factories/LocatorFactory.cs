using System;
using Common.Editor.Infrastructure.Old.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Editor.Infrastructure.Tests.Old.Factories
{
    [TestClass]
    public class LocatorFactory
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LocatorFactory_WhenCreatingNewLocatorWithIdValueBelowZero_ExpectException()
        {
            var _ = LocatorFactory<MockLocator>.New(-1);
        }

        [TestMethod]
        public void LocatorFactory_WhenCreatingNewLocatorWithIdValueOfZero_ExpectIdValueToBeSet()
        {
            var sut = LocatorFactory<MockLocator>.New(0);
            Assert.IsTrue(sut.Id == 0);
        }

        [TestMethod]
        public void LocatorFactory_WhenCreatingNewLocatorWithIdValueAboveZero_ExpectIdValueToBeSet()
        {
            var sut = LocatorFactory<MockLocator>.New(int.MaxValue);
            Assert.IsTrue(sut.Id == int.MaxValue);
        }
    }
}