using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;

namespace DigitalAppaloosa.Shared.Prism
{
    public class ModuleBase : IModule
    {
        private UnityContainer container;
        private RegionManager regionManager;

        public ModuleBase(UnityContainer container, RegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}
