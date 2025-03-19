using Avalonia.Input.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextEncryption;
using TextEncryptionGUI.Messages;

namespace TextEncryptionGUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public const string JSON_FILE = "configs.json";

    [ObservableProperty]
    private bool displayPassword;

    private bool? lastIsEncrypting = true;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private char passwordChar = '*';

    [ObservableProperty]
    private string prefixes = "##";

    [ObservableProperty]
    private bool savePassword;

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

    private void Decrypt(string value)
    {
        if (T2 == null)
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
            Save();
        }
        catch (Exception ex)
        {
            T1 = ex.Message;
        }
        finally
        {
            updating = false;
        }
    }

    private void Encrypt(string value)
    {
        if (T1 == null)
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
            Save();
        }
        catch (Exception ex)
        {
            T2 = ex.Message;
        }
        finally
        {
            updating = false;
        }
    }

    partial void OnDisplayPasswordChanged(bool value)
    {
        PasswordChar = value ? '\0' : '*';
    }
    partial void OnPasswordChanged(string value)
    {
        if (!lastIsEncrypting.HasValue)
        {
            return;
        }
        switch (lastIsEncrypting.Value)
        {
            case true:
                Encrypt(T1);
                break;
            case false:
                Decrypt(T2);
                break;
        }
    }

    partial void OnSavePasswordChanged(bool value)
    {
        Save();
    }

    partial void OnT1Changed(string value)
    {
        if (updating == true)
        {
            return;
        }
        lastIsEncrypting = true;
        Encrypt(value);
    }

    partial void OnT2Changed(string value)
    {
        if (updating == true)
        {
            return;
        }
        lastIsEncrypting = false;
        Decrypt(value);
    }
    private void Save()
    {
        var jobj = new JsonObject
        {
            [nameof(Password)] = SavePassword ? Password : null,
            [nameof(Prefixes)] = Prefixes,
            [nameof(Suffixes)] = Suffixes
        };
        File.WriteAllText(JSON_FILE, jobj.ToString());
    }
}
