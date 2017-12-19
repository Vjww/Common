using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Editor.Data.Tests.Old.Old.Datasets
{
    [TestClass]
    public class Dataset
    {
        [TestMethod]
        public void Dataset_WhenConstructingWithPopulatedList_ExpectDatasetToBePopulated()
        {
            var list = new MockEntityList();

            var sut = new Dataset<MockEntity>(list);

            Assert.IsTrue(sut.Get().Count() == list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Dataset_WhenConstructingWithNullListParameter_ExpectException()
        {
            var _ = new Dataset<MockEntity>(null);
        }

        [TestMethod]
        public void Dataset_WhenGettingEntityById_ExpectEntityOfId()
        {
            const int id = 2;
            var dataset = new Dataset<MockEntity>(new MockEntityList());

            var sut = dataset.GetById(id);

            Assert.IsTrue(sut.Id == id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Dataset_WhenGettingEntityByIdWithValueBelowZero_ExpectException()
        {
            const int id = -1;
            var dataset = new Dataset<MockEntity>(new MockEntityList());

            var _ = dataset.GetById(id);
        }

        [TestMethod]
        public void Dataset_WhenGettingEntityList_ExpectEntityList()
        {
            var list = new MockEntityList();
            var dataset = new Dataset<MockEntity>(list);

            var sut = dataset.Get();

            Assert.IsTrue(sut.SequenceEqual(list));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Dataset_WhenGettingEntityListWithNullPredicate_ExpectException()
        {
            var list = new MockEntityList();
            var dataset = new Dataset<MockEntity>(list);

            var _ = dataset.Get(null);
        }

        [TestMethod]
        public void Dataset_WhenGettingEntityListWithPredicate_ExpectFilteredEntityList()
        {
            const int id = 1;
            var list = new MockEntityList();
            var dataset = new Dataset<MockEntity>(list);

            var sut = dataset.Get(x => x.Id == id);

            Assert.IsTrue(sut.Single().Id == id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Dataset_WhenSettingEntityByIdWithNullEntity_ExpectException()
        {
            var dataset = new Dataset<MockEntity>(new MockEntityList());

            dataset.SetById(null);
        }

        [TestMethod]
        public void Dataset_WhenSettingEntityById_ExpectAlteredEntityList()
        {
            const int id = 1;
            const int value = int.MaxValue;
            var list = new MockEntityList();
            var dataset = new Dataset<MockEntity>(list);

            var entity = list.Single(x => x.Id == id);
            entity.Value = value;
            dataset.SetById(entity);

            var sut = dataset.Get();

            Assert.IsTrue(sut.Single(x => x.Id == id).Value == value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Dataset_WhenSettingEntityListWithNullEntityList_ExpectException()
        {
            var dataset = new Dataset<MockEntity>(new MockEntityList());

            dataset.Set(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Dataset_WhenSettingEntityListWithDifferingItemCount_ExpectException()
        {
            const int id = 1;
            const int value = int.MaxValue;
            var list = new MockEntityList();
            var dataset = new Dataset<MockEntity>(list);

            var newList = new MockEntityList
            {
                new MockEntity() { Id = id, Value = value }
            };
            dataset.Set(newList);
        }

        [TestMethod]
        public void Dataset_WhenSettingEntityList_ExpectAlteredEntityList()
        {
            const int id = 1;
            const int value = int.MaxValue;
            var list = new MockEntityList();
            var dataset = new Dataset<MockEntity>(list);

            // ReSharper disable once CollectionNeverUpdated.Local
            var newList = new MockEntityList();
            newList.Single(x => x.Id == id).Value = value;
            dataset.Set(newList);

            var sut = dataset.Get();

            Assert.IsTrue(sut.Single(x => x.Id == id).Value == value);
        }
    }
}