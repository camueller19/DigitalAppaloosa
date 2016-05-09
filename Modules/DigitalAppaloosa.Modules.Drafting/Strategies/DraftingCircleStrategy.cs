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
        static Logger logger = LogManager.GetCurrentClassLogger();
        //Polyline debugPolyline;

        public DraftingCircleStrategy(IDraftingPaneViewModel draftingViewModel, FrameworkElement positionReference)
        : base(draftingViewModel, positionReference)
        {
        }

        public override void BeginDrafting(IMouseButtonEventDataTransferObject mouseEventData)
        {
            draftingFigure = new Ellipse
            {
                Fill = new SolidColorBrush(Colors.DarkSlateBlue)
            };
            PlaceDraftingFigure(mouseEventData);
            var xPos = startPosition.X;
            var yPos = startPosition.Y;
            logger.Info($"Circle StartPosition: {xPos}, {yPos}");
            Canvas.SetLeft(draftingFigure, xPos);
            Canvas.SetTop(draftingFigure, yPos);

            //debugPolyline = new Polyline() { Fill = new SolidColorBrush(Colors.OrangeRed) };
            //debugPolyline.Points.Add(startPosition);
            //draftingViewModel.Items.Add(debugPolyline);
        }

        public override void IsDrafting(IMouseButtonEventDataTransferObject mouseEventData)
        {
            if (draftingFigure != null)
            {
                var position = mouseEventData.GetPosition(positionReference);
                var radius = startPosition.DistanceTo(position);
                var circleCenter = new Point();
                circleCenter.X = startPosition.X - radius;
                circleCenter.Y = startPosition.Y - radius;

                Canvas.SetLeft(draftingFigure, circleCenter.X);
                Canvas.SetTop(draftingFigure, circleCenter.Y);

                var dimension = Math.Max(1, radius * 2);
                draftingFigure.Height = dimension;
                draftingFigure.Width = dimension;

                //debugPolyline.Points.Add(position);
                //logger.Debug($"circleCenter: {circleCenter} | position: {position}");
            }
        }
    }
}