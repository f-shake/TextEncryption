using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Messaging;
using TextEncryptionGUI.Messages;

namespace TextEncryptionGUI.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        WeakReferenceMessenger.Default.Register<ClipboardMessage>(Content, (sender, message) =>
        {
            message.Clipboard = TopLevel.GetTopLevel(this).Clipboard;
        });
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        txtD.Focus();
    }
}
