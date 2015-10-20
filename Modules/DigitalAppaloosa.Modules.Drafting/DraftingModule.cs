using DigitalAppaloosa.Interfaces;
using DigitalAppaloosa.Modules.Drafting.ViewModels;
using DigitalAppaloosa.Modules.Drafting.Views;
using DigitalAppaloosa.Shared.Prism;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Regions;

namespace DigitalAppaloosa.Modules.Drafting
{
    public class DraftingModule : ModuleBase
    {
        private DraftingController draftingController;

        public DraftingModule(UnityContainer container, RegionManager regionManager, EventAggregator eventAggregator)
            : base(container, regionManager, eventAggregator)
        {
        }

        public override void RegisterViews()
        {
            var draftingRibView = new DraftingRibbonTabView();
            var draftingRibVM = new DraftingRibbonTabViewModel(eventAggregator);
            draftingRibView.DataContext = draftingRibVM;
            regionManager.AddToRegion(RegionNames.RibbonRegion, draftingRibView);

            //var testCanvasView = new TestCanvasView();
            var draftingView = new HeadDraftingPaneView();
            //var testCanvasVM = new TestCanvasViewModel();
            var draftingVM = new HeadDraftingPaneViewModel();
            //testCanvasView.DataContext = testCanvasVM;
            draftingView.DataContext = draftingVM;
            regionManager.AddToRegion(RegionNames.MainContentRegion, draftingView);
            //base.RegisterViews();
            draftingController = new DraftingController(eventAggregator, draftingVM);
        }
    }

}