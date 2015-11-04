using DigitalAppaloosa.Contracts.Interfaces;
using NLog;

namespace DigitalAppaloosa.Windows.Handlers
{
    public class DragDropHandler : IMouseButtonEventHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void HandlePreviewMouseLeftButtonDownEvent()
        {
            logger.Info(nameof(DragDropHandler));
        }

        public void HandlePreviewMouseLeftButtonUpEvent()
        {
            logger.Info(nameof(DragDropHandler));
        }

        public void HandlePreviewMouseMove()
        {
            logger.Info(nameof(DragDropHandler));
        }
    }
}