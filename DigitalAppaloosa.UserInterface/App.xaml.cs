using System.Windows;

namespace DigitalAppaloosa.UserInterface
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootstrapper = new DigitalAppaloosaBootstrapper();
            bootstrapper.Run();
        }
    }
}
