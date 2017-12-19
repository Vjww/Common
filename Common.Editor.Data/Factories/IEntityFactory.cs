using Common.Editor.Data.Entities;

namespace Common.Editor.Data.Factories
{
    public interface IEntityFactory<out TEntity>
        where TEntity : class, IEntity
    {
        TEntity Create(int id);
    }
}