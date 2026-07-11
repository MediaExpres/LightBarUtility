using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace LightBarUtility
{
    public partial class MainWindow : Window
    {
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

        [DllImport("shell32.dll")]
        public static extern int SHAppBarMessage(int dwMessage, ref APPBARDATA pData);

        private const int ABM_NEW = 0x0000;
        private const int ABM_REMOVE = 0x0001;
        private const int ABM_QUERYPOS = 0x0002; // Comanda vitală care lipsea
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
            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            
            APPBARDATA data = new APPBARDATA();
            data.cbSize = Marshal.SizeOf(data);
            data.hWnd = hWnd;
            
            // 1. Înregistrăm bara
            SHAppBarMessage(ABM_NEW, ref data);

            // 2. Cerem Windows-ului să calculeze marginile reale ale ecranului liber
            data.uEdge = ABE_BOTTOM;
            data.rc.left = 0;
            data.rc.right = (int)SystemParameters.PrimaryScreenWidth;
            data.rc.top = 0;
            data.rc.bottom = (int)SystemParameters.PrimaryScreenHeight;

            SHAppBarMessage(ABM_QUERYPOS, ref data);

            // 3. Tăiem doar 40 de pixeli pentru bara noastră
            int baraHeight = 40;
            data.rc.top = data.rc.bottom - baraHeight;

            // 4. Confirmăm rezervarea
            SHAppBarMessage(ABM_SETPOS, ref data);

            // 5. Aplicăm coordonatele ferestrei noastre
            this.Left = data.rc.left;
            this.Top = data.rc.top;
            this.Width = data.rc.right - data.rc.left;
            this.Height = baraHeight;
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            APPBARDATA data = new APPBARDATA();
            data.cbSize = Marshal.SizeOf(data);
            data.hWnd = hWnd;
            SHAppBarMessage(ABM_REMOVE, ref data);
        }
    }
}