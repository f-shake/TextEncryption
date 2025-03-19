using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using TextEncryptionGUI.ViewModels;
using TextEncryptionGUI.Views;

namespace TextEncryptionGUI;
public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        if (OperatingSystem.IsWindows())
        {
            Resources.Add("ContentControlThemeFontFamily", new FontFamily("Microsoft YaHei"));
        }
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);


        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = GetMainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = GetMainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private MainViewModel GetMainViewModel()
    {
        if (File.Exists(MainViewModel.JSON_FILE))
        {
            var viewModel = new MainViewModel();
            try
            {
                var jobj = (JsonObject)JsonNode.Parse(File.ReadAllText(MainViewModel.JSON_FILE));
                var password = jobj[nameof(MainViewModel.Password)]?.GetValue<string>();
                if (password != null)
                {
                    viewModel.Password = password;
                    viewModel.SavePassword = true;
                }
                viewModel.Prefixes = jobj[nameof(MainViewModel.Prefixes)]?.GetValue<string>();
                viewModel.Suffixes = jobj[nameof(MainViewModel.Suffixes)]?.GetValue<string>();
            }
            catch
            {
            }
            return viewModel;
        }
        return new MainViewModel();
    }
}
