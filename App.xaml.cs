using System;
using System.Threading;
using System.Windows;

namespace LightBarForKeyboard;

public partial class App : Application
{
    private static Mutex? _mutex = null;

    protected override void OnStartup(StartupEventArgs e)
    {
        const string appName = "LightBarForKeyboard_UniqueInstance";
        bool createdNew;

        _mutex = new Mutex(true, appName, out createdNew);

        if (!createdNew)
        {
            Environment.Exit(0);
        }

        base.OnStartup(e);

        MainWindow mainWindow = new();
        mainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        if (_mutex != null)
        {
            _mutex.ReleaseMutex();
            _mutex.Dispose();
        }

        base.OnExit(e);
    }
}