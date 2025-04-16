// ------------------------------------------------------------
// Nerdy Tool Box – WindowHistoryManager.cs
// Verwaltung von Undo/Redo-Zuständen für Fensterpositionen
// ------------------------------------------------------------

using System.Collections.Generic;
using System;
using NerdyToolBox.Models;

namespace NerdyToolBox
{
    public class WindowHistoryManager
    {
        // ------------------------------------------------------------
        // Stacks zur Verwaltung von Undo-/Redo-Zuständen
        // ------------------------------------------------------------

        private readonly Stack<WindowState> undoStack = new Stack<WindowState>();
        private readonly Stack<WindowState> redoStack = new Stack<WindowState>();

        public bool CanUndo => undoStack.Count > 0;
        public bool CanRedo => redoStack.Count > 0;

        // ------------------------------------------------------------
        // Speichert den aktuellen Zustand (und leert den Redo-Stack)
        // ------------------------------------------------------------
        public void SaveState(WindowState state)
        {
            undoStack.Push(state);
            redoStack.Clear(); // Neue Aktion -> Redo-Zustände verwerfen
        }

        // ------------------------------------------------------------
        // Macht eine Aktion rückgängig
        // ------------------------------------------------------------
        public WindowState Undo(WindowState current)
        {
            if (undoStack.Count == 0)
                return new WindowState(); // Leerer Zustand = ungültig

            redoStack.Push(current);
            return undoStack.Pop();
        }

        // ------------------------------------------------------------
        // Stellt eine rückgängig gemachte Aktion wieder her
        // ------------------------------------------------------------
        public WindowState Redo(WindowState current)
        {
            if (redoStack.Count == 0)
                return new WindowState();

            undoStack.Push(current);
            return redoStack.Pop();
        }
    }
}
