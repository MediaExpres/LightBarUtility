using System;
using System.Threading;
using System.Windows;

namespace LightBarUtility;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private static Mutex? _mutex = null;

    protected override void OnStartup(StartupEventArgs e)
    {
        const string appName = "LightBarUtility_UniqueInstance";
        bool createdNew;

        // Încearcă să creeze un Mutex cu un nume unic la nivel de sistem
        _mutex = new Mutex(true, appName, out createdNew);

        if (!createdNew)
        {
            // Dacă Mutex-ul există deja, închide aplicația imediat
            Application.Current.Shutdown();
            return;
        }

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        // Eliberează Mutex-ul la închiderea aplicației
        if (_mutex != null)
        {
            _mutex.ReleaseMutex();
            _mutex.Dispose();
        }

        base.OnExit(e);
    }
}