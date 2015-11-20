using System.Collections.Generic;
using System.Windows;
using DigitalAppaloosa.Contracts.Interfaces;
using DigitalAppaloosa.Modules.Drafting.Strategies;
using DigitalAppaloosa.Shared.PubSubEvents;
using NLog;

namespace DigitalAppaloosa.Modules.Drafting.Handlers
{
    public class DraftingHandler : IMouseButtonEventHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //private IDraftingPaneViewModel draftingViewModel;
        //private FrameworkElement positionReference;
        private Dictionary<FigureOperation, IDraftingStrategy> draftingStrategies;

        public FigureOperation DrawFigure { get; set; }

        public DraftingHandler(IDraftingPaneViewModel draftingViewModel, FrameworkElement positionReference)
        {
            //this.draftingViewModel = draftingViewModel;
            //this.positionReference = positionReference;
            draftingStrategies = new Dictionary<FigureOperation, IDraftingStrategy>()
            {
                { FigureOperation.Rectangle, new DraftingRectangleStrategy(draftingViewModel, positionReference) },
                { FigureOperation.Circle, new DraftingCircleStrategy(draftingViewModel, positionReference) }
            };
        }

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