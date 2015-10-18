using DigitalAppaloosa.Interfaces;
using DigitalAppaloosa.Modules.Drafting.ViewModels;
using DigitalAppaloosa.Modules.Drafting.Views;
using DigitalAppaloosa.Shared.Prism;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace DigitalAppaloosa.Modules.Drafting
{
    public class DraftingModule : ModuleBase
    {
        public DraftingModule(UnityContainer container, RegionManager regionManager)
            : base(container, regionManager)
        {

        }

        public override void RegisterViews()
        {
            //var testCanvasView = new TestCanvasView();
            var draftingView = new HeadDraftingPaneView();
            //var testCanvasVM = new TestCanvasViewModel();
            var draftingVM = new HeadDraftingPaneViewModel();
            //testCanvasView.DataContext = testCanvasVM;
            draftingView.DataContext = draftingVM;
            regionManager.AddToRegion(RegionNames.MainContentRegion, draftingView);
            //base.RegisterViews();
        }

    }
}
