// ------------------------------------------------------------
// Nerdy Tool Box – MainForm.cs
// Strukturierte Hauptklasse mit GUI-Logik und delegierten Helfermethoden
// ------------------------------------------------------------

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NerdyToolBox;
using NerdyToolBox.Helpers;
using NerdyToolBox.Interop;
using NerdyToolBox.Models;

namespace FensterTool
{
    public partial class MainForm : Form
    {
        // ------------------------------------------------------------
        // Felder & Setup
        // ------------------------------------------------------------

        private WindowInfo _activeWindow;
        private WindowHistoryManager historyManager = new WindowHistoryManager();
        private PreviewForm previewForm = new PreviewForm();
        private IntPtr lastWindowHandle = IntPtr.Zero;
        private Timer timerAlwaysMaximized = new Timer();
        private bool alreadyNotifiedOnce = false;

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        // ------------------------------------------------------------
        // Konstruktor
        // ------------------------------------------------------------
        public MainForm()
        {
            InitializeComponent();

            InitMenuBar();
            TrayManager.InitTray(notifyIconNTB, trayMenu, this);

            timerAlwaysMaximized.Interval = 500;
            timerAlwaysMaximized.Tick += AlwaysMaximizedMonitor_Tick;
            timerAlwaysMaximized.Start();
            timerMouse.Interval = 100;
            timerMouse.Tick += TimerMouse_Tick;
            timerMouse.Start();
            WindowHelper.FilterWindowList(listBoxWindows, txtSearch.Text);
            previewForm.Show();
            previewForm.Visible = chkPreviewEnabled.Checked;
            UpdateUndoRedoButtons();
        }

        // ------------------------------------------------------------
        // CLI-Befehlserzeugung
        // ------------------------------------------------------------

        private void btnCopyMouseCli_Click(object sender, EventArgs e)
        {
            WindowHelper.CopyTextIfNotEmpty(textBoxMouseCli);
        }

        private void btnCopyCliFull_Click(object sender, EventArgs e)
        {
            WindowHelper.CopyTextIfNotEmpty(txtCliFull);
        }

        private void UpdateCliClassic(WindowInfo win)
        {
            txtCliClassic.Text = CliBuilder.BuildClassic(win);
            UpdateCliFull(win);
        }

        private void UpdateCliSmart(WindowInfo win)
        {
            txtCliSmart.Text = CliBuilder.BuildSmart(win);
        }

        private void UpdatePreview(object sender, EventArgs e)
        {
            if (!chkPreviewEnabled.Checked) return;
            WindowHelper.UpdatePreviewFromTextboxes(txtX, txtY, txtWidth, txtHeight, previewForm);
        }

        private void UpdateCliFull(WindowInfo win)
        {
            int mouseX = (int)numericX.Value;
            int mouseY = (int)numericY.Value;
            int delay = (int)numericDelay.Value;
            string clickType = MouseHelper.GetSelectedClickType(radioNone, radioLeft, radioRight, radioMiddle);

            string action = buttonMinimieren.Focused ? "--minimize" :
                            buttonMaximieren.Focused ? "--maximize" :
                            buttonWiederherstellen.Focused ? "--restore" :
                            "";

            txtCliFull.Text = CliBuilder.BuildFull(win, mouseX, mouseY, delay, clickType, action);
        }

        private void UpdateMouseCliPreview(object sender, EventArgs e)
        {
            int x = (int)numericX.Value;
            int y = (int)numericY.Value;
            int delay = (int)numericDelay.Value;
            string clickType = MouseHelper.GetSelectedClickType(radioNone, radioLeft, radioRight, radioMiddle);

            textBoxMouseCli.Text = CliBuilder.BuildMouseCommand(x, y, delay, clickType);

            if (_activeWindow != null)
                UpdateCliFull(_activeWindow);
        }

