namespace Practice
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            contextMenuStrip1 = new ContextMenuStrip(components);
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            openToolStripButton1 = new ToolStripButton();
            toolStrip1 = new ToolStrip();
            saveToolStripButton1 = new ToolStripButton();
            statusLabel = new StatusStrip();
            InfoToolStripStatusLabel = new ToolStripStatusLabel();
            tabPage3 = new TabPage();
            tabControl3 = new TabControl();
            tabPage7 = new TabPage();
            OscPlotCurrent1 = new ScottPlot.WinForms.FormsPlot();
            tabPage8 = new TabPage();
            OscPlotCurrent2 = new ScottPlot.WinForms.FormsPlot();
            tabPage9 = new TabPage();
            OscPlotCurrent3 = new ScottPlot.WinForms.FormsPlot();
            tabPage10 = new TabPage();
            OscPlotCurrent4 = new ScottPlot.WinForms.FormsPlot();
            tabPage12 = new TabPage();
            labelShockCurrentC = new Label();
            labelShockCurrentB = new Label();
            labelShockCurrentA = new Label();
            labelFaultType = new Label();
            labelCurrentZero = new Label();
            labelCurrentNegative = new Label();
            labelCurrentPositive = new Label();
            tabPage2 = new TabPage();
            textBox1 = new TextBox();
            tabPage1 = new TabPage();
            tabControl2 = new TabControl();
            tabPage4 = new TabPage();
            OscPlot = new ScottPlot.WinForms.FormsPlot();
            tabPage5 = new TabPage();
            OscPlot1 = new ScottPlot.WinForms.FormsPlot();
            tabPage6 = new TabPage();
            OscPlot2 = new ScottPlot.WinForms.FormsPlot();
            tabPage11 = new TabPage();
            labelVoltageZero = new Label();
            labelVoltagePositive = new Label();
            tabControl1 = new TabControl();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusLabel.SuspendLayout();
            tabPage3.SuspendLayout();
            tabControl3.SuspendLayout();
            tabPage7.SuspendLayout();
            tabPage8.SuspendLayout();
            tabPage9.SuspendLayout();
            tabPage10.SuspendLayout();
            tabPage12.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage6.SuspendLayout();
            tabPage11.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 20);
            helpToolStripMenuItem.Text = "Справка";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(149, 22);
            aboutToolStripMenuItem.Text = "О программе";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(870, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripButton1
            // 
            openToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openToolStripButton1.Image = (Image)resources.GetObject("openToolStripButton1.Image");
            openToolStripButton1.ImageTransparentColor = Color.Magenta;
            openToolStripButton1.Name = "openToolStripButton1";
            openToolStripButton1.Size = new Size(24, 24);
            openToolStripButton1.Text = "toolStripButton1";
            openToolStripButton1.ToolTipText = "Открыть файл";
            openToolStripButton1.Click += openToolStripButton1_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { openToolStripButton1, saveToolStripButton1 });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(870, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // saveToolStripButton1
            // 
            saveToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveToolStripButton1.Image = (Image)resources.GetObject("saveToolStripButton1.Image");
            saveToolStripButton1.ImageTransparentColor = Color.Magenta;
            saveToolStripButton1.Name = "saveToolStripButton1";
            saveToolStripButton1.Size = new Size(24, 24);
            saveToolStripButton1.Text = "toolStripButton1";
            saveToolStripButton1.ToolTipText = "Сохранить";
            saveToolStripButton1.Click += saveToolStripButton1_Click;
            // 
            // statusLabel
            // 
            statusLabel.ImageScalingSize = new Size(20, 20);
            statusLabel.Items.AddRange(new ToolStripItem[] { InfoToolStripStatusLabel });
            statusLabel.Location = new Point(0, 459);
            statusLabel.Name = "statusLabel";
            statusLabel.RightToLeft = RightToLeft.No;
            statusLabel.Size = new Size(870, 22);
            statusLabel.TabIndex = 1;
            statusLabel.Text = "statusStrip1";
            // 
            // InfoToolStripStatusLabel
            // 
            InfoToolStripStatusLabel.Name = "InfoToolStripStatusLabel";
            InfoToolStripStatusLabel.Size = new Size(152, 17);
            InfoToolStripStatusLabel.Text = "Ожидание загрузки файла";
            InfoToolStripStatusLabel.Click += InfoToolStripStatusLabel_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tabControl3);
            tabPage3.Location = new Point(4, 26);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(862, 375);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "Токи";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            tabControl3.Alignment = TabAlignment.Bottom;
            tabControl3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl3.Controls.Add(tabPage7);
            tabControl3.Controls.Add(tabPage8);
            tabControl3.Controls.Add(tabPage9);
            tabControl3.Controls.Add(tabPage10);
            tabControl3.Controls.Add(tabPage12);
            tabControl3.Font = new Font("VAG World", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 204);
            tabControl3.Location = new Point(-2, 2);
            tabControl3.Multiline = true;
            tabControl3.Name = "tabControl3";
            tabControl3.SelectedIndex = 0;
            tabControl3.Size = new Size(868, 373);
            tabControl3.TabIndex = 1;
            // 
            // tabPage7
            // 
            tabPage7.BackColor = Color.DeepSkyBlue;
            tabPage7.Controls.Add(OscPlotCurrent1);
            tabPage7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabPage7.Location = new Point(4, 4);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(5);
            tabPage7.Size = new Size(807, 378);
            tabPage7.TabIndex = 0;
            tabPage7.Text = "Фазный ток";
            // 
            // OscPlotCurrent1
            // 
            OscPlotCurrent1.BackColor = Color.White;
            OscPlotCurrent1.DisplayScale = 1F;
            OscPlotCurrent1.Dock = DockStyle.Fill;
            OscPlotCurrent1.ForeColor = SystemColors.ControlText;
            OscPlotCurrent1.Location = new Point(5, 5);
            OscPlotCurrent1.Margin = new Padding(2, 1, 2, 1);
            OscPlotCurrent1.Name = "OscPlotCurrent1";
            OscPlotCurrent1.Size = new Size(797, 368);
            OscPlotCurrent1.TabIndex = 1;
            // 
            // tabPage8
            // 
            tabPage8.BackColor = Color.DeepSkyBlue;
            tabPage8.Controls.Add(OscPlotCurrent2);
            tabPage8.Location = new Point(4, 4);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new Padding(5);
            tabPage8.Size = new Size(1003, 638);
            tabPage8.TabIndex = 1;
            tabPage8.Text = "Ток прямой последовательности";
            // 
            // OscPlotCurrent2
            // 
            OscPlotCurrent2.BackColor = Color.White;
            OscPlotCurrent2.DisplayScale = 1F;
            OscPlotCurrent2.Dock = DockStyle.Fill;
            OscPlotCurrent2.ForeColor = SystemColors.ControlText;
            OscPlotCurrent2.Location = new Point(5, 5);
            OscPlotCurrent2.Margin = new Padding(2, 1, 2, 1);
            OscPlotCurrent2.Name = "OscPlotCurrent2";
            OscPlotCurrent2.Size = new Size(993, 628);
            OscPlotCurrent2.TabIndex = 2;
            // 
            // tabPage9
            // 
            tabPage9.BackColor = Color.DeepSkyBlue;
            tabPage9.BackgroundImageLayout = ImageLayout.None;
            tabPage9.BorderStyle = BorderStyle.FixedSingle;
            tabPage9.Controls.Add(OscPlotCurrent3);
            tabPage9.Location = new Point(4, 4);
            tabPage9.Name = "tabPage9";
            tabPage9.Padding = new Padding(5);
            tabPage9.Size = new Size(1003, 638);
            tabPage9.TabIndex = 2;
            tabPage9.Text = "Ток обратной последовательности";
            // 
            // OscPlotCurrent3
            // 
            OscPlotCurrent3.BackColor = Color.White;
            OscPlotCurrent3.DisplayScale = 1F;
            OscPlotCurrent3.Dock = DockStyle.Fill;
            OscPlotCurrent3.ForeColor = SystemColors.ControlText;
            OscPlotCurrent3.Location = new Point(5, 5);
            OscPlotCurrent3.Margin = new Padding(2, 1, 2, 1);
            OscPlotCurrent3.Name = "OscPlotCurrent3";
            OscPlotCurrent3.Size = new Size(991, 626);
            OscPlotCurrent3.TabIndex = 3;
            OscPlotCurrent3.Load += formsPlot3_Load;
            // 
            // tabPage10
            // 
            tabPage10.BackColor = Color.DeepSkyBlue;
            tabPage10.Controls.Add(OscPlotCurrent4);
            tabPage10.Location = new Point(4, 4);
            tabPage10.Name = "tabPage10";
            tabPage10.Padding = new Padding(5);
            tabPage10.Size = new Size(860, 339);
            tabPage10.TabIndex = 3;
            tabPage10.Text = "Ток нулевой последовательности";
            // 
            // OscPlotCurrent4
            // 
            OscPlotCurrent4.BackColor = Color.White;
            OscPlotCurrent4.DisplayScale = 1F;
            OscPlotCurrent4.Dock = DockStyle.Fill;
            OscPlotCurrent4.ForeColor = SystemColors.ControlText;
            OscPlotCurrent4.Location = new Point(5, 5);
            OscPlotCurrent4.Margin = new Padding(2, 1, 2, 1);
            OscPlotCurrent4.Name = "OscPlotCurrent4";
            OscPlotCurrent4.Size = new Size(850, 329);
            OscPlotCurrent4.TabIndex = 4;
            // 
            // tabPage12
            // 
            tabPage12.Controls.Add(labelShockCurrentC);
            tabPage12.Controls.Add(labelShockCurrentB);
            tabPage12.Controls.Add(labelShockCurrentA);
            tabPage12.Controls.Add(labelFaultType);
            tabPage12.Controls.Add(labelCurrentZero);
            tabPage12.Controls.Add(labelCurrentNegative);
            tabPage12.Controls.Add(labelCurrentPositive);
            tabPage12.Location = new Point(4, 4);
            tabPage12.Name = "tabPage12";
            tabPage12.Padding = new Padding(3);
            tabPage12.Size = new Size(860, 339);
            tabPage12.TabIndex = 4;
            tabPage12.Text = "Ударный ток";
            tabPage12.UseVisualStyleBackColor = true;
            // 
            // labelShockCurrentC
            // 
            labelShockCurrentC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelShockCurrentC.AutoEllipsis = true;
            labelShockCurrentC.AutoSize = true;
            labelShockCurrentC.BorderStyle = BorderStyle.FixedSingle;
            labelShockCurrentC.Font = new Font("VAG World", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelShockCurrentC.Location = new Point(6, 274);
            labelShockCurrentC.Name = "labelShockCurrentC";
            labelShockCurrentC.Size = new Size(496, 33);
            labelShockCurrentC.TabIndex = 11;
            labelShockCurrentC.Text = "Ударный ток КЗ (фаза С): ожидание загрузки файла...\r\n";
            labelShockCurrentC.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelShockCurrentB
            // 
            labelShockCurrentB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelShockCurrentB.AutoEllipsis = true;
            labelShockCurrentB.AutoSize = true;
            labelShockCurrentB.BorderStyle = BorderStyle.FixedSingle;
            labelShockCurrentB.Font = new Font("VAG World", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelShockCurrentB.Location = new Point(6, 227);
            labelShockCurrentB.Name = "labelShockCurrentB";
            labelShockCurrentB.Size = new Size(496, 33);
            labelShockCurrentB.TabIndex = 10;
            labelShockCurrentB.Text = "Ударный ток КЗ (фаза B): ожидание загрузки файла...\r\n";
            labelShockCurrentB.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelShockCurrentA
            // 
            labelShockCurrentA.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelShockCurrentA.AutoEllipsis = true;
            labelShockCurrentA.AutoSize = true;
            labelShockCurrentA.BorderStyle = BorderStyle.FixedSingle;
            labelShockCurrentA.Font = new Font("VAG World", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelShockCurrentA.Location = new Point(6, 184);
            labelShockCurrentA.Name = "labelShockCurrentA";
            labelShockCurrentA.Size = new Size(497, 33);
            labelShockCurrentA.TabIndex = 9;
            labelShockCurrentA.Text = "Ударный ток КЗ (фаза А): ожидание загрузки файла...\r\n";
            labelShockCurrentA.TextAlign = ContentAlignment.TopCenter;
            labelShockCurrentA.Click += label1_Click_2;
            // 
            // labelFaultType
            // 
            labelFaultType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelFaultType.AutoEllipsis = true;
            labelFaultType.AutoSize = true;
            labelFaultType.BorderStyle = BorderStyle.FixedSingle;
            labelFaultType.Font = new Font("VAG World", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelFaultType.Location = new Point(6, 139);
            labelFaultType.Name = "labelFaultType";
            labelFaultType.Size = new Size(336, 33);
            labelFaultType.TabIndex = 8;
            labelFaultType.Text = "Тип КЗ: ожидание загрузки файла...\r\n";
            labelFaultType.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelCurrentZero
            // 
            labelCurrentZero.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelCurrentZero.AutoEllipsis = true;
            labelCurrentZero.AutoSize = true;
            labelCurrentZero.BorderStyle = BorderStyle.FixedSingle;
            labelCurrentZero.Font = new Font("VAG World", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelCurrentZero.Location = new Point(6, 94);
            labelCurrentZero.Name = "labelCurrentZero";
            labelCurrentZero.Size = new Size(583, 33);
            labelCurrentZero.TabIndex = 3;
            labelCurrentZero.Text = "Ток нулевой последовательности: ожидание загрузки файла...\r\n";
            labelCurrentZero.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelCurrentNegative
            // 
            labelCurrentNegative.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelCurrentNegative.AutoEllipsis = true;
            labelCurrentNegative.AutoSize = true;
            labelCurrentNegative.BorderStyle = BorderStyle.FixedSingle;
            labelCurrentNegative.Font = new Font("VAG World", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelCurrentNegative.Location = new Point(6, 48);
            labelCurrentNegative.Name = "labelCurrentNegative";
            labelCurrentNegative.Size = new Size(593, 33);
            labelCurrentNegative.TabIndex = 2;
            labelCurrentNegative.Text = "Ток обратной последовательности: ожидание загрузки файла...\r\n";
            labelCurrentNegative.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelCurrentPositive
            // 
            labelCurrentPositive.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelCurrentPositive.AutoEllipsis = true;
            labelCurrentPositive.AutoSize = true;
            labelCurrentPositive.BorderStyle = BorderStyle.FixedSingle;
            labelCurrentPositive.Font = new Font("VAG World", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelCurrentPositive.Location = new Point(6, 3);
            labelCurrentPositive.Name = "labelCurrentPositive";
            labelCurrentPositive.Size = new Size(576, 33);
            labelCurrentPositive.TabIndex = 1;
            labelCurrentPositive.Text = "Ток прямой последовательности: ожидание загрузки файла...\r\n";
            labelCurrentPositive.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox1);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(862, 375);
            tabPage2.TabIndex = 2;
            tabPage2.Text = "Файл Comtrade";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(856, 371);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tabControl2);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(862, 375);
            tabPage1.TabIndex = 1;
            tabPage1.Text = "Напряжение";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Alignment = TabAlignment.Bottom;
            tabControl2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Controls.Add(tabPage5);
            tabControl2.Controls.Add(tabPage6);
            tabControl2.Controls.Add(tabPage11);
            tabControl2.Font = new Font("VAG World", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 204);
            tabControl2.Location = new Point(0, 0);
            tabControl2.Multiline = true;
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(866, 379);
            tabControl2.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.Firebrick;
            tabPage4.Controls.Add(OscPlot);
            tabPage4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabPage4.Location = new Point(4, 4);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(5);
            tabPage4.Size = new Size(858, 345);
            tabPage4.TabIndex = 0;
            tabPage4.Text = "Фазное напряжение";
            // 
            // OscPlot
            // 
            OscPlot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OscPlot.AutoSize = true;
            OscPlot.BackColor = Color.White;
            OscPlot.DisplayScale = 1F;
            OscPlot.ForeColor = Color.Transparent;
            OscPlot.Location = new Point(5, 5);
            OscPlot.Margin = new Padding(2, 1, 2, 1);
            OscPlot.Name = "OscPlot";
            OscPlot.Size = new Size(848, 334);
            OscPlot.TabIndex = 1;
            OscPlot.Load += OscPlot_Load;
            // 
            // tabPage5
            // 
            tabPage5.BackColor = Color.Firebrick;
            tabPage5.Controls.Add(OscPlot1);
            tabPage5.Location = new Point(4, 4);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(5);
            tabPage5.Size = new Size(858, 345);
            tabPage5.TabIndex = 1;
            tabPage5.Text = "Напряжение прямой последовательности";
            // 
            // OscPlot1
            // 
            OscPlot1.BackColor = Color.White;
            OscPlot1.DisplayScale = 1F;
            OscPlot1.Dock = DockStyle.Fill;
            OscPlot1.ForeColor = SystemColors.ControlText;
            OscPlot1.Location = new Point(5, 5);
            OscPlot1.Margin = new Padding(2, 1, 2, 1);
            OscPlot1.Name = "OscPlot1";
            OscPlot1.Size = new Size(848, 335);
            OscPlot1.TabIndex = 2;
            // 
            // tabPage6
            // 
            tabPage6.BackColor = Color.Firebrick;
            tabPage6.Controls.Add(OscPlot2);
            tabPage6.Location = new Point(4, 4);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(5);
            tabPage6.Size = new Size(858, 345);
            tabPage6.TabIndex = 2;
            tabPage6.Text = "Напряжение нулевой последовательности";
            // 
            // OscPlot2
            // 
            OscPlot2.BackColor = Color.White;
            OscPlot2.DisplayScale = 1F;
            OscPlot2.Dock = DockStyle.Fill;
            OscPlot2.ForeColor = SystemColors.ControlText;
            OscPlot2.Location = new Point(5, 5);
            OscPlot2.Margin = new Padding(2, 1, 2, 1);
            OscPlot2.Name = "OscPlot2";
            OscPlot2.Size = new Size(848, 335);
            OscPlot2.TabIndex = 3;
            // 
            // tabPage11
            // 
            tabPage11.Controls.Add(labelVoltageZero);
            tabPage11.Controls.Add(labelVoltagePositive);
            tabPage11.ForeColor = SystemColors.ControlText;
            tabPage11.Location = new Point(4, 4);
            tabPage11.Name = "tabPage11";
            tabPage11.Padding = new Padding(3);
            tabPage11.Size = new Size(858, 345);
            tabPage11.TabIndex = 3;
            tabPage11.Text = "Значения";
            tabPage11.UseVisualStyleBackColor = true;
            // 
            // labelVoltageZero
            // 
            labelVoltageZero.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelVoltageZero.AutoEllipsis = true;
            labelVoltageZero.AutoSize = true;
            labelVoltageZero.BorderStyle = BorderStyle.FixedSingle;
            labelVoltageZero.Font = new Font("VAG World", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelVoltageZero.Location = new Point(6, 77);
            labelVoltageZero.Name = "labelVoltageZero";
            labelVoltageZero.Size = new Size(678, 33);
            labelVoltageZero.TabIndex = 3;
            labelVoltageZero.Text = "Напряжение обратной последовательности: ожидание загрузки файла...\r\n";
            labelVoltageZero.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelVoltagePositive
            // 
            labelVoltagePositive.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelVoltagePositive.AutoEllipsis = true;
            labelVoltagePositive.AutoSize = true;
            labelVoltagePositive.BorderStyle = BorderStyle.FixedSingle;
            labelVoltagePositive.Font = new Font("VAG World", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelVoltagePositive.Location = new Point(6, 3);
            labelVoltagePositive.Name = "labelVoltagePositive";
            labelVoltagePositive.Size = new Size(661, 33);
            labelVoltagePositive.TabIndex = 2;
            labelVoltagePositive.Text = "Напряжение прямой последовательности: ожидание загрузки файла...\r\n";
            labelVoltagePositive.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            tabControl1.Location = new Point(0, 51);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(870, 405);
            tabControl1.TabIndex = 2;
            tabControl1.Tag = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 481);
            Controls.Add(statusLabel);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Comtrade_Analyzer_from_Team9";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusLabel.ResumeLayout(false);
            statusLabel.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabControl3.ResumeLayout(false);
            tabPage7.ResumeLayout(false);
            tabPage8.ResumeLayout(false);
            tabPage9.ResumeLayout(false);
            tabPage10.ResumeLayout(false);
            tabPage12.ResumeLayout(false);
            tabPage12.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage6.ResumeLayout(false);
            tabPage11.ResumeLayout(false);
            tabPage11.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripButton openToolStripButton1;
        private ToolStrip toolStrip1;
        private StatusStrip statusLabel;
        private ToolStripStatusLabel InfoToolStripStatusLabel;
        private ToolStripButton saveToolStripButton1;
        private TabPage tabPage3;
        private TabControl tabControl3;
        private TabPage tabPage7;
        private ScottPlot.WinForms.FormsPlot OscPlotCurrent1;
        private TabPage tabPage8;
        private ScottPlot.WinForms.FormsPlot OscPlotCurrent2;
        private TabPage tabPage9;
        private ScottPlot.WinForms.FormsPlot OscPlotCurrent3;
        private TabPage tabPage10;
        private ScottPlot.WinForms.FormsPlot OscPlotCurrent4;
        private TabPage tabPage12;
        private Label labelCurrentPositive;
        private TabPage tabPage2;
        private TextBox textBox1;
        private TabPage tabPage1;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private ScottPlot.WinForms.FormsPlot OscPlot;
        private TabPage tabPage5;
        private ScottPlot.WinForms.FormsPlot OscPlot1;
        private TabPage tabPage6;
        private ScottPlot.WinForms.FormsPlot OscPlot2;
        private TabControl tabControl1;
        private Label labelCurrentZero;
        private Label labelCurrentNegative;
        private TabPage tabPage11;
        private Label labelVoltageZero;
        private Label labelVoltagePositive;
        private Label labelFaultType;
        private Label labelShockCurrentA;
        private Label labelShockCurrentB;
        private Label labelShockCurrentC;
    }
}
