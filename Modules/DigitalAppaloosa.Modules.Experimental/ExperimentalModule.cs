using System.Windows.Controls.Ribbon;
using DigitalAppaloosa.Interfaces;
using DigitalAppaloosa.Modules.Experimental.ViewModels;
using DigitalAppaloosa.Modules.Experimental.Views;
using DigitalAppaloosa.Shared.Prism;
using Prism.Regions;
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

            //var testCanvasView = new TestCanvasView();
            //var testCanvasVM = new TestCanvasViewModel();
            //testCanvasView.DataContext = testCanvasVM;
            //regionManager.AddToRegion(RegionNames.MainContentRegion, testCanvasView);

            //var ribbonTabTestBView = new RibbonTabTestAView();
            //var ribbonTabTestBVM = new RibbonTabTestAViewModel();
            //ribbonTabTestAView.DataContext = ribbonTabTestBVM;
            //ribbonTabTestBView.Header = "TestRibbonB";
            //regionManager.AddToRegion(RegionNames.RibbonRegion, ribbonTabTestBView);

            //regionManager.AddToRegion(RegionNames.RibbonRegion, ribbonTabTestBView, )

            var ribbonTestAView = new RibbonTestAView();
            var newRibbonRegionManager = regionManager.AddToRegion(RegionNames.RibbonRegion, ribbonTestAView);

            var ribbonGroupTestAView = new RibbonGroupTestAView();
            var ribbonGroupTestAVM = new RibbonGroupTestAViewModel();
            ribbonGroupTestAView.DataContext = ribbonGroupTestAVM;
            newRibbonRegionManager.AddToRegion(RegionNames.RibbonTabRegion, ribbonGroupTestAView);

            var ribbonGroupTestBView = new RibbonGroupTestBView();
            var newRibbonGroupRegionManager = newRibbonRegionManager.AddToRegion(RegionNames.RibbonTabRegion, ribbonGroupTestBView);

            var ribbonButtonD = new RibbonButton() { Command = ExperimentalStaticCommands.ButtonDCommand , Label = "Button D" };
            newRibbonGroupRegionManager.AddToRegion(RegionNames.RibbonGroupRegion, ribbonButtonD);
        }

        //public void Initialize()
        //{
        //    //throw new NotImplementedException();
        //}
    }
}