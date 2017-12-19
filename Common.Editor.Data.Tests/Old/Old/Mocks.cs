using System;
using System.Collections.Generic;
using System.IO;

namespace Common.Editor.Data.Tests.Old.Old
{
    public class MockStream : StreamService<MemoryStream>
    {
        public MockStream(MemoryStream stream) : base(stream)
        {
        }
    }

    public class MockDataConnection : IConnection
    {
    }

    public class MockDataSource : IDataSource<MockDataConnection>
    {
        public MockStream BinaryResource { get; set; }

        public MockDataSource()
        {
            BinaryResource = new MockStream(new MemoryStream());
            var bytes = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            BinaryResource.Write(0, bytes);
        }

        public void Load(MockDataConnection connection)
        {
            throw new NotImplementedException();
        }

        public void Save(MockDataConnection connection)
        {
            throw new NotImplementedException();
        }
    }

    public class MockEntity : EntityBase
    {
        public int Value { get; set; }
    }

    public class MockLocator : LocatorBase
    {
        private const int BaseOffset = 0;
        private const int LocalOffset = 4;
        private const int ValueOffset = 0;

        public int Value { get; set; }

        public MockLocator()
        {
            var stepOffset = LocalOffset * Id;

            Value = BaseOffset + stepOffset + ValueOffset;
        }
    }

    public class MockMapper : MapperBase<MockDataSource, MockDataConnection, MockEntity, MockLocator>
    {
        public override void ImportEntityFromDataSource(MockDataSource dataSource, MockEntity entity, MockLocator locator)
        {
            entity.Value = ReadIntegerFromMemoryStream(dataSource.BinaryResource, locator.Value);
        }

        public override void ExportEntityToDataSource(MockDataSource dataSource, MockEntity entity, MockLocator locator)
        {
            WriteIntegerToMemoryStream(dataSource.BinaryResource, locator.Value, entity.Value);
        }
    }

    public class MockEntityList : List<MockEntity>
    {
        public MockEntityList()
        {
            var entity0 = EntityFactory<MockEntity>.New(0);
            var entity1 = EntityFactory<MockEntity>.New(1);
            var entity2 = EntityFactory<MockEntity>.New(2);

            entity0.Value = 305419896; // 0x12345678
            entity1.Value = 878082202; // 0x3456789A
            entity2.Value = 1450744508; // 0x56789ABC

            Add(entity0);
            Add(entity1);
            Add(entity2);
        }
    }

    public class MockRepository : RepositoryBase<MockDataSource, MockDataConnection>
    {
        public int ItemCount { get; set; }
        public Dataset<MockEntity> Dataset { get; set; }

        public MockRepository()
        {
            ItemCount = int.MaxValue;
            Dataset = new Dataset<MockEntity>(new MockEntityList());
        }

        public override void Import(MockDataSource dataSource)
        {
            Dataset = ImportRepositoryFromDataSource<MockDataSource, MockEntity, MockLocator, MockMapper>(dataSource, ItemCount);
        }

        public override void Export(MockDataSource dataSource)
        {
            ExportRepositoryToDataSource<MockDataSource, MockEntity, MockLocator, MockMapper>(dataSource, Dataset, ItemCount);
        }
    }
}