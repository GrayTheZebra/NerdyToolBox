using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace FensterTool
{
    static class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        const uint MOUSEEVENTF_LEFTUP = 0x04;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        const uint MOUSEEVENTF_RIGHTUP = 0x10;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x20;
        const uint MOUSEEVENTF_MIDDLEUP = 0x40;


        static void SimulateMouseClick(string type)
        {
            switch (type)
            {
                case "left":
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    break;
                case "right":
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                    break;
                case "middle":
                    mouse_event(MOUSEEVENTF_MIDDLEDOWN, 0, 0, 0, 0);
                    mouse_event(MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
                    break;
            }
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        const int SW_MINIMIZE = 6;
        const int SW_MAXIMIZE = 3;
        const int SW_RESTORE = 9;

        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                bool hadEffect = CommandModeHandler(args);

                if (args.Contains("--exit") && hadEffect)
                    return; // Beenden, da Aktion erfolgt + --exit gesetzt
            }

            // Normales Startverhalten
            Application.Run(new MainForm());
        }

        static bool CommandModeHandler(string[] args)
        {
            int? mouseX = null, mouseY = null;
            string mouseClick = "none";

            string title = null;
            int? x = null, y = null, width = null, height = null;
            bool minimize = false, maximize = false, restore = false;

            int delayMs = 50;

            // Logging aller args
            System.IO.File.AppendAllText("debug.log", $"ARGS: {string.Join(" | ", args)}{Environment.NewLine}");
            System.IO.File.AppendAllText("debug.log", $"Delay (ms): {delayMs}{Environment.NewLine}");

            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                string nextArg = (i + 1 < args.Length) ? args[i + 1] : null;

                switch (arg)
                {
                    case "--title":
                        if (nextArg != null) { title = nextArg; i++; }
                        break;
                    case "--x":
                        if (nextArg != null && int.TryParse(nextArg, NumberStyles.Integer, CultureInfo.InvariantCulture, out int valX)) { x = valX; i++; }
                        break;
                    case "--y":
                        if (nextArg != null && int.TryParse(nextArg, NumberStyles.Integer, CultureInfo.InvariantCulture, out int valY)) { y = valY; i++; }
                        break;
                    case "--width":
                        if (nextArg != null && int.TryParse(nextArg, NumberStyles.Integer, CultureInfo.InvariantCulture, out int valW)) { width = valW; i++; }
                        break;
                    case "--height":
                        if (nextArg != null && int.TryParse(nextArg, NumberStyles.Integer, CultureInfo.InvariantCulture, out int valH)) { height = valH; i++; }
                        break;
                    case "--minimize":
                        minimize = true;
                        break;
                    case "--maximize":
                        maximize = true;
                        break;
                    case "--restore":
                        restore = true;
                        break;
                    case "--mouse-x":
                        if (nextArg != null && int.TryParse(nextArg, NumberStyles.Integer, CultureInfo.InvariantCulture, out int mx)) { mouseX = mx; i++; }
                        break;
                    case "--mouse-y":
                        if (nextArg != null && int.TryParse(nextArg, NumberStyles.Integer, CultureInfo.InvariantCulture, out int my)) { mouseY = my; i++; }
                        break;
                    case "--click":
                        if (nextArg != null) { mouseClick = nextArg.ToLowerInvariant(); i++; }
                        break;
                    case "--delay":
                        if (nextArg != null && int.TryParse(nextArg, NumberStyles.Integer, CultureInfo.InvariantCulture, out int d)) { delayMs = d; i++; }
                        break;
                }
            }

            // Logging der geparsten Werte
            System.IO.File.AppendAllText("debug.log", $"Parsed mouseX: {mouseX}, mouseY: {mouseY}, click: {mouseClick}{Environment.NewLine}");

            bool found = false;
            bool mouseAction = false;

            // Fenstersteuerung
            if (!string.IsNullOrWhiteSpace(title))
            {
                EnumWindows((hWnd, lParam) =>
                {
                    if (IsWindowVisible(hWnd))
                    {
                        int length = GetWindowTextLength(hWnd);
                        if (length > 0)
                        {
                            var builder = new StringBuilder(length + 1);
                            GetWindowText(hWnd, builder, builder.Capacity);
                            string windowTitle = builder.ToString();

                            if (windowTitle.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                if (GetWindowRect(hWnd, out RECT rect))
                                {
                                    int newX = x ?? rect.Left;
                                    int newY = y ?? rect.Top;
                                    int newW = width ?? (rect.Right - rect.Left);
                                    int newH = height ?? (rect.Bottom - rect.Top);

                                    MoveWindow(hWnd, newX, newY, newW, newH, true);

                                    if (minimize) ShowWindow(hWnd, SW_MINIMIZE);
                                    else if (maximize) ShowWindow(hWnd, SW_MAXIMIZE);
                                    else if (restore) ShowWindow(hWnd, SW_RESTORE);

                                    found = true;
                                    return false;
                                }
                            }
                        }
                    }
                    return true;
                }, IntPtr.Zero);
            }

            // Maussteuerung
            if (mouseX.HasValue && mouseY.HasValue)
            {
                System.Threading.Thread.Sleep(delayMs);
                SetCursorPos(mouseX.Value, mouseY.Value);

                if (mouseClick != "none")
                {
                    SimulateMouseClick(mouseClick);
                }

                mouseAction = true;
            }

            return found || mouseAction;
        }

    }
}
