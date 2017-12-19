using System.Collections.Generic;

namespace Common.Editor.Data.Catalogues
{
    public interface ICatalogueImporter<out TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        IEnumerable<TCatalogueItem> Import(string filePath);
    }
}