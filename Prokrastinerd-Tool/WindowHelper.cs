// ------------------------------------------------------------
// Nerdy Tool Box – WindowHelper.cs
// Hilfsmethoden für Fensterposition, -größe, -status, Vorschau & Undo/Redo
// ------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using FensterTool;
using NerdyToolBox.Interop;
using NerdyToolBox.Models;

namespace NerdyToolBox
{
    public static class WindowHelper
    {
        // ------------------------------------------------------------
        // Allgemeine Fensterinformationen
        // ------------------------------------------------------------

        public static int GetMonitorNumberForPoint(int x, int y)
        {
            var point = new System.Drawing.Point(x, y);
            var screens = Screen.AllScreens;
            for (int i = 0; i < screens.Length; i++)
            {
                if (screens[i].Bounds.Contains(point))
                    return i + 1;
            }
            return -1;
        }

        public static FormWindowState GetWindowState(IntPtr hWnd)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = System.Runtime.InteropServices.Marshal.SizeOf(placement);
            NativeMethods.GetWindowPlacement(hWnd, ref placement);

            switch (placement.showCmd)
            {
                case NativeConstants.SW_MAXIMIZE:
                    return FormWindowState.Maximized;
                case NativeConstants.SW_MINIMIZE:
                    return FormWindowState.Minimized;
                default:
                    return FormWindowState.Normal;
            }
        }

        public static WindowState GetCurrentWindowState(IntPtr hWnd)
        {
            NativeMethods.GetWindowRect(hWnd, out RECT rect);
            return new WindowState
            {
                Handle = hWnd,
                X = rect.Left,
                Y = rect.Top,
                Width = rect.Right - rect.Left,
                Height = rect.Bottom - rect.Top,
                State = GetWindowState(hWnd)
            };
        }

        public static void RestoreWindowState(WindowState state)
        {
            const uint SWP_NOZORDER = 0x0004;
            const uint SWP_SHOWWINDOW = 0x0040;

            NativeMethods.SetWindowPos(state.Handle, IntPtr.Zero,
                state.X, state.Y, state.Width, state.Height,
                SWP_NOZORDER | SWP_SHOWWINDOW);

            int command;

            switch (state.State)
            {
                case FormWindowState.Maximized:
                    command = NativeConstants.SW_MAXIMIZE;
                    break;
                case FormWindowState.Minimized:
                    command = NativeConstants.SW_MINIMIZE;
                    break;
                default:
                    command = NativeConstants.SW_RESTORE;
                    break;
            }

            NativeMethods.ShowWindow(state.Handle, command);
        }

        // ------------------------------------------------------------
        // Fensterliste filtern & anzeigen
        // ------------------------------------------------------------

        public static void FilterWindowList(ListBox listBox, string search)
        {
            listBox.Items.Clear();

            NativeMethods.EnumWindows((hWnd, lParam) =>
            {
                if (NativeMethods.IsWindowVisible(hWnd))
                {
                    int length = NativeMethods.GetWindowTextLength(hWnd);
                    if (length > 0)
                    {
                        StringBuilder classNameBuilder = new StringBuilder(256);
                        NativeMethods.GetClassName(hWnd, classNameBuilder, classNameBuilder.Capacity);
                        string className = classNameBuilder.ToString();

                        if (className == "Progman") return true;

                        StringBuilder builder = new StringBuilder(length + 1);
                        NativeMethods.GetWindowText(hWnd, builder, builder.Capacity);
                        string title = builder.ToString()?.Trim();

                        if (!string.IsNullOrWhiteSpace(title) && title.Length > 2 &&
                            title.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            listBox.Items.Add(new WindowInfo { Handle = hWnd, Title = title });
                        }
                    }
                }
                return true;
            }, IntPtr.Zero);
        }

        // ------------------------------------------------------------
        // Vorschau- & UI-Hilfsfunktionen
        // ------------------------------------------------------------

        public static void ApplyWindowStateToControls(WindowState state, TextBox txtX, TextBox txtY, TextBox txtWidth, TextBox txtHeight)
        {
            txtX.Text = state.X.ToString();
            txtY.Text = state.Y.ToString();
            txtWidth.Text = state.Width.ToString();
            txtHeight.Text = state.Height.ToString();
        }

