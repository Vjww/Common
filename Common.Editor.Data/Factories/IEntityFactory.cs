using Common.Editor.Infrastructure.Entities;

namespace Common.Editor.Infrastructure.Factories
{
    public interface IEntityFactory<out TEntity>
        where TEntity : class, IEntity
    {
        TEntity Create(int id);
    }
}