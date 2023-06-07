using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5.Services.Abstractions
{
    public interface IFileService : IDisposable
    {
        public bool CreateDirectory(string pachDirectory, string nameDirectory);
        public bool CreateFile(string path, string fileName);
        public int? CurrentCountFilesInDirectory(string pachDirectory);
        public bool WriteToFile(string text);
        public bool MoveOldFiles(string sourcePath, string destinationPath, int maxFileCount);
    }
}
