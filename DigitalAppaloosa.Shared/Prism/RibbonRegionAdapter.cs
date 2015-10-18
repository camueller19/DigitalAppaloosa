using System;
using System.Collections.Specialized;
using System.Windows.Controls.Ribbon;
using Prism.Regions;

namespace DigitalAppaloosa.Shared.Prism
{
    public class RibbonRegionAdapter : RegionAdapterBase<Ribbon>
    {
        public RibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        { }

        private Ribbon ribbonRegionTarget;

        protected override void Adapt(IRegion region, Ribbon regionTarget)
        {
            ribbonRegionTarget = regionTarget;

            region.ActiveViews.CollectionChanged += new NotifyCollectionChangedEventHandler(OnActiveViewsChanged);

            foreach (RibbonTab ribbonTabView in region.ActiveViews)
            {
                AddRibbonViewToRegion(ribbonTabView);
            }
        }

        private void OnActiveViewsChanged(object sender, NotifyCollectionChangedEventArgs e)
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

        private void AddRibbonViewToRegion(object ribbonView)
        {
            if (ribbonView is RibbonTab)
            {
                ribbonRegionTarget.Items.Add(ribbonView);
            }
            else
            {
                throw new ArgumentException("unsupported type " + ribbonView.GetType().Name);
            }
        }

        private void RemoveRibbonViewFromRegion(object ribbonView)
        {
            if (ribbonView is RibbonTab)
            {
                ribbonRegionTarget.Items.Remove(ribbonView);
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