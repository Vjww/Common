namespace Common.Editor.Infrastructure
{
    public interface IFileResourceMapper
    {
        int Id { get; set; }

        void Map(int id);
    }
}