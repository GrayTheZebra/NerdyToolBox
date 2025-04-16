// ------------------------------------------------------------
// Nerdy Tool Box – MouseHelper.cs
// Hilfsklasse für Mausaktionen und Positionierung
// ------------------------------------------------------------

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using NerdyToolBox.Interop;

namespace NerdyToolBox.Helpers
{
    public static class MouseHelper
    {
        // ------------------------------------------------------------
        // Öffentliche Methoden zur Auswahl und Positionsermittlung
        // ------------------------------------------------------------

        /// <summary>
        /// Gibt den aktuell ausgewählten Klicktyp zurück ("left", "right", "middle", "none").
        /// </summary>
        public static string GetSelectedClickType(RadioButton none, RadioButton left, RadioButton right, RadioButton middle)
        {
            if (left.Checked) return "left";
            if (right.Checked) return "right";
            if (middle.Checked) return "middle";
            return "none";
        }

        /// <summary>
        /// Gibt die Bildschirmmitte eines Fensters zurück.
        /// </summary>
        public static Point GetCenterPointOfWindow(IntPtr hWnd)
        {
            if (NativeMethods.GetWindowRect(hWnd, out RECT rect))
            {
                int centerX = rect.Left + (rect.Right - rect.Left) / 2;
                int centerY = rect.Top + (rect.Bottom - rect.Top) / 2;
                return new Point(centerX, centerY);
            }
            return Point.Empty;
        }

        /// <summary>
        /// Gibt die aktuelle Mausposition zurück.
        /// </summary>
        public static Point GetMousePosition()
        {
            if (NativeMethods.GetCursorPos(out POINT pt))
            {
                return new Point(pt.X, pt.Y);
            }
            return Point.Empty;
        }

        /// <summary>
        /// Gibt die Nummer des Monitors zurück, auf dem sich der Punkt befindet.
        /// </summary>
        public static int GetMonitorIndexFromPoint(Point point)
        {
            var screens = Screen.AllScreens;
            for (int i = 0; i < screens.Length; i++)
            {
                if (screens[i].Bounds.Contains(point))
                    return i + 1;
            }
            return -1;
        }

        // ------------------------------------------------------------
        // Maussteuerung & Klick-Simulation
        // ------------------------------------------------------------

        /// <summary>
        /// Setzt die Mausposition und simuliert optional einen Klick.
        /// </summary>
        public static async Task PerformMouseActionAsync(int x, int y, string clickType = null, int delayMs = 1000)
        {
            await Task.Delay(delayMs);
            NativeMethods.SetCursorPos(x, y);

            if (!string.IsNullOrEmpty(clickType))
            {
                SimulateMouseClick(clickType);
            }
        }

        /// <summary>
        /// Führt den gewünschten Mausklick aus.
        /// </summary>
        public static void SimulateMouseClick(string clickType)
        {
            uint down, up;

            switch (clickType.ToLower())
            {
                case "left":
                    down = NativeConstants.MOUSEEVENTF_LEFTDOWN;
                    up = NativeConstants.MOUSEEVENTF_LEFTUP;
                    break;
                case "right":
                    down = NativeConstants.MOUSEEVENTF_RIGHTDOWN;
                    up = NativeConstants.MOUSEEVENTF_RIGHTUP;
                    break;
                case "middle":
                    down = NativeConstants.MOUSEEVENTF_MIDDLEDOWN;
                    up = NativeConstants.MOUSEEVENTF_MIDDLEUP;
                    break;
                default:
                    return; // Keine gültige Aktion
            }

            NativeMethods.mouse_event(down, 0, 0, 0, 0);
            NativeMethods.mouse_event(up, 0, 0, 0, 0);
        }

        // ------------------------------------------------------------
        // Ende MouseHelper
        // ------------------------------------------------------------
    }
}
