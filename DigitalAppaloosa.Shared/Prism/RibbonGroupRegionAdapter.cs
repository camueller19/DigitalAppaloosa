using System;
using System.Collections.Specialized;
using Fluent;
using Prism.Regions;

namespace DigitalAppaloosa.Shared.Prism
{
    public class RibbonGroupRegionAdapter : RegionAdapterBase<RibbonGroupBox>
    {
        public RibbonGroupRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        RibbonGroupBox ribbonRegionTarget;

        protected override void Adapt(IRegion region, RibbonGroupBox regionTarget)
        {
            ribbonRegionTarget = regionTarget;

            region.ActiveViews.CollectionChanged += OnActiveViewsChanged;

            foreach (Button ribbonGroupView in region.ActiveViews)
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
            var button = ribbonView as Button;
            if (button != null)
            {
                ribbonRegionTarget.Items.Add(button);
            }
            else
            {
                throw new ArgumentException("unsupported type " + ribbonView.GetType().Name);
            }
        }

        void RemoveRibbonViewFromRegion(object ribbonView)
        {
            var button = ribbonView as Button;
            if (button != null)
            {
                ribbonRegionTarget.Items.Remove(button);
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