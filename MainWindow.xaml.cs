using System;
using System.Windows;

namespace LightBarUtility
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // Așteptăm ca fereastra să fie gata înainte să o mutăm
            this.SourceInitialized += MainWindow_SourceInitialized;
        }

        private void MainWindow_SourceInitialized(object? sender, EventArgs e)
        {
            // Setăm lățimea barei pe toată lățimea ecranului
            this.Width = SystemParameters.WorkArea.Width;
            
            // O poziționăm perfect în partea de jos (deasupra taskbar-ului)
            this.Left = SystemParameters.WorkArea.Left;
            this.Top = SystemParameters.WorkArea.Bottom - this.Height;
        }
    }
}