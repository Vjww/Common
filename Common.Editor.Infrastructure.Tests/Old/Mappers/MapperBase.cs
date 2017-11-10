using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Editor.Infrastructure.Tests.Old.Mappers
{
    [TestClass]
    public class MapperBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapperBase_WhenBinaryResourceInDataSourceIsNull_ExpectException()
        {
            var dataSource = new MockDataSource();
            //{
            //    BinaryResource = null
            //};
            var sut = new MockMapper();

            sut.ImportEntityFromDataSource(dataSource, new MockEntity(), new MockLocator());
        }

        [Ignore]
        [TestMethod]
        public void MapperBase_When_Expect()
        {
            // TODO: Write unit tests
        }
    }
}