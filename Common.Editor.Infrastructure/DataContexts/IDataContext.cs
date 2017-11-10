using Common.Editor.Infrastructure.DataConnections;

namespace Common.Editor.Infrastructure.DataContexts
{
    public interface IDataContext<in TDataConnection>
        where TDataConnection : class, IDataConnection
    {
        void Import(TDataConnection connection);
        void Export(TDataConnection connection);
    }
}