using Avalonia.Input.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextEncryption;
using TextEncryptionGUI.Messages;

namespace TextEncryptionGUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public const string JSON_FILE = "configs.json";

    [ObservableProperty]
    private bool displayPassword;

    [ObservableProperty]
    private string errorMessage = "";

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

    private void CheckConfig()
    {
        if (string.IsNullOrEmpty(Password))
        {
            throw new Exception("密码为空");
        }

        if (string.IsNullOrEmpty(Prefixes))
        {
            throw new Exception("前缀为空");
        }

        if (string.IsNullOrEmpty(Suffixes))
        {
            throw new Exception("后缀为空");
        }
    }

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
        if (T2 == null) return;

        updating = true;
        try
        {
            CheckConfig();

            TextEncryptor te = new TextEncryptor(Password);
            string pattern = $"{Regex.Escape(Prefixes)}(.*?){Regex.Escape(Suffixes)}"; // 动态匹配前后缀
            var matches = Regex.Matches(value, pattern, RegexOptions.Singleline);
            StringBuilder result = new StringBuilder(value);

            // 反向遍历避免替换时影响索引
            foreach (Match match in matches.Cast<Match>().Reverse())
            {
                string encryptedText = match.Groups[1].Value;

                string decryptedText = te.Decrypt(encryptedText);
                result.Remove(match.Index, match.Length)
                    .Insert(match.Index, decryptedText);
            }

            T1 = result.ToString();
            ErrorMessage = null;
            Save();
        }
        catch (Exception ex)
        {
            T1 = null;
            ErrorMessage = ex.Message;
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
            CheckConfig();

            TextEncryptor te = new TextEncryptor(Password);
            var text = te.Encrypt(value);
            string test = te.Decrypt(text);
            if (test != value)
            {
                throw new Exception("测试解密后的文本与源文本不同，需要检查算法");
            }

            T2 = $"{Prefixes}{text}{Suffixes}";
            ErrorMessage = null;
            Save();
        }
        catch (Exception ex)
        {
            T2 = null;
            ErrorMessage = ex.Message;
        }
        finally
        {
            updating = false;
        }
    }

    private void EncryptOrDecryptAgain()
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

    partial void OnDisplayPasswordChanged(bool value)
    {
        PasswordChar = value ? '\0' : '*';
    }

    partial void OnPasswordChanged(string value)
    {
        EncryptOrDecryptAgain();
    }

    partial void OnPrefixesChanged(string value)
    {
        EncryptOrDecryptAgain();
    }

    partial void OnSavePasswordChanged(bool value)
    {
        Save();
    }

    partial void OnSuffixesChanged(string value)
    {
        EncryptOrDecryptAgain();
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