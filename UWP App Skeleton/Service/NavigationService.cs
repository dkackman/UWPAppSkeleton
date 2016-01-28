using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;

using GalaSoft.MvvmLight.Views;

namespace Sunlight.Service
{
    sealed class NavigationService : INavigationService, INavigationService2
    {
        private readonly IDictionary<string, Type> _pages = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        private Frame _root;

        public event EventHandler Navigated;

        public NavigationService()
        {
            SystemNavigationManager.GetForCurrentView().BackRequested += (o, e) => e.Handled = TryGoBack();
        }

        public Frame Root
        {
            get { return _root; }
            set
            {
                Debug.Assert(_root == null, "Root should only be set once");
                Debug.Assert(value != null, "Root cannot be null");

                _root = value;
                _root.Navigated += _root_Navigated;
            }
        }

        private void _root_Navigated(object sender, NavigationEventArgs e)
        {
            if (Root.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }

        public void Configure(string key, Type type)
        {
            _pages.Add(key, type);
        }

        public string CurrentPageKey { get; private set; }

        private bool TryGoBack()
        {
            if (Root.CanGoBack)
            {
                Root.GoBack();
                var kvp = _pages.FirstOrDefault(pair => pair.Value == Root.CurrentSourcePageType);
                if (kvp.Key != null)
                {
                    CurrentPageKey = kvp.Key;
                }
                OnNavigated();
                return true;
            }

            return false;
        }

        public void GoBack()
        {
            TryGoBack();
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            if (Root.Navigate(_pages[pageKey], parameter))
            {
                CurrentPageKey = pageKey;
                OnNavigated();
            }
        }

        private void OnNavigated()
        {
            var e = Navigated;
            if (e != null)
            {
                e(this, EventArgs.Empty);
            }
        }
    }
}
