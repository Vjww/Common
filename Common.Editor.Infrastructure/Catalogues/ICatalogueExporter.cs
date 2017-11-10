﻿using System.Collections.Generic;

namespace Common.Editor.Infrastructure.Catalogues
{
    public interface ICatalogueExporter<in TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        void Export(IEnumerable<TCatalogueItem> catalogue, string filePath);
    }
}