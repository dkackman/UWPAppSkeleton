using System.Diagnostics;

using Windows.UI.Xaml.Controls;

using GalaSoft.MvvmLight.Ioc;

using Sunlight.Service;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Sunlight.Controls
{
    public sealed partial class NavControl : UserControl
    {
        public NavControl()
        {
            this.InitializeComponent();

            // TODO - MAGIC
            // there is a chicken and egg problem between the instantiation of the nav service in ViewModelLocator
            // and the creation of our embedded navigation frame (this.MainFrame)
            // this is the first place where MainFrame is created so go get the nav service and tell it about our frame
            // Any attempt to navigate prior to this will fail
            var n = SimpleIoc.Default.GetInstance<INavigationService2>();
            if (n != null && n.Root == null)
            {
                n.Root = this.MainFrame;
            }
            else
            {
                Debug.Assert(false, "You changed something that is violating an assumption about how navigation is wired up");
            }
        }
    }
}
