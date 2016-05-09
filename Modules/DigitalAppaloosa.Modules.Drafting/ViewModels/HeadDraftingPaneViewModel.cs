using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
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
        //private int offset;

        public HeadDraftingPaneViewModel()
        {
            var rectangle1 = new Rectangle
            {
                Fill = new SolidColorBrush(Colors.Blue),
                Height = 20,
                Width = 30,
                RadiusX = 10,
                RadiusY = 10
                //Margin = new Thickness(50, 200, 10, 10)
            };
            Canvas.SetTop(rectangle1, 10);
            Canvas.SetLeft(rectangle1, 10);

            var ellipse1 = new Ellipse
            {
                Width = 20,
                Height = 20,
                Fill = new SolidColorBrush(Colors.Red)
            };
            Canvas.SetTop(ellipse1, 25);
            Canvas.SetLeft(ellipse1, 25);

            items = new ObservableCollection<FrameworkElement> { rectangle1, ellipse1 };
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