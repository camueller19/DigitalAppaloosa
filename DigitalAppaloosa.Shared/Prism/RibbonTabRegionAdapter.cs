using System;
using System.Collections.Specialized;
using Fluent;
using Prism.Regions;

namespace DigitalAppaloosa.Shared.Prism
{
    public class RibbonTabRegionAdapter : RegionAdapterBase<RibbonTabItem>
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        public RibbonTabRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        { }

        RibbonTabItem ribbonRegionTarget;

        protected override void Adapt(IRegion region, RibbonTabItem regionTarget)
        {
            ribbonRegionTarget = regionTarget;

            region.ActiveViews.CollectionChanged += OnActiveViewsChanged;

            foreach (RibbonGroupBox ribbonGroupView in region.ActiveViews)
            {
                AddRibbonViewToRegion(ribbonGroupView);
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
            var group = ribbonView as RibbonGroupBox;
            if (group != null)
            {
                ribbonRegionTarget.Groups.Add(group);
            }
            else
            {
                throw new ArgumentException("unsupported type " + ribbonView.GetType().Name);
            }
        }

        void RemoveRibbonViewFromRegion(object ribbonView)
        {
            var group = ribbonView as RibbonGroupBox;
            if (group != null)
            {
                ribbonRegionTarget.Groups.Remove(group);
            }
            else
            {
                throw new ArgumentException("unsupported type " + ribbonView.GetType().Name);
            }
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
            //return new SingleActiveRegion();
        }
    }
}