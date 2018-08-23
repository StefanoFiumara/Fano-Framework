using Fano.Events.Core;
using Fano.Mvvm.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fano.UnitTests.Mvvm
{
    [TestClass]
    public class ViewModelTests
    {
        private BaseViewModel ViewModel { get; set; }

        [TestInitialize]
        public void Init()
        {
            this.ViewModel = new BaseViewModel(new EventAggregator());

        }

        [TestMethod]
        public void PropertyChanged()
        {
            bool hasPropertyChanged = false;
            void SetPropertyChanged()
            {
                hasPropertyChanged = true;
            }

            this.ViewModel.PropertyChanged += (sender, args) => SetPropertyChanged();

            this.ViewModel.IsBusy = true;

            Assert.IsTrue(hasPropertyChanged);
        }

        [TestMethod]
        public void PropertyUnchanged()
        {
            bool hasPropertyChanged = false;
            void SetPropertyChanged()
            {
                hasPropertyChanged = true;
            }

            this.ViewModel.PropertyChanged += (sender, args) => SetPropertyChanged();

            this.ViewModel.IsBusy = false;

            Assert.IsFalse(hasPropertyChanged);
        }

    }
}