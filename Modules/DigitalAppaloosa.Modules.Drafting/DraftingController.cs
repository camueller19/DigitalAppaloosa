using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using DigitalAppaloosa.Modules.Drafting.ViewModels;
using DigitalAppaloosa.Shared.PubSubEvents;
using NLog;
using Prism.Events;

namespace DigitalAppaloosa.Modules.Drafting
{
    public class DraftingController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IEventAggregator eventAggregator;
        private HeadDraftingPaneViewModel headDraftingPaneViewModel;
        private int offset;

        public DraftingController(IEventAggregator eventAggregator, HeadDraftingPaneViewModel headDraftingPaneViewModel)
        {
            this.eventAggregator = eventAggregator;
            this.headDraftingPaneViewModel = headDraftingPaneViewModel;
            offset = 1;
            eventAggregator.GetEvent<FigureOperationEvent>().Subscribe(FigureOperationChanged);
        }

        private void FigureOperationChanged(FigureOperation figureOperation)
        {
            logger.Info("Draw: " + figureOperation);
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
                headDraftingPaneViewModel.Items.Add(newFigure);
            }

            //throw new NotImplementedException();
        }
    }
}