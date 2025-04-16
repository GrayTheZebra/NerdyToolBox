using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System;

namespace FensterTool
{
    public class PreviewForm : Form
    {
        // Konstante für WS_EX_TRANSPARENT
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int WS_EX_NOACTIVATE = 0x8000000;
        private const int WS_EX_TOOLWINDOW = 0x80;

        // Import für Fensterstil setzen
        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        private const int GWL_EXSTYLE = -20;


        public PreviewForm()
        {
            this.Load += (s, e) =>
            {
                int exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
                exStyle |= WS_EX_TRANSPARENT | WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW;
                SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle);
            };

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(0);
            this.Margin = new Padding(0);
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.LimeGreen;
            this.Opacity = 0.3;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;
        }

        public void UpdatePreview(int x, int y, int width, int height)
        {
            this.Bounds = new Rectangle(x, y, width, height);
        }
    }
}
