namespace ScanPmrWinForm.Views
{
    partial class PmrNumberForm
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
            this.numericPmr = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblerrmsg = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericPmr)).BeginInit();
            this.SuspendLayout();
            // 
            // numericPmr
            // 
            this.numericPmr.Location = new System.Drawing.Point(26, 65);
            this.numericPmr.Name = "numericPmr";
            this.numericPmr.Size = new System.Drawing.Size(182, 20);
            this.numericPmr.TabIndex = 0;
            this.numericPmr.ValueChanged += new System.EventHandler(this.numericPmr_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(23, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inserisci il numero di PMR da scansire";
            // 
            // lblerrmsg
            // 
            this.lblerrmsg.AutoSize = true;
            this.lblerrmsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblerrmsg.Location = new System.Drawing.Point(40, 88);
            this.lblerrmsg.Name = "lblerrmsg";
            this.lblerrmsg.Size = new System.Drawing.Size(0, 13);
            this.lblerrmsg.TabIndex = 8;
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.Transparent;
            this.btnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnContinue.FlatAppearance.BorderSize = 3;
            this.btnContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Location = new System.Drawing.Point(26, 111);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(182, 40);
            this.btnContinue.TabIndex = 9;
            this.btnContinue.TabStop = false;
            this.btnContinue.Text = "CONTINUA";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // PmrNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(235, 163);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.lblerrmsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericPmr);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PmrNumberForm";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.numericPmr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericPmr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblerrmsg;
        private System.Windows.Forms.Button btnContinue;
    }
}