using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Editor.Data.Tests.Old.Old.Repositories
{
    [TestClass]
    public class RepositoryBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RepositoryBase_WhenExportingWithNullDataSource_ExpectException()
        {
            var sut = new MockRepository();
            sut.Export(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RepositoryBase_WhenExportingWithNullRepositoryService_ExpectException()
        {
            var sut = new MockRepository
            {
                Dataset = null
            };
            sut.Export(new MockDataSource());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RepositoryBase_WhenExportingWithItemCountEqualToZero_ExpectException()
        {
            var sut = new MockRepository
            {
                ItemCount = 0
            };

            sut.Export(new MockDataSource());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RepositoryBase_WhenExportingWithItemCountLessThanZero_ExpectException()
        {
            var dataSource = new StubIDataSource<StubIConnection>
            {
                LoadT0 = connection => { },
                SaveT0 = connection => { }
            };

            var repository =
                new StubIRepository<StubIDataSource<StubIConnection>, StubIConnection>
                {
                    ExportT0 = source => { },
                    ImportT0 = source => { }
                };

            repository.ExportT0(dataSource);

            //var sut = new MockRepository
            //{
            //    ItemCount = -1
            //};

            //sut.Export(new MockDataSource());
        }

        [TestMethod]
        public void RepositoryBase_WhenExportingWithAlteredData_ExpectDataSourceIsUpdated()
        {
            const int id = 1;
            var dataSource = new MockDataSource();
            var sut = new MockRepository { ItemCount = 3 };
            var record = sut.Dataset.Get(x => x.Id == id).Single();
            record.Value = int.MaxValue;
            sut.Dataset.SetById(record);

            sut.Export(dataSource);

            var current = BitConverter.ToInt32(dataSource.BinaryResource.Read(4, 4), 0);
            Assert.IsTrue(current == int.MaxValue);
        }

        //[TestMethod]
        //public void RepositoryBase_WhenExportingRepositoryToDataSource_ExpectPopulatedDataSource()
        //{
        //    // TODO: Create test and consider mocking test classes
        //}

        // TODO: Write further unit tests for export logic

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RepositoryBase_WhenImportingWithNullDataSource_ExpectException()
        {
            var sut = new MockRepository();
            sut.Import(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RepositoryBase_WhenImportingWithItemCountEqualToZero_ExpectException()
        {
            var sut = new MockRepository
            {
                ItemCount = 0
            };

            sut.Import(new MockDataSource());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RepositoryBase_WhenImportingWithItemCountLessThanZero_ExpectException()
        {
            var sut = new MockRepository
            {
                ItemCount = -1
            };

            sut.Import(new MockDataSource());
        }

        //[TestMethod]
        //public void RepositoryBase_WhenImportingRepositoryFromDataSource_ExpectPopulatedList()
        //{
        //    // TODO: Create test and consider mocking test classes
        //}

        // TODO: Write further unit tests for import logic

        [Ignore]
        [TestMethod]
        public void RepositoryBase_When_Expect()
        {
            // TODO: Fix up and complete unit tests
        }
    }
}