using CommunityToolkit.Mvvm.ComponentModel;
using System;
using TextEncryption;

namespace TextEncryptionGUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string t1;

    [ObservableProperty]
    private string t2;

    [ObservableProperty]
    private string password;

    private bool updating = false;

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
            T2 = te.Encrypt(value);
            string test = te.Decrypt(T2);
            if (test != value)
            {
                throw new Exception("测试解密后的文本与源文本不同，需要检查算法");
            }
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
            T1 = te.Decrypt(value);
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
