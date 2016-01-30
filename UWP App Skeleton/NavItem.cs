using System.ComponentModel;

using GalaSoft.MvvmLight.Command;

namespace Sunlight
{
    /// <summary>
    /// Description of an item that will show up in the NavBar
    /// </summary>
    public sealed class NavItem : INotifyPropertyChanged
    {
        /// <summary>
        /// The longer description of the item
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The short (usually single character text) that represents the item's glyph
        /// This should be a unicode character code (like "\uE80F") in FontFamily="Segoe MDL2 Assets"
        /// http://modernicons.io/segoe-mdl2/cheatsheet/
        /// </summary>
        public string ButtonText { get; set; }

        /// <summary>
        /// The command to execute when the nav button is clicked.
        /// Is usally a navigate operation but can also be things like opening a web page or whatever makes sense
        /// </summary>
        public RelayCommand Command { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isSelected;
        /// <summary>
        /// Used to disable and render a button differently when it represents the curently active page
        /// Makes it visually obvious what item is active 
        /// </summary>
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

        /// <summary>
        /// Prevents extraneous navigation to the currently active page
        /// </summary>
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
