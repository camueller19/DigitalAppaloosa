using System.Collections.Generic;
using System.Windows;
using DigitalAppaloosa.Contracts.Enums;
using DigitalAppaloosa.Contracts.Interfaces;
using DigitalAppaloosa.Modules.Drafting.Strategies;
using NLog;

namespace DigitalAppaloosa.Modules.Drafting.Handlers
{
    public class DraftingHandler : IMouseButtonEventHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private Dictionary<FigureOperation, IDraftingStrategy> draftingStrategies;

        public DraftingHandler(IDraftingPaneViewModel draftingViewModel, FrameworkElement positionReference)
        {
            draftingStrategies = new Dictionary<FigureOperation, IDraftingStrategy>()
            {
                [FigureOperation.Rectangle] = new DraftingRectangleStrategy(draftingViewModel, positionReference),
                [FigureOperation.Circle] = new DraftingCircleStrategy(draftingViewModel, positionReference),
                [FigureOperation.Line] = new DraftingLineStrategy(draftingViewModel, positionReference)
            };
        }

        public FigureOperation DrawFigure { get; set; }

        public void HandlePreviewMouseLeftButtonDownEvent(IMouseButtonEventDataTransferObject mouseEventData)
        {
            if (draftingStrategies.ContainsKey(DrawFigure))
            {
                draftingStrategies[DrawFigure].BeginDrafting(mouseEventData);
            }
        }

        public void HandlePreviewMouseLeftButtonUpEvent(IMouseButtonEventDataTransferObject mouseEventData)
        {
            if (draftingStrategies.ContainsKey(DrawFigure))
            {
                draftingStrategies[DrawFigure].EndDrafting();
            }
        }

        public void HandlePreviewMouseMove(IMouseButtonEventDataTransferObject mouseEventData)
        {
            if (draftingStrategies.ContainsKey(DrawFigure))
            {
                draftingStrategies[DrawFigure].IsDrafting(mouseEventData);
            }
        }
    }
}