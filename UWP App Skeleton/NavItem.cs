using System.ComponentModel;

using GalaSoft.MvvmLight.Command;

namespace Sunlight
{
    public sealed class NavItem : INotifyPropertyChanged
    {
        public string Text { get; set; }

        public string ButtonText { get; set; }

        public RelayCommand Command { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    RaisePropertyChanged("IsSelected");
                    RaisePropertyChanged("IsEnabled");
                }
            }
        }

        public bool IsEnabled
        {
            get { return !_isSelected; }
        }

        private void RaisePropertyChanged(string property)
        {
            var e = PropertyChanged;
            if (e != null)
            {
                e(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
