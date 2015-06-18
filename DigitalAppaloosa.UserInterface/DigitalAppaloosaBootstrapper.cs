using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DigitalAppaloosa.Modules.Experimental;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;
using DigitalAppaloosa.Shared.Prism;

namespace DigitalAppaloosa.UserInterface
{
    public class DigitalAppaloosaBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            //Application.Current.RootVisual = (UIElement)this.Shell;
            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
        }

        protected override void ConfigureContainer()
        {
            //base.ConfigureContainer();
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
                regionAdapterMappings.RegisterMapping(typeof(Ribbon), this.Container.Resolve<RibbonRegionAdapter>());
            }

            return base.ConfigureRegionAdapterMappings();
        }
    }
}
