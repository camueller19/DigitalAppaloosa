using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using NLog;
using System.Windows.Input;

namespace DigitalAppaloosa.Modules.Experimental.ViewModels
{
    public class RibbonTabTestAViewModel : ViewModelBase
    {
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public RibbonTabTestAViewModel()
        {
            buttonACommand = new RelayCommand(ButtonACommandExecuted);
            buttonBCommand = new RelayCommand(ButtonBCommandExecuted);
            buttonCCommand = new RelayCommand(ButtonCCommandExecuted);
        }

        #region ButtonACommand

        private ICommand buttonACommand;

        public ICommand ButtonACommand
        {
            get { return buttonACommand; }
            set { buttonACommand = value; }
        }

        private void ButtonACommandExecuted()
        {
            //throw new NotImplementedException();
            logger.Info("Button A clicked");
        }

        #endregion

        #region ButtonBCommand

        private ICommand buttonBCommand;

        public ICommand ButtonBCommand
        {
            get { return buttonBCommand; }
            set { buttonBCommand = value; }
        }

        private void ButtonBCommandExecuted()
        {
            //throw new NotImplementedException();
            logger.Info("Button B clicked");
        }

        #endregion

        #region ButtonCCommand

        private ICommand buttonCCommand;

        public ICommand ButtonCCommand
        {
            get { return buttonCCommand; }
            set { buttonCCommand = value; }
        }

        private void ButtonCCommandExecuted()
        {
            //throw new NotImplementedException();
            logger.Info("Button C clicked");
        }

        #endregion

    }
}
