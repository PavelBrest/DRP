using DRP.Core.Services.Abstractions;
using System.IO;

namespace DRP.Infrastructure.Logger
{
    internal class FileLogger : IFileLogger
    {
        private const string FILE_PATH = @"C:\Users\pnov\source\repos\DRP\test.txt";
        private static readonly object _locker = new object();

        public void Log(string message)
        {
            lock(_locker)
            {
                using (var writer = File.AppendText(FILE_PATH))
                    writer.WriteLine(message);
            }
        }
    }
}
