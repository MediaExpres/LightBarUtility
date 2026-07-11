using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace LightBarUtility
{
    public partial class MainWindow : Window
    {
        // 1. Definim structurile native cu care lucrează Windows
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left, top, right, bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct APPBARDATA
        {
            public int cbSize;
            public IntPtr hWnd;
            public int uCallbackMessage;
            public int uEdge;
            public RECT rc;
            public IntPtr lParam;
        }

        // 2. Importăm funcția care negociază spațiul (din shell32.dll)
        [DllImport("shell32.dll")]
        public static extern int SHAppBarMessage(int dwMessage, ref APPBARDATA pData);

        private const int ABM_NEW = 0x0000;
        private const int ABM_REMOVE = 0x0001;
        private const int ABM_SETPOS = 0x0003;
        private const int ABE_BOTTOM = 3;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Loaded(object? sender, RoutedEventArgs e)
        {
            // Obținem ID-ul ferestrei noastre
            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            
            APPBARDATA data = new APPBARDATA();
            data.cbSize = Marshal.SizeOf(data);
            data.hWnd = hWnd;
            
            // Înregistrăm fereastra ca Bară de Sistem
            SHAppBarMessage(ABM_NEW, ref data);

            // Cerem Windows-ului să ne rezerve spațiul exact deasupra Taskbar-ului
            data.uEdge = ABE_BOTTOM;
            data.rc.left = (int)SystemParameters.WorkArea.Left;
            data.rc.right = (int)SystemParameters.WorkArea.Right;
            data.rc.bottom = (int)SystemParameters.WorkArea.Bottom;
            data.rc.top = data.rc.bottom - (int)this.Height;

            // Confirmăm rezervarea
            SHAppBarMessage(ABM_SETPOS, ref data);

            // Mutăm fereastra noastră albă efectiv în acel spațiu sigur
            this.Left = data.rc.left;
            this.Top = data.rc.top;
            this.Width = data.rc.right - data.rc.left;
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            // Când apeși Alt+F4, spunem Windows-ului să elibereze spațiul ecranului
            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            APPBARDATA data = new APPBARDATA();
            data.cbSize = Marshal.SizeOf(data);
            data.hWnd = hWnd;
            SHAppBarMessage(ABM_REMOVE, ref data);
        }
    }
}