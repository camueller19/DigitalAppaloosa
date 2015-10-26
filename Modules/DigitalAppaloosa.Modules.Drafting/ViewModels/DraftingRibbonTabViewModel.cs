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
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IEventAggregator eventAggregator;

        public DraftingRibbonTabViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            drawRectangleCommand = new RelayCommand(DrawRectangleCommandExecuted);
        }

        //DrawRectangleCommand
        #region DrawRectangleCommand
        private ICommand drawRectangleCommand;

        public ICommand DrawRectangleCommand
        {
            get { return drawRectangleCommand; }
            set { drawRectangleCommand = value; }
        }

        private void DrawRectangleCommandExecuted()
        {
            //throw new NotImplementedException();
            logger.Info("DrawRectangleCommand clicked");
            var foe = eventAggregator.GetEvent<FigureOperationEvent>();
            foe.Publish(FigureOperation.Rectangle);
        }

        #endregion
    }
}
