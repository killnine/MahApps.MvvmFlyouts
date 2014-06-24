using System.Threading.Tasks;
using System.Windows.Interactivity;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MvvmFlyouts.Helpers.Enums;
using MvvmFlyouts.Helpers.Messages;

namespace MvvmFlyouts.Helpers
{
    public class DialogBehavior : Behavior<MetroWindow>
    {
        public MetroWindow Window { get; set; }

        protected override void OnAttached()
        {
            Window = base.AssociatedObject;

            base.OnAttached();

            Messenger.Default.Register<CustomDialogMessage>(this, DialogMessageEnum.ErrorDialog, async msg => await ShowErrorDialog(msg));
            Messenger.Default.Register<CustomDialogMessage>(this, DialogMessageEnum.ProgressDialog, async msg => await ShowProgressDialog(msg));
        }

        private async Task ShowProgressDialog(CustomDialogMessage obj)
        {
            var controller = await Window.ShowProgressAsync(obj.Title, obj.Content);

            await Task.Delay(3000);

            double i = 0.0;
            while (i < 6.0)
            {
                double val = i/100.0*20.0;
                controller.SetProgress(val);
                controller.SetMessage("Completing time-consuming task..." + (val*100) + " percent complete.");

                i += 1.0;

                await Task.Delay(1000);
            }

            await controller.CloseAsync();
        }

        private async Task ShowErrorDialog(CustomDialogMessage obj)
        {
            await Window.ShowMessageAsync(obj.Title, obj.Content);
        }
    }
}
