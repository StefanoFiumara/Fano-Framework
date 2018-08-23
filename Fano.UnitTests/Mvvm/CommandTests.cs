using Fano.Mvvm.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fano.UnitTests.Mvvm
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void RelayCommand_Execute()
        {
            bool executed = false;
            var cmd = new RelayCommand(() => executed = true);

            if (cmd.CanExecute(null))
            {
                cmd.Execute(null);
            }

            Assert.IsTrue(executed);
        }

        [TestMethod]
        public void RelayCommand_CanExecute_False()
        {
            bool executed = false;
            var cmd = new RelayCommand(() => executed = true, () => false);

            if (cmd.CanExecute(null))
            {
                cmd.Execute(null);
            }

            Assert.IsFalse(executed);
        }

        [TestMethod]
        public void RelayCommand_Execute_WithParams()
        {
            int value = 0;
            var setValueCommand = new RelayCommand<int>(arg => value = arg);

            if (setValueCommand.CanExecute(5))
            {
                setValueCommand.Execute(5);
            }

            Assert.IsTrue(value == 5);
        }

        [TestMethod]
        public void RelayCommand_CanExecute_False_WithParams()
        {
            int value = 0;
            var setValueCommand = new RelayCommand<int>(arg => value = arg, arg => false);

            if (setValueCommand.CanExecute(5))
            {
                setValueCommand.Execute(5);
            }

            Assert.IsTrue(value == 0);
        }
    }
}