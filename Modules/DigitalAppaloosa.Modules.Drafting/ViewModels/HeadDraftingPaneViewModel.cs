using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using GalaSoft.MvvmLight;

namespace DigitalAppaloosa.Modules.Drafting.ViewModels
{
    public class HeadDraftingPaneViewModel : ViewModelBase
    {
        public HeadDraftingPaneViewModel()
        {
            items = new ObservableCollection<FrameworkElement>();
            items.Add(new Rectangle()
            {
                Fill = new SolidColorBrush(Colors.Blue),
                Height=20,
                Width=30,
                Margin = new Thickness(50, 200, 10, 10)
            });
        }

        private ICollection<FrameworkElement> items;

        public ICollection<FrameworkElement> Items
        {
            get { return items; }
            set { Set(nameof(Items), ref items, value); }
        }
    }
}
