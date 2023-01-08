
namespace DiagnosisPrognosisClient
{
    partial class Login
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.pbClose = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.pbSTIlogo = new System.Windows.Forms.PictureBox();
			this.txtIp = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSTIlogo)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
			this.panel1.Controls.Add(this.pbClose);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(464, 74);
			this.panel1.TabIndex = 0;
			// 
			// pbClose
			// 
			this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbClose.Image = global::DiagnosisPrognosisClient.Properties.Resources.Exit_new;
			this.pbClose.Location = new System.Drawing.Point(410, -16);
			this.pbClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pbClose.Name = "pbClose";
			this.pbClose.Size = new System.Drawing.Size(65, 67);
			this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbClose.TabIndex = 3;
			this.pbClose.TabStop = false;
			this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
			this.label3.Location = new System.Drawing.Point(24, 25);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 22);
			this.label3.TabIndex = 2;
			this.label3.Text = "Log in";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
			this.label1.Location = new System.Drawing.Point(24, 195);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(140, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Admin Username:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
			this.label2.Location = new System.Drawing.Point(24, 295);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "Password:";
			// 
			// txtUsername
			// 
			this.txtUsername.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.txtUsername.Location = new System.Drawing.Point(29, 234);
			this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(410, 30);
			this.txtUsername.TabIndex = 3;
			// 
			// txtPassword
			// 
			this.txtPassword.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.txtPassword.Location = new System.Drawing.Point(29, 333);
			this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(410, 32);
			this.txtPassword.TabIndex = 4;
			// 
			// btnLogin
			// 
			this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
			this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnLogin.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnLogin.Location = new System.Drawing.Point(180, 396);
			this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(110, 40);
			this.btnLogin.TabIndex = 5;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = false;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// btnClear
			// 
			this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(56)))), ((int)(((byte)(23)))));
			this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnClear.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnClear.Location = new System.Drawing.Point(180, 441);
			this.btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(110, 40);
			this.btnClear.TabIndex = 6;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// pbSTIlogo
			// 
			this.pbSTIlogo.Image = global::DiagnosisPrognosisClient.Properties.Resources.sti_logo;
			this.pbSTIlogo.Location = new System.Drawing.Point(186, 81);
			this.pbSTIlogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pbSTIlogo.Name = "pbSTIlogo";
			this.pbSTIlogo.Size = new System.Drawing.Size(93, 74);
			this.pbSTIlogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbSTIlogo.TabIndex = 1;
			this.pbSTIlogo.TabStop = false;
			// 
			// txtIp
			// 
			this.txtIp.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.txtIp.Location = new System.Drawing.Point(246, 173);
			this.txtIp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.txtIp.Name = "txtIp";
			this.txtIp.Size = new System.Drawing.Size(193, 32);
			this.txtIp.TabIndex = 7;
			this.txtIp.Text = "192.168.0.30";
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
			this.ClientSize = new System.Drawing.Size(464, 510);
			this.Controls.Add(this.txtIp);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.pbSTIlogo);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "Login";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSTIlogo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox pbSTIlogo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbClose;
		private TextBox txtIp;
	}
}