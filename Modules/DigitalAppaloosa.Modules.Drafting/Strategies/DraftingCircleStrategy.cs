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

        private Polyline debugPolyline;

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

            debugPolyline = new Polyline() { Fill = new SolidColorBrush(Colors.OrangeRed) };
            debugPolyline.Points.Add(startPosition);
            draftingViewModel.Items.Add(debugPolyline);
        }

        public override void IsDrafting(IMouseButtonEventDataTransferObject mouseEventData)
        {
            if (draftingFigure != null)
            {
                var position = mouseEventData.GetPosition(positionReference);
                var distance = startPosition.DistanceTo(position);
                var offset = CalculateOffset(distance);

                double newPositionY = double.NaN;
                double debugPositionY = double.NaN;
                if (position.Y < startPosition.Y)
                {
                    //double
                    newPositionY = CalculatePosition(startPosition.Y, position.Y);
                    debugPositionY = newPositionY;
                }
                else
                {
                    newPositionY = startPosition.Y;
                    debugPositionY = position.Y;
                }
                newPositionY -= offset;
                Canvas.SetTop(draftingFigure, newPositionY);

                double newPositionX = double.NaN;
                double debugPositionX = double.NaN;
                if (position.X < startPosition.X)
                {
                    //double
                    newPositionX = CalculatePosition(startPosition.X, position.X);
                    debugPositionX = newPositionX;
                }
                else
                {
                    newPositionX = startPosition.X;
                    debugPositionX = position.X;
                }
                newPositionX -= offset;
                Canvas.SetLeft(draftingFigure, newPositionX);

                var dimension = Math.Max(1, distance);
                draftingFigure.Height = dimension;
                draftingFigure.Width = dimension;

                var debugPoint = new Point(debugPositionX, debugPositionY);
                debugPolyline.Points.Add(debugPoint);
                logger.Debug($"Move to Position: {newPositionX}|{newPositionY}, offset: {offset}, distance: {distance}");
            }
        }

        private double CalculatePosition(double startValue, double currentValue)
        {
            //var yDistance = startPosition.Y - position.Y;
            var newPosition = startValue - (startValue - currentValue); // /2
            return newPosition;
        }

        private double CalculateOffset(double d)
        {
            var sqrt2 = Math.Sqrt(2);
            var a = d / sqrt2;
            var x = (a / sqrt2) - (a / 2);
            return x; 

            //return d - ((2 * d) / Math.Sqrt(2));
        }
    }
}

//var dimension = Math.Max(1, Math.Max(mouseRouteY, mouseRouteX));

//private Point latestPosition;
//latestPosition = startPosition;
//var mouseRouteY = position.Y - latestPosition.Y;

//if (mouseRouteY < 0)
//{
//    mouseRouteY = Math.Abs(mouseRouteY);
//    newPositionY = startPosition.Y - mouseRouteY;
//    Canvas.SetTop(draftingFigure, newPositionY);
//    latestPosition.Y = newPositionY;

//}

//var mouseRouteX = position.X - latestPosition.X;

//if (mouseRouteX < 0)
//{
//    mouseRouteX = Math.Abs(mouseRouteX);
//    newPositionX = startPosition.X - mouseRouteX;
//    Canvas.SetLeft(draftingFigure, newPositionX);
//    latestPosition.X = newPositionX;
//}