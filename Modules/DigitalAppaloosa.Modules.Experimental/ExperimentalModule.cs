using DigitalAppaloosa.Interfaces;
using DigitalAppaloosa.Modules.Experimental.ViewModels;
using DigitalAppaloosa.Modules.Experimental.Views;
using DigitalAppaloosa.Shared.Prism;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace DigitalAppaloosa.Modules.Experimental
{
    public class ExperimentalModule : ModuleBase
    {

        public ExperimentalModule(UnityContainer container, RegionManager regionManager)
            : base(container, regionManager)
        {

        }

        public override void RegisterViews()
        {
            //base.RegisterViews();
            var ribbonTabTestAView = new RibbonTabTestAView();
            var ribbonTabTestAVM = new RibbonTabTestAViewModel();
            ribbonTabTestAView.DataContext = ribbonTabTestAVM;
            regionManager.AddToRegion(RegionNames.RibbonRegion, ribbonTabTestAView);

            var testCanvasView = new TestCanvasView();
            var testCanvasVM = new TestCanvasViewModel();
            testCanvasView.DataContext = testCanvasVM;
            regionManager.AddToRegion(RegionNames.MainContentRegion, testCanvasView);

            var ribbonTabTestBView = new RibbonTabTestAView();
            var ribbonTabTestBVM = new RibbonTabTestAViewModel();
            ribbonTabTestAView.DataContext = ribbonTabTestBVM;
            ribbonTabTestBView.Header = "TestRibbonB";
            regionManager.AddToRegion(RegionNames.RibbonRegion, ribbonTabTestBView);
        }

        //public void Initialize()
        //{
        //    //throw new NotImplementedException();
        //}
    }
}
