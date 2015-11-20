using System.Windows.Input;
using DigitalAppaloosa.Shared.PubSubEvents;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using NLog;
using Prism.Events;

namespace DigitalAppaloosa.Modules.Drafting.ViewModels
{
    public class DraftingRibbonTabViewModel : ViewModelBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private ICommand drawCircleCommand;

        private ICommand drawRectangleCommand;

        public DraftingRibbonTabViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            drawRectangleCommand = new RelayCommand(DrawRectangleCommandExecuted);
            drawCircleCommand = new RelayCommand(DrawCircleCommandExecuted);
        }

        public ICommand DrawCircleCommand
        {
            get { return drawCircleCommand; }
            set { drawCircleCommand = value; }
        }

        public ICommand DrawRectangleCommand
        {
            get { return drawRectangleCommand; }
            set { drawRectangleCommand = value; }
        }

        private void DrawCircleCommandExecuted()
        {
            PublishFigureEvent(FigureOperation.Circle);
        }

        private void DrawRectangleCommandExecuted()
        {
            PublishFigureEvent(FigureOperation.Rectangle);
        }

        private void PublishFigureEvent(FigureOperation figure)
        {
            logger.Info(figure + " DrawCommand clicked");
            var foe = eventAggregator.GetEvent<FigureOperationEvent>();
            foe.Publish(figure);
        }
    }
}