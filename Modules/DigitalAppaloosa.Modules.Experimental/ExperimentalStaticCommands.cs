using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using NLog;

namespace DigitalAppaloosa.Modules.Experimental
{
    public static class ExperimentalStaticCommands
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        static ExperimentalStaticCommands()
        {
            buttonDCommand = new RelayCommand(ButtonDCommandExecuted);
        }

        private static void ButtonDCommandExecuted()
        {
            logger.Info("Button D clicked");
        }

        private static ICommand buttonDCommand;

        public static ICommand ButtonDCommand
        {
            get { return buttonDCommand; }
            set { buttonDCommand = value; }
        }
    }
}