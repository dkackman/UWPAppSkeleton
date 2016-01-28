using System;
using System.Windows.Input;

using Windows.System;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

using Sunlight.Model;
using Sunlight.Service;

namespace Sunlight.ViewModel
{
    public sealed class AboutViewModel : ViewModel
    {
        private readonly IAbout _about;

        public AboutViewModel(IAbout about, INavigationService2 navigationService)
            : base(navigationService)
        {
            _about = about;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            RateCommand = new RelayCommand(() => Launcher.LaunchUriAsync(new Uri($"ms-windows-store:REVIEW?ProductId={_about.ProductId}")));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

//windows-feedback:ADD?PFN=Microsoft.WindowsFeedback_cw5n1h2txyewy
            //FeedbackCommand = new RelayCommand(() => Launcher.LaunchUriAsync(
            //        new Uri($"ms-windows-store:REVIEW?PFN={_about.PackageName}")));
        }

        public IAbout Model => _about;

        public ICommand RateCommand { get; private set; }

        public ICommand FeedbackCommand { get; private set; }
    }
}

