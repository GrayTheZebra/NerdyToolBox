// ------------------------------------------------------------
// Nerdy Tool Box – CliBuilder.cs
// Baut Kommandozeilenbefehle für Fenster- und Mausaktionen
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using NerdyToolBox.Interop;
using NerdyToolBox.Helpers;
using NerdyToolBox.Models;

namespace NerdyToolBox.Helpers
{
    public static class CliBuilder
    {
        // ------------------------------------------------------------
        // Fensterbezogene CLI-Kommandos
        // ------------------------------------------------------------

        /// <summary>
        /// Erstellt einen klassischen CLI-Befehl mit festen Positionen und Größenangaben.
        /// </summary>
        public static string BuildClassic(WindowInfo win)
        {
            if (win == null || !NativeMethods.GetWindowRect(win.Handle, out RECT rect))
                return string.Empty;

            string titleEscaped = win.Title.Replace("\"", "\\\"");
            int x = rect.Left;
            int y = rect.Top;
            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;

            return $"NerdyToolBox.exe --title \"{titleEscaped}\" --x {x} --y {y} --width {width} --height {height} --exit";
        }

        /// <summary>
        /// Erstellt ein intelligentes Kommando basierend auf Fensterstatus und Monitorposition.
        /// </summary>
        public static string BuildSmart(WindowInfo win)
        {
            if (win == null)
                return string.Empty;

            string titleEscaped = win.Title.Replace("\"", "\\\"");

            bool minimized = NativeMethods.IsIconic(win.Handle);
            bool maximized = NativeMethods.IsZoomed(win.Handle);

            var point = MouseHelper.GetCenterPointOfWindow(win.Handle);
            int monitorIndex = MouseHelper.GetMonitorIndexFromPoint(point);

            string action;
            if (maximized)
                action = "--maximize";
            else if (minimized)
                action = "--minimize";
            else
                action = "--restore";

            return $"NerdyToolBox.exe --title \"{titleEscaped}\" --monitor {monitorIndex} {action} --exit";
        }

        /// <summary>
        /// Kombiniert Fenster-, Maus- und Delay-Daten zu einem vollständigen Kommando.
        /// </summary>
        public static string BuildFull(WindowInfo win, int mouseX, int mouseY, int delay, string clickType, string action)
        {
            if (win == null || !NativeMethods.GetWindowRect(win.Handle, out RECT rect))
                return string.Empty;

            string titleEscaped = win.Title.Replace("\"", "\\\"");
            int x = rect.Left;
            int y = rect.Top;
            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;

            var parts = new List<string>
            {
                $"NerdyToolBox.exe",
                $"--title \"{titleEscaped}\"",
                $"--x {x}",
                $"--y {y}",
                $"--width {width}",
                $"--height {height}"
            };

            if (!string.IsNullOrEmpty(action))
                parts.Add(action);

            parts.Add($"--mouse-x {mouseX}");
            parts.Add($"--mouse-y {mouseY}");
            parts.Add($"--click {clickType}");
            parts.Add($"--delay {delay}");
            parts.Add("--exit");

            return string.Join(" ", parts);
        }

        // ------------------------------------------------------------
        // Mausaktion als eigenständiges CLI-Kommando
        // ------------------------------------------------------------

        /// <summary>
        /// Erzeugt ein Mauskommando ohne Fensterbezug.
        /// </summary>
        public static string BuildMouseCommand(int x, int y, int delay, string clickType)
        {
            return $"NerdyToolBox.exe --mouse-x {x} --mouse-y {y} --click {clickType} --delay {delay} --exit";
        }

        // ------------------------------------------------------------
        // Ende CliBuilder
        // ------------------------------------------------------------
    }
}
