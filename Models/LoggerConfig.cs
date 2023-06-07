using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW5.Models
{
    public class LoggerConfig
    {
        public int LineSeparator { get; set; }
        public string TimeFormat { get; set; }
        public string DirectoryPath { get; set; }
        public string BackUpDirectotyPath { get; set; }
        public string FileExtension { get; set; }
        public int MaxLogCount { get; set; }
    }
}
