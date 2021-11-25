using System;
using System.IO;
using Module2HW5.Services.Abstractions;
using Module2HW5.Helpers;

namespace Module2HW5.Services
{
    public class FileService : IFileService
    {
        private StreamWriter _fileStream;
        private bool _disposed = false;
        ~FileService()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool CreateDirectory(string pachDirectory, string nameDirectory)
        {
            try
            {
                var dir = new DirectoryInfo(pachDirectory);
                dir.CreateSubdirectory(nameDirectory);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public int? CurrentCountFilesInDirectory(string pachDirectory)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(pachDirectory);
                return directoryInfo.GetFiles().Length;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CreateFile(string path, string fileName)
        {
            try
            {
                _fileStream = new StreamWriter($"{path}/{fileName}");
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool WriteToFile(string text)
        {
            if (_fileStream == null)
            {
                return false;
            }

            try
            {
                _fileStream.WriteLine(text);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool MoveOldFiles(string sourcePath, string destinationPath, int maxFileCount)
        {
            try
            {
                var sourceDirectoryInfo = new DirectoryInfo(sourcePath);
                var allFilesInDirectory = sourceDirectoryInfo.GetFiles();
                Array.Sort(allFilesInDirectory, new FileInfoComparer());
                var count = allFilesInDirectory.Length;
                for (int i = 0; i < count - maxFileCount; i++)
                {
                    string fileName = allFilesInDirectory[i].Name;
                    File.Move($"{sourcePath}{fileName}", $"{destinationPath}{fileName}");
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _fileStream.Close();
                    _fileStream.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
