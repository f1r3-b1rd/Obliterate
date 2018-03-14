namespace obliterate
{
    partial class ProgressForm
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
            this.pBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pBar1
            // 
            this.pBar1.Location = new System.Drawing.Point(63, 64);
            this.pBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pBar1.Name = "pBar1";
            this.pBar1.Size = new System.Drawing.Size(260, 28);
            this.pBar1.Step = 1;
            this.pBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar1.TabIndex = 1;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 156);
            this.ControlBox = false;
            this.Controls.Add(this.pBar1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Processing";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ProgressBar pBar1;
        private System.Windows.Forms.Label messageLabel;
        #endregion
    }
}