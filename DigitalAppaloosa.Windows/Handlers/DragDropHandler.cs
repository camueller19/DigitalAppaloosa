using DigitalAppaloosa.Contracts.Interfaces;
using NLog;

namespace DigitalAppaloosa.Windows.Handlers
{
    public class DragDropHandler : IMouseButtonEventHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void HandleMouseButtonEvent()
        {
            logger.Info(nameof(DragDropHandler));
        }
    }
}