        public static void UpdateTextboxenFromRect(RECT rect, TextBox txtX, TextBox txtY, TextBox txtWidth, TextBox txtHeight)
        {
            txtX.Text = rect.Left.ToString();
            txtY.Text = rect.Top.ToString();
            txtWidth.Text = (rect.Right - rect.Left).ToString();
            txtHeight.Text = (rect.Bottom - rect.Top).ToString();
        }

        public static void UpdateWindowLabels(WindowInfo win, RECT rect, Label lblHandle, Label lblPosition, Label lblSize, Label lblMonitor, Label lblTitle)
        {
            lblHandle.Text = $"Handle: {win.Handle}";
            lblPosition.Text = $"Position: X={rect.Left}, Y={rect.Top}";
            lblSize.Text = $"Größe: {rect.Right - rect.Left} x {rect.Bottom - rect.Top}";
            lblMonitor.Text = $"Monitor: {GetMonitorNumberForPoint(rect.Left, rect.Top)}";
            lblTitle.Text = $"Titel: {win.Title}";
        }

        public static void UpdateProcessLabel(IntPtr hWnd, Label lblProcess)
        {
            NativeMethods.GetWindowThreadProcessId(hWnd, out uint processId);
            try
            {
                var proc = Process.GetProcessById((int)processId);
                lblProcess.Text = $"Prozess: {proc.ProcessName}.exe";
            }
            catch
            {
                lblProcess.Text = "Prozess: unbekannt";
            }
        }

        public static void UpdatePreviewFromTextboxes(TextBox txtX, TextBox txtY, TextBox txtWidth, TextBox txtHeight, PreviewForm preview)
        {
            if (int.TryParse(txtX.Text, out int x) &&
                int.TryParse(txtY.Text, out int y) &&
                int.TryParse(txtWidth.Text, out int width) &&
                int.TryParse(txtHeight.Text, out int height))
            {
                preview.UpdatePreview(x, y, width, height);
            }
        }

        // ------------------------------------------------------------
        // Fensteraktionen: Verschieben & Größenänderung
        // ------------------------------------------------------------

        public static bool TryResizeWindow(IntPtr hWnd, int width, int height, out RECT updatedRect)
        {
            updatedRect = new RECT();

            if (!NativeMethods.GetWindowRect(hWnd, out RECT originalRect))
                return false;

            bool moved = NativeMethods.MoveWindow(hWnd, originalRect.Left, originalRect.Top, width, height, true);
            return moved && NativeMethods.GetWindowRect(hWnd, out updatedRect);
        }

        public static bool TryMoveWindow(IntPtr hWnd, int x, int y, int width, int height, out RECT updatedRect)
        {
            updatedRect = new RECT();
            bool moved = NativeMethods.MoveWindow(hWnd, x, y, width, height, true);
            return moved && NativeMethods.GetWindowRect(hWnd, out updatedRect);
        }

        public static bool TryParseWindowRect(TextBox txtX, TextBox txtY, TextBox txtWidth, TextBox txtHeight, out int x, out int y, out int width, out int height)
        {
            x = y = width = height = 0;

            return int.TryParse(txtX.Text, out x) &&
                   int.TryParse(txtY.Text, out y) &&
                   int.TryParse(txtWidth.Text, out width) &&
                   int.TryParse(txtHeight.Text, out height);
        }

        // ------------------------------------------------------------
        // Fensterzustände & Undo/Redo
        // ------------------------------------------------------------

        public static bool ApplyHistoryStep(
            WindowInfo win,
            WindowHistoryManager historyManager,
            Func<WindowState, WindowState> action,
            Action<WindowState> applyToUI)
        {
            if (win == null) return false;

            var current = GetCurrentWindowState(win.Handle);
            var result = action(current);

            if (result != null && result.Handle != IntPtr.Zero)
            {
                RestoreWindowState(result);
                applyToUI(result);
                return true;
            }

            return false;
        }

        public static void ChangeWindowState(WindowInfo win, int command, WindowHistoryManager historyManager)
        {
            if (win == null) return;

            if (NativeMethods.GetWindowRect(win.Handle, out RECT _))
            {
                var state = new WindowState
                {
                    Handle = win.Handle,
                    State = GetWindowState(win.Handle)
                };

                historyManager.SaveState(state);
                NativeMethods.ShowWindow(win.Handle, command);
            }
        }

        // ------------------------------------------------------------
        // Sonstige Helfer
        // ------------------------------------------------------------

        public static void CopyTextIfNotEmpty(TextBox textBox)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
                Clipboard.SetText(textBox.Text);
        }
    }
}
