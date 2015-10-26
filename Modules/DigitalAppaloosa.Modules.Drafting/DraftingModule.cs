using DigitalAppaloosa.Interfaces;
using DigitalAppaloosa.Modules.Drafting.ViewModels;
using DigitalAppaloosa.Modules.Drafting.Views;
using DigitalAppaloosa.Shared.Prism;
using DigitalAppaloosa.Shared.PubSubEvents;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Regions;

namespace DigitalAppaloosa.Modules.Drafting
{
    public class DraftingModule : ModuleBase
    {
        public DraftingModule(UnityContainer container, RegionManager regionManager, EventAggregator eventAggregator)
            : base(container, regionManager, eventAggregator)
        {
        }

        public override void RegisterEvents()
        {
            eventAggregator.GetEvent<FigureOperationEvent>().Subscribe(DraftingController.FigureOperationEventTest);
        }

        public override void RegisterViews()
        {
            var draftingRibView = new DraftingRibbonTabView();
            var draftingRibVM = new DraftingRibbonTabViewModel(eventAggregator);
            draftingRibView.DataContext = draftingRibVM;
            regionManager.AddToRegion(RegionNames.RibbonRegion, draftingRibView);

            var draftingView = new HeadDraftingPaneView();
            var draftingVM = new HeadDraftingPaneViewModel();
            draftingView.DataContext = draftingVM;
            regionManager.AddToRegion(RegionNames.MainContentRegion, draftingView);
            DraftingController.Instance.RegisterViewModel(draftingVM);
        }
    }
}

//draftingController = new DraftingController(eventAggregator, draftingVM);