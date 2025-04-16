// ------------------------------------------------------------
// Nerdy Tool Box – NativeConstants.cs
// Native Konstanten für Fenster- und Mauseingaben (WinAPI)
// ------------------------------------------------------------

namespace NerdyToolBox.Interop
{
    public static class NativeConstants
    {
        // ------------------------------------------------------------
        // Maus-Events (für mouse_event)
        // ------------------------------------------------------------

        public const uint MOUSEEVENTF_LEFTDOWN = 0x0002; // Linke Maustaste drücken
        public const uint MOUSEEVENTF_LEFTUP = 0x0004; // Linke Maustaste loslassen
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x0008; // Rechte Maustaste drücken
        public const uint MOUSEEVENTF_RIGHTUP = 0x0010; // Rechte Maustaste loslassen
        public const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020; // Mittlere Maustaste drücken
        public const uint MOUSEEVENTF_MIDDLEUP = 0x0040; // Mittlere Maustaste loslassen

        // ------------------------------------------------------------
        // Fensterzustände (für ShowWindow)
        // ------------------------------------------------------------

        public const int SW_RESTORE = 9; // Fenster wiederherstellen
        public const int SW_MAXIMIZE = 3; // Fenster maximieren
        public const int SW_MINIMIZE = 6; // Fenster minimieren
    }
}
