using System;
using System.Threading;
using System.Windows;

namespace LightBarUtility;

public partial class App : Application
{
    private static Mutex? _mutex = null;

    protected override void OnStartup(StartupEventArgs e)
    {
        const string appName = "LightBarUtility_UniqueInstance";
        bool createdNew;

        _mutex = new Mutex(true, appName, out createdNew);

        if (!createdNew)
        {
            Environment.Exit(0);
        }

        base.OnStartup(e);

        // Deschidem fereastra manual doar dacă este prima instanță
        LightBarForKeyboard.MainWindow mainWindow = new();
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