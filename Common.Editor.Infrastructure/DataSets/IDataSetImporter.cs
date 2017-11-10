namespace Common.Editor.Infrastructure.DataSets
{
    public interface IDataSetImporter
    {
        IDataSet Import(int itemCount);
    }
}