        // ------------------------------------------------------------
        // Fensterauswahl & Vorschau-Logik
        // ------------------------------------------------------------
        private void listBoxWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxWindows.SelectedItem is WindowInfo win &&
                NativeMethods.GetWindowRect(win.Handle, out RECT rect))
            {
                WindowHelper.UpdateTextboxenFromRect(rect, txtX, txtY, txtWidth, txtHeight);
                WindowHelper.UpdateWindowLabels(win, rect, lblHandle, lblPosition, lblSize, lblMonitor, lblTitle);
                WindowHelper.UpdateProcessLabel(win.Handle, lblProcess);

                _activeWindow = win;
                UpdateCliClassic(win);
                UpdateCliSmart(win);
            }
        }

        private void AlwaysMaximizedMonitor_Tick(object sender, EventArgs e)
        {
            if (chkAlwaysMaximized.Checked && listBoxWindows.SelectedItem is WindowInfo win)
            {
                if (!NativeMethods.IsZoomed(win.Handle))
                {
                    NativeMethods.ShowWindow(win.Handle, NativeConstants.SW_MAXIMIZE);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            WindowHelper.FilterWindowList(listBoxWindows, txtSearch.Text);
        }

        private void chkPreviewEnabled_CheckedChanged(object sender, EventArgs e)
        {
            previewForm.Visible = chkPreviewEnabled.Checked;
        }

        // ------------------------------------------------------------
        // Button-Events: Verschieben / Größe ändern
        // ------------------------------------------------------------
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            WindowHelper.FilterWindowList(listBoxWindows, txtSearch.Text);
        }

        private async void btnExecuteMouseAction_Click(object sender, EventArgs e)
        {
            int x = (int)numericX.Value;
            int y = (int)numericY.Value;
            string clickType = MouseHelper.GetSelectedClickType(radioNone, radioLeft, radioRight, radioMiddle);
            int delayMs = (int)numericDelay.Value;
            await MouseHelper.PerformMouseActionAsync(x, y, clickType, delayMs);
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (listBoxWindows.SelectedItem is WindowInfo selectedWindow)
            {
                if (WindowHelper.TryParseWindowRect(txtX, txtY, txtWidth, txtHeight, out int x, out int y, out int width, out int height))
                {
                    SaveWindowStateForUndo(selectedWindow.Handle);

                    if (WindowHelper.TryMoveWindow(selectedWindow.Handle, x, y, width, height, out RECT updatedRect))
                    {
                        WindowHelper.UpdateTextboxenFromRect(updatedRect, txtX, txtY, txtWidth, txtHeight);
                        UpdateCliClassic(selectedWindow);
                        UpdateCliSmart(selectedWindow);
                    }
                    else
                    {
                        MessageBox.Show("Fehler beim Verschieben des Fensters.");
                    }
                }
                else
                {
                    MessageBox.Show("Bitte gültige Zahlen für X, Y, Breite und Höhe eingeben.");
                }
            }
            else
            {
                MessageBox.Show("Bitte ein Fenster aus der Liste auswählen.");
            }
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (listBoxWindows.SelectedItem is WindowInfo selectedWindow)
            {
                if (WindowHelper.TryParseWindowRect(txtX, txtY, txtWidth, txtHeight, out int x, out int y, out int width, out int height))
                {
                    SaveWindowStateForUndo(selectedWindow.Handle);

                    if (WindowHelper.TryResizeWindow(selectedWindow.Handle, width, height, out RECT updatedRect))
                    {
                        WindowHelper.UpdateTextboxenFromRect(updatedRect, txtX, txtY, txtWidth, txtHeight);
                        UpdateCliClassic(selectedWindow);
                        UpdateCliSmart(selectedWindow);
                    }
                    else
                    {
                        MessageBox.Show("Fehler beim Anpassen des Fensters.");
                    }
                }
                else
                {
                    MessageBox.Show("Bitte gültige Zahlen für Breite und Höhe eingeben.");
                }
            }
            else
            {
                MessageBox.Show("Bitte ein Fenster aus der Liste auswählen.");
            }
        }

        // ------------------------------------------------------------
        // Fenstersteuerung (Min/Max/Restore)
        // ------------------------------------------------------------

        

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (listBoxWindows.SelectedItem is WindowInfo win)
            {
                WindowHelper.ChangeWindowState(win, NativeConstants.SW_MINIMIZE, historyManager);
            }
        }


        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (listBoxWindows.SelectedItem is WindowInfo win)
            {
                WindowHelper.ChangeWindowState(win, NativeConstants.SW_MAXIMIZE, historyManager);
            }
        }


        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (listBoxWindows.SelectedItem is WindowInfo win)
            {
                WindowHelper.ChangeWindowState(win, NativeConstants.SW_RESTORE, historyManager);
            }
        }

        // ------------------------------------------------------------
        // Undo / Redo
        // ------------------------------------------------------------
        private void UpdateTextboxenFromState(WindowState state)
        {
            WindowHelper.ApplyWindowStateToControls(state, txtX, txtY, txtWidth, txtHeight);

            if (listBoxWindows.SelectedItem is WindowInfo win && win.Handle == state.Handle)
            {
                UpdateCliClassic(win);
                UpdateCliSmart(win);
            }
        }

        private void SaveWindowStateForUndo(IntPtr hWnd)
        {
            if (NativeMethods.GetWindowRect(hWnd, out RECT rect))
            {
                var state = new WindowState
                {
                    Handle = hWnd,
                    X = rect.Left,
                    Y = rect.Top,
                    Width = rect.Right - rect.Left,
                    Height = rect.Bottom - rect.Top,
                    State = WindowHelper.GetWindowState(hWnd)
                };

                historyManager.SaveState(state);
                UpdateUndoRedoButtons();
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (listBoxWindows.SelectedItem is WindowInfo win)
            {
                bool done = WindowHelper.ApplyHistoryStep(win, historyManager, historyManager.Redo, UpdateTextboxenFromState);
                if (done)
                    UpdateUndoRedoButtons();
                else
                    MessageBox.Show("Kein Redo verfügbar.", "Redo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bitte ein Fenster auswählen.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (listBoxWindows.SelectedItem is WindowInfo win)
            {
                bool done = WindowHelper.ApplyHistoryStep(win, historyManager, historyManager.Undo, UpdateTextboxenFromState);
                if (done)
                    UpdateUndoRedoButtons();
                else
                    MessageBox.Show("Kein Undo verfügbar.", "Undo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bitte ein Fenster auswählen.", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateUndoRedoButtons()
        {
            btnUndo.Enabled = historyManager.CanUndo;
            btnRedo.Enabled = historyManager.CanRedo;
        }

        // ------------------------------------------------------------
        // Copy-Buttons
        // ------------------------------------------------------------
        private void btnCopySmart_Click(object sender, EventArgs e)
        {
            WindowHelper.CopyTextIfNotEmpty(txtCliSmart);
        }

        private void btnCopyCommand_Click(object sender, EventArgs e)
        {
            WindowHelper.CopyTextIfNotEmpty(txtCliClassic);
        }

        // ------------------------------------------------------------
        // Menüleiste & Tray-Handling
        // ------------------------------------------------------------
        private void InitMenuBar()
        {
            ToolStrip toolStrip = new ToolStrip
            {
                Dock = DockStyle.Top,
                GripStyle = ToolStripGripStyle.Hidden,
                RenderMode = ToolStripRenderMode.System,
                BackColor = SystemColors.ControlLight
            };

            string iconPath;

            // Beenden-Button
            iconPath = Path.Combine(Application.StartupPath, "icons", "icon_exit.png");
            ToolStripButton btnExit = new ToolStripButton
            {
                Image = System.Drawing.Image.FromFile(iconPath),
                ToolTipText = "Beenden",
                DisplayStyle = ToolStripItemDisplayStyle.Image
            };
            btnExit.Click += (s, e) => System.Windows.Forms.Application.Exit();
            toolStrip.Items.Add(btnExit);

            // Über-Button
            iconPath = Path.Combine(Application.StartupPath, "icons", "icon_info.png");
            ToolStripButton btnAbout = new ToolStripButton
            {
                Image = System.Drawing.Image.FromFile(iconPath),
                ToolTipText = "Über Nerdy Tool Box",
                DisplayStyle = ToolStripItemDisplayStyle.Image
            };
            btnAbout.Click += (s, e) =>
            {
                MessageBox.Show("Nerdy Tool Box\nVersion 1.0\nby Gray The Zebra", "Über", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            toolStrip.Items.Add(btnAbout);

            // Update prüfen (deaktiviert)
            iconPath = Path.Combine(Application.StartupPath, "icons", "icon_update.png");
            ToolStripButton btnUpdate = new ToolStripButton
            {
                Image = System.Drawing.Image.FromFile(iconPath),
                ToolTipText = "Update prüfen (noch nicht verfügbar)",
                Enabled = false,
                DisplayStyle = ToolStripItemDisplayStyle.Image
            };
            toolStrip.Items.Add(btnUpdate);

            this.Controls.Add(toolStrip);
        }

        private void TimerMouse_Tick(object sender, EventArgs e)
        {
            if (NativeMethods.GetCursorPos(out POINT point))
            {
                lblMouseX.Text = $"X: {point.X}";
                lblMouseY.Text = $"Y: {point.Y}";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!TrayManager.HandleTrayClose(e, this, notifyIconNTB, ref alreadyNotifiedOnce))
            {
                base.OnFormClosing(e);
            }
        }

        // ------------------------------------------------------------
        // Ende MainForm
        // ------------------------------------------------------------
    }
}
