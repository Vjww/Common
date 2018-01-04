namespace Common.Editor.Data.DataLocators
{
    public interface IDataLocator
    {
        int Id { get; }

        void Initialise(int id);
    }
}