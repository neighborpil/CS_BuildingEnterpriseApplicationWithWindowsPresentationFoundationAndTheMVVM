using System;
using System.Collections.Generic;
using System.Text;

namespace CH02_DesignPatterns.IoC
{
    public interface ILogger
    {
        void WriteLog(string message);
    }

    public sealed class Writer
    {
        private ILogger logger;

        /// <summary>
        /// Writer 클래스 초기화
        /// </summary>
        /// <param name="logger"></param>
        public Writer(ILogger logger)
        {
            this.logger = logger;
        }

        public void Write(string message)
        {
            this.logger.WriteLog(message);
        }
    }

    public class FileLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine($"FileLogger: {message}");
        }
    }


    class IoC_Logger
    {
        static void TestMain(string[] args)
        {
            var firstLogger = new FileLogger();

            var writer = new Writer(firstLogger);
            writer.Write("Log for the file system");
        }
    }
}
