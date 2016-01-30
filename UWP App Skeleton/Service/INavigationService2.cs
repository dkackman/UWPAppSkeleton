using System;

using Windows.UI.Xaml.Controls;

using GalaSoft.MvvmLight.Views;

namespace SKELETON.Service
{
    /// <summary>
    /// Some additoinal stuff to help with navigation
    /// </summary>
    public interface INavigationService2 : INavigationService
    {
        /// <summary>
        /// Eent raised when a page is successfully navigated to
        /// </summary>
        event EventHandler Navigated;

        /// <summary>
        /// The Root <see cref="Frame"/> that hosts pages. In this app's case this is not the app frame
        /// </summary>
        Frame Root { get; set; }
    }
}
