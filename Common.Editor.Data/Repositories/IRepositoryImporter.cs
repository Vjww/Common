using Common.Editor.Infrastructure.Entities;

namespace Common.Editor.Infrastructure.Repositories
{
    public interface IRepositoryImporter
    {
        void Import(IRepository<IEntity> repository);
    }
}