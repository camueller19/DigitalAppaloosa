using DigitalAppaloosa.Contracts.Interfaces;
using NLog;

namespace DigitalAppaloosa.Windows.Handlers
{
    public class DragDropHandler : IMouseButtonEventHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void HandlePreviewMouseLeftButtonDownEvent(IMouseButtonEventDataTransferObject mouseEventData)
        {
            logger.Info(nameof(DragDropHandler));
        }

        public void HandlePreviewMouseLeftButtonUpEvent(IMouseButtonEventDataTransferObject mouseEventData)
        {
            logger.Info(nameof(DragDropHandler));
        }

        public void HandlePreviewMouseMove(IMouseButtonEventDataTransferObject mouseEventData)
        {
            logger.Info(nameof(DragDropHandler));
        }
    }
}