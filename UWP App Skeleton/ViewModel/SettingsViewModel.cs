using System.Collections.Generic;

using Sunlight.Model;
using Sunlight.Service;

namespace Sunlight.ViewModel
{
    public sealed class SettingsViewModel : ViewModel
    {
        private readonly ISettings _settings;

        public SettingsViewModel(ISettings settings, INavigationService2 navigationService)
            : base(navigationService)
        {
            _settings = settings;
        }

        /// <summary>
        /// The app theme name
        /// </summary>
        public string Theme
        {
            get
            {
                return _settings.Theme;
            }
            set
            {
                _settings.Theme = value;
            }
        }

        /// <summary>
        /// This populates the Theme combo box. Don't change it unless Micsroft adds more theme or add your own subsytem
        /// </summary>
        public IEnumerable<string> ThemeList => new List<string>() { "Light", "Dark" };
    }
}
