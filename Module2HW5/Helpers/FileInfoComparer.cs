using System;
using System.Collections.Generic;
using System.IO;

namespace Module2HW5.Helpers
{
    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return DateTime.Compare(x.LastWriteTime, y.LastWriteTime);
        }
    }
}
