namespace Common.Editor.Infrastructure.Old.DataSources
{
    public interface IDataSource<in TConnection>
        where TConnection : class, IConnection
    {
        void Load(TConnection connection);
        void Save(TConnection connection);
    }
}