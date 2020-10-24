namespace ImageProcessing01
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem basicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oCRToolStripMenuItem;
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.basicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oCRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoad = new System.Windows.Forms.Button();
            this.chartRectY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRectX = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ptbLoad = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.nudDegree = new System.Windows.Forms.NumericUpDown();
            this.lblPointChecker = new System.Windows.Forms.TextBox();
            this.lblRotation = new System.Windows.Forms.TextBox();
            this.btnOCR = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.plotView2 = new OxyPlot.WindowsForms.PlotView();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.listBox = new System.Windows.Forms.ListBox();
            this.txtOCR = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRectY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRectX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDegree)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.basicToolStripMenuItem,
            this.oCRToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1047, 24);
            this.menuStrip1.TabIndex = 403;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // basicToolStripMenuItem
            // 
            this.basicToolStripMenuItem.Name = "basicToolStripMenuItem";
            this.basicToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.basicToolStripMenuItem.Text = "Basic";
            this.basicToolStripMenuItem.Click += new System.EventHandler(this.basicToolStripMenuItem_Click);
            // 
            // oCRToolStripMenuItem
            // 
            this.oCRToolStripMenuItem.Name = "oCRToolStripMenuItem";
            this.oCRToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.oCRToolStripMenuItem.Text = "OCR";
            this.oCRToolStripMenuItem.Click += new System.EventHandler(this.oCRToolStripMenuItem_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLoad.Location = new System.Drawing.Point(91, 63);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(105, 37);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Picture";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ptbLoad
            // 
            this.ptbLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptbLoad.Location = new System.Drawing.Point(248, 3);
            this.ptbLoad.Name = "ptbLoad";
            this.ptbLoad.Size = new System.Drawing.Size(1000, 800);
            this.ptbLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ptbLoad.TabIndex = 0;
            this.ptbLoad.TabStop = false;
            this.ptbLoad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptbLoad_MouseDown);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(256, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 800);
            this.panel1.TabIndex = 401;
            this.panel1.Controls.Add(this.ptbLoad);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPlay.Location = new System.Drawing.Point(92, 146);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(105, 37);
            this.btnPlay.TabIndex = 404;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            // 
            // nudDegree
            // 
            this.nudDegree.Location = new System.Drawing.Point(92, 203);
            this.nudDegree.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudDegree.Name = "nudDegree";
            this.nudDegree.Size = new System.Drawing.Size(105, 20);
            this.nudDegree.TabIndex = 405;
            // 
            // lblPointChecker
            // 
            this.lblPointChecker.Location = new System.Drawing.Point(92, 242);
            this.lblPointChecker.Name = "lblPointChecker";
            this.lblPointChecker.Size = new System.Drawing.Size(105, 20);
            this.lblPointChecker.TabIndex = 406;
            // 
            // lblRotation
            // 
            this.lblRotation.Location = new System.Drawing.Point(92, 284);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(105, 20);
            this.lblRotation.TabIndex = 407;
            // 
            // btnOCR
            // 
            this.btnOCR.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnOCR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOCR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOCR.Location = new System.Drawing.Point(85, 120);
            this.btnOCR.Name = "btnOCR";
            this.btnOCR.Size = new System.Drawing.Size(105, 37);
            this.btnOCR.TabIndex = 404;
            this.btnOCR.Text = "OCR";
            this.btnOCR.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ptbLoad);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnLoad);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Controls.Add(this.plotView2);
            this.panel2.Controls.Add(this.plotView1);
            this.panel2.Location = new System.Drawing.Point(11, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2000, 659);
            this.panel2.TabIndex = 404;
            // 
            // plotView2
            // 
            this.plotView2.Location = new System.Drawing.Point(259, 438);
            this.plotView2.Name = "plotView2";
            this.plotView2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView2.Size = new System.Drawing.Size(731, 157);
            this.plotView2.TabIndex = 405;
            this.plotView2.Text = "plotView2";
            this.plotView2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plotView1
            // 
            this.plotView1.Location = new System.Drawing.Point(1000, 30);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(222, 400);
            this.plotView1.TabIndex = 404;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(262, 431);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(519, 199);
            this.listBox.TabIndex = 404;
            // 
            // txtOCR
            // 
            this.txtOCR.Location = new System.Drawing.Point(92, 279);
            this.txtOCR.Multiline = true;
            this.txtOCR.Name = "txtOCR";
            this.txtOCR.Size = new System.Drawing.Size(129, 83);
            this.txtOCR.TabIndex = 406;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 671);
            this.Controls.Add(this.panel2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRectY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRectX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDegree)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRectY;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRectX;
        private System.Windows.Forms.PictureBox ptbLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.NumericUpDown nudDegree;
        private System.Windows.Forms.TextBox lblPointChecker;
        private System.Windows.Forms.TextBox lblRotation;
        private System.Windows.Forms.Button btnOCR;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox;
        private OxyPlot.WindowsForms.PlotView plotView2;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.TextBox txtOCR;
    }
}

