using Common.Editor.Data.Entities;

namespace Common.Editor.Data.Repositories
{
    public interface IRepositoryExporter
    {
        void Export(IRepository<IEntity> repository);
    }
}