namespace CHECK_HOTMAIL_LINKED_FACEBOOK
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
        private void InitializeComponent()
        {
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnImPort = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSaveListTrue = new System.Windows.Forms.Button();
            this.btnStopp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(14, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(51, 16);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Resutl";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(475, 76);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(127, 41);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnImPort
            // 
            this.btnImPort.Location = new System.Drawing.Point(475, 29);
            this.btnImPort.Name = "btnImPort";
            this.btnImPort.Size = new System.Drawing.Size(127, 41);
            this.btnImPort.TabIndex = 3;
            this.btnImPort.Text = "ImPort";
            this.btnImPort.UseVisualStyleBackColor = true;
            this.btnImPort.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(15, 29);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(453, 380);
            this.txtResult.TabIndex = 4;
            this.txtResult.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar1.Location = new System.Drawing.Point(17, 415);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(451, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(475, 123);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(127, 41);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Exit";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSaveListTrue
            // 
            this.btnSaveListTrue.Location = new System.Drawing.Point(476, 171);
            this.btnSaveListTrue.Name = "btnSaveListTrue";
            this.btnSaveListTrue.Size = new System.Drawing.Size(126, 51);
            this.btnSaveListTrue.TabIndex = 7;
            this.btnSaveListTrue.Text = "Save";
            this.btnSaveListTrue.UseVisualStyleBackColor = true;
            this.btnSaveListTrue.Click += new System.EventHandler(this.btnSaveListTrue_Click);
            // 
            // btnStopp
            // 
            this.btnStopp.Location = new System.Drawing.Point(476, 228);
            this.btnStopp.Name = "btnStopp";
            this.btnStopp.Size = new System.Drawing.Size(126, 46);
            this.btnStopp.TabIndex = 8;
            this.btnStopp.Text = "Stop";
            this.btnStopp.UseVisualStyleBackColor = true;
            this.btnStopp.Click += new System.EventHandler(this.btnStopp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 450);
            this.Controls.Add(this.btnStopp);
            this.Controls.Add(this.btnSaveListTrue);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnImPort);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lbl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Mail Linked Facebook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnImPort;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSaveListTrue;
        private System.Windows.Forms.Button btnStopp;
    }
}

