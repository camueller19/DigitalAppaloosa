using System;
using System.Collections.Specialized;
using System.Windows.Controls.Ribbon;
using Microsoft.Practices.Prism.Regions;

namespace DigitalAppaloosa.Shared.Prism
{
    public class RibbonGroupRegionAdapter : RegionAdapterBase<RibbonGroup>
    {
        public RibbonGroupRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        private RibbonGroup ribbonRegionTarget;

        protected override void Adapt(IRegion region, RibbonGroup regionTarget)
        {
            ribbonRegionTarget = regionTarget;

            region.ActiveViews.CollectionChanged += new NotifyCollectionChangedEventHandler(OnActiveViewsChanged);

            foreach (RibbonButton ribbonGroupView in region.ActiveViews)
            {
                AddRibbonViewToRegion(ribbonGroupView);
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
            if (ribbonView is RibbonButton)
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
            //foreach (UIElement elementLoopVariable in e.OldItems)
            //{
            //    var element = elementLoopVariable;
            //    if (regionTarget.Items.Contains(element))
            //    {
            //        regionTarget.Items.Remove(element);
            //    }
            //}

            if (ribbonView is RibbonButton)
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