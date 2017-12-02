using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FanoMvvm.Annotations;
using FanoMvvm.Events;

namespace FanoMvvm.Core
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected IEventAggregator EventAggregator { get; }

        private bool _isBusy;
        private string _busyText;

        public bool IsBusy
        {
            get => this._isBusy;
            set
            {
                if (value == this._isBusy) return;
                this._isBusy = value;
                this.OnPropertyChanged();
            }
        }

        public string BusyText
        {
            get => this._busyText;
            set
            {
                if (value == this._busyText) return;
                this._busyText = value;
                this.OnPropertyChanged();
            }
        }

        public BaseViewModel(IEventAggregator eventAggregator)
        {
            this.EventAggregator = eventAggregator;
        }
    }
}