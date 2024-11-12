using System.Text;
using System;
using TextEncryption;
using System.Diagnostics;


start:
Console.Clear();
Console.WriteLine("==========文本加密工具==========");
string? password = null;
while (string.IsNullOrWhiteSpace(password))
{
    Console.Write("请输入密码：");
    password = Console.ReadLine()?.Trim();
}

int type = 0;
while (type is not (1 or 2))
{
    Console.Write("加密（1）/解密（2）：");
    char key = Console.ReadKey().KeyChar;
    if (key is '1' or '2')
    {
        type = key - '0';
    }
    Console.WriteLine();
}

string? inputText = null;
while (string.IsNullOrWhiteSpace(inputText))
{
    Console.WriteLine("请输入文本或UTF8格式的文件地址：");
    inputText = Console.ReadLine()?.Trim();
}
if (File.Exists(inputText))
{
    inputText = File.ReadAllText(inputText);
}

Console.WriteLine();
Console.WriteLine();

TextEncryptor te = new TextEncryptor(password);
if (type == 1)
{
    string encryptedText = te.Encrypt(inputText);
    string test = te.Decrypt(encryptedText);
    if (test != inputText)
    {
        throw new Exception("测试解密后的文本与源文本不同，需要检查算法");
    }
    Console.WriteLine("==========密文==========");
    Console.WriteLine(encryptedText);
    Console.WriteLine("==========密文==========");
}
else
{
    string decryptedText = te.Decrypt(inputText);
    Console.WriteLine("==========原文==========");
    Console.WriteLine(decryptedText);
    Console.WriteLine("==========原文==========");
}


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("按R以重新开始");

if (Console.ReadKey().Key == ConsoleKey.R)
{
    goto start;
}