using Avalonia.Input.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Threading.Tasks;
using TextEncryption;
using TextEncryptionGUI.Messages;

namespace TextEncryptionGUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private string prefixes = "##";

    [ObservableProperty]
    private string suffixes = "##";

    [ObservableProperty]
    private string t1;

    [ObservableProperty]
    private string t2;
    private bool updating = false;

    [RelayCommand]
    private async Task CopyAsync(string type)
    {
        IClipboard clipboard = WeakReferenceMessenger.Default.Send<ClipboardMessage>().Clipboard;
        switch (type)
        {
            case "d":
                await clipboard.SetTextAsync(T1);
                break;
            case "e":
                await clipboard.SetTextAsync(T2);
                break;
        }
    }

    partial void OnT1Changed(string value)
    {
        if (updating == true)
        {
            return;
        }
        updating = true;
        try
        {
            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("密码为空");
            }
            TextEncryptor te = new TextEncryptor(Password);
            var text = te.Encrypt(value);
            string test = te.Decrypt(text);
            if (test != value)
            {
                throw new Exception("测试解密后的文本与源文本不同，需要检查算法");
            }
            T2 = $"{Prefixes}{text}{Suffixes}";
        }
        catch (Exception ex)
        {
            T2 = ex.ToString();
        }
        finally
        {
            updating = false;
        }
    }

    partial void OnT2Changed(string value)
    {
        if (updating == true)
        {
            return;
        }
        updating = true;
        try
        {
            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("密码为空");
            }
            TextEncryptor te = new TextEncryptor(Password);
            var text = value;
            if (!string.IsNullOrEmpty(Prefixes) && text.StartsWith(Prefixes))
            {
                text = text[Prefixes.Length..];
            }
            if (!string.IsNullOrEmpty(Suffixes) && text.EndsWith(Suffixes))
            {
                text = text[..^Suffixes.Length];
            }
            T1 = te.Decrypt(text);
        }
        catch (Exception ex)
        {
            T1 = ex.ToString();
        }
        finally
        {
            updating = false;
        }
    }
}
