using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DigitalAppaloosa.Shared.PubSubEvents;
using GalaSoft.MvvmLight;

namespace DigitalAppaloosa.Modules.Drafting.ViewModels
{
    public class HeadDraftingPaneViewModel : ViewModelBase
    {
        private ICollection<FrameworkElement> items;

        private int offset;

        public HeadDraftingPaneViewModel()
        {
            items = new ObservableCollection<FrameworkElement>();
            items.Add(new Rectangle()
            {
                Fill = new SolidColorBrush(Colors.Blue),
                Height = 20,
                Width = 30,
                Margin = new Thickness(50, 200, 10, 10)
            });
            offset = 1;
        }

        public ICollection<FrameworkElement> Items
        {
            get { return items; }
            set { Set(nameof(Items), ref items, value); }
        }

        internal void AddFigure(FigureOperation figureOperation)
        {
            if (figureOperation == FigureOperation.Rectangle)
            {
                var newFigure = new Rectangle()
                {
                    Fill = new SolidColorBrush(Colors.Green),
                    Height = 20,
                    Width = 30,
                    Margin = new Thickness(50, 200, 10, 10)
                };
                Canvas.SetLeft(newFigure, 10 * offset);
                Canvas.SetTop(newFigure, 10 * offset);
                offset++;
                Items.Add(newFigure);
            }
        }
    }
}