using Common.Editor.Data.DataConnections;

namespace Common.Editor.Data.DataEndpoints
{
    public interface IDataEndpoint<in TDataConnection>
        where TDataConnection : class, IDataConnection
    {
        void Import(TDataConnection dataConnection);
        void Export(TDataConnection dataConnection);
    }
}