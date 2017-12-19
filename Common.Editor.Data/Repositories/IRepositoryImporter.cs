using Common.Editor.Data.Entities;

namespace Common.Editor.Data.Repositories
{
    public interface IRepositoryImporter
    {
        void Import(IRepository<IEntity> repository);
    }
}