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
            this.gbShape = new System.Windows.Forms.GroupBox();
            this.btnPolygon = new System.Windows.Forms.Button();
            this.btnHexagon = new System.Windows.Forms.Button();
            this.btnPentagon = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.gbColor = new System.Windows.Forms.GroupBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbLineGLTimer = new System.Windows.Forms.Label();
            this.gbDrawing = new System.Windows.Forms.GroupBox();
            this.gbTimer = new System.Windows.Forms.GroupBox();
            this.lbAlgorithm = new System.Windows.Forms.Label();
            this.btnResetTimer = new System.Windows.Forms.Button();
            this.btnStopTimer = new System.Windows.Forms.Button();
            this.lbTriGLTimer = new System.Windows.Forms.Label();
            this.lbEllipseGLTimer = new System.Windows.Forms.Label();
            this.lbPenGLTimer = new System.Windows.Forms.Label();
            this.lbHexGLTimer = new System.Windows.Forms.Label();
            this.lbRecGLTimer = new System.Windows.Forms.Label();
            this.lbCirGLTimer = new System.Windows.Forms.Label();
            this.gbDrawArea = new System.Windows.Forms.GroupBox();
            this.gbAlgorithm = new System.Windows.Forms.GroupBox();
            this.cbAlgorithm = new System.Windows.Forms.ComboBox();
            this.btnClearShape = new System.Windows.Forms.Button();
            this.btnScanLineFill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.gbShape.SuspendLayout();
            this.gbSize.SuspendLayout();
            this.gbColor.SuspendLayout();
            this.gbDrawing.SuspendLayout();
            this.gbTimer.SuspendLayout();
            this.gbDrawArea.SuspendLayout();
            this.gbAlgorithm.SuspendLayout();
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
            // gbShape
            // 
            this.gbShape.Controls.Add(this.btnPolygon);
            this.gbShape.Controls.Add(this.btnHexagon);
            this.gbShape.Controls.Add(this.btnPentagon);
            this.gbShape.Controls.Add(this.btnLine);
            this.gbShape.Controls.Add(this.btnTriangle);
            this.gbShape.Controls.Add(this.btnEllipse);
            this.gbShape.Controls.Add(this.btnCircle);
            this.gbShape.Controls.Add(this.btnRectangle);
            this.gbShape.Location = new System.Drawing.Point(1035, 72);
            this.gbShape.Name = "gbShape";
            this.gbShape.Size = new System.Drawing.Size(143, 260);
            this.gbShape.TabIndex = 4;
            this.gbShape.TabStop = false;
            this.gbShape.Text = "Shapes";
            // 
            // btnPolygon
            // 
            this.btnPolygon.Location = new System.Drawing.Point(13, 223);
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(118, 23);
            this.btnPolygon.TabIndex = 1;
            this.btnPolygon.Text = "Polygon";
            this.btnPolygon.UseVisualStyleBackColor = true;
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // btnHexagon
            // 
            this.btnHexagon.Location = new System.Drawing.Point(13, 194);
            this.btnHexagon.Name = "btnHexagon";
            this.btnHexagon.Size = new System.Drawing.Size(118, 23);
            this.btnHexagon.TabIndex = 1;
            this.btnHexagon.Text = "Equilateral Hexagon";
            this.btnHexagon.UseVisualStyleBackColor = true;
            this.btnHexagon.Click += new System.EventHandler(this.btnHexagon_Click);
            // 
            // btnPentagon
            // 
            this.btnPentagon.Location = new System.Drawing.Point(13, 165);
            this.btnPentagon.Name = "btnPentagon";
            this.btnPentagon.Size = new System.Drawing.Size(118, 23);
            this.btnPentagon.TabIndex = 1;
            this.btnPentagon.Text = "Equilateral Pentagon";
            this.btnPentagon.UseVisualStyleBackColor = true;
            this.btnPentagon.Click += new System.EventHandler(this.btnPentagon_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(13, 21);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(118, 23);
            this.btnLine.TabIndex = 1;
            this.btnLine.Text = "Line";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.Location = new System.Drawing.Point(13, 107);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(118, 23);
            this.btnTriangle.TabIndex = 1;
            this.btnTriangle.Text = "Equilateral Triangle";
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.Location = new System.Drawing.Point(13, 78);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(118, 23);
            this.btnEllipse.TabIndex = 1;
            this.btnEllipse.Text = "Ellipse";
            this.btnEllipse.UseVisualStyleBackColor = true;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(13, 50);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(118, 23);
            this.btnCircle.TabIndex = 1;
            this.btnCircle.Text = "Circle";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Location = new System.Drawing.Point(13, 136);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(118, 23);
            this.btnRectangle.TabIndex = 1;
            this.btnRectangle.Text = "Rectangle";
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnRec_Click);
            // 
            // gbSize
            // 
            this.gbSize.Controls.Add(this.cbLineWidth);
            this.gbSize.Location = new System.Drawing.Point(1035, 359);
            this.gbSize.Name = "gbSize";
            this.gbSize.Size = new System.Drawing.Size(143, 52);
            this.gbSize.TabIndex = 5;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Size";
            // 
            // gbColor
            // 
            this.gbColor.Controls.Add(this.btnColorTable);
            this.gbColor.Location = new System.Drawing.Point(1035, 439);
            this.gbColor.Name = "gbColor";
            this.gbColor.Size = new System.Drawing.Size(143, 52);
            this.gbColor.TabIndex = 6;
            this.gbColor.TabStop = false;
            this.gbColor.Text = "Color";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(6, 20);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(45, 16);
            this.lbStatus.TabIndex = 7;
            this.lbStatus.Text = "None";
            // 
            // lbLineGLTimer
            // 
            this.lbLineGLTimer.AutoSize = true;
            this.lbLineGLTimer.Location = new System.Drawing.Point(6, 19);
            this.lbLineGLTimer.Name = "lbLineGLTimer";
            this.lbLineGLTimer.Size = new System.Drawing.Size(94, 13);
            this.lbLineGLTimer.TabIndex = 8;
            this.lbLineGLTimer.Text = "Line:       0.000 ms";
            // 
            // gbDrawing
            // 
            this.gbDrawing.Controls.Add(this.lbStatus);
            this.gbDrawing.Location = new System.Drawing.Point(936, 12);
            this.gbDrawing.Name = "gbDrawing";
            this.gbDrawing.Size = new System.Drawing.Size(242, 52);
            this.gbDrawing.TabIndex = 9;
            this.gbDrawing.TabStop = false;
            this.gbDrawing.Text = "Drawing";
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
            this.gbTimer.Size = new System.Drawing.Size(577, 62);
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
            // btnResetTimer
            // 
            this.btnResetTimer.Location = new System.Drawing.Point(515, 33);
            this.btnResetTimer.Name = "btnResetTimer";
            this.btnResetTimer.Size = new System.Drawing.Size(56, 23);
            this.btnResetTimer.TabIndex = 9;
            this.btnResetTimer.Text = "Reset";
            this.btnResetTimer.UseVisualStyleBackColor = true;
            this.btnResetTimer.Click += new System.EventHandler(this.btnResetTimer_Click);
            // 
            // btnStopTimer
            // 
            this.btnStopTimer.Location = new System.Drawing.Point(515, 11);
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
            this.lbTriGLTimer.Location = new System.Drawing.Point(6, 35);
            this.lbTriGLTimer.Name = "lbTriGLTimer";
            this.lbTriGLTimer.Size = new System.Drawing.Size(94, 13);
            this.lbTriGLTimer.TabIndex = 8;
            this.lbTriGLTimer.Text = "Triangle: 0.000 ms";
            // 
            // lbEllipseGLTimer
            // 
            this.lbEllipseGLTimer.AutoSize = true;
            this.lbEllipseGLTimer.Location = new System.Drawing.Point(244, 19);
            this.lbEllipseGLTimer.Name = "lbEllipseGLTimer";
            this.lbEllipseGLTimer.Size = new System.Drawing.Size(101, 13);
            this.lbEllipseGLTimer.TabIndex = 8;
            this.lbEllipseGLTimer.Text = "Ellipse:      0.000 ms";
            // 
            // lbPenGLTimer
            // 
            this.lbPenGLTimer.AutoSize = true;
            this.lbPenGLTimer.Location = new System.Drawing.Point(243, 35);
            this.lbPenGLTimer.Name = "lbPenGLTimer";
            this.lbPenGLTimer.Size = new System.Drawing.Size(102, 13);
            this.lbPenGLTimer.TabIndex = 8;
            this.lbPenGLTimer.Text = "Pentagon: 0.000 ms";
            // 
            // lbHexGLTimer
            // 
            this.lbHexGLTimer.AutoSize = true;
            this.lbHexGLTimer.Location = new System.Drawing.Point(369, 35);
            this.lbHexGLTimer.Name = "lbHexGLTimer";
            this.lbHexGLTimer.Size = new System.Drawing.Size(99, 13);
            this.lbHexGLTimer.TabIndex = 8;
            this.lbHexGLTimer.Text = "Hexagon: 0.000 ms";
            // 
            // lbRecGLTimer
            // 
            this.lbRecGLTimer.AutoSize = true;
            this.lbRecGLTimer.Location = new System.Drawing.Point(116, 35);
            this.lbRecGLTimer.Name = "lbRecGLTimer";
            this.lbRecGLTimer.Size = new System.Drawing.Size(105, 13);
            this.lbRecGLTimer.TabIndex = 8;
            this.lbRecGLTimer.Text = "Rectangle: 0.000 ms";
            // 
            // lbCirGLTimer
            // 
            this.lbCirGLTimer.AutoSize = true;
            this.lbCirGLTimer.Location = new System.Drawing.Point(118, 19);
            this.lbCirGLTimer.Name = "lbCirGLTimer";
            this.lbCirGLTimer.Size = new System.Drawing.Size(103, 13);
            this.lbCirGLTimer.TabIndex = 8;
            this.lbCirGLTimer.Text = "Circle:        0.000 ms";
            // 
            // gbDrawArea
            // 
            this.gbDrawArea.Controls.Add(this.openGLControl);
            this.gbDrawArea.Location = new System.Drawing.Point(1, 72);
            this.gbDrawArea.Name = "gbDrawArea";
            this.gbDrawArea.Size = new System.Drawing.Size(1028, 619);
            this.gbDrawArea.TabIndex = 11;
            this.gbDrawArea.TabStop = false;
            this.gbDrawArea.Text = "Draw Area";
            // 
            // gbAlgorithm
            // 
            this.gbAlgorithm.Controls.Add(this.cbAlgorithm);
            this.gbAlgorithm.Location = new System.Drawing.Point(1035, 520);
            this.gbAlgorithm.Name = "gbAlgorithm";
            this.gbAlgorithm.Size = new System.Drawing.Size(143, 67);
            this.gbAlgorithm.TabIndex = 1;
            this.gbAlgorithm.TabStop = false;
            this.gbAlgorithm.Text = "Algorithm";
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
            this.btnClearShape.Location = new System.Drawing.Point(694, 29);
            this.btnClearShape.Name = "btnClearShape";
            this.btnClearShape.Size = new System.Drawing.Size(131, 23);
            this.btnClearShape.TabIndex = 12;
            this.btnClearShape.Text = "Clear All Shapes";
            this.btnClearShape.UseVisualStyleBackColor = true;
            this.btnClearShape.Click += new System.EventHandler(this.btnClearShape_Click);
            // 
            // btnScanLineFill
            // 
            this.btnScanLineFill.Location = new System.Drawing.Point(1054, 608);
            this.btnScanLineFill.Name = "btnScanLineFill";
            this.btnScanLineFill.Size = new System.Drawing.Size(97, 23);
            this.btnScanLineFill.TabIndex = 13;
            this.btnScanLineFill.Text = "Scan Line Fill";
            this.btnScanLineFill.UseVisualStyleBackColor = true;
            this.btnScanLineFill.Click += new System.EventHandler(this.btnScanLineFill_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1184, 691);
            this.Controls.Add(this.btnScanLineFill);
            this.Controls.Add(this.btnClearShape);
            this.Controls.Add(this.gbAlgorithm);
            this.Controls.Add(this.gbDrawArea);
            this.Controls.Add(this.gbTimer);
            this.Controls.Add(this.gbDrawing);
            this.Controls.Add(this.gbColor);
            this.Controls.Add(this.gbSize);
            this.Controls.Add(this.gbShape);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 730);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 730);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint Clone";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.gbShape.ResumeLayout(false);
            this.gbSize.ResumeLayout(false);
            this.gbColor.ResumeLayout(false);
            this.gbDrawing.ResumeLayout(false);
            this.gbDrawing.PerformLayout();
            this.gbTimer.ResumeLayout(false);
            this.gbTimer.PerformLayout();
            this.gbDrawArea.ResumeLayout(false);
            this.gbAlgorithm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Button btnColorTable;
        private System.Windows.Forms.ColorDialog colorDlg;
        private System.Windows.Forms.ComboBox cbLineWidth;
        private System.Windows.Forms.GroupBox gbShape;
        private System.Windows.Forms.Button btnHexagon;
        private System.Windows.Forms.Button btnPentagon;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.GroupBox gbSize;
        private System.Windows.Forms.GroupBox gbColor;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Label lbLineGLTimer;
        private System.Windows.Forms.GroupBox gbDrawing;
        private System.Windows.Forms.GroupBox gbTimer;
        private System.Windows.Forms.Button btnStopTimer;
        private System.Windows.Forms.Label lbAlgorithm;
        private System.Windows.Forms.GroupBox gbDrawArea;
        private System.Windows.Forms.Label lbTriGLTimer;
        private System.Windows.Forms.Label lbEllipseGLTimer;
        private System.Windows.Forms.Label lbPenGLTimer;
        private System.Windows.Forms.Label lbHexGLTimer;
        private System.Windows.Forms.Label lbRecGLTimer;
        private System.Windows.Forms.Label lbCirGLTimer;
        private System.Windows.Forms.GroupBox gbAlgorithm;
        private System.Windows.Forms.ComboBox cbAlgorithm;
        private System.Windows.Forms.Button btnClearShape;
        private System.Windows.Forms.Button btnResetTimer;
        private System.Windows.Forms.Button btnPolygon;
        private System.Windows.Forms.Button btnScanLineFill;
    }
}

