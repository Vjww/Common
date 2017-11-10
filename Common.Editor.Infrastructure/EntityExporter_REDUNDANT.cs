//using System;
//using System.IO;
//using Common.Editor.Infrastructure.Old.DataSources;
//using Common.Editor.Infrastructure.Old.Locators;

//namespace Common.Editor.Infrastructure
//{
//    public abstract class EntityExporterBase<TEntity> : IEntityExporter
//        where TEntity : IEntity
//    {
//        private readonly IDataSource<IConnection> _dataSource;
//        private readonly TEntity _entity;
//        private readonly ILocator _locator;
//        private readonly object _mapper;

//        public EntityExporterBase(IDataSource<IConnection> dataSource, TEntity entity, ILocator locator)
//        {
//            _dataSource = dataSource;
//            _entity = entity;
//            _locator = locator;
//        }

//        public abstract void Export(IEntity entity);
//        //{
//        //    // TODO: Move to derived class
//        //    WriteStringToTextResource(_dataSource.EnglishLanguageResource, _locator.Name, _entity.Name.English);
//        //    WriteStringToTextResource(_dataSource.FrenchLanguageResource, _locator.Name, _entity.Name.French);
//        //    WriteStringToTextResource(_dataSource.GermanLanguageResource, _locator.Name, _entity.Name.German);
//        //    WriteIntegerToMemoryStream(_dataSource.GameExecutable, _locator.LastPosition, _entity.LastPosition);
//        //    WriteIntegerToMemoryStream(_dataSource.GameExecutable, _locator.LastPoints, _entity.LastPoints);
//        //    WriteIntegerToMemoryStream(_dataSource.GameExecutable, _locator.FirstGpTrack, _entity.FirstGpTrack);
//        //    WriteIntegerToMemoryStream(_dataSource.GameExecutable, _locator.FirstGpYear, _entity.FirstGpYear);
//        //    WriteIntegerToMemoryStream(_dataSource.GameExecutable, _locator.Wins, _entity.Wins);
//        //    WriteIntegerToMemoryStream(_dataSource.GameExecutable, _locator.YearlyBudget, _entity.YearlyBudget);
//        //    WriteIntegerToMemoryStream(_dataSource.GameExecutable, _locator.UnknownA, _entity.UnknownA);
//        //    WriteIntegerToMemoryStream(_dataSource.GameExecutable, _locator.CountryMapId, _entity.CountryMapId);
//        //    WriteIntegerToMemoryStream(_dataSource.GameExecutable, _locator.LocationPointerX, _entity.LocationPointerX);
//        //    WriteIntegerToMemoryStream(_dataSource.GameExecutable, _locator.LocationPointerY, _entity.LocationPointerY);
//        //    WriteIntegerToMemoryStream(_dataSource.GameExecutable, _locator.TyreSupplierId, _entity.TyreSupplierId);
//        //}

//        protected int ReadIntegerFromMemoryStream(IStreamReader<MemoryStream> reader, int offset)
//        {
//            if (reader == null) throw new ArgumentNullException(nameof(reader));

//            var bytes = reader.Read(offset, 4);
//            return BitConverter.ToInt32(bytes, 0);
//        }

//        protected string ReadStringFromTextResource(ITextResourceReader reader, int id)
//        {
//            if (reader == null) throw new ArgumentNullException(nameof(reader));
//            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

//            return reader.Read(id);
//        }

//        protected void WriteIntegerToMemoryStream(IStreamWriter<MemoryStream> writer, int offset, int value)
//        {
//            if (writer == null) throw new ArgumentNullException(nameof(writer));

//            var bytes = BitConverter.GetBytes(value);
//            writer.Write(offset, bytes);
//        }

//        protected void WriteStringToTextResource(ITextResourceWriter writer, int id, string value)
//        {
//            if (writer == null) throw new ArgumentNullException(nameof(writer));
//            if (value == null) throw new ArgumentNullException(nameof(value));
//            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

//            writer.Write(id, value);
//        }
//    }

//    public interface ITextResourceReader
//    {
//        string Read(int id);
//    }

//    public interface ITextResourceWriter
//    {
//        void Write(int id, string value);
//    }
//}