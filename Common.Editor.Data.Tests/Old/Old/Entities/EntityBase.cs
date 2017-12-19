using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Editor.Data.Tests.Old.Old.Entities
{
    [TestClass]
    public class EntityBase
    {
        [TestMethod]
        public void EntityBase_WhenConstructing_ExpectIdValueToBeZero()
        {
            var sut = new MockEntity();
            Assert.IsTrue(sut.Id == 0);
        }

        [TestMethod]
        public void EntityBase_WhenSettingIdWithValueOfZero_ExpectIdValueToBeSet()
        {
            var sut = new MockEntity { Id = 0 };
            Assert.IsTrue(sut.Id == 0);
        }

        [TestMethod]
        public void EntityBase_WhenSettingIdWithValueAboveZero_ExpectIdValueToBeSet()
        {
            var sut = new MockEntity { Id = int.MaxValue };
            Assert.IsTrue(sut.Id == int.MaxValue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EntityBase_WhenSettingIdWithValueAfterIdHasAlreadyBeenSet_ExpectException()
        {
            var sut = new MockEntity { Id = int.MaxValue };
            sut.Id = int.MaxValue;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EntityBase_WhenSettingIdWithValueBelowZero_ExpectException()
        {
            var _ = new MockEntity { Id = -1 };
        }
    }
}