using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DigitalAppaloosa.Contracts.Interfaces;
using DigitalAppaloosa.Shared.Extensions;
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
                //Width = 20,
                //Height = 20,
                Fill = new SolidColorBrush(Colors.DarkSlateBlue),
                //HorizontalAlignment = HorizontalAlignment.Left,
                //VerticalAlignment = VerticalAlignment.Top
            };
            PlaceDraftingFigure(mouseEventData);
            var xPos = startPosition.X; // - (draftingFigure.Width / 2);
            var yPos = startPosition.Y; // - (draftingFigure.Height / 2);
            logger.Info("Circle StartPosition: " + xPos.ToString() + ", " + yPos.ToString());
            Canvas.SetLeft(draftingFigure, xPos);
            Canvas.SetTop(draftingFigure, yPos);
        }

        public override void IsDrafting(IMouseButtonEventDataTransferObject mouseEventData)
        {
            if (draftingFigure != null)
            {
                var position = mouseEventData.GetPosition(positionReference);
                var distance = startPosition.DistanceTo(position);
                var mouseRouteY = position.Y - startPosition.Y;
                if (mouseRouteY < 0)
                {
                    mouseRouteY = Math.Abs(mouseRouteY);
                    Canvas.SetTop(draftingFigure, startPosition.Y - mouseRouteY);
                }

                var mouseRouteX = position.X - startPosition.X;
                if (mouseRouteX < 0)
                {
                    mouseRouteX = Math.Abs(mouseRouteX);
                    Canvas.SetLeft(draftingFigure, startPosition.X - mouseRouteX);
                }

                //var dimension = Math.Max(1, Math.Max(mouseRouteY, mouseRouteX));
                var dimension = Math.Max(1, distance);
                draftingFigure.Height = dimension;
                draftingFigure.Width = dimension;
            }
        }
    }
}