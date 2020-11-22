namespace Paint
{
    partial class MainForm
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
        private void InitializeComponent()
        {
            this.openGLControl = new SharpGL.OpenGLControl();
            this.btnColorTable = new System.Windows.Forms.Button();
            this.colorDlg = new System.Windows.Forms.ColorDialog();
            this.cbLineWidth = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPentagon = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnRec = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbLineGLTimer = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gbTimer = new System.Windows.Forms.GroupBox();
            this.lbAlgorithm = new System.Windows.Forms.Label();
            this.btnStopTimer = new System.Windows.Forms.Button();
            this.lbTriGLTimer = new System.Windows.Forms.Label();
            this.lbEllipseGLTimer = new System.Windows.Forms.Label();
            this.lbPenGLTimer = new System.Windows.Forms.Label();
            this.lbHexGLTimer = new System.Windows.Forms.Label();
            this.lbRecGLTimer = new System.Windows.Forms.Label();
            this.lbCirGLTimer = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbAlgorithm = new System.Windows.Forms.ComboBox();
            this.btnClearShape = new System.Windows.Forms.Button();
            this.btnResetTimer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbTimer.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(2, 17);
            this.openGLControl.Margin = new System.Windows.Forms.Padding(0);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(1024, 600);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // btnColorTable
            // 
            this.btnColorTable.Location = new System.Drawing.Point(19, 19);
            this.btnColorTable.Name = "btnColorTable";
            this.btnColorTable.Size = new System.Drawing.Size(97, 21);
            this.btnColorTable.TabIndex = 1;
            this.btnColorTable.UseVisualStyleBackColor = true;
            this.btnColorTable.Click += new System.EventHandler(this.btnColorTable_Click);
            // 
            // cbLineWidth
            // 
            this.cbLineWidth.FormattingEnabled = true;
            this.cbLineWidth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbLineWidth.Location = new System.Drawing.Point(19, 19);
            this.cbLineWidth.Name = "cbLineWidth";
            this.cbLineWidth.Size = new System.Drawing.Size(97, 21);
            this.cbLineWidth.TabIndex = 2;
            this.cbLineWidth.Text = "1";
            this.cbLineWidth.SelectedIndexChanged += new System.EventHandler(this.cbLineWidth_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnPentagon);
            this.groupBox1.Controls.Add(this.btnLine);
            this.groupBox1.Controls.Add(this.btnTriangle);
            this.groupBox1.Controls.Add(this.btnEllipse);
            this.groupBox1.Controls.Add(this.btnCircle);
            this.groupBox1.Controls.Add(this.btnRec);
            this.groupBox1.Location = new System.Drawing.Point(1035, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 231);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shapes";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Hexagon";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnHexagon_Click);
            // 
            // btnPentagon
            // 
            this.btnPentagon.Location = new System.Drawing.Point(34, 165);
            this.btnPentagon.Name = "btnPentagon";
            this.btnPentagon.Size = new System.Drawing.Size(69, 23);
            this.btnPentagon.TabIndex = 1;
            this.btnPentagon.Text = "Pentagon";
            this.btnPentagon.UseVisualStyleBackColor = true;
            this.btnPentagon.Click += new System.EventHandler(this.btnPentagon_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(34, 21);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(69, 23);
            this.btnLine.TabIndex = 1;
            this.btnLine.Text = "Line";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.Location = new System.Drawing.Point(34, 107);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(69, 23);
            this.btnTriangle.TabIndex = 1;
            this.btnTriangle.Text = "Triangle";
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.Location = new System.Drawing.Point(34, 78);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(69, 23);
            this.btnEllipse.TabIndex = 1;
            this.btnEllipse.Text = "Ellipse";
            this.btnEllipse.UseVisualStyleBackColor = true;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(34, 49);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(69, 23);
            this.btnCircle.TabIndex = 1;
            this.btnCircle.Text = "Circle";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnRec
            // 
            this.btnRec.Location = new System.Drawing.Point(34, 136);
            this.btnRec.Name = "btnRec";
            this.btnRec.Size = new System.Drawing.Size(69, 23);
            this.btnRec.TabIndex = 1;
            this.btnRec.Text = "Rectangle";
            this.btnRec.UseVisualStyleBackColor = true;
            this.btnRec.Click += new System.EventHandler(this.btnRec_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbLineWidth);
            this.groupBox2.Location = new System.Drawing.Point(1035, 316);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 52);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Size";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnColorTable);
            this.groupBox3.Location = new System.Drawing.Point(1035, 396);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 52);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Color";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(1, 20);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(33, 13);
            this.lbStatus.TabIndex = 7;
            this.lbStatus.Text = "None";
            // 
            // lbLineGLTimer
            // 
            this.lbLineGLTimer.AutoSize = true;
            this.lbLineGLTimer.Location = new System.Drawing.Point(6, 16);
            this.lbLineGLTimer.Name = "lbLineGLTimer";
            this.lbLineGLTimer.Size = new System.Drawing.Size(94, 13);
            this.lbLineGLTimer.TabIndex = 8;
            this.lbLineGLTimer.Text = "Line:       0.000 ms";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbStatus);
            this.groupBox4.Location = new System.Drawing.Point(1035, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(143, 52);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Drawing";
            // 
            // gbTimer
            // 
            this.gbTimer.Controls.Add(this.lbAlgorithm);
            this.gbTimer.Controls.Add(this.btnResetTimer);
            this.gbTimer.Controls.Add(this.btnStopTimer);
            this.gbTimer.Controls.Add(this.lbTriGLTimer);
            this.gbTimer.Controls.Add(this.lbEllipseGLTimer);
            this.gbTimer.Controls.Add(this.lbPenGLTimer);
            this.gbTimer.Controls.Add(this.lbHexGLTimer);
            this.gbTimer.Controls.Add(this.lbRecGLTimer);
            this.gbTimer.Controls.Add(this.lbCirGLTimer);
            this.gbTimer.Controls.Add(this.lbLineGLTimer);
            this.gbTimer.Location = new System.Drawing.Point(12, 4);
            this.gbTimer.Name = "gbTimer";
            this.gbTimer.Size = new System.Drawing.Size(510, 62);
            this.gbTimer.TabIndex = 10;
            this.gbTimer.TabStop = false;
            this.gbTimer.Text = "OpenGL Algorithm Timer";
            // 
            // lbAlgorithm
            // 
            this.lbAlgorithm.AutoSize = true;
            this.lbAlgorithm.Location = new System.Drawing.Point(6, 32);
            this.lbAlgorithm.Name = "lbAlgorithm";
            this.lbAlgorithm.Size = new System.Drawing.Size(0, 13);
            this.lbAlgorithm.TabIndex = 10;
            // 
            // btnStopTimer
            // 
            this.btnStopTimer.Location = new System.Drawing.Point(448, 11);
            this.btnStopTimer.Name = "btnStopTimer";
            this.btnStopTimer.Size = new System.Drawing.Size(56, 23);
            this.btnStopTimer.TabIndex = 9;
            this.btnStopTimer.Text = "Stop";
            this.btnStopTimer.UseVisualStyleBackColor = true;
            this.btnStopTimer.Click += new System.EventHandler(this.btnStopTimer_Click);
            // 
            // lbTriGLTimer
            // 
            this.lbTriGLTimer.AutoSize = true;
            this.lbTriGLTimer.Location = new System.Drawing.Point(6, 32);
            this.lbTriGLTimer.Name = "lbTriGLTimer";
            this.lbTriGLTimer.Size = new System.Drawing.Size(94, 13);
            this.lbTriGLTimer.TabIndex = 8;
            this.lbTriGLTimer.Text = "Triangle: 0.000 ms";
            // 
            // lbEllipseGLTimer
            // 
            this.lbEllipseGLTimer.AutoSize = true;
            this.lbEllipseGLTimer.Location = new System.Drawing.Point(213, 16);
            this.lbEllipseGLTimer.Name = "lbEllipseGLTimer";
            this.lbEllipseGLTimer.Size = new System.Drawing.Size(101, 13);
            this.lbEllipseGLTimer.TabIndex = 8;
            this.lbEllipseGLTimer.Text = "Ellipse:      0.000 ms";
            // 
            // lbPenGLTimer
            // 
            this.lbPenGLTimer.AutoSize = true;
            this.lbPenGLTimer.Location = new System.Drawing.Point(212, 32);
            this.lbPenGLTimer.Name = "lbPenGLTimer";
            this.lbPenGLTimer.Size = new System.Drawing.Size(102, 13);
            this.lbPenGLTimer.TabIndex = 8;
            this.lbPenGLTimer.Text = "Pentagon: 0.000 ms";
            // 
            // lbHexGLTimer
            // 
            this.lbHexGLTimer.AutoSize = true;
            this.lbHexGLTimer.Location = new System.Drawing.Point(317, 32);
            this.lbHexGLTimer.Name = "lbHexGLTimer";
            this.lbHexGLTimer.Size = new System.Drawing.Size(99, 13);
            this.lbHexGLTimer.TabIndex = 8;
            this.lbHexGLTimer.Text = "Hexagon: 0.000 ms";
            // 
            // lbRecGLTimer
            // 
            this.lbRecGLTimer.AutoSize = true;
            this.lbRecGLTimer.Location = new System.Drawing.Point(104, 32);
            this.lbRecGLTimer.Name = "lbRecGLTimer";
            this.lbRecGLTimer.Size = new System.Drawing.Size(105, 13);
            this.lbRecGLTimer.TabIndex = 8;
            this.lbRecGLTimer.Text = "Rectangle: 0.000 ms";
            // 
            // lbCirGLTimer
            // 
            this.lbCirGLTimer.AutoSize = true;
            this.lbCirGLTimer.Location = new System.Drawing.Point(106, 16);
            this.lbCirGLTimer.Name = "lbCirGLTimer";
            this.lbCirGLTimer.Size = new System.Drawing.Size(103, 13);
            this.lbCirGLTimer.TabIndex = 8;
            this.lbCirGLTimer.Text = "Circle:        0.000 ms";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.openGLControl);
            this.groupBox6.Location = new System.Drawing.Point(1, 72);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1028, 619);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Draw Area";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbAlgorithm);
            this.groupBox7.Location = new System.Drawing.Point(1035, 477);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(143, 67);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Algorithm";
            // 
            // cbAlgorithm
            // 
            this.cbAlgorithm.FormattingEnabled = true;
            this.cbAlgorithm.Items.AddRange(new object[] {
            "OpenGL",
            "Theory"});
            this.cbAlgorithm.Location = new System.Drawing.Point(19, 29);
            this.cbAlgorithm.Name = "cbAlgorithm";
            this.cbAlgorithm.Size = new System.Drawing.Size(97, 21);
            this.cbAlgorithm.TabIndex = 3;
            this.cbAlgorithm.Text = "OpenGL";
            this.cbAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cbAlgorithm_SelectedIndexChanged);
            // 
            // btnClearShape
            // 
            this.btnClearShape.Location = new System.Drawing.Point(595, 26);
            this.btnClearShape.Name = "btnClearShape";
            this.btnClearShape.Size = new System.Drawing.Size(131, 23);
            this.btnClearShape.TabIndex = 12;
            this.btnClearShape.Text = "Clear All Shapes";
            this.btnClearShape.UseVisualStyleBackColor = true;
            this.btnClearShape.Click += new System.EventHandler(this.btnClearShape_Click);
            // 
            // btnResetTimer
            // 
            this.btnResetTimer.Location = new System.Drawing.Point(448, 33);
            this.btnResetTimer.Name = "btnResetTimer";
            this.btnResetTimer.Size = new System.Drawing.Size(56, 23);
            this.btnResetTimer.TabIndex = 9;
            this.btnResetTimer.Text = "Reset";
            this.btnResetTimer.UseVisualStyleBackColor = true;
            this.btnResetTimer.Click += new System.EventHandler(this.btnResetTimer_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1184, 691);
            this.Controls.Add(this.btnClearShape);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.gbTimer);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 730);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 730);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint Clone";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbTimer.ResumeLayout(false);
            this.gbTimer.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Button btnColorTable;
        private System.Windows.Forms.ColorDialog colorDlg;
        private System.Windows.Forms.ComboBox cbLineWidth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPentagon;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnRec;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Label lbLineGLTimer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox gbTimer;
        private System.Windows.Forms.Button btnStopTimer;
        private System.Windows.Forms.Label lbAlgorithm;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbTriGLTimer;
        private System.Windows.Forms.Label lbEllipseGLTimer;
        private System.Windows.Forms.Label lbPenGLTimer;
        private System.Windows.Forms.Label lbHexGLTimer;
        private System.Windows.Forms.Label lbRecGLTimer;
        private System.Windows.Forms.Label lbCirGLTimer;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox cbAlgorithm;
        private System.Windows.Forms.Button btnClearShape;
        private System.Windows.Forms.Button btnResetTimer;
    }
}

