using System.Collections.Generic;

namespace Common.Editor.Data.Catalogues
{
    public interface ICatalogueReader<in TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        string Read(IEnumerable<TCatalogueItem> catalogue, int id);
    }
}