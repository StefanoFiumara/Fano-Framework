using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fano.Events.Core;
using Fano.Mvvm.Properties;

namespace Fano.Mvvm.Core
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected IEventAggregator EventAggregator { get; }

        private bool _isBusy;
        private string _busyText;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (value == _isBusy) return;
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public string BusyText
        {
            get => _busyText;
            set
            {
                if (value == _busyText) return;
                _busyText = value;
                OnPropertyChanged();
            }
        }

        public BaseViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }
    }
}