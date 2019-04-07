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

        public Task Log(string value)
        {
            throw new NotImplementedException();
        }

        public async Task LogToFile(string value)
        {
            await File.AppendAllTextAsync(_filePath, $"{DateTime.UtcNow} - {value}\n\n");
        }
    }
}
