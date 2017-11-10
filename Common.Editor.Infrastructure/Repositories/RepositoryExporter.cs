using Common.Editor.Infrastructure.DataSets;

namespace Common.Editor.Infrastructure.Repositories
{
    public class RepositoryExporter : IRepositoryExporter
    {
        private readonly IDataSetExporter _exporter;

        public RepositoryExporter(IDataSetExporter exporter)
        {
            _exporter = exporter;
        }

        public void Export(RepositoryBase repository)
        {
            foreach (var dataSet in repository)
            {
                _exporter.Export(dataSet);
            }
        }
    }
}