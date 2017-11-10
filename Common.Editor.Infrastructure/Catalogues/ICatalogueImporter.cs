using System.Collections.Generic;

namespace Common.Editor.Infrastructure.Catalogues
{
    public interface ICatalogueImporter<out TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        IEnumerable<TCatalogueItem> Import(string filePath);
    }
}