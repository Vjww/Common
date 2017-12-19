namespace Common.Editor.Infrastructure.Entities
{
    public interface IEntityImporter
    {
        IEntity Import(int id);
    }
}