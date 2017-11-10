using System.Collections.Generic;
using Common.Editor.Infrastructure.Entities;

namespace Common.Editor.Infrastructure.DataSets
{
    public class DataSetImporter : IDataSetImporter
    {
        private readonly IEntityImporter _importer;

        public DataSetImporter(IEntityImporter importer)
        {
            _importer = importer;
        }

        public IDataSet Import(int itemCount)
        {
            var list = new List<IEntity>();
            for (var i = 0; i < itemCount; i++)
            {
                var entity = _importer.Import(i);
                list.Add(entity);
            }

            return new DataSetBase(list, itemCount);
        }
    }
}