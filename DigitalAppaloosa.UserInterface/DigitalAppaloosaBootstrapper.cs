using System.Windows;
using DigitalAppaloosa.Modules.Drafting;
using DigitalAppaloosa.Modules.Experimental;
using DigitalAppaloosa.Shared.Logging;
using DigitalAppaloosa.Shared.Prism;
using Fluent;
using Microsoft.Practices.Unity;
using NLog;
using Prism.Logging;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace DigitalAppaloosa.UserInterface
{
    public class DigitalAppaloosaBootstrapper : UnityBootstrapper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            //Application.Current.RootVisual = (UIElement)this.Shell;
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var experimentalModule = typeof(ExperimentalModule);
            var draftingModule = typeof(DraftingModule);
            ModuleCatalog.AddModule(
                new ModuleInfo
                {
                    ModuleName = experimentalModule.Name,
                    ModuleType = experimentalModule.AssemblyQualifiedName
                });
            ModuleCatalog.AddModule(
                new ModuleInfo
                {
                    ModuleName = draftingModule.Name,
                    ModuleType= draftingModule.AssemblyQualifiedName
                });
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var regionAdapterMappings = Container.TryResolve<RegionAdapterMappings>();
            if (regionAdapterMappings != null)
            {
                regionAdapterMappings.RegisterMapping(typeof(Ribbon), Container.Resolve<RibbonRegionAdapter>());
                regionAdapterMappings.RegisterMapping(typeof(RibbonTabItem), Container.Resolve<RibbonTabRegionAdapter>());
            }

            //logger.Debug("Test Log");
            //logger.Info("Info Log");
            //logger.Trace("Trace Log");
            //logger.Warn("Warn Log");
            //logger.Error("Error Log");
            //logger.Fatal("Fatal Log");

            return base.ConfigureRegionAdapterMappings();
        }

        protected override ILoggerFacade CreateLogger()
        {
            //return base.CreateLogger();
            return new NLogLogger();
        }
    }
}

//protected override void ConfigureContainer()
//{
//    base.ConfigureContainer();
//}