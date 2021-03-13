namespace Kuto
{
    partial class KutoBrowser
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
            this.components = new System.ComponentModel.Container();
            this.tmrLoader = new System.Windows.Forms.Timer(this.components);
            this.tmrTrigger = new System.Windows.Forms.Timer(this.components);
            this.timeout = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrLoader
            // 
            this.tmrLoader.Enabled = true;
            this.tmrLoader.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmrTrigger
            // 
            this.tmrTrigger.Interval = 500;
            this.tmrTrigger.Tick += new System.EventHandler(this.tmrTrigger_Tick);
            // 
            // timeout
            // 
            this.timeout.Enabled = true;
            this.timeout.Interval = 60000;
            this.timeout.Tick += new System.EventHandler(this.timeout_Tick);
            // 
            // KutoBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 179);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KutoBrowser";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Kuto";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrLoader;
        private System.Windows.Forms.Timer tmrTrigger;
        private System.Windows.Forms.Timer timeout;
    }
}