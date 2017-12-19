namespace Common.Editor.Infrastructure.DataLocators
{
    public interface IDataLocator
    {
        int Id { get; }

        void Map(int id);
    }
}