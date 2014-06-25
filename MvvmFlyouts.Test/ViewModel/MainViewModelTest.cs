using GalaSoft.MvvmLight.Messaging;
using MvvmFlyouts.Helpers.Enums;
using MvvmFlyouts.Helpers.Messages;
using MvvmFlyouts.ViewModel;
using NUnit.Framework;

namespace MvvmFlyouts.Test.ViewModel
{
    [TestFixture]
    public class MainViewModelTest
    {
        [Test]
        public void ShouldInitializeMainViewModelWithFlyoutClosed()
        {
            //Arrange
            MainViewModel sut = new MainViewModel();

            //Act
            bool isOpen = sut.IsFlyoutOpen;

            //Assert
            Assert.IsFalse(isOpen);
        }

        [Test]
        public void OpenFlyoutCommandShouldSetIsFlyoutOpenTrue()
        {
            //Arrange
            MainViewModel sut = new MainViewModel();

            //Act
            sut.OpenFlyoutCommand.Execute(null);

            //Assert
            Assert.IsTrue(sut.IsFlyoutOpen);
        }

        [Test]
        public void OpenDialogCommandShouldGenerateCustomDialogMessage()
        {
            //Arrange
            MainViewModel sut = new MainViewModel();

            int messagesThatOccurred = 0;
            Messenger.Default.Register<CustomDialogMessage>(this, DialogMessageEnum.ErrorDialog, msg => { messagesThatOccurred++; });

            //Act
            sut.OpenDialogCommand.Execute(null);

            //Assert
            Assert.AreEqual(1, messagesThatOccurred);
        }

        [Test]
        public void OpenProgressDialogCommandShouldGenerateCustomMessageDialog()
        {
            //Arrange
            MainViewModel sut = new MainViewModel();

            int messagesThatOccurred = 0;
            Messenger.Default.Register<CustomDialogMessage>(this, DialogMessageEnum.ProgressDialog, msg => { messagesThatOccurred++; });

            //Act
            sut.OpenProgressDialogCommand.Execute(null);
            
            //Assert
            Assert.AreEqual(1, messagesThatOccurred);
        }
    }
}
