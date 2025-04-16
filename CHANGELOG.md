# 📃 CHANGELOG

Alle relevanten Änderungen an der Nerdy Tool Box. Dieser Changelog folgt grob dem [Keep a Changelog](https://keepachangelog.com/de/1.0.0/) Format.

---

## [1.0.0] - 2025-04-16
### Hinzugefügt
- Erste stabile Version mit Fenstersteuerung (Move, Resize, Minimize, Maximize, Restore)
- Vorschaufunktion mit Live-Update
- Undo/Redo-Historie für Fensterzustände
- Mausaktionen mit Delay und Positionierung
- Zwei Arten von CLI-Generatoren: Classic & Smart
- Vollbild-CLI-Generator mit Mausaktion
- Preview-Fenster
- Toolstrip-Menü mit Icons für Exit, Info und Update (noch deaktiviert)
- Minimierung in den Tray mit Ballon-Info
- Tray-Icon aus eingebetteter Ressource
- Komplette Strukturierung der MainForm mit Kommentaren
- Auslagerung von Hilfsklassen und Strukturierung der Namespaces
- Verwendung von Models für gemeinsame Datenklassen
- Erste Version der README.md und CHANGELOG.md für GitHub

### Geändert
- Methoden auf Utility-Klassen ausgelagert (MouseHelper, WindowHelper, CliBuilder, TrayManager)
- Konsistente Benennung und Strukturierung nach Themenbereichen
- Übergang zu konsistenter Namespace-Struktur (z. B. `NerdyToolBox.Models`)
- Alle UI-Aktualisierungen auf Helper ausgelagert

### Entfernt
- Veraltete Methode `UpdatePreviewFrame`

---

## Vorversionen
Keine dokumentierten Versionen vor 1.0.0
