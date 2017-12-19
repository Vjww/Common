using Common.Editor.Infrastructure.DataConnections;

namespace Common.Editor.Infrastructure.DataEndpoints
{
    public interface IDataEndpoint<in TDataConnection>
        where TDataConnection : class, IDataConnection
    {
        void Import(TDataConnection dataConnection);
        void Export(TDataConnection dataConnection);
    }
}