using Common.Editor.Infrastructure.DataSets;

namespace Common.Editor.Infrastructure.Repositories
{
    public class RepositoryImporter : IRepositoryImporter
    {
        private readonly IDataSetImporter _importer;

        public RepositoryImporter(IDataSetImporter importer)
        {
            _importer = importer;
        }

        public void Import(RepositoryBase repository)
        {
            foreach (var dataSet in repository)
            {
                _importer.Import(dataSet.Capacity);
            }
        }
    }
}