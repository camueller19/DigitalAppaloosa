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

        public DraftingRibbonTabViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            DrawCommand = new RelayCommand<FigureOperation>(OnDrawCommandExecuted);
            ShowPathCommand = new RelayCommand(OnShowPathCommandExecuted);
        }

        public ICommand DrawCommand { get; set; }

        public ICommand ShowPathCommand { get; set; }

        private void OnDrawCommandExecuted(FigureOperation operation)
        {
            PublishFigureEvent(operation);
        }

        private void OnShowPathCommandExecuted()
        {
            var spe = eventAggregator.GetEvent<ShowPathEvent>();
            spe.Publish(int.MaxValue);
        }

        private void PublishFigureEvent(FigureOperation figure)
        {
            logger.Info(figure + " DrawCommand clicked");
            var foe = eventAggregator.GetEvent<FigureOperationEvent>();
            foe.Publish(figure);
        }
    }
}