
namespace DiagnosisPrognosisClient
{
    partial class Homepage
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
			this.lblInventory = new System.Windows.Forms.Label();
			this.pbInventory = new System.Windows.Forms.PictureBox();
			this.lblDiagnosis = new System.Windows.Forms.Label();
			this.pbDiagnosis = new System.Windows.Forms.PictureBox();
			this.lblPatient = new System.Windows.Forms.Label();
			this.pbPatient = new System.Windows.Forms.PictureBox();
			this.pbLogout = new System.Windows.Forms.PictureBox();
			this.lblLogout = new System.Windows.Forms.Label();
			this.pbSTIlogo = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pbClose = new System.Windows.Forms.PictureBox();
			this.pbSTICampus = new System.Windows.Forms.PictureBox();
			this.diagnosisUC1 = new DiagnosisPrognosisClient.DiagnosisUC();
			this.addPatientForm1 = new DiagnosisPrognosisClient.AddPatientForm();
			this.inventoryuc1 = new DiagnosisPrognosisClient.InventoryUC();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbInventory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDiagnosis)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPatient)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbLogout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSTIlogo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSTICampus)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(56)))), ((int)(((byte)(74)))));
			this.panel1.Controls.Add(this.lblInventory);
			this.panel1.Controls.Add(this.pbInventory);
			this.panel1.Controls.Add(this.lblDiagnosis);
			this.panel1.Controls.Add(this.pbDiagnosis);
			this.panel1.Controls.Add(this.lblPatient);
			this.panel1.Controls.Add(this.pbPatient);
			this.panel1.Controls.Add(this.pbLogout);
			this.panel1.Controls.Add(this.lblLogout);
			this.panel1.Location = new System.Drawing.Point(0, 77);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(198, 606);
			this.panel1.TabIndex = 3;
			// 
			// lblInventory
			// 
			this.lblInventory.AutoSize = true;
			this.lblInventory.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblInventory.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblInventory.ForeColor = System.Drawing.Color.White;
			this.lblInventory.Location = new System.Drawing.Point(71, 169);
			this.lblInventory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInventory.Name = "lblInventory";
			this.lblInventory.Size = new System.Drawing.Size(80, 19);
			this.lblInventory.TabIndex = 16;
			this.lblInventory.Text = "Inventory";
			this.lblInventory.Click += new System.EventHandler(this.pbInventory_Click);
			// 
			// pbInventory
			// 
			this.pbInventory.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbInventory.Image = global::DiagnosisPrognosisClient.Properties.Resources.rsz_update_details;
			this.pbInventory.Location = new System.Drawing.Point(13, 158);
			this.pbInventory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pbInventory.Name = "pbInventory";
			this.pbInventory.Size = new System.Drawing.Size(50, 40);
			this.pbInventory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbInventory.TabIndex = 15;
			this.pbInventory.TabStop = false;
			this.pbInventory.Click += new System.EventHandler(this.pbInventory_Click);
			// 
			// lblDiagnosis
			// 
			this.lblDiagnosis.AutoSize = true;
			this.lblDiagnosis.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblDiagnosis.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblDiagnosis.ForeColor = System.Drawing.Color.White;
			this.lblDiagnosis.Location = new System.Drawing.Point(71, 98);
			this.lblDiagnosis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDiagnosis.Name = "lblDiagnosis";
			this.lblDiagnosis.Size = new System.Drawing.Size(80, 19);
			this.lblDiagnosis.TabIndex = 14;
			this.lblDiagnosis.Text = "Diagnosis";
			this.lblDiagnosis.Click += new System.EventHandler(this.pbDiagnosis_Click);
			// 
			// pbDiagnosis
			// 
			this.pbDiagnosis.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbDiagnosis.Image = global::DiagnosisPrognosisClient.Properties.Resources.add_diag;
			this.pbDiagnosis.Location = new System.Drawing.Point(13, 88);
			this.pbDiagnosis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pbDiagnosis.Name = "pbDiagnosis";
			this.pbDiagnosis.Size = new System.Drawing.Size(50, 40);
			this.pbDiagnosis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbDiagnosis.TabIndex = 13;
			this.pbDiagnosis.TabStop = false;
			this.pbDiagnosis.Click += new System.EventHandler(this.pbDiagnosis_Click);
			// 
			// lblPatient
			// 
			this.lblPatient.AutoSize = true;
			this.lblPatient.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblPatient.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblPatient.ForeColor = System.Drawing.Color.White;
			this.lblPatient.Location = new System.Drawing.Point(71, 27);
			this.lblPatient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPatient.Name = "lblPatient";
			this.lblPatient.Size = new System.Drawing.Size(63, 19);
			this.lblPatient.TabIndex = 12;
			this.lblPatient.Text = "Patient";
			this.lblPatient.Click += new System.EventHandler(this.pbPatient_Click);
			// 
			// pbPatient
			// 
			this.pbPatient.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbPatient.Image = global::DiagnosisPrognosisClient.Properties.Resources.add_new_patient;
			this.pbPatient.Location = new System.Drawing.Point(13, 17);
			this.pbPatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pbPatient.Name = "pbPatient";
			this.pbPatient.Size = new System.Drawing.Size(50, 40);
			this.pbPatient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbPatient.TabIndex = 11;
			this.pbPatient.TabStop = false;
			this.pbPatient.Click += new System.EventHandler(this.pbPatient_Click);
			// 
			// pbLogout
			// 
			this.pbLogout.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbLogout.Image = global::DiagnosisPrognosisClient.Properties.Resources.Logout;
			this.pbLogout.Location = new System.Drawing.Point(13, 225);
			this.pbLogout.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pbLogout.Name = "pbLogout";
			this.pbLogout.Size = new System.Drawing.Size(50, 51);
			this.pbLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbLogout.TabIndex = 10;
			this.pbLogout.TabStop = false;
			this.pbLogout.Click += new System.EventHandler(this.pbLogout_Click);
			// 
			// lblLogout
			// 
			this.lblLogout.AutoSize = true;
			this.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblLogout.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblLogout.ForeColor = System.Drawing.Color.White;
			this.lblLogout.Location = new System.Drawing.Point(71, 239);
			this.lblLogout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblLogout.Name = "lblLogout";
			this.lblLogout.Size = new System.Drawing.Size(70, 22);
			this.lblLogout.TabIndex = 9;
			this.lblLogout.Text = "Logout";
			this.lblLogout.Click += new System.EventHandler(this.pbLogout_Click);
			// 
			// pbSTIlogo
			// 
			this.pbSTIlogo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbSTIlogo.Image = global::DiagnosisPrognosisClient.Properties.Resources.sti_bg;
			this.pbSTIlogo.Location = new System.Drawing.Point(1, 0);
			this.pbSTIlogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pbSTIlogo.Name = "pbSTIlogo";
			this.pbSTIlogo.Size = new System.Drawing.Size(97, 66);
			this.pbSTIlogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbSTIlogo.TabIndex = 2;
			this.pbSTIlogo.TabStop = false;
			this.pbSTIlogo.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
			this.label1.Location = new System.Drawing.Point(21, 21);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(323, 28);
			this.label1.TabIndex = 4;
			this.label1.Text = "STI Global City Clinic System";
			// 
			// pbClose
			// 
			this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbClose.Image = global::DiagnosisPrognosisClient.Properties.Resources.Exit_new;
			this.pbClose.Location = new System.Drawing.Point(1261, 0);
			this.pbClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pbClose.Name = "pbClose";
			this.pbClose.Size = new System.Drawing.Size(88, 70);
			this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbClose.TabIndex = 5;
			this.pbClose.TabStop = false;
			this.pbClose.Visible = false;
			this.pbClose.Click += new System.EventHandler(this.pbClose_Click_1);
			// 
			// pbSTICampus
			// 
			this.pbSTICampus.Image = global::DiagnosisPrognosisClient.Properties.Resources.global;
			this.pbSTICampus.Location = new System.Drawing.Point(197, 77);
			this.pbSTICampus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pbSTICampus.Name = "pbSTICampus";
			this.pbSTICampus.Size = new System.Drawing.Size(1069, 606);
			this.pbSTICampus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbSTICampus.TabIndex = 2;
			this.pbSTICampus.TabStop = false;
			// 
			// diagnosisUC1
			// 
			this.diagnosisUC1.BackColor = System.Drawing.Color.White;
			this.diagnosisUC1.Location = new System.Drawing.Point(197, 77);
			this.diagnosisUC1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.diagnosisUC1.Name = "diagnosisUC1";
			this.diagnosisUC1.Size = new System.Drawing.Size(1069, 606);
			this.diagnosisUC1.TabIndex = 6;
			// 
			// addPatientForm1
			// 
			this.addPatientForm1.BackColor = System.Drawing.Color.White;
			this.addPatientForm1.Location = new System.Drawing.Point(197, 77);
			this.addPatientForm1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.addPatientForm1.Name = "addPatientForm1";
			this.addPatientForm1.Size = new System.Drawing.Size(1106, 697);
			this.addPatientForm1.TabIndex = 7;
			// 
			// inventoryuc1
			// 
			this.inventoryuc1.BackColor = System.Drawing.Color.White;
			this.inventoryuc1.Location = new System.Drawing.Point(197, 77);
			this.inventoryuc1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.inventoryuc1.Name = "inventoryuc1";
			this.inventoryuc1.Size = new System.Drawing.Size(1106, 697);
			this.inventoryuc1.TabIndex = 8;
			// 
			// Homepage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
			this.ClientSize = new System.Drawing.Size(1264, 681);
			this.Controls.Add(this.inventoryuc1);
			this.Controls.Add(this.addPatientForm1);
			this.Controls.Add(this.diagnosisUC1);
			this.Controls.Add(this.pbClose);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pbSTICampus);
			this.Controls.Add(this.pbSTIlogo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "Homepage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "2.";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Homepage_FormClosing);
			this.Load += new System.EventHandler(this.Homepage_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbInventory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDiagnosis)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbPatient)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbLogout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSTIlogo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSTICampus)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbSTICampus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbSTIlogo;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox pbLogout;
        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.PictureBox pbInventory;
        private System.Windows.Forms.Label lblDiagnosis;
        private System.Windows.Forms.PictureBox pbDiagnosis;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.PictureBox pbPatient;
		private DiagnosisUC diagnosisUC1;
		private AddPatientForm addPatientForm1;
		private InventoryUC inventoryuc1;
	}
}

