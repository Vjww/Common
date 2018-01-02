using System.Collections.Generic;

namespace Common.Editor.Data.Catalogues
{
    public interface ICatalogueWriter<in TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        void Write(IEnumerable<TCatalogueItem> catalogue, int id, string value);
    }
}