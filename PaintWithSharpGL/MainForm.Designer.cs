namespace LineDraw
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
            this.btnLine = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnColorTable = new System.Windows.Forms.Button();
            this.colorDlg = new System.Windows.Forms.ColorDialog();
            this.btnRec = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.cbLineWidth = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(-1, 66);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(848, 438);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(22, 25);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(75, 23);
            this.btnLine.TabIndex = 1;
            this.btnLine.Text = "Line";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(184, 25);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(75, 23);
            this.btnCircle.TabIndex = 1;
            this.btnCircle.Text = "Circle";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnColorTable
            // 
            this.btnColorTable.Location = new System.Drawing.Point(757, 25);
            this.btnColorTable.Name = "btnColorTable";
            this.btnColorTable.Size = new System.Drawing.Size(75, 23);
            this.btnColorTable.TabIndex = 1;
            this.btnColorTable.Text = "Color Table";
            this.btnColorTable.UseVisualStyleBackColor = true;
            this.btnColorTable.Click += new System.EventHandler(this.btnColorTable_Click);
            // 
            // btnRec
            // 
            this.btnRec.Location = new System.Drawing.Point(103, 25);
            this.btnRec.Name = "btnRec";
            this.btnRec.Size = new System.Drawing.Size(75, 23);
            this.btnRec.TabIndex = 1;
            this.btnRec.Text = "Rec";
            this.btnRec.UseVisualStyleBackColor = true;
            this.btnRec.Click += new System.EventHandler(this.btnRec_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.Location = new System.Drawing.Point(265, 25);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(75, 23);
            this.btnTriangle.TabIndex = 1;
            this.btnTriangle.Text = "Triangle";
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // cbLineWidth
            // 
            this.cbLineWidth.FormattingEnabled = true;
            this.cbLineWidth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbLineWidth.Location = new System.Drawing.Point(399, 27);
            this.cbLineWidth.Name = "cbLineWidth";
            this.cbLineWidth.Size = new System.Drawing.Size(121, 21);
            this.cbLineWidth.TabIndex = 2;
            this.cbLineWidth.Text = "Line Width";
            this.cbLineWidth.SelectedIndexChanged += new System.EventHandler(this.cbLineWidth_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(844, 501);
            this.Controls.Add(this.cbLineWidth);
            this.Controls.Add(this.btnColorTable);
            this.Controls.Add(this.btnRec);
            this.Controls.Add(this.btnTriangle);
            this.Controls.Add(this.btnCircle);
            this.Controls.Add(this.btnLine);
            this.Controls.Add(this.openGLControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint Clone";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnColorTable;
        private System.Windows.Forms.ColorDialog colorDlg;
        private System.Windows.Forms.Button btnRec;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.ComboBox cbLineWidth;
    }
}

