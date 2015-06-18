using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;
using System.Collections.Specialized;

namespace DigitalAppaloosa.Shared.Prism
{
   public class RibbonRegionAdapter : RegionAdapterBase<Ribbon>
    {
        public RibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory) { }

        private Ribbon ribbonRegionTarget;

        protected override void Adapt(IRegion region, Ribbon regionTarget)
        {
            ribbonRegionTarget = regionTarget;

            region.ActiveViews.CollectionChanged += new NotifyCollectionChangedEventHandler(OnActiveViewsChanged);

            foreach (RibbonTab ribbonTabView in region.ActiveViews)
            {
                regionTarget.Items.Add(ribbonTabView);
            }
        }

        private void OnActiveViewsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                // Hinzufügen von Ribboncontrols
                case NotifyCollectionChangedAction.Add:
                    // für jedes neue Item
                    foreach (object ribbonView in e.NewItems)
                    {
                        // wenn es ein Ribbon ist - SPEZIALFALL
                        if (ribbonView is Ribbon)
                        {
                            Ribbon rb = ribbonView as Ribbon;
                            for (int i = rb.Items.Count - 1; i >= 0; i--)
                            {
                                if (rb.Items[i] is RibbonTab)
                                {
                                    // Umhängen aller Ribbontab in das Ribbon des Adapters
                                    RibbonTab rt = (rb.Items[i] as RibbonTab);
                                    rb.Items.Remove(rt);
                                    ribbonRegionTarget.Items.Add(rt);
                                }
                            }
                        }
                        else
                            // wenn es ein Ribbontab ist
                            if (ribbonView is RibbonTab)
                        {
                            ribbonRegionTarget.Items.Add(ribbonView);
                        }
                        else
                                // wenn es ein Ribbonbutton ist
                                if (ribbonView is RibbonButton)
                        {
                            bool alreadyInserted = false;

                            foreach (object ot in ribbonRegionTarget.Items)
                            {
                                // in das erste Ribbontab
                                if (ot is RibbonTab && !alreadyInserted)
                                {
                                    foreach (object og in ((RibbonTab)ot).Items)
                                    {
                                        // in die erste Ribbon group
                                        if (og is RibbonGroup)
                                        {
                                            ((RibbonGroup)og).Items.Add(ribbonView);
                                            alreadyInserted = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            throw new ArgumentException("unsupported type " + ribbonView.GetType().Name);
                        }
                    }
                    break;
                // entfernen von Ribboncontrols 
                case NotifyCollectionChangedAction.Remove:
                    {
                        if (e.NewItems != null)
                            foreach (object ribbonView in e.NewItems)
                            {
                                // wenn es ein Ribbon ist - SPEZIALFALL
                                if (ribbonView is Ribbon)
                                {
                                    Ribbon rb = ribbonView as Ribbon;
                                    for (int i = rb.Items.Count - 1; i >= 0; i--)
                                    {
                                        if (rb.Items[i] is RibbonTab)
                                        {
                                            RibbonTab rt = (rb.Items[i] as RibbonTab);
                                            rb.Items.Remove(rt);
                                            ribbonRegionTarget.Items.Remove(rt);
                                        }
                                    }
                                }
                                else
                                    // wenn es ein Ribbontab ist
                                    if (ribbonView is RibbonTab)
                                {
                                    ribbonRegionTarget.Items.Remove(ribbonView);
                                }
                                else
                                        // wenn es ein Ribbonbutton ist
                                        if (ribbonView is RibbonButton)
                                {
                                    // doesn't work - strange!
                                    ((RibbonButton)ribbonView).Visibility = System.Windows.Visibility.Hidden;
                                    // doesn't work - strange!

                                    ribbonRegionTarget.Items.Remove(ribbonView);
                                }
                                else
                                {
                                    throw new ArgumentException("unsupported type " + ribbonView.GetType().Name);
                                }
                            }
                        break;
                    }
            }
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
