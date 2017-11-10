namespace Common.Editor.Infrastructure.Old.Locators
{
    public interface ILocator
    {
        int Id { get; set; }

        void Initialise();
    }
}