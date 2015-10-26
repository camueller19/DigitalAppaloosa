using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;

namespace DigitalAppaloosa.Shared.Prism
{
    public class ModuleBase : IModule
    {
        protected IUnityContainer container;
        protected IRegionManager regionManager;
        protected IEventAggregator eventAggregator;

        public ModuleBase(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.container = container;
            this.regionManager = regionManager;
            this.eventAggregator=eventAggregator;
        }

        public void Initialize()
        {
            //throw new NotImplementedException();
            RegisterEvents();
            RegisterViews();
        }

        public virtual void RegisterEvents()
        {

        }

        public virtual void RegisterViews()
        {
        }
    }
}