// ------------------------------------------------------------
// Nerdy Tool Box – TrayManager.cs
// Handhabt das Tray-Icon, Kontextmenü und Minimierungsverhalten
// ------------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;

namespace NerdyToolBox.Helpers
{
    public static class TrayManager
    {
        // ------------------------------------------------------------
        // Initialisierung
        // ------------------------------------------------------------

        /// <summary>
        /// Initialisiert das Tray-Icon samt Kontextmenü und Doppelklick-Verhalten.
        /// </summary>
        public static void InitTray(NotifyIcon notifyIcon, ContextMenuStrip trayMenu, Form mainForm)
        {
            notifyIcon.ContextMenuStrip = trayMenu;
            notifyIcon.Icon = new Icon(typeof(TrayManager).Assembly.GetManifestResourceStream("NerdyToolBox.NerdyToolBox.ico"));
            notifyIcon.Text = "Nerdy Tool Box läuft im Hintergrund";

            notifyIcon.DoubleClick += (s, e) => RestoreFromTray(mainForm, notifyIcon);
            trayMenu.ItemClicked += (s, e) => HandleTrayMenuClick(e, mainForm, notifyIcon);
        }

        // ------------------------------------------------------------
        // Menü-Interaktion
        // ------------------------------------------------------------

        /// <summary>
        /// Verarbeitet Klicks im Kontextmenü des Tray-Icons.
        /// </summary>
        public static void HandleTrayMenuClick(ToolStripItemClickedEventArgs e, Form mainForm, NotifyIcon notifyIcon)
        {
            switch (e.ClickedItem.Name)
            {
                case "menuOpen":
                    RestoreFromTray(mainForm, notifyIcon);
                    break;

                case "menuExit":
                    notifyIcon.Visible = false;
                    Application.Exit();
                    break;
            }
        }

        // ------------------------------------------------------------
        // Tray-Verhalten
        // ------------------------------------------------------------

        /// <summary>
        /// Stellt das Fenster aus dem Tray wieder her.
        /// </summary>
        public static void RestoreFromTray(Form mainForm, NotifyIcon notifyIcon)
        {
            mainForm.Show();
            mainForm.WindowState = FormWindowState.Normal;
            mainForm.BringToFront();
            notifyIcon.Visible = false;
        }

        /// <summary>
        /// Handhabt das Minimieren in den Tray beim Schließen des Fensters.
        /// </summary>
        public static bool HandleTrayClose(FormClosingEventArgs e, Form mainForm, NotifyIcon notifyIcon, ref bool alreadyNotifiedOnce)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                mainForm.Hide();
                notifyIcon.Visible = true;

                if (!alreadyNotifiedOnce)
                {
                    notifyIcon.ShowBalloonTip(
                        3000,
                        "NTB läuft weiter",
                        "Die Nerdy Tool Box wurde in den Tray minimiert.",
                        ToolTipIcon.Info
                    );
                    alreadyNotifiedOnce = true;
                }

                return true;
            }

            return false;
        }

        // ------------------------------------------------------------
        // Ende TrayManager
        // ------------------------------------------------------------
    }
}
