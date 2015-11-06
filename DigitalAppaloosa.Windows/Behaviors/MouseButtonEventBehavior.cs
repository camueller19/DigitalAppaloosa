using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using DigitalAppaloosa.Contracts.Interfaces;
using NLog;

namespace DigitalAppaloosa.Windows.Behaviors
{
    public class MouseButtonEventBehavior : Behavior<ItemsControl>
    {
        public static readonly DependencyProperty MouseButtonEventHandlersProperty = DependencyProperty.Register(
                nameof(MouseButtonEventHandlers),
                typeof(IEnumerable<IMouseButtonEventHandler>),
                typeof(MouseButtonEventBehavior),
                new PropertyMetadata(null));

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<IMouseButtonEventHandler> MouseButtonEventHandlers
        {
            get { return (IEnumerable<IMouseButtonEventHandler>)GetValue(MouseButtonEventHandlersProperty); }
            set { SetValue(MouseButtonEventHandlersProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            var itemsControl = AssociatedObject;
            itemsControl.PreviewMouseLeftButtonDown += ItemsControlPreviewMouseLeftButtonDown;
            itemsControl.PreviewMouseLeftButtonUp += ItemsControlPreviewMouseLeftButtonUp;
            itemsControl.PreviewMouseMove += ItemsControlPreviewMouseMove;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            var itemsControl = AssociatedObject;
            itemsControl.PreviewMouseLeftButtonDown -= ItemsControlPreviewMouseLeftButtonDown;
            itemsControl.PreviewMouseLeftButtonUp -= ItemsControlPreviewMouseLeftButtonUp;
            itemsControl.PreviewMouseMove -= ItemsControlPreviewMouseMove;
        }

        private void ItemsControlPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            logger.Info("handled in DraftingBehavior ");
            if (MouseButtonEventHandlers != null)
            {
                var mbedto = new MouseButtonEventDataTransferObject(e);
                foreach (var handler in MouseButtonEventHandlers)
                {
                    //e.GetPosition()
                    handler.HandlePreviewMouseLeftButtonDownEvent(mbedto);
                }
            }
        }

        private void ItemsControlPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            logger.Info("handled in DraftingBehavior ");
            if (MouseButtonEventHandlers != null)
            {
                var mbedto = new MouseButtonEventDataTransferObject(e);
                foreach (var handler in MouseButtonEventHandlers)
                {
                    handler.HandlePreviewMouseLeftButtonUpEvent(mbedto);
                }
            }
        }

        private void ItemsControlPreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
            logger.Info("handled in DraftingBehavior ");
            if (MouseButtonEventHandlers != null)
            {
                var mbedto = new MouseButtonEventDataTransferObject(e);
                foreach (var handler in MouseButtonEventHandlers)
                {
                    handler.HandlePreviewMouseMove(mbedto);
                }
            }
        }
    }

    public class MouseButtonEventDataTransferObject : IMouseButtonEventDataTransferObject
    {
        public MouseButtonEventDataTransferObject(MouseEventArgs eventArgs)
        {
            GetPosition = eventArgs.GetPosition;
        }

        public Func<IInputElement, Point> GetPosition
        {
            get;
            private set;
        }
    }
}