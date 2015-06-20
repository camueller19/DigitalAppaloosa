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

        public void Initialize()
        {
            //throw new NotImplementedException();
        }
    }
}
