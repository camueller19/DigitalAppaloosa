using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DigitalAppaloosa.Contracts.Interfaces;
using NLog;

namespace DigitalAppaloosa.Modules.Drafting.Handlers
{
    public class DraftingHandler : IMouseButtonEventHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IDraftingPaneViewModel draftingViewModel;
        private Shape draftingFigure;
        private FrameworkElement positionReference;
        private Point startPosition;

        public DraftingHandler(IDraftingPaneViewModel draftingViewModel, FrameworkElement positionReference)
        {
            this.draftingViewModel = draftingViewModel;
            this.positionReference = positionReference;
        }

        public void HandlePreviewMouseLeftButtonDownEvent(IMouseButtonEventDataTransferObject mouseEventData)
        {
            //logger.Info(nameof(DraftingHandler));
            draftingFigure = new Rectangle()
            {
                Fill = new SolidColorBrush(Colors.Green),
                Height = 1,
                Width = 1
                //Margin = new Thickness(50, 200, 10, 10)
            };
            draftingViewModel.Items.Add(draftingFigure);
            var startPositionLog = mouseEventData.GetPosition(null);
            startPosition = mouseEventData.GetPosition(positionReference);
            logger.Info("StartPosition: " + startPosition.ToString() + "|" + startPositionLog.ToString());
            Canvas.SetLeft(draftingFigure, startPosition.X);
            Canvas.SetTop(draftingFigure, startPosition.Y);
        }

        public void HandlePreviewMouseLeftButtonUpEvent(IMouseButtonEventDataTransferObject mouseEventData)
        {
            //logger.Info(nameof(DraftingHandler));
            draftingFigure = null;
        }

        public void HandlePreviewMouseMove(IMouseButtonEventDataTransferObject mouseEventData)
        {
            //logger.Info(nameof(DraftingHandler));
            if (draftingFigure != null)
            {
                var position = mouseEventData.GetPosition(positionReference);
                //var position = mouseEventData.GetPosition(null);
                var mouseRouteY = position.Y - startPosition.Y;
                if (mouseRouteY > 0)
                {
                    draftingFigure.Height = mouseRouteY;
                }
                else
                {
                    var figureHeight = System.Math.Abs(mouseRouteY);
                    draftingFigure.Height = figureHeight;
                    Canvas.SetTop(draftingFigure, position.Y);
                }

                var mouseRouteX = position.X - startPosition.X;
                if (mouseRouteX > 0)
                {
                    draftingFigure.Width = mouseRouteX;
                }
                else
                {
                    var figureWidth = System.Math.Abs(mouseRouteX);
                    draftingFigure.Width = figureWidth;
                    Canvas.SetLeft(draftingFigure, position.X);
                }
            }
        }
    }
}

//internal void AddFigure(FigureOperation figureOperation)
//{
//    if (figureOperation == FigureOperation.Rectangle)
//    {
//        Canvas.SetLeft(newFigure, 10 * offset);
//        Canvas.SetTop(newFigure, 10 * offset);
//        offset++;
//        Items.Add(newFigure);
//    }
//}