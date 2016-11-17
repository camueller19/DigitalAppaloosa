using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DigitalAppaloosa.Contracts.Interfaces;

namespace DigitalAppaloosa.Modules.Drafting.Handlers
{
    public class ShowPathHandler
    {
        private readonly IDraftingPaneViewModel draftingViewModel;

        public ShowPathHandler(IDraftingPaneViewModel draftingViewModel)
        {
            this.draftingViewModel = draftingViewModel;
        }

        public void Handle()
        {
            draftingViewModel.Items.Clear();
            var points = new List<Point> {
                new Point(450, 50),
                new Point(10, 25),
                new Point(216, 94),
                new Point(362, 169),
                new Point(445, 248),
                new Point(326, 357),
                new Point(184, 441) };

            foreach (var point in points)
            {
                var rect = new Rectangle
                {
                    Fill = new SolidColorBrush(Colors.Green),
                    Height = 3,
                    Width = 3
                };
                draftingViewModel.Items.Add(rect);
                Canvas.SetLeft(rect, point.X);
                Canvas.SetTop(rect, point.Y);
            }

            var pathFigure = new PathFigure();
            for (int i = 0; i < points.Count; i++)
            {
                if (i == 0)
                {
                    pathFigure.StartPoint = points[i];
                }
                else
                {
                    var lineSegment = new LineSegment
                    {
                        Point = points[i]
                    };
                    pathFigure.Segments.Add(lineSegment);
                }
            }
            var pathGeometry = new PathGeometry
            {
                FillRule = FillRule.Nonzero
            };
            pathGeometry.Figures.Add(pathFigure);

            var showPath = new Path
            {
                Stroke = new SolidColorBrush(Colors.OrangeRed),
                StrokeThickness = 2,
                Data = pathGeometry
            };

            draftingViewModel.Items.Add(showPath);

            for (int i = 0; i < points.Count - 1; i++)
            {
                var line = new Line
                {
                    Stroke = new SolidColorBrush(Colors.DarkGreen),
                    X1 = points[i].X,
                    Y1 = points[i].Y,
                    X2 = points[i + 1].X,
                    Y2 = points[i + 1].Y
                };
                draftingViewModel.Items.Add(line);
            }

            var polyline = new Polyline
            {
                Stroke = new SolidColorBrush(Colors.DarkSlateBlue),
                StrokeThickness = 2,
                FillRule = FillRule.Nonzero
            };
            foreach (var point in points)
            {
                polyline.Points.Add(point);
            }
            draftingViewModel.Items.Add(polyline);
        }
    }
}