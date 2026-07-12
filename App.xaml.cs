using System;
using System.Diagnostics;
using System.Windows;

namespace LightBarUtility;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
        {
            Environment.Exit(0);
        }

        base.OnStartup(e);
    }
}