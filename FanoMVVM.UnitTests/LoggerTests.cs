using System;
using System.IO;
using FanoMvvm.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FanoMVVM.UnitTests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void FileLogger_TestLogEntry()
        {
            ILogger log = new FileLogger("test.log");

            log.Info("Test Info");
            log.Warning("Test Info");
            log.Error("Test Error");

            var currentSessionLog = log.GetCurrentSessionLog();
            var fileContents = File.ReadAllText("test.log");
            Assert.AreEqual(currentSessionLog, fileContents);
        }

        [TestMethod]
        public void ConsoleLogger_TestLogEntry()
        {
            ILogger log = new ConsoleLogger();
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                log.Info("Test Info");
                log.Warning("Test Info");
                log.Error("Test Error");

                var currentSessionLog = log.GetCurrentSessionLog();
                var consoleOutput = writer.ToString();
                Assert.AreEqual(currentSessionLog, consoleOutput);
            }
            
        }
    }
}