
namespace CSharpProgrWFGraphs
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.timerTrackBars = new System.Windows.Forms.Timer(this.components);
            this.trackBarScale = new System.Windows.Forms.TrackBar();
            this.buttonGenGraph = new System.Windows.Forms.Button();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelChance = new System.Windows.Forms.Label();
            this.trackBarConnectionChance = new System.Windows.Forms.TrackBar();
            this.richTextBoxAjacencyMatrix = new System.Windows.Forms.RichTextBox();
            this.labelVertexFrom = new System.Windows.Forms.Label();
            this.trackBarVertexTo = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarConnectionChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVertexTo)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleOpenGlControl1
            // 
            this.simpleOpenGlControl1.AccumBits = ((byte)(0));
            this.simpleOpenGlControl1.AutoCheckErrors = false;
            this.simpleOpenGlControl1.AutoFinish = false;
            this.simpleOpenGlControl1.AutoMakeCurrent = true;
            this.simpleOpenGlControl1.AutoSwapBuffers = true;
            this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Black;
            this.simpleOpenGlControl1.ColorBits = ((byte)(32));
            this.simpleOpenGlControl1.DepthBits = ((byte)(16));
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(0, 0);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(787, 765);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            // 
            // timerTrackBars
            // 
            this.timerTrackBars.Interval = 16;
            this.timerTrackBars.Tick += new System.EventHandler(this.timerTrackBars_Tick);
            // 
            // trackBarScale
            // 
            this.trackBarScale.Location = new System.Drawing.Point(100, 0);
            this.trackBarScale.Minimum = 1;
            this.trackBarScale.Name = "trackBarScale";
            this.trackBarScale.Size = new System.Drawing.Size(200, 45);
            this.trackBarScale.TabIndex = 1;
            this.trackBarScale.Value = 1;
            // 
            // buttonGenGraph
            // 
            this.buttonGenGraph.Location = new System.Drawing.Point(485, 0);
            this.buttonGenGraph.Name = "buttonGenGraph";
            this.buttonGenGraph.Size = new System.Drawing.Size(302, 45);
            this.buttonGenGraph.TabIndex = 2;
            this.buttonGenGraph.Text = "Generate New Graph";
            this.buttonGenGraph.UseVisualStyleBackColor = true;
            this.buttonGenGraph.Click += new System.EventHandler(this.buttonGenGraph_Click);
            // 
            // labelSize
            // 
            this.labelSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSize.Location = new System.Drawing.Point(0, 0);
            this.labelSize.Name = "labelSize";
            this.labelSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelSize.Size = new System.Drawing.Size(100, 45);
            this.labelSize.TabIndex = 3;
            this.labelSize.Text = "Scale";
            this.labelSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelChance
            // 
            this.labelChance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelChance.Location = new System.Drawing.Point(485, 45);
            this.labelChance.Name = "labelChance";
            this.labelChance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelChance.Size = new System.Drawing.Size(106, 45);
            this.labelChance.TabIndex = 4;
            this.labelChance.Text = "Connection Chance";
            this.labelChance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarConnectionChance
            // 
            this.trackBarConnectionChance.Location = new System.Drawing.Point(587, 45);
            this.trackBarConnectionChance.Maximum = 100;
            this.trackBarConnectionChance.Name = "trackBarConnectionChance";
            this.trackBarConnectionChance.Size = new System.Drawing.Size(200, 45);
            this.trackBarConnectionChance.TabIndex = 5;
            this.trackBarConnectionChance.Value = 50;
            // 
            // richTextBoxAjacencyMatrix
            // 
            this.richTextBoxAjacencyMatrix.Location = new System.Drawing.Point(0, 45);
            this.richTextBoxAjacencyMatrix.Name = "richTextBoxAjacencyMatrix";
            this.richTextBoxAjacencyMatrix.Size = new System.Drawing.Size(112, 112);
            this.richTextBoxAjacencyMatrix.TabIndex = 6;
            this.richTextBoxAjacencyMatrix.Text = "";
            // 
            // labelVertexFrom
            // 
            this.labelVertexFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelVertexFrom.Location = new System.Drawing.Point(112, 45);
            this.labelVertexFrom.Name = "labelVertexFrom";
            this.labelVertexFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelVertexFrom.Size = new System.Drawing.Size(100, 45);
            this.labelVertexFrom.TabIndex = 7;
            this.labelVertexFrom.Text = "From v0 to v";
            this.labelVertexFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarVertexTo
            // 
            this.trackBarVertexTo.Location = new System.Drawing.Point(112, 90);
            this.trackBarVertexTo.Minimum = 1;
            this.trackBarVertexTo.Name = "trackBarVertexTo";
            this.trackBarVertexTo.Size = new System.Drawing.Size(100, 45);
            this.trackBarVertexTo.TabIndex = 8;
            this.trackBarVertexTo.Value = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.trackBarVertexTo);
            this.Controls.Add(this.labelVertexFrom);
            this.Controls.Add(this.richTextBoxAjacencyMatrix);
            this.Controls.Add(this.trackBarConnectionChance);
            this.Controls.Add(this.labelChance);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.buttonGenGraph);
            this.Controls.Add(this.trackBarScale);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarConnectionChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVertexTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.Timer timerTrackBars;
        private System.Windows.Forms.TrackBar trackBarScale;
        private System.Windows.Forms.Button buttonGenGraph;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelChance;
        private System.Windows.Forms.TrackBar trackBarConnectionChance;
        private System.Windows.Forms.RichTextBox richTextBoxAjacencyMatrix;
        private System.Windows.Forms.Label labelVertexFrom;
        private System.Windows.Forms.TrackBar trackBarVertexTo;
    }
}

