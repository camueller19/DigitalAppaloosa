using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using DigitalAppaloosa.Contracts.Interfaces;
using NLog;

namespace DigitalAppaloosa.Modules.Drafting.Strategies
{
    public class DraftingLineStrategy : DraftingStrategyBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DraftingLineStrategy(IDraftingPaneViewModel draftingViewModel, FrameworkElement positionReference)
        : base(draftingViewModel, positionReference)
        {
        }

        public override void BeginDrafting(IMouseButtonEventDataTransferObject mouseEventData)
        {
            //Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            //StrokeThickness = 2;
            draftingFigure = new Line()
            {
                Fill = new SolidColorBrush(Colors.DarkBlue)
            };
            PlaceDraftingFigure(mouseEventData);

            logger.Info($"Circle StartPosition: {startPosition}");

            var tmpLine = draftingFigure as Line;
            tmpLine.X1 = startPosition.X;
            tmpLine.Y1 = startPosition.Y;
        }

        public override void IsDrafting(IMouseButtonEventDataTransferObject mouseEventData)
        {
            if (draftingFigure != null)
            {
                var position = mouseEventData.GetPosition(positionReference);
                var tmpLine = draftingFigure as Line;
                tmpLine.X2 = position.X;
                tmpLine.Y2 = position.Y;
            }
        }
    }
}