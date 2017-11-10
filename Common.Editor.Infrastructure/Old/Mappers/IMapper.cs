namespace Common.Editor.Infrastructure.Old.Mappers
{
    public interface IMapper<in TDataSource, in TEntity, in TLocator>
    {
        void ImportEntityFromDataSource(TDataSource dataSource, TEntity entity, TLocator locator);
        void ExportEntityToDataSource(TDataSource dataSource, TEntity entity, TLocator locator);
    }
}