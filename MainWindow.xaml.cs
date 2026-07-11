using System;
using System.Windows;
using WpfAppBar; 

namespace LightBarUtility
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // Wait for the window handle to be ready before hooking into the OS
            this.SourceInitialized += MainWindow_SourceInitialized;
        }

        // Added '?' to 'object' to resolve the CS8622 warning
        private void MainWindow_SourceInitialized(object? sender, EventArgs e)
        {
            // Dock the window to the bottom edge of the screen
            AppBarFunctions.SetAppBar(this, ABEdge.Bottom);
        }

        // Safely unregister the reserved space when the app closes
        protected override void OnClosed(EventArgs e)
        {
            AppBarFunctions.SetAppBar(this, ABEdge.None);
            base.OnClosed(e);
        }
    }
}