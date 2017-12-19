using Common.Editor.Infrastructure.Entities;

namespace Common.Editor.Infrastructure.Repositories
{
    public interface IRepositoryExporter
    {
        void Export(IRepository<IEntity> repository);
    }
}