namespace ScanPmrWinForm.Views
{
    partial class DetailPmrForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFronte = new System.Windows.Forms.TabPage();
            this.tabRetro = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBoxFronte = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBoxRetro = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tabFronte.SuspendLayout();
            this.tabRetro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFronte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetro)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabFronte);
            this.tabControl.Controls.Add(this.tabRetro);
            this.tabControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(8, 8);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tabFronte
            // 
            this.tabFronte.BackColor = System.Drawing.Color.Transparent;
            this.tabFronte.Controls.Add(this.button1);
            this.tabFronte.Controls.Add(this.pictureBoxFronte);
            this.tabFronte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabFronte.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabFronte.Location = new System.Drawing.Point(4, 44);
            this.tabFronte.Name = "tabFronte";
            this.tabFronte.Padding = new System.Windows.Forms.Padding(3);
            this.tabFronte.Size = new System.Drawing.Size(792, 402);
            this.tabFronte.TabIndex = 0;
            this.tabFronte.Text = "Fronte";
            // 
            // tabRetro
            // 
            this.tabRetro.Controls.Add(this.button2);
            this.tabRetro.Controls.Add(this.pictureBoxRetro);
            this.tabRetro.Location = new System.Drawing.Point(4, 44);
            this.tabRetro.Name = "tabRetro";
            this.tabRetro.Padding = new System.Windows.Forms.Padding(3);
            this.tabRetro.Size = new System.Drawing.Size(792, 402);
            this.tabRetro.TabIndex = 1;
            this.tabRetro.Text = "Retro";
            this.tabRetro.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Image = global::ScanPmrWinForm.Properties.Resources.icons8_ruota_a_sinistra_60;
            this.button1.Location = new System.Drawing.Point(6, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 72);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ruota";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBoxFronte
            // 
            this.pictureBoxFronte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxFronte.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxFronte.Name = "pictureBoxFronte";
            this.pictureBoxFronte.Size = new System.Drawing.Size(786, 396);
            this.pictureBoxFronte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFronte.TabIndex = 1;
            this.pictureBoxFronte.TabStop = false;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.button2.FlatAppearance.BorderSize = 3;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(182)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Image = global::ScanPmrWinForm.Properties.Resources.icons8_ruota_a_sinistra_60;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 72);
            this.button2.TabIndex = 3;
            this.button2.Text = "Ruota";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBoxRetro
            // 
            this.pictureBoxRetro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRetro.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxRetro.Name = "pictureBoxRetro";
            this.pictureBoxRetro.Size = new System.Drawing.Size(786, 396);
            this.pictureBoxRetro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRetro.TabIndex = 0;
            this.pictureBoxRetro.TabStop = false;
            // 
            // DetailPmrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "DetailPmrForm";
            this.Text = "DetailPmrForm";
            this.tabControl.ResumeLayout(false);
            this.tabFronte.ResumeLayout(false);
            this.tabFronte.PerformLayout();
            this.tabRetro.ResumeLayout(false);
            this.tabRetro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFronte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabFronte;
        private System.Windows.Forms.TabPage tabRetro;
        private System.Windows.Forms.PictureBox pictureBoxFronte;
        private System.Windows.Forms.PictureBox pictureBoxRetro;
        public System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}