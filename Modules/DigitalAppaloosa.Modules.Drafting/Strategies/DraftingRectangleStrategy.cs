using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DigitalAppaloosa.Contracts.Interfaces;

namespace DigitalAppaloosa.Modules.Drafting.Strategies
{
    public class DraftingRectangleStrategy : DraftingStrategyBase
    {
        public DraftingRectangleStrategy(IDraftingPaneViewModel draftingViewModel, FrameworkElement positionReference)
        : base(draftingViewModel, positionReference)
        {
        }

        public override void BeginDrafting(IMouseButtonEventDataTransferObject mouseEventData)
        {
            //logger.Info(nameof(DraftingHandler));
            draftingFigure = new Rectangle()
            {
                Fill = new SolidColorBrush(Colors.Green),
                //Height = 1,
                //Width = 1
                //Margin = new Thickness(50, 200, 10, 10)
            };
            PlaceDraftingFigure(mouseEventData);
            Canvas.SetLeft(draftingFigure, startPosition.X);
            Canvas.SetTop(draftingFigure, startPosition.Y);
        }

        public override void IsDrafting(IMouseButtonEventDataTransferObject mouseEventData)
        {
            //logger.Info(nameof(DraftingHandler));
            if (draftingFigure != null)
            {
                var position = mouseEventData.GetPosition(positionReference);
                //var position = mouseEventData.GetPosition(null);
                var mouseRouteY = position.Y - startPosition.Y;
                double newFigureHeight;
                if (mouseRouteY > 0)
                {
                    newFigureHeight = mouseRouteY;
                }
                else
                {
                    newFigureHeight = Math.Abs(mouseRouteY);
                    Canvas.SetTop(draftingFigure, position.Y);
                }

                var mouseRouteX = position.X - startPosition.X;
                double newFigureWidth;
                if (mouseRouteX > 0)
                {
                    newFigureWidth = mouseRouteX;
                }
                else
                {
                    newFigureWidth = Math.Abs(mouseRouteX);
                    Canvas.SetLeft(draftingFigure, position.X);
                }

                draftingFigure.Height = Math.Max(1, newFigureHeight);
                draftingFigure.Width = Math.Max(1, newFigureWidth);
            }
        }
    }
}