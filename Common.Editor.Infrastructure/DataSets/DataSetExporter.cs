using Common.Editor.Infrastructure.Entities;

namespace Common.Editor.Infrastructure.DataSets
{
    public class DataSetExporter : IDataSetExporter
    {
        private readonly IEntityExporter _exporter;

        public DataSetExporter(IEntityExporter exporter)
        {
            _exporter = exporter;
        }

        public void Export(IDataSet dataSet)
        {
            var entities = dataSet.Get();
            foreach (var entity in entities)
            {
                _exporter.Export(entity);
            }
        }
    }
}