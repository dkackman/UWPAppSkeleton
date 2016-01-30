using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;

using Sunlight.Service;

namespace Sunlight.ViewModel
{
    /// <summary>
    /// some handy ViewModel stuff
    /// </summary>
    public abstract class ViewModel : ViewModelBase
    {
        static ViewModel()
        {
            DispatcherHelper.Initialize();
        }

        private readonly INavigationService2 _navigationService;

        protected ViewModel(INavigationService2 navigationService)
        {
            _navigationService = navigationService;
        }

        public string ActivePage { get { return _navigationService.CurrentPageKey; } }

        protected void NavigateTo(string page)
        {
            NavigateTo(page, null);
        }

        protected void NavigateTo(string page, object state)
        {
            // make sure this happens on the ui thread it can be coming from a task continuation etc
            DispatcherHelper.CheckBeginInvokeOnUI(() => _navigationService.NavigateTo(page, state));
        }

        protected void RaisePropertyChangedOnUI(string propertyName)
        {
            // make sure our notification happens on the UI
            DispatcherHelper.CheckBeginInvokeOnUI(() => RaisePropertyChanged(propertyName));
        }

        protected void RaisePropertiesChanged(params string[] properties)
        {
            foreach (string p in properties)
            {
                RaisePropertyChangedOnUI(p);
            }
        }
    }
}
