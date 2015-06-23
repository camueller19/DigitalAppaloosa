using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace DigitalAppaloosa.Shared.Prism
{
    public class ModuleBase : IModule
    {
        protected UnityContainer container;
        protected RegionManager regionManager;

        public ModuleBase(UnityContainer container, RegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
            RegisterViews();
        }

        public virtual void RegisterViews()
        {
        }
    }
}
