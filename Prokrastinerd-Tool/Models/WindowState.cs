// ------------------------------------------------------------
// Nerdy Tool Box – WindowState.cs
// Datenklasse zur Speicherung eines Fensterzustands (Undo/Redo)
// ------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace NerdyToolBox.Models
{
    public class WindowState
    {
        public IntPtr Handle { get; set; }             // Fenster-Handle
        public int X { get; set; }                     // Position links
        public int Y { get; set; }                     // Position oben
        public int Width { get; set; }                 // Breite
        public int Height { get; set; }                // Höhe
        public FormWindowState State { get; set; }     // Normal, Minimiert, Maximiert
    }
}
