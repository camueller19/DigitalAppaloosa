using DigitalAppaloosa.Contracts.Interfaces;
using NLog;

namespace DigitalAppaloosa.Modules.Drafting.Handlers
{
    public class DraftingHandler : IMouseButtonEventHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void HandleMouseButtonEvent()
        {
            logger.Info(nameof(DraftingHandler));
        }
    }
}