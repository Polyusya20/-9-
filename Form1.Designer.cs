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
            tabPage2 = new TabPage();
            textBox1 = new TextBox();
            tabPage1 = new TabPage();
            OscPlot = new ScottPlot.WinForms.FormsPlot();
            tabControl1 = new TabControl();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusLabel.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
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
            menuStrip1.Size = new Size(762, 24);
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
            toolStrip1.Size = new Size(762, 27);
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
            statusLabel.Location = new Point(0, 439);
            statusLabel.Name = "statusLabel";
            statusLabel.RightToLeft = RightToLeft.No;
            statusLabel.Size = new Size(762, 22);
            statusLabel.TabIndex = 1;
            statusLabel.Text = "statusStrip1";
            // 
            // InfoToolStripStatusLabel
            // 
            InfoToolStripStatusLabel.Name = "InfoToolStripStatusLabel";
            InfoToolStripStatusLabel.Size = new Size(118, 17);
            InfoToolStripStatusLabel.Text = "toolStripStatusLabel1";
            InfoToolStripStatusLabel.Click += InfoToolStripStatusLabel_Click;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(754, 357);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "Токи";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(754, 357);
            tabPage2.TabIndex = 2;
            tabPage2.Text = "Данные";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(748, 353);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(OscPlot);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(754, 357);
            tabPage1.TabIndex = 1;
            tabPage1.Text = "Осциллограмма";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // OscPlot
            // 
            OscPlot.BackgroundImageLayout = ImageLayout.None;
            OscPlot.DisplayScale = 1F;
            OscPlot.Dock = DockStyle.Fill;
            OscPlot.Location = new Point(3, 3);
            OscPlot.Name = "OscPlot";
            OscPlot.Size = new Size(748, 351);
            OscPlot.TabIndex = 0;
            OscPlot.Load += formsPlot1_Load;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Top;
            tabControl1.Location = new Point(0, 51);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(762, 385);
            tabControl1.TabIndex = 2;
            tabControl1.Tag = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 461);
            Controls.Add(statusLabel);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusLabel.ResumeLayout(false);
            statusLabel.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage1.ResumeLayout(false);
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
        private TabPage tabPage3;
        private TabPage tabPage2;
        private TextBox textBox1;
        private TabPage tabPage1;
        private ScottPlot.WinForms.FormsPlot OscPlot;
        private TabControl tabControl1;
        private ToolStripButton saveToolStripButton1;
    }
}
