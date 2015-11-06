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
            logger.Info(nameof(DraftingHandler));
            draftingFigure = new Rectangle()
            {
                Fill = new SolidColorBrush(Colors.Green),
                Height = 1,
                Width = 1,
                Margin = new Thickness(50, 200, 10, 10)
            };
            draftingViewModel.Items.Add(draftingFigure);
            startPosition = mouseEventData.GetPosition(positionReference);
            Canvas.SetLeft(draftingFigure, startPosition.X);
            Canvas.SetTop(draftingFigure, startPosition.Y);
        }

        public void HandlePreviewMouseLeftButtonUpEvent(IMouseButtonEventDataTransferObject mouseEventData)
        {
            logger.Info(nameof(DraftingHandler));
            draftingFigure = null;
        }

        public void HandlePreviewMouseMove(IMouseButtonEventDataTransferObject mouseEventData)
        {
            logger.Info(nameof(DraftingHandler));
            if (draftingFigure != null)
            {
                var position = mouseEventData.GetPosition(positionReference);
                var figureHeight = System.Math.Abs(position.Y - startPosition.Y);
                draftingFigure.Height = figureHeight;
                var figureWidth = System.Math.Abs(position.X - startPosition.X);
                draftingFigure.Width = figureWidth;
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