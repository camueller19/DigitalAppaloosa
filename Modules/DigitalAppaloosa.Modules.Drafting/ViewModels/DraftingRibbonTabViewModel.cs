using System.Windows.Input;
using DigitalAppaloosa.Contracts.Enums;
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

        private ICommand drawCommand;

        public DraftingRibbonTabViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            DrawCommand = new RelayCommand<FigureOperation>(DrawCommandExecuted);
        }

        public ICommand DrawCommand
        {
            get { return drawCommand; }
            set { drawCommand = value; }
        }

        private void DrawCommandExecuted(FigureOperation operation)
        {
            PublishFigureEvent(operation);
        }

        private void PublishFigureEvent(FigureOperation figure)
        {
            logger.Info(figure + " DrawCommand clicked");
            var foe = eventAggregator.GetEvent<FigureOperationEvent>();
            foe.Publish(figure);
        }
    }
}