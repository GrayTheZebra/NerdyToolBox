namespace FensterTool
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBoxWindows = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.timerMouse = new System.Windows.Forms.Timer(this.components);
            this.groupBoxWindows = new System.Windows.Forms.GroupBox();
            this.txtSearchLabel = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBoxPosition = new System.Windows.Forms.GroupBox();
            this.chkAlwaysMaximized = new System.Windows.Forms.CheckBox();
            this.chkPreviewEnabled = new System.Windows.Forms.CheckBox();
            this.btnResize = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.yPosLabel = new System.Windows.Forms.Label();
            this.xPosLabel = new System.Windows.Forms.Label();
            this.groupBoxMouse = new System.Windows.Forms.GroupBox();
            this.lblMouseY = new System.Windows.Forms.Label();
            this.lblMouseX = new System.Windows.Forms.Label();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.lblProcess = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMonitor = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblHandle = new System.Windows.Forms.Label();
            this.cliGroupbox = new System.Windows.Forms.GroupBox();
            this.CLIFullLabel = new System.Windows.Forms.Label();
            this.btnCopyFullCli = new System.Windows.Forms.Button();
            this.txtCliFull = new System.Windows.Forms.TextBox();
            this.btnCopyMouseCli = new System.Windows.Forms.Button();
            this.textBoxMouseCli = new System.Windows.Forms.TextBox();
            this.CLUMausLabel = new System.Windows.Forms.Label();
            this.CLIFensterSmartLabel = new System.Windows.Forms.Label();
            this.CLIFensterClassicLabel = new System.Windows.Forms.Label();
            this.btnCopySmart = new System.Windows.Forms.Button();
            this.txtCliSmart = new System.Windows.Forms.TextBox();
            this.btnCopyClassic = new System.Windows.Forms.Button();
            this.txtCliClassic = new System.Windows.Forms.TextBox();
            this.buttonMinimieren = new System.Windows.Forms.Button();
            this.buttonMaximieren = new System.Windows.Forms.Button();
            this.buttonWiederherstellen = new System.Windows.Forms.Button();
            this.WindowButtonsGroupBox = new System.Windows.Forms.GroupBox();
            this.globalFensterGroupBox = new System.Windows.Forms.GroupBox();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.notifyIconNTB = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.globalMausGroupBox = new System.Windows.Forms.GroupBox();
            this.MauspositionGroupBox = new System.Windows.Forms.GroupBox();
            this.delayLabel = new System.Windows.Forms.Label();
            this.numericDelay = new System.Windows.Forms.NumericUpDown();
            this.radioMiddle = new System.Windows.Forms.RadioButton();
            this.radioRight = new System.Windows.Forms.RadioButton();
            this.radioNone = new System.Windows.Forms.RadioButton();
            this.radioLeft = new System.Windows.Forms.RadioButton();
            this.btnExecuteMouseAction = new System.Windows.Forms.Button();
            this.setMausY = new System.Windows.Forms.Label();
            this.numericY = new System.Windows.Forms.NumericUpDown();
            this.setMausX = new System.Windows.Forms.Label();
            this.numericX = new System.Windows.Forms.NumericUpDown();
            this.groupBoxWindows.SuspendLayout();
            this.groupBoxPosition.SuspendLayout();
            this.groupBoxMouse.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.cliGroupbox.SuspendLayout();
            this.WindowButtonsGroupBox.SuspendLayout();
            this.globalFensterGroupBox.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.globalMausGroupBox.SuspendLayout();
            this.MauspositionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxWindows
            // 
            this.listBoxWindows.FormattingEnabled = true;
            this.listBoxWindows.Location = new System.Drawing.Point(6, 45);
            this.listBoxWindows.Name = "listBoxWindows";
            this.listBoxWindows.Size = new System.Drawing.Size(300, 329);
            this.listBoxWindows.TabIndex = 0;
            this.listBoxWindows.SelectedIndexChanged += new System.EventHandler(this.listBoxWindows_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(231, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(173, 14);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = "move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(48, 16);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(119, 20);
            this.txtX.TabIndex = 4;
            this.txtX.TextChanged += new System.EventHandler(this.UpdatePreview);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(48, 42);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(119, 20);
            this.txtY.TabIndex = 5;
            this.txtY.TextChanged += new System.EventHandler(this.UpdatePreview);
            // 
            // timerMouse
            // 
            this.timerMouse.Enabled = true;
            this.timerMouse.Tick += new System.EventHandler(this.TimerMouse_Tick);
            // 
            // groupBoxWindows
            // 
            this.groupBoxWindows.Controls.Add(this.txtSearchLabel);
            this.groupBoxWindows.Controls.Add(this.txtSearch);
            this.groupBoxWindows.Controls.Add(this.listBoxWindows);
            this.groupBoxWindows.Controls.Add(this.btnRefresh);
            this.groupBoxWindows.Location = new System.Drawing.Point(7, 19);
            this.groupBoxWindows.Name = "groupBoxWindows";
            this.groupBoxWindows.Size = new System.Drawing.Size(315, 390);
            this.groupBoxWindows.TabIndex = 6;
            this.groupBoxWindows.TabStop = false;
            this.groupBoxWindows.Text = "Fensterliste";
            // 
            // txtSearchLabel
            // 
            this.txtSearchLabel.AutoSize = true;
            this.txtSearchLabel.Location = new System.Drawing.Point(3, 19);
            this.txtSearchLabel.Name = "txtSearchLabel";
            this.txtSearchLabel.Size = new System.Drawing.Size(44, 13);
            this.txtSearchLabel.TabIndex = 3;
            this.txtSearchLabel.Text = "Suchen";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(53, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(172, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // groupBoxPosition
            // 
            this.groupBoxPosition.Controls.Add(this.chkAlwaysMaximized);
            this.groupBoxPosition.Controls.Add(this.chkPreviewEnabled);
            this.groupBoxPosition.Controls.Add(this.btnResize);
            this.groupBoxPosition.Controls.Add(this.txtHeight);
            this.groupBoxPosition.Controls.Add(this.txtWidth);
            this.groupBoxPosition.Controls.Add(this.lblHeight);
            this.groupBoxPosition.Controls.Add(this.lblWidth);
            this.groupBoxPosition.Controls.Add(this.yPosLabel);
            this.groupBoxPosition.Controls.Add(this.xPosLabel);
            this.groupBoxPosition.Controls.Add(this.txtX);
            this.groupBoxPosition.Controls.Add(this.txtY);
            this.groupBoxPosition.Controls.Add(this.btnMove);
            this.groupBoxPosition.Location = new System.Drawing.Point(328, 19);
            this.groupBoxPosition.Name = "groupBoxPosition";
            this.groupBoxPosition.Size = new System.Drawing.Size(361, 148);
            this.groupBoxPosition.TabIndex = 7;
            this.groupBoxPosition.TabStop = false;
            this.groupBoxPosition.Text = "Fensterposition";
            // 
            // chkAlwaysMaximized
            // 
            this.chkAlwaysMaximized.AutoSize = true;
            this.chkAlwaysMaximized.Location = new System.Drawing.Point(111, 124);
            this.chkAlwaysMaximized.Name = "chkAlwaysMaximized";
            this.chkAlwaysMaximized.Size = new System.Drawing.Size(132, 17);
            this.chkAlwaysMaximized.TabIndex = 18;
            this.chkAlwaysMaximized.Text = "Immer maximiert halten";
            this.chkAlwaysMaximized.UseVisualStyleBackColor = true;
            // 
            // chkPreviewEnabled
            // 
            this.chkPreviewEnabled.AutoSize = true;
            this.chkPreviewEnabled.Location = new System.Drawing.Point(10, 124);
            this.chkPreviewEnabled.Name = "chkPreviewEnabled";
            this.chkPreviewEnabled.Size = new System.Drawing.Size(94, 17);
            this.chkPreviewEnabled.TabIndex = 17;
            this.chkPreviewEnabled.Text = "Live-Vorschau";
            this.chkPreviewEnabled.UseVisualStyleBackColor = true;
            this.chkPreviewEnabled.CheckedChanged += new System.EventHandler(this.chkPreviewEnabled_CheckedChanged);
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(173, 69);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(75, 23);
            this.btnResize.TabIndex = 12;
            this.btnResize.Text = "resize";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(48, 98);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(119, 20);
            this.txtHeight.TabIndex = 11;
            this.txtHeight.TextChanged += new System.EventHandler(this.UpdatePreview);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(48, 71);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(119, 20);
            this.txtWidth.TabIndex = 10;
            this.txtWidth.TextChanged += new System.EventHandler(this.UpdatePreview);
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(7, 101);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(36, 13);
            this.lblHeight.TabIndex = 9;
            this.lblHeight.Text = "Höhe:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(7, 74);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(37, 13);
            this.lblWidth.TabIndex = 8;
            this.lblWidth.Text = "Breite:";
            // 
            // yPosLabel
            // 
            this.yPosLabel.AutoSize = true;
            this.yPosLabel.Location = new System.Drawing.Point(7, 45);
            this.yPosLabel.Name = "yPosLabel";
            this.yPosLabel.Size = new System.Drawing.Size(35, 13);
            this.yPosLabel.TabIndex = 7;
            this.yPosLabel.Text = "Y-Pos";
            // 
            // xPosLabel
            // 
            this.xPosLabel.AutoSize = true;
            this.xPosLabel.Location = new System.Drawing.Point(7, 19);
            this.xPosLabel.Name = "xPosLabel";
            this.xPosLabel.Size = new System.Drawing.Size(35, 13);
            this.xPosLabel.TabIndex = 6;
            this.xPosLabel.Text = "X-Pos";
            // 
            // groupBoxMouse
            // 
            this.groupBoxMouse.Controls.Add(this.lblMouseY);
            this.groupBoxMouse.Controls.Add(this.lblMouseX);
            this.groupBoxMouse.Location = new System.Drawing.Point(6, 23);
            this.groupBoxMouse.Name = "groupBoxMouse";
            this.groupBoxMouse.Size = new System.Drawing.Size(266, 57);
            this.groupBoxMouse.TabIndex = 8;
            this.groupBoxMouse.TabStop = false;
            this.groupBoxMouse.Text = "Mausposition";
            // 
            // lblMouseY
            // 
            this.lblMouseY.AutoSize = true;
            this.lblMouseY.Location = new System.Drawing.Point(9, 37);
            this.lblMouseY.Name = "lblMouseY";
            this.lblMouseY.Size = new System.Drawing.Size(14, 13);
            this.lblMouseY.TabIndex = 1;
            this.lblMouseY.Text = "Y";
            // 
            // lblMouseX
            // 
            this.lblMouseX.AutoSize = true;
            this.lblMouseX.Location = new System.Drawing.Point(9, 20);
            this.lblMouseX.Name = "lblMouseX";
            this.lblMouseX.Size = new System.Drawing.Size(14, 13);
            this.lblMouseX.TabIndex = 0;
            this.lblMouseX.Text = "X";
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.lblProcess);
            this.groupBoxDetails.Controls.Add(this.lblTitle);
            this.groupBoxDetails.Controls.Add(this.lblMonitor);
            this.groupBoxDetails.Controls.Add(this.lblSize);
            this.groupBoxDetails.Controls.Add(this.lblPosition);
            this.groupBoxDetails.Controls.Add(this.lblHandle);
            this.groupBoxDetails.Location = new System.Drawing.Point(329, 242);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(360, 104);
            this.groupBoxDetails.TabIndex = 9;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Fensterdetails";
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(6, 81);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(50, 13);
            this.lblProcess.TabIndex = 5;
            this.lblProcess.Text = "Prozess: ";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(6, 68);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 13);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Titel: ";
            // 
            // lblMonitor
            // 
            this.lblMonitor.AutoSize = true;
            this.lblMonitor.Location = new System.Drawing.Point(5, 55);
            this.lblMonitor.Name = "lblMonitor";
            this.lblMonitor.Size = new System.Drawing.Size(48, 13);
            this.lblMonitor.TabIndex = 3;
            this.lblMonitor.Text = "Monitor: ";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(6, 42);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(42, 13);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Größe: ";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(6, 29);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(50, 13);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "Position: ";
            // 
            // lblHandle
            // 
            this.lblHandle.AutoSize = true;
            this.lblHandle.Location = new System.Drawing.Point(6, 16);
            this.lblHandle.Name = "lblHandle";
            this.lblHandle.Size = new System.Drawing.Size(47, 13);
            this.lblHandle.TabIndex = 0;
            this.lblHandle.Text = "Handle: ";
            // 
            // cliGroupbox
            // 
            this.cliGroupbox.Controls.Add(this.CLIFullLabel);
            this.cliGroupbox.Controls.Add(this.btnCopyFullCli);
            this.cliGroupbox.Controls.Add(this.txtCliFull);
            this.cliGroupbox.Controls.Add(this.btnCopyMouseCli);
            this.cliGroupbox.Controls.Add(this.textBoxMouseCli);
            this.cliGroupbox.Controls.Add(this.CLUMausLabel);
            this.cliGroupbox.Controls.Add(this.CLIFensterSmartLabel);
            this.cliGroupbox.Controls.Add(this.CLIFensterClassicLabel);
            this.cliGroupbox.Controls.Add(this.btnCopySmart);
            this.cliGroupbox.Controls.Add(this.txtCliSmart);
            this.cliGroupbox.Controls.Add(this.btnCopyClassic);
            this.cliGroupbox.Controls.Add(this.txtCliClassic);
            this.cliGroupbox.Location = new System.Drawing.Point(12, 457);
            this.cliGroupbox.Name = "cliGroupbox";
            this.cliGroupbox.Size = new System.Drawing.Size(985, 133);
            this.cliGroupbox.TabIndex = 10;
            this.cliGroupbox.TabStop = false;
            this.cliGroupbox.Text = "CLI";
            // 
            // CLIFullLabel
            // 
            this.CLIFullLabel.AutoSize = true;
            this.CLIFullLabel.Location = new System.Drawing.Point(6, 105);
            this.CLIFullLabel.Name = "CLIFullLabel";
            this.CLIFullLabel.Size = new System.Drawing.Size(77, 13);
            this.CLIFullLabel.TabIndex = 11;
            this.CLIFullLabel.Text = "CLI Vollständig";
            // 
            // btnCopyFullCli
            // 
            this.btnCopyFullCli.Location = new System.Drawing.Point(904, 100);
            this.btnCopyFullCli.Name = "btnCopyFullCli";
            this.btnCopyFullCli.Size = new System.Drawing.Size(75, 23);
            this.btnCopyFullCli.TabIndex = 10;
            this.btnCopyFullCli.Text = "copy";
            this.btnCopyFullCli.UseVisualStyleBackColor = true;
            this.btnCopyFullCli.Click += new System.EventHandler(this.btnCopyCliFull_Click);
            // 
            // txtCliFull
            // 
            this.txtCliFull.Location = new System.Drawing.Point(119, 102);
            this.txtCliFull.Name = "txtCliFull";
            this.txtCliFull.ReadOnly = true;
            this.txtCliFull.Size = new System.Drawing.Size(779, 20);
            this.txtCliFull.TabIndex = 9;
            // 
            // btnCopyMouseCli
            // 
            this.btnCopyMouseCli.Location = new System.Drawing.Point(904, 74);
            this.btnCopyMouseCli.Name = "btnCopyMouseCli";
            this.btnCopyMouseCli.Size = new System.Drawing.Size(75, 23);
            this.btnCopyMouseCli.TabIndex = 8;
            this.btnCopyMouseCli.Text = "copy";
            this.btnCopyMouseCli.UseVisualStyleBackColor = true;
            this.btnCopyMouseCli.Click += new System.EventHandler(this.btnCopyMouseCli_Click);
            // 
            // textBoxMouseCli
            // 
            this.textBoxMouseCli.Location = new System.Drawing.Point(119, 76);
            this.textBoxMouseCli.Name = "textBoxMouseCli";
            this.textBoxMouseCli.ReadOnly = true;
            this.textBoxMouseCli.Size = new System.Drawing.Size(779, 20);
            this.textBoxMouseCli.TabIndex = 7;
            // 
            // CLUMausLabel
            // 
            this.CLUMausLabel.AutoSize = true;
            this.CLUMausLabel.Location = new System.Drawing.Point(6, 79);
            this.CLUMausLabel.Name = "CLUMausLabel";
            this.CLUMausLabel.Size = new System.Drawing.Size(52, 13);
            this.CLUMausLabel.TabIndex = 6;
            this.CLUMausLabel.Text = "Maus CLI";
            // 
            // CLIFensterSmartLabel
            // 
            this.CLIFensterSmartLabel.AutoSize = true;
            this.CLIFensterSmartLabel.Location = new System.Drawing.Point(6, 51);
            this.CLIFensterSmartLabel.Name = "CLIFensterSmartLabel";
            this.CLIFensterSmartLabel.Size = new System.Drawing.Size(91, 13);
            this.CLIFensterSmartLabel.TabIndex = 5;
            this.CLIFensterSmartLabel.Text = "Fenster CLI Smart";
            // 
            // CLIFensterClassicLabel
            // 
            this.CLIFensterClassicLabel.AutoSize = true;
            this.CLIFensterClassicLabel.Location = new System.Drawing.Point(6, 23);
            this.CLIFensterClassicLabel.Name = "CLIFensterClassicLabel";
            this.CLIFensterClassicLabel.Size = new System.Drawing.Size(97, 13);
            this.CLIFensterClassicLabel.TabIndex = 4;
            this.CLIFensterClassicLabel.Text = "Fenster CLI Classic";
            // 
            // btnCopySmart
            // 
            this.btnCopySmart.Location = new System.Drawing.Point(904, 46);
            this.btnCopySmart.Name = "btnCopySmart";
            this.btnCopySmart.Size = new System.Drawing.Size(75, 23);
            this.btnCopySmart.TabIndex = 3;
            this.btnCopySmart.Text = "copy";
            this.btnCopySmart.UseVisualStyleBackColor = true;
            this.btnCopySmart.Click += new System.EventHandler(this.btnCopySmart_Click);
            // 
            // txtCliSmart
            // 
            this.txtCliSmart.Location = new System.Drawing.Point(119, 48);
            this.txtCliSmart.Name = "txtCliSmart";
            this.txtCliSmart.ReadOnly = true;
            this.txtCliSmart.Size = new System.Drawing.Size(779, 20);
            this.txtCliSmart.TabIndex = 2;
            this.txtCliSmart.Text = "NerdyToolBox.exe";
            // 
            // btnCopyClassic
            // 
            this.btnCopyClassic.Location = new System.Drawing.Point(904, 18);
            this.btnCopyClassic.Name = "btnCopyClassic";
            this.btnCopyClassic.Size = new System.Drawing.Size(75, 23);
            this.btnCopyClassic.TabIndex = 1;
            this.btnCopyClassic.Text = "copy";
            this.btnCopyClassic.UseVisualStyleBackColor = true;
            this.btnCopyClassic.Click += new System.EventHandler(this.btnCopyCommand_Click);
            // 
            // txtCliClassic
            // 
            this.txtCliClassic.Location = new System.Drawing.Point(119, 20);
            this.txtCliClassic.Name = "txtCliClassic";
            this.txtCliClassic.ReadOnly = true;
            this.txtCliClassic.Size = new System.Drawing.Size(779, 20);
            this.txtCliClassic.TabIndex = 0;
            this.txtCliClassic.Text = "NerdyToolBox.exe";
            // 
            // buttonMinimieren
            // 
            this.buttonMinimieren.Location = new System.Drawing.Point(6, 19);
            this.buttonMinimieren.Name = "buttonMinimieren";
            this.buttonMinimieren.Size = new System.Drawing.Size(111, 23);
            this.buttonMinimieren.TabIndex = 13;
            this.buttonMinimieren.Text = "Minimieren";
            this.buttonMinimieren.UseVisualStyleBackColor = true;
            this.buttonMinimieren.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // buttonMaximieren
            // 
            this.buttonMaximieren.Location = new System.Drawing.Point(123, 19);
            this.buttonMaximieren.Name = "buttonMaximieren";
            this.buttonMaximieren.Size = new System.Drawing.Size(108, 23);
            this.buttonMaximieren.TabIndex = 14;
            this.buttonMaximieren.Text = "Maximieren";
            this.buttonMaximieren.UseVisualStyleBackColor = true;
            this.buttonMaximieren.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // buttonWiederherstellen
            // 
            this.buttonWiederherstellen.Location = new System.Drawing.Point(237, 19);
            this.buttonWiederherstellen.Name = "buttonWiederherstellen";
            this.buttonWiederherstellen.Size = new System.Drawing.Size(112, 23);
            this.buttonWiederherstellen.TabIndex = 15;
            this.buttonWiederherstellen.Text = "Wiederherstellen";
            this.buttonWiederherstellen.UseVisualStyleBackColor = true;
            this.buttonWiederherstellen.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // WindowButtonsGroupBox
            // 
            this.WindowButtonsGroupBox.Controls.Add(this.buttonMinimieren);
            this.WindowButtonsGroupBox.Controls.Add(this.buttonWiederherstellen);
            this.WindowButtonsGroupBox.Controls.Add(this.buttonMaximieren);
            this.WindowButtonsGroupBox.Location = new System.Drawing.Point(329, 173);
            this.WindowButtonsGroupBox.Name = "WindowButtonsGroupBox";
            this.WindowButtonsGroupBox.Size = new System.Drawing.Size(360, 63);
            this.WindowButtonsGroupBox.TabIndex = 11;
            this.WindowButtonsGroupBox.TabStop = false;
            this.WindowButtonsGroupBox.Text = "Fenster-Buttons";
            // 
            // globalFensterGroupBox
            // 
            this.globalFensterGroupBox.Controls.Add(this.btnRedo);
            this.globalFensterGroupBox.Controls.Add(this.btnUndo);
            this.globalFensterGroupBox.Controls.Add(this.groupBoxWindows);
            this.globalFensterGroupBox.Controls.Add(this.WindowButtonsGroupBox);
            this.globalFensterGroupBox.Controls.Add(this.groupBoxDetails);
            this.globalFensterGroupBox.Controls.Add(this.groupBoxPosition);
            this.globalFensterGroupBox.Location = new System.Drawing.Point(3, 36);
            this.globalFensterGroupBox.Name = "globalFensterGroupBox";
            this.globalFensterGroupBox.Size = new System.Drawing.Size(701, 415);
            this.globalFensterGroupBox.TabIndex = 12;
            this.globalFensterGroupBox.TabStop = false;
            this.globalFensterGroupBox.Text = "Fenster-Controller";
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(410, 352);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(75, 23);
            this.btnRedo.TabIndex = 13;
            this.btnRedo.Text = "↷ Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(329, 352);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(75, 23);
            this.btnUndo.TabIndex = 12;
            this.btnUndo.Text = "↶ Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // notifyIconNTB
            // 
            this.notifyIconNTB.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconNTB.Icon")));
            this.notifyIconNTB.Text = "Nerdy Tool Box (läuft im Hintergrund)";
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuExit});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(193, 48);
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(192, 22);
            this.menuOpen.Text = "Nerdy Tool Box öffnen";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(192, 22);
            this.menuExit.Text = "Beenden";
            // 
            // globalMausGroupBox
            // 
            this.globalMausGroupBox.Controls.Add(this.MauspositionGroupBox);
            this.globalMausGroupBox.Controls.Add(this.groupBoxMouse);
            this.globalMausGroupBox.Location = new System.Drawing.Point(717, 37);
            this.globalMausGroupBox.Name = "globalMausGroupBox";
            this.globalMausGroupBox.Size = new System.Drawing.Size(280, 414);
            this.globalMausGroupBox.TabIndex = 13;
            this.globalMausGroupBox.TabStop = false;
            this.globalMausGroupBox.Text = "Maussteuerung";
            // 
            // MauspositionGroupBox
            // 
            this.MauspositionGroupBox.Controls.Add(this.delayLabel);
            this.MauspositionGroupBox.Controls.Add(this.numericDelay);
            this.MauspositionGroupBox.Controls.Add(this.radioMiddle);
            this.MauspositionGroupBox.Controls.Add(this.radioRight);
            this.MauspositionGroupBox.Controls.Add(this.radioNone);
            this.MauspositionGroupBox.Controls.Add(this.radioLeft);
            this.MauspositionGroupBox.Controls.Add(this.btnExecuteMouseAction);
            this.MauspositionGroupBox.Controls.Add(this.setMausY);
            this.MauspositionGroupBox.Controls.Add(this.numericY);
            this.MauspositionGroupBox.Controls.Add(this.setMausX);
            this.MauspositionGroupBox.Controls.Add(this.numericX);
            this.MauspositionGroupBox.Location = new System.Drawing.Point(7, 87);
            this.MauspositionGroupBox.Name = "MauspositionGroupBox";
            this.MauspositionGroupBox.Size = new System.Drawing.Size(265, 258);
            this.MauspositionGroupBox.TabIndex = 11;
            this.MauspositionGroupBox.TabStop = false;
            this.MauspositionGroupBox.Text = "Maussteuerung";
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(8, 170);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(64, 13);
            this.delayLabel.TabIndex = 18;
            this.delayLabel.Text = "Delay in MS";
            // 
            // numericDelay
            // 
            this.numericDelay.Location = new System.Drawing.Point(78, 168);
            this.numericDelay.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericDelay.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericDelay.Name = "numericDelay";
            this.numericDelay.Size = new System.Drawing.Size(120, 20);
            this.numericDelay.TabIndex = 17;
            this.numericDelay.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericDelay.ValueChanged += new System.EventHandler(this.UpdateMouseCliPreview);
            // 
            // radioMiddle
            // 
            this.radioMiddle.AutoSize = true;
            this.radioMiddle.Location = new System.Drawing.Point(11, 142);
            this.radioMiddle.Name = "radioMiddle";
            this.radioMiddle.Size = new System.Drawing.Size(72, 17);
            this.radioMiddle.TabIndex = 16;
            this.radioMiddle.Text = "Mittelklick";
            this.radioMiddle.UseVisualStyleBackColor = true;
            this.radioMiddle.CheckedChanged += new System.EventHandler(this.UpdateMouseCliPreview);
            // 
            // radioRight
            // 
            this.radioRight.AutoSize = true;
            this.radioRight.Location = new System.Drawing.Point(11, 118);
            this.radioRight.Name = "radioRight";
            this.radioRight.Size = new System.Drawing.Size(81, 17);
            this.radioRight.TabIndex = 15;
            this.radioRight.Text = "Rechtsklick";
            this.radioRight.UseVisualStyleBackColor = true;
            this.radioRight.CheckedChanged += new System.EventHandler(this.UpdateMouseCliPreview);
            // 
            // radioNone
            // 
            this.radioNone.AutoSize = true;
            this.radioNone.Checked = true;
            this.radioNone.Location = new System.Drawing.Point(11, 71);
            this.radioNone.Name = "radioNone";
            this.radioNone.Size = new System.Drawing.Size(72, 17);
            this.radioNone.TabIndex = 14;
            this.radioNone.TabStop = true;
            this.radioNone.Text = "Kein Klick";
            this.radioNone.UseVisualStyleBackColor = true;
            this.radioNone.CheckedChanged += new System.EventHandler(this.UpdateMouseCliPreview);
            // 
            // radioLeft
            // 
            this.radioLeft.AutoSize = true;
            this.radioLeft.Location = new System.Drawing.Point(11, 94);
            this.radioLeft.Name = "radioLeft";
            this.radioLeft.Size = new System.Drawing.Size(72, 17);
            this.radioLeft.TabIndex = 13;
            this.radioLeft.Text = "Linksklick";
            this.radioLeft.UseVisualStyleBackColor = true;
            this.radioLeft.CheckedChanged += new System.EventHandler(this.UpdateMouseCliPreview);
            // 
            // btnExecuteMouseAction
            // 
            this.btnExecuteMouseAction.Location = new System.Drawing.Point(8, 191);
            this.btnExecuteMouseAction.Name = "btnExecuteMouseAction";
            this.btnExecuteMouseAction.Size = new System.Drawing.Size(75, 23);
            this.btnExecuteMouseAction.TabIndex = 12;
            this.btnExecuteMouseAction.Text = "ausführen";
            this.btnExecuteMouseAction.UseVisualStyleBackColor = true;
            this.btnExecuteMouseAction.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnExecuteMouseAction_Click);
            // 
            // setMausY
            // 
            this.setMausY.AutoSize = true;
            this.setMausY.Location = new System.Drawing.Point(8, 47);
            this.setMausY.Name = "setMausY";
            this.setMausY.Size = new System.Drawing.Size(14, 13);
            this.setMausY.TabIndex = 1;
            this.setMausY.Text = "Y";
            // 
            // numericY
            // 
            this.numericY.Location = new System.Drawing.Point(28, 45);
            this.numericY.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericY.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numericY.Name = "numericY";
            this.numericY.Size = new System.Drawing.Size(120, 20);
            this.numericY.TabIndex = 10;
            this.numericY.ValueChanged += new System.EventHandler(this.UpdateMouseCliPreview);
            // 
            // setMausX
            // 
            this.setMausX.AutoSize = true;
            this.setMausX.Location = new System.Drawing.Point(8, 21);
            this.setMausX.Name = "setMausX";
            this.setMausX.Size = new System.Drawing.Size(14, 13);
            this.setMausX.TabIndex = 0;
            this.setMausX.Text = "X";
            // 
            // numericX
            // 
            this.numericX.Location = new System.Drawing.Point(28, 19);
            this.numericX.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericX.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numericX.Name = "numericX";
            this.numericX.Size = new System.Drawing.Size(120, 20);
            this.numericX.TabIndex = 9;
            this.numericX.ValueChanged += new System.EventHandler(this.UpdateMouseCliPreview);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1009, 660);
            this.Controls.Add(this.globalMausGroupBox);
            this.Controls.Add(this.globalFensterGroupBox);
            this.Controls.Add(this.cliGroupbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Nerdy Tool Box (NTB)";
            this.groupBoxWindows.ResumeLayout(false);
            this.groupBoxWindows.PerformLayout();
            this.groupBoxPosition.ResumeLayout(false);
            this.groupBoxPosition.PerformLayout();
            this.groupBoxMouse.ResumeLayout(false);
            this.groupBoxMouse.PerformLayout();
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.cliGroupbox.ResumeLayout(false);
            this.cliGroupbox.PerformLayout();
            this.WindowButtonsGroupBox.ResumeLayout(false);
            this.globalFensterGroupBox.ResumeLayout(false);
            this.trayMenu.ResumeLayout(false);
            this.globalMausGroupBox.ResumeLayout(false);
            this.MauspositionGroupBox.ResumeLayout(false);
            this.MauspositionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxWindows;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Timer timerMouse;
        private System.Windows.Forms.GroupBox groupBoxWindows;
        private System.Windows.Forms.GroupBox groupBoxPosition;
        private System.Windows.Forms.Label yPosLabel;
        private System.Windows.Forms.Label xPosLabel;
        private System.Windows.Forms.GroupBox groupBoxMouse;
        private System.Windows.Forms.Label lblMouseY;
        private System.Windows.Forms.Label lblMouseX;
        private System.Windows.Forms.Label txtSearchLabel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMonitor;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblHandle;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.GroupBox cliGroupbox;
        private System.Windows.Forms.TextBox txtCliClassic;
        private System.Windows.Forms.Button btnCopyClassic;
        private System.Windows.Forms.Button buttonWiederherstellen;
        private System.Windows.Forms.Button buttonMaximieren;
        private System.Windows.Forms.Button buttonMinimieren;
        private System.Windows.Forms.TextBox txtCliSmart;
        private System.Windows.Forms.Button btnCopySmart;
        private System.Windows.Forms.CheckBox chkPreviewEnabled;
        private System.Windows.Forms.GroupBox WindowButtonsGroupBox;
        private System.Windows.Forms.GroupBox globalFensterGroupBox;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.CheckBox chkAlwaysMaximized;
        private System.Windows.Forms.NotifyIcon notifyIconNTB;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.GroupBox globalMausGroupBox;
        private System.Windows.Forms.NumericUpDown numericY;
        private System.Windows.Forms.NumericUpDown numericX;
        private System.Windows.Forms.GroupBox MauspositionGroupBox;
        private System.Windows.Forms.Label setMausY;
        private System.Windows.Forms.Label setMausX;
        private System.Windows.Forms.Button btnExecuteMouseAction;
        private System.Windows.Forms.RadioButton radioLeft;
        private System.Windows.Forms.RadioButton radioMiddle;
        private System.Windows.Forms.RadioButton radioRight;
        private System.Windows.Forms.RadioButton radioNone;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.NumericUpDown numericDelay;
        private System.Windows.Forms.TextBox textBoxMouseCli;
        private System.Windows.Forms.Label CLUMausLabel;
        private System.Windows.Forms.Label CLIFensterSmartLabel;
        private System.Windows.Forms.Label CLIFensterClassicLabel;
        private System.Windows.Forms.Button btnCopyMouseCli;
        private System.Windows.Forms.Button btnCopyFullCli;
        private System.Windows.Forms.TextBox txtCliFull;
        private System.Windows.Forms.Label CLIFullLabel;
    }
}

