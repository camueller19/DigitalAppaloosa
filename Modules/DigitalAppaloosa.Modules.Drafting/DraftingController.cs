using DigitalAppaloosa.Modules.Drafting.Handlers;
using DigitalAppaloosa.Modules.Drafting.ViewModels;
using DigitalAppaloosa.Shared.PubSubEvents;
using NLog;

namespace DigitalAppaloosa.Modules.Drafting
{
    public class DraftingController
    {
        private static DraftingController instance;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private DraftingController()
        {
        }

        public static DraftingController Instance
        {
            get { return instance = instance ?? new DraftingController(); }
            set { instance = value; }
        }

        public DraftingHandler DraftingHandler { get; private set; }

        public HeadDraftingPaneViewModel HeadDraftingPaneViewModel { get; private set; }

        public static void FigureOperationEventTest(FigureOperation figureOperation)
        {
            logger.Info("FigureOperationEvent with Payload: " + figureOperation);
            Instance.DraftingHandler.DrawFigure = figureOperation;
        }

        internal void RegisterDraftingHandler(DraftingHandler draftingHandler)
        {
            DraftingHandler = draftingHandler;
        }

        public void RegisterViewModel(HeadDraftingPaneViewModel headDraftingPaneViewModel)
        {
            HeadDraftingPaneViewModel = headDraftingPaneViewModel;
        }
    }
}

//private IEventAggregator eventAggregator;
//public DraftingController(IEventAggregator eventAggregator, HeadDraftingPaneViewModel headDraftingPaneViewModel)
//{
//    this.eventAggregator = eventAggregator;
//    this.headDraftingPaneViewModel = headDraftingPaneViewModel;
//    eventAggregator.GetEvent<FigureOperationEvent>().Subscribe(FigureOperationChanged);
//}