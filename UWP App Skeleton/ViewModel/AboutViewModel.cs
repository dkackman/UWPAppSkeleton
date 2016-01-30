using System;
using System.Windows.Input;

using Windows.System;
using GalaSoft.MvvmLight.Command;

using SKELETON.Model;
using SKELETON.Service;

namespace SKELETON.ViewModel
{
    public sealed class AboutViewModel : ViewModel
    {
        private readonly IAbout _about;

        public AboutViewModel(IAbout about, INavigationService2 navigationService)
            : base(navigationService)
        {
            _about = about;

            // TODO - set this to null if you don't want the little "Rate Our App" widget
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            RateCommand = new RelayCommand(() => Launcher.LaunchUriAsync(new Uri($"ms-windows-store:REVIEW?ProductId={_about.ProductId}")));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            // This currently only works for Microsoft's apps so don't uncomment it
            //FeedbackCommand = new RelayCommand(() => Launcher.LaunchUriAsync(new Uri($"windows-feedback:?contextid=522")));
        }

        public IAbout Model => _about;

        public ICommand RateCommand { get; private set; }

        public ICommand FeedbackCommand { get; private set; }
    }
}

