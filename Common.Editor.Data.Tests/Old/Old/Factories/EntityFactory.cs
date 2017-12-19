using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Editor.Data.Tests.Old.Old.Factories
{
    [TestClass]
    public class EntityFactory
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EntityFactory_WhenCreatingNewEntityWithIdValueBelowZero_ExpectException()
        {
            var _ = EntityFactory<MockEntity>.New(-1);
        }

        [TestMethod]
        public void EntityFactory_WhenCreatingNewEntityWithIdValueOfZero_ExpectIdValueToBeSet()
        {
            var sut = EntityFactory<MockEntity>.New(0);
            Assert.IsTrue(sut.Id == 0);
        }

        [TestMethod]
        public void EntityFactory_WhenCreatingNewEntityWithIdValueAboveZero_ExpectIdValueToBeSet()
        {
            var sut = EntityFactory<MockEntity>.New(int.MaxValue);
            Assert.IsTrue(sut.Id == int.MaxValue);
        }
    }
}