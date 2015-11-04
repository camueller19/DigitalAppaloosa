using DigitalAppaloosa.Contracts.Interfaces;
using NLog;

namespace DigitalAppaloosa.Modules.Drafting.Handlers
{
    public class DraftingHandler : IMouseButtonEventHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void HandlePreviewMouseLeftButtonDownEvent()
        {
            logger.Info(nameof(DraftingHandler));
        }

        public void HandlePreviewMouseLeftButtonUpEvent()
        {
            logger.Info(nameof(DraftingHandler));
        }

        public void HandlePreviewMouseMove()
        {
            logger.Info(nameof(DraftingHandler));
        }
    }
}