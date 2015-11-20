using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DigitalAppaloosa.Contracts.Interfaces;
using NLog;

namespace DigitalAppaloosa.Modules.Drafting.Strategies
{
    public class DraftingCircleStrategy : DraftingStrategyBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DraftingCircleStrategy(IDraftingPaneViewModel draftingViewModel, FrameworkElement positionReference)
        : base(draftingViewModel, positionReference)
        {
        }

        public override void BeginDrafting(IMouseButtonEventDataTransferObject mouseEventData)
        {
            draftingFigure = new Ellipse()
            {
                Width = 20,
                Height = 20,
                Fill = new SolidColorBrush(Colors.DarkSlateBlue),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            PlaceDraftingFigure(mouseEventData);
            Canvas.SetLeft(draftingFigure, startPosition.X - (draftingFigure.Width / 2));
            Canvas.SetTop(draftingFigure, startPosition.Y - (draftingFigure.Height / 2));
        }

        public override void IsDrafting(IMouseButtonEventDataTransferObject mouseEventData)
        {
            if (draftingFigure != null)
            {
                var position = mouseEventData.GetPosition(positionReference);
                var mouseRouteY = position.Y - startPosition.Y;
                if (mouseRouteY < 0)
                {
                    mouseRouteY = Math.Abs(mouseRouteY);
                }

                var mouseRouteX = position.X - startPosition.X;
                if (mouseRouteX < 0)
                {
                    mouseRouteX = Math.Abs(mouseRouteX);
                }

                var dimension = Math.Max(mouseRouteY, mouseRouteX);
                draftingFigure.Height = dimension;
                draftingFigure.Width = dimension;
            }
        }
    }
}