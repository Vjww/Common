using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Editor.Infrastructure.Tests.Old.Locators
{
    [TestClass]
    public class LocatorBase
    {
        [TestMethod]
        public void LocatorBase_WhenConstructing_ExpectIdValueToBeZero()
        {
            var sut = new MockLocator();
            Assert.IsTrue(sut.Id == 0);
        }

        [TestMethod]
        public void LocatorBase_WhenSettingIdWithValueOfZero_ExpectIdValueToBeSet()
        {
            var sut = new MockLocator { Id = 0 };
            Assert.IsTrue(sut.Id == 0);
        }

        [TestMethod]
        public void LocatorBase_WhenSettingIdWithValueAboveZero_ExpectIdValueToBeSet()
        {
            var sut = new MockLocator { Id = int.MaxValue };
            Assert.IsTrue(sut.Id == int.MaxValue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LocatorBase_WhenSettingIdWithValueAfterItHasAlreadyBeenSet_ExpectException()
        {
            var sut = new MockLocator { Id = int.MaxValue };
            sut.Id = int.MaxValue;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LocatorBase_WhenSettingIdWithValueBelowZero_ExpectException()
        {
            var _ = new MockLocator { Id = -1 };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LocatorBase_WhenInvokingInitialiseBeforeSettingIdWithValue_ExpectException()
        {
            var sut = new MockLocator();
            sut.Initialise();
        }

        [Ignore]
        [TestMethod]
        public void LocatorBase_When_Expect()
        {
            // TODO: Write unit tests for GetMultiplier0To31From0To21 and GetTeamAlphabeticalId
        }
    }
}