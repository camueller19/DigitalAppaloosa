using System.Windows;
using System.Windows.Shapes;
using DigitalAppaloosa.Contracts.Interfaces;
using NLog;

namespace DigitalAppaloosa.Modules.Drafting.Strategies
{
    public interface IDraftingStrategy
    {
        void BeginDrafting(IMouseButtonEventDataTransferObject mouseEventData);

        void EndDrafting();

        void IsDrafting(IMouseButtonEventDataTransferObject mouseEventData);
    }

    public abstract class DraftingStrategyBase : IDraftingStrategy
    {
        protected Shape draftingFigure;
        protected IDraftingPaneViewModel draftingViewModel;
        protected FrameworkElement positionReference;
        protected Point startPosition;
        static readonly Logger logger = LogManager.GetCurrentClassLogger();

        protected DraftingStrategyBase(IDraftingPaneViewModel draftingViewModel, FrameworkElement positionReference)
        {
            this.draftingViewModel = draftingViewModel;
            this.positionReference = positionReference;
        }

        public abstract void BeginDrafting(IMouseButtonEventDataTransferObject mouseEventData);

        public virtual void EndDrafting()
        {
            draftingFigure = null;
        }

        public abstract void IsDrafting(IMouseButtonEventDataTransferObject mouseEventData);

        protected void PlaceDraftingFigure(IMouseButtonEventDataTransferObject mouseEventData)
        {
            draftingViewModel.Items.Add(draftingFigure);
            var startPositionLog = mouseEventData.GetPosition(null);
            startPosition = mouseEventData.GetPosition(positionReference);
            logger.Info($"StartPosition: {startPosition}|{startPositionLog}");
        }
    }
}