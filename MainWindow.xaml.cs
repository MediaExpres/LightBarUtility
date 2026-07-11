using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace LightBarUtility
{
    public partial class MainWindow : Window
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT { public int left, top, right, bottom; }

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

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        private const int ABM_NEW = 0x0000;
        private const int ABM_REMOVE = 0x0001;
        private const int ABM_QUERYPOS = 0x0002;
        private const int ABM_SETPOS = 0x0003;
        private const int ABE_BOTTOM = 3;
        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;

        private bool isDocked = false;
        private bool isAppBarRegistered = false;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Loaded(object? sender, RoutedEventArgs e)
        {
            SetDockedMode();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isDocked && e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MenuDocked_Click(object sender, RoutedEventArgs e)
        {
            if (!isDocked)
            {
                SetDockedMode();
            }
        }

        private void MenuFloating_Click(object sender, RoutedEventArgs e)
        {
            if (isDocked)
            {
                isDocked = false;
                UnregisterAppBar();
            }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetDockedMode()
        {
            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            
            PresentationSource source = PresentationSource.FromVisual(this);
            double dpiY = source?.CompositionTarget?.TransformToDevice.M22 ?? 1.0;
            double dpiX = source?.CompositionTarget?.TransformToDevice.M11 ?? 1.0;

            APPBARDATA data = new APPBARDATA();
            data.cbSize = Marshal.SizeOf(data);
            data.hWnd = hWnd;

            if (!isAppBarRegistered)
            {
                SHAppBarMessage(ABM_NEW, ref data);
                isAppBarRegistered = true;
            }

            data.uEdge = ABE_BOTTOM;
            data.rc.left = 0;
            data.rc.right = GetSystemMetrics(SM_CXSCREEN);
            data.rc.top = 0;
            data.rc.bottom = GetSystemMetrics(SM_CYSCREEN);

            SHAppBarMessage(ABM_QUERYPOS, ref data);

            int physicalHeight = (int)(40 * dpiY);
            data.rc.top = data.rc.bottom - physicalHeight;

            SHAppBarMessage(ABM_SETPOS, ref data);

            this.Left = data.rc.left / dpiX;
            this.Top = data.rc.top / dpiY;
            this.Width = (data.rc.right - data.rc.left) / dpiX;
            this.Height = 40;

            isDocked = true;
        }

        private void UnregisterAppBar()
        {
            if (isAppBarRegistered)
            {
                IntPtr hWnd = new WindowInteropHelper(this).Handle;
                APPBARDATA data = new APPBARDATA();
                data.cbSize = Marshal.SizeOf(data);
                data.hWnd = hWnd;
                SHAppBarMessage(ABM_REMOVE, ref data);
                isAppBarRegistered = false;
            }
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            UnregisterAppBar();
        }
    }
}