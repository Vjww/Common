using System;
using System.IO;
using System.Text;
using Common.Enums;

namespace Common.FileConnection
{
    public class TextFileConnectionBase : IDisposable
    {
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;
        protected StreamDirectionType? StreamDirection;
        protected string FilePath;

        protected TextFileConnectionBase(string filePath)
        {
            FilePath = filePath;

            Open(StreamDirectionType.Read);
        }

        public void Dispose()
        {
            Close();
        }

        protected void Open(StreamDirectionType streamDirection)
        {
            StreamDirection = streamDirection;

            // Open a stream for reading or writing
            FileStream fileStream = null;
            try
            {
                switch (StreamDirection)
                {
                    case StreamDirectionType.Read:
                        fileStream = File.Open(FilePath, FileMode.Open);
                        _streamReader = new StreamReader(fileStream, Encoding.Default, false);
                        break;
                    case StreamDirectionType.Write:
                        fileStream = File.Open(FilePath, FileMode.Open);
                        _streamWriter = new StreamWriter(fileStream, Encoding.Default);
                        break;
                    default:
                        throw new NotImplementedException("Case not implemented in switch statement.");
                }
            }
            catch (Exception)
            {
                // Close streams
                if (_streamReader != null)
                {
                    _streamReader.Close();
                    _streamReader = null;
                }

                if (_streamWriter != null)
                {
                    _streamWriter.Close();
                    _streamWriter = null;
                }

                // Close underlying stream if not already closed
                fileStream?.Close();

                throw;
            }
        }

        protected void Close()
        {
            // Close streams
            if (_streamReader != null)
            {
                _streamReader.Close();
                _streamReader = null;
            }

            if (_streamWriter != null)
            {
                _streamWriter.Close();
                _streamWriter = null;
            }

            // Clear stream direction
            StreamDirection = null;
        }

        protected virtual string ReadLine()
        {
            if (StreamDirection != StreamDirectionType.Read)
            {
                throw new Exception("Stream direction must be read.");
            }

            return _streamReader.ReadLine();
        }

        protected virtual void WriteLine(string line)
        {
            if (StreamDirection != StreamDirectionType.Write)
            {
                throw new Exception("Stream direction must be write.");
            }

            _streamWriter.WriteLine(line);
        }
    }
}
