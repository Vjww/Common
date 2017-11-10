using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Editor.Infrastructure.Catalogues
{
    public class CatalogueBase<TCatalogueItem> : List<TCatalogueItem>, ICatalogue
        where TCatalogueItem : class, ICatalogueItem
    {
        private readonly ICatalogueExporter<TCatalogueItem> _catalogueExporter;
        private readonly ICatalogueImporter<TCatalogueItem> _catalogueImporter;
        private readonly ICatalogueReader _catalogueReader;
        private readonly ICatalogueWriter _catalogueWriter;

        public CatalogueBase(
            ICatalogueExporter<TCatalogueItem> catalogueExporter,
            ICatalogueImporter<TCatalogueItem> catalogueImporter,
            ICatalogueReader catalogueReader,
            ICatalogueWriter catalogueWriter)
        {
            _catalogueExporter = catalogueExporter ?? throw new ArgumentNullException(nameof(catalogueExporter));
            _catalogueImporter = catalogueImporter ?? throw new ArgumentNullException(nameof(catalogueImporter));
            _catalogueReader = catalogueReader ?? throw new ArgumentNullException(nameof(catalogueReader));
            _catalogueWriter = catalogueWriter ?? throw new ArgumentNullException(nameof(catalogueWriter));
        }

        public void Export(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            _catalogueExporter.Export(this.ToList(), filePath);
        }

        public void Import(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            Clear();
            AddRange(_catalogueImporter.Import(filePath));
        }

        public string Read(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            return _catalogueReader.Read(id);
        }

        public void Write(int id, string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            _catalogueWriter.Write(id, value);
        }
    }
}