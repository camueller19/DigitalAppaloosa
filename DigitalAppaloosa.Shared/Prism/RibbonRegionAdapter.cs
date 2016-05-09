using System;
using System.Collections.Specialized;
using Fluent;
using Prism.Regions;

namespace DigitalAppaloosa.Shared.Prism
{
    public class RibbonRegionAdapter : RegionAdapterBase<Ribbon>
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        public RibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        { }

        Ribbon ribbonRegionTarget;

        protected override void Adapt(IRegion region, Ribbon regionTarget)
        {
            ribbonRegionTarget = regionTarget;

            region.ActiveViews.CollectionChanged += OnActiveViewsChanged;

            foreach (RibbonTabItem ribbonTabView in region.ActiveViews)
            {
                AddRibbonViewToRegion(ribbonTabView);
            }
        }

        void OnActiveViewsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (object ribbonView in e.NewItems)
                    {
                        AddRibbonViewToRegion(ribbonView);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (object ribbonView in e.OldItems)
                    {
                        RemoveRibbonViewFromRegion(ribbonView);
                    }
                    break;
            }
        }

        void AddRibbonViewToRegion(object ribbonView)
        {
            var tab = ribbonView as RibbonTabItem;
            if (tab != null)
            {
                ribbonRegionTarget.Tabs.Add(tab);
                //logger.Info("View added: " + ribbonView);
            }
            else
            {
                throw new ArgumentException("unsupported type " + ribbonView.GetType().Name);
            }
        }

        void RemoveRibbonViewFromRegion(object ribbonView)
        {
            var tab = ribbonView as RibbonTabItem;
            if (tab != null)
            {
                ribbonRegionTarget.Tabs.Remove(tab);
            }
            else
            {
                throw new ArgumentException("unsupported type " + ribbonView.GetType().Name);
            }
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}