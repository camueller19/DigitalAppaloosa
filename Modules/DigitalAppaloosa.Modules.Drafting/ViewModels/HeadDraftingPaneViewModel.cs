using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using DigitalAppaloosa.Contracts.Interfaces;
using GalaSoft.MvvmLight;

namespace DigitalAppaloosa.Modules.Drafting.ViewModels
{
    public class HeadDraftingPaneViewModel : ViewModelBase, IDraftingPaneViewModel
    {
        private ICollection<FrameworkElement> items;
        private IEnumerable<IMouseButtonEventHandler> mouseButtonEventHandlers;
        private int offset;

        public HeadDraftingPaneViewModel()
        {
            items = new ObservableCollection<FrameworkElement>();
            items.Add(new Rectangle()
            {
                Fill = new SolidColorBrush(Colors.Blue),
                Height = 20,
                Width = 30
                //Margin = new Thickness(50, 200, 10, 10)
            });
            offset = 1;
        }

        public ICollection<FrameworkElement> Items
        {
            get { return items; }
            set { Set(nameof(Items), ref items, value); }
        }

        public IEnumerable<IMouseButtonEventHandler> MouseButtonEventHandlers
        {
            get { return mouseButtonEventHandlers; }
            set { Set(nameof(MouseButtonEventHandlers), ref mouseButtonEventHandlers, value); }
        }
    }
}