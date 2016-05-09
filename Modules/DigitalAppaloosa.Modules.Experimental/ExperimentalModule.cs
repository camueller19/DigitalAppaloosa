using DigitalAppaloosa.Contracts;
using DigitalAppaloosa.Modules.Experimental.ViewModels;
using DigitalAppaloosa.Modules.Experimental.Views;
using DigitalAppaloosa.Shared.Prism;
using Fluent;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Regions;

namespace DigitalAppaloosa.Modules.Experimental
{
    public class ExperimentalModule : ModuleBase
    {
        public ExperimentalModule(UnityContainer container, RegionManager regionManager, EventAggregator eventAggregator)
            : base(container, regionManager, eventAggregator)
        {
        }

        public override void RegisterViews()
        {
            //base.RegisterViews();
            var ribbonTabTestAView = new RibbonTabTestAView();
            var ribbonTabTestAVM = new RibbonTabTestAViewModel();
            ribbonTabTestAView.DataContext = ribbonTabTestAVM;
            regionManager.AddToRegion(RegionNames.RibbonRegion, ribbonTabTestAView);

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

            //TODO
            //var ribbonGroupTestBView = new RibbonGroupTestBView();
            //var newRibbonGroupRegionManager = newRibbonRegionManager.AddToRegion(RegionNames.RibbonTabRegion, ribbonGroupTestBView);
            //var ribbonButtonD = new Button { Command = ExperimentalStaticCommands.ButtonDCommand, Header = "Button D" };
            //newRibbonGroupRegionManager.AddToRegion(RegionNames.RibbonGroupRegion, ribbonButtonD);
        }
    }
}