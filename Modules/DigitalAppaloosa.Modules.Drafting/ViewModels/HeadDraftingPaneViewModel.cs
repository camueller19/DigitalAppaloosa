using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DigitalAppaloosa.Contracts.Interfaces;
using DigitalAppaloosa.Modules.Drafting.Handlers;
using DigitalAppaloosa.Shared.PubSubEvents;
using DigitalAppaloosa.Windows.Handlers;
using GalaSoft.MvvmLight;

namespace DigitalAppaloosa.Modules.Drafting.ViewModels
{
    public class HeadDraftingPaneViewModel : ViewModelBase
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
                Width = 30,
                Margin = new Thickness(50, 200, 10, 10)
            });
            offset = 1;

            mouseButtonEventHandlers = new ObservableCollection<IMouseButtonEventHandler>() {
                new DraftingHandler(), new DragDropHandler() };
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