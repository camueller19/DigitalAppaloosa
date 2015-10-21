using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using NLog;

namespace DigitalAppaloosa.Windows.Behaviors
{
    public class DraftingBehavior : Behavior<ItemsControl>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override void OnAttached()
        {
            base.OnAttached();
            var itemsControl = this.AssociatedObject;
            itemsControl.PreviewMouseLeftButtonDown += ItemsControlPreviewMouseLeftButtonDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            var itemsControl = this.AssociatedObject;
            itemsControl.PreviewMouseLeftButtonDown -= ItemsControlPreviewMouseLeftButtonDown;
        }

        private void ItemsControlPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            logger.Info("handled in DraftingBehavior ");
        }
    }
}