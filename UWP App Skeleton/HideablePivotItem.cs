using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using WinRTXamlToolkit.Interactivity;

namespace Sunlight
{
    /// <summary>
    /// Behavior which enables showing/hiding of a pivot item`
    /// </summary>
    sealed class HideablePivotItemBehavior : Behavior<PivotItem>
    {
        public static readonly DependencyProperty VisibleProperty = DependencyProperty.Register(
            "Visible",
            typeof(bool),
            typeof(HideablePivotItemBehavior),
            new PropertyMetadata(true, VisiblePropertyChanged));

        private Pivot _parentPivot;

        private PivotItem _pivotItem;

        private int _previousPivotItemIndex;

        private int _lastPivotItemsCount;

        public bool Visible
        {
            get
            {
                return (bool)this.GetValue(VisibleProperty);
            }

            set
            {
                this.SetValue(VisibleProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            this._pivotItem = AssociatedObject;
        }

        private static void VisiblePropertyChanged(DependencyObject dpObj, DependencyPropertyChangedEventArgs change)
        {
            if (change.NewValue.GetType() != typeof(bool) || dpObj.GetType() != typeof(HideablePivotItemBehavior))
            {
                return;
            }

            var behavior = (HideablePivotItemBehavior)dpObj;
            var pivotItem = behavior._pivotItem;

            // Parent pivot has to be assigned after the visual tree is initialized
            if (behavior._parentPivot == null)
            {
                behavior._parentPivot = (Pivot)behavior._pivotItem.Parent;
                // if the parent is null return
                if (behavior._parentPivot == null)
                {
                    return;
                }
            }

            var parentPivot = behavior._parentPivot;
            if (!(bool)change.NewValue)
            {
                if (parentPivot.Items.Contains(behavior._pivotItem))
                {
                    behavior._previousPivotItemIndex = parentPivot.Items.IndexOf(pivotItem);
                    parentPivot.Items.Remove(pivotItem);
                    behavior._lastPivotItemsCount = parentPivot.Items.Count;
                }
            }
            //else
            //{
            //    if (!parentPivot.Items.Contains(pivotItem))
            //    {
            //        if (behavior._lastPivotItemsCount >= parentPivot.Items.Count)
            //        {

            //            parentPivot.Items.Insert(behavior._previousPivotItemIndex, pivotItem);
            //        }
            //        else
            //        {
            //            parentPivot.Items.Add(pivotItem);
            //        }
            //    }
            //}
        }
    }
}
