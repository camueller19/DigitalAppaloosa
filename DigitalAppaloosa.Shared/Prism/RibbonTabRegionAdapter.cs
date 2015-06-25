using Microsoft.Practices.Prism.Regions;
using System.Collections.Specialized;
using System.Windows.Controls.Ribbon;
using System;

namespace DigitalAppaloosa.Shared.Prism
{
    //RibbonTabRegionAdapter
    public class RibbonTabRegionAdapter : RegionAdapterBase<RibbonTab>
    {
        public RibbonTabRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        { }

        private RibbonTab ribbonRegionTarget;

        protected override void Adapt(IRegion region, RibbonTab regionTarget)
        {
            ribbonRegionTarget = regionTarget;

            region.ActiveViews.CollectionChanged += new NotifyCollectionChangedEventHandler(OnActiveViewsChanged);

            foreach (RibbonGroup ribbonGroupView in region.ActiveViews)
            {
                regionTarget.Items.Add(ribbonGroupView);
            }
        }

        private void OnActiveViewsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {

                case NotifyCollectionChangedAction.Add:
                    // für jedes neue Item
                    foreach (object ribbonView in e.NewItems)
                    {
                        AddRibbonViewToRegion(ribbonView);

                    }
                    break;
                // entfernen von Ribboncontrols 
                case NotifyCollectionChangedAction.Remove:
                    {
                        //e.OldItems?
                        if (e.NewItems != null)
                            foreach (object ribbonView in e.NewItems)
                            {
                                RemoveRibbonViewToRegion(ribbonView);

                            }
                        break;
                    }
            }
        }



        private void AddRibbonViewToRegion(object ribbonView)
        {
            //foreach (FrameworkElement element in e.NewItems)
            //{
            //    regionTarget.Items.Add(element);
            //}

            //// wenn es ein Ribbon ist - SPEZIALFALL
            //if (ribbonView is Ribbon)
            //{
            //    Ribbon rb = ribbonView as Ribbon;
            //    for (int i = rb.Items.Count - 1; i >= 0; i--)
            //    {
            //        if (rb.Items[i] is RibbonTab)
            //        {
            //            // Umhängen aller Ribbontab in das Ribbon des Adapters
            //            RibbonTab rt = (rb.Items[i] as RibbonTab);
            //            rb.Items.Remove(rt);
            //            ribbonRegionTarget.Items.Add(rt);
            //        }
            //    }
            //}
            //else
            //    // wenn es ein Ribbontab ist
            //    if (ribbonView is RibbonTab)
            //{
            //    ribbonRegionTarget.Items.Add(ribbonView);
            //}
            //else
            //        // wenn es ein Ribbonbutton ist
            //        if (ribbonView is RibbonButton)
            //{
            //    bool alreadyInserted = false;

            //    foreach (object ot in ribbonRegionTarget.Items)
            //    {
            //        // in das erste Ribbontab
            //        if (ot is RibbonTab && !alreadyInserted)
            //        {
            //            foreach (object og in ((RibbonTab)ot).Items)
            //            {
            //                // in die erste Ribbon group
            //                if (og is RibbonGroup)
            //                {
            //                    ((RibbonGroup)og).Items.Add(ribbonView);
            //                    alreadyInserted = true;
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    throw new ArgumentException("unsupported type " + ribbonView.GetType().Name);
            //}
        }

        private void RemoveRibbonViewToRegion(object ribbonView)
        {
            //foreach (UIElement elementLoopVariable in e.OldItems)
            //{
            //    var element = elementLoopVariable;
            //    if (regionTarget.Items.Contains(element))
            //    {
            //        regionTarget.Items.Remove(element);
            //    }
            //}

            //// wenn es ein Ribbon ist - SPEZIALFALL
            //if (ribbonView is Ribbon)
            //{
            //    Ribbon rb = ribbonView as Ribbon;
            //    for (int i = rb.Items.Count - 1; i >= 0; i--)
            //    {
            //        if (rb.Items[i] is RibbonTab)
            //        {
            //            RibbonTab rt = (rb.Items[i] as RibbonTab);
            //            rb.Items.Remove(rt);
            //            ribbonRegionTarget.Items.Remove(rt);
            //        }
            //    }
            //}
            //else
            //    // wenn es ein Ribbontab ist
            //    if (ribbonView is RibbonTab)
            //{
            //    ribbonRegionTarget.Items.Remove(ribbonView);
            //}
            //else
            //        // wenn es ein Ribbonbutton ist
            //        if (ribbonView is RibbonButton)
            //{
            //    // doesn't work - strange!
            //    ((RibbonButton)ribbonView).Visibility = Visibility.Hidden;
            //    // doesn't work - strange!

            //    ribbonRegionTarget.Items.Remove(ribbonView);
            //}
            //else
            //{
            //    throw new ArgumentException("unsupported type " + ribbonView.GetType().Name);
            //}
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
            //return new SingleActiveRegion(); 
        }
    }
}
