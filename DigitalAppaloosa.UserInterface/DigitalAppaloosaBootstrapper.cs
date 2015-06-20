using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using System.Windows;
using DigitalAppaloosa.Modules.Experimental;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;
using DigitalAppaloosa.Shared.Prism;
using Microsoft.Practices.Prism.Logging;
using DigitalAppaloosa.Shared.Logging;
using NLog;

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
            ModuleCatalog.AddModule(
                new ModuleInfo()
                {
                    ModuleName = experimentalModule.Name,
                    ModuleType = experimentalModule.AssemblyQualifiedName,
                });
        }        

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var regionAdapterMappings = Container.TryResolve<RegionAdapterMappings>();
            if (regionAdapterMappings != null)
            {
                regionAdapterMappings.RegisterMapping(typeof(Ribbon), Container.Resolve<RibbonRegionAdapter>());
            }
            logger.Debug("Test Log");
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

