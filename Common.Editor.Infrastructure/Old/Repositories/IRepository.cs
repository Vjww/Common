using Common.Editor.Infrastructure.Old.DataSources;

namespace Common.Editor.Infrastructure.Old.Repositories
{
    public interface IRepository<in TDataSource, TConnection>
        where TDataSource : class, IDataSource<TConnection>
        where TConnection : class, IConnection
    {
        void Import(TDataSource dataSource);
        void Export(TDataSource dataSource);
    }
}