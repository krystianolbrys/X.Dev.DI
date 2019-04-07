using System;
using System.IO;
using System.Threading.Tasks;

namespace X.Logger
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public async Task Log(string value)
        {
            await File.AppendAllTextAsync(_filePath, $"{DateTime.UtcNow} - {value}\n\n");
        }
    }
}
