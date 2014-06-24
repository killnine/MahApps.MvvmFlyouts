using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MvvmFlyouts.Helpers.Enums;
using MvvmFlyouts.Helpers.Messages;

namespace MvvmFlyouts.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand OpenFlyoutCommand { get { return new RelayCommand(() => IsFlyoutOpen = true);} }
        public ICommand OpenDialogCommand { get { return new RelayCommand(GenerateDialog);} }
        public ICommand OpenProgressDialogCommand { get { return new RelayCommand(GenerateProgressDialog);} }

        private bool _isFlyoutOpen;
        public bool IsFlyoutOpen
        {
            get { return _isFlyoutOpen; }
            set { Set(() => IsFlyoutOpen, ref _isFlyoutOpen, value); }
        }

        public MainViewModel()
        {
            IsFlyoutOpen = false;
        }

        private void GenerateDialog()
        {
            Messenger.Default.Send(new CustomDialogMessage("Generated Message", "Here's some content"), DialogMessageEnum.ErrorDialog);
        }

        private void GenerateProgressDialog()
        {
            Messenger.Default.Send(new CustomDialogMessage("Progress Dialog", "Here's more content"), DialogMessageEnum.ProgressDialog);
        }
    }
}