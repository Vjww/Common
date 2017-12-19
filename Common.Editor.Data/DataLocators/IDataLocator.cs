namespace Common.Editor.Data.DataLocators
{
    public interface IDataLocator
    {
        int Id { get; }

        void Map(int id);
    }
}