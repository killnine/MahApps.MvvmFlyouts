using GalaSoft.MvvmLight.Messaging;

namespace MvvmFlyouts.Helpers.Messages
{
    public class CustomDialogMessage : MessageBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string DefaultText { get; set; }

        public CustomDialogMessage(string title, string content, string defaultText = "")
        {
            Title = title;
            Content = content;
            DefaultText = defaultText;
        }
    }
}
