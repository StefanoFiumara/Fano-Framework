using System;
using System.IO;
using System.Linq;
using Fano.Logging;
using Fano.Logging.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fano.UnitTests.Logging
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
            
            Assert.IsTrue(File.Exists("test.log"));
            var fileContent = File.ReadAllLines("test.log");
            Assert.AreEqual(6, fileContent.Length); //3 lines header, 3 lines log entries
        }
    }
}