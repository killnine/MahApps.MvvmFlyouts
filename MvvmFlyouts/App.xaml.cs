using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace MvvmFlyouts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherHelper.Initialize();
        }

    }
}
