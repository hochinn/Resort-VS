namespace PROJECTRE
{
    partial class LOGINADMIN
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textUadd = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textPass = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PROJECTRE.Properties.Resources.iconfinder_application_pgp_signature_24736;
            this.pictureBox1.Location = new System.Drawing.Point(211, 85);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 171);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Angsana New", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 63);
            this.label1.TabIndex = 9;
            this.label1.Text = "LOGIN  ADMIN";
            // 
            // textUadd
            // 
            this.textUadd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textUadd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textUadd.Font = new System.Drawing.Font("Angsana New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUadd.Location = new System.Drawing.Point(92, 279);
            this.textUadd.Margin = new System.Windows.Forms.Padding(4);
            this.textUadd.Multiline = true;
            this.textUadd.Name = "textUadd";
            this.textUadd.Size = new System.Drawing.Size(424, 50);
            this.textUadd.TabIndex = 8;
            this.textUadd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(187, 413);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(202, 49);
            this.buttonLogin.TabIndex = 11;
            this.buttonLogin.Text = "LOGIN FOR ADMID";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // textPass
            // 
            this.textPass.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textPass.Font = new System.Drawing.Font("Angsana New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPass.Location = new System.Drawing.Point(92, 337);
            this.textPass.Margin = new System.Windows.Forms.Padding(4);
            this.textPass.Multiline = true;
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '*';
            this.textPass.Size = new System.Drawing.Size(424, 50);
            this.textPass.TabIndex = 12;
            this.textPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LOGINADMIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 519);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textUadd);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(622, 566);
            this.MinimumSize = new System.Drawing.Size(622, 566);
            this.Name = "LOGINADMIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGINADMIN";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textUadd;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textPass;
    }
}