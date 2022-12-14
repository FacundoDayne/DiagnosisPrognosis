
namespace DiagnosisPrognosis
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
            this.PanelCeiling = new System.Windows.Forms.Panel();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbSTIlogo = new System.Windows.Forms.PictureBox();
            this.panelPatientInfo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnPatientInfo = new System.Windows.Forms.Button();
            this.panelDiagnosis = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnDiagnosis = new System.Windows.Forms.Button();
            this.panelInventory = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnInventory = new System.Windows.Forms.Button();
            this.panelLogout = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pbSTICampus = new System.Windows.Forms.PictureBox();
            this.inventoryUC1 = new DiagnosisPrognosis.InventoryUC();
            this.diagnosisUC1 = new DiagnosisPrognosis.DiagnosisUC();
            this.addPatientForm1 = new DiagnosisPrognosis.AddPatientForm();
            this.PanelCeiling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSTIlogo)).BeginInit();
            this.panelPatientInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelDiagnosis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelLogout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSTICampus)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelCeiling
            // 
            this.PanelCeiling.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PanelCeiling.Controls.Add(this.pbClose);
            this.PanelCeiling.Controls.Add(this.label1);
            this.PanelCeiling.Controls.Add(this.pbSTIlogo);
            this.PanelCeiling.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelCeiling.Location = new System.Drawing.Point(0, 0);
            this.PanelCeiling.Name = "PanelCeiling";
            this.PanelCeiling.Size = new System.Drawing.Size(975, 100);
            this.PanelCeiling.TabIndex = 0;
            // 
            // pbClose
            // 
            this.pbClose.Image = global::DiagnosisPrognosis.Properties.Resources.Close;
            this.pbClose.Location = new System.Drawing.Point(928, 12);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(35, 31);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClose.TabIndex = 2;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(601, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clinic Management System";
            // 
            // pbSTIlogo
            // 
            this.pbSTIlogo.Image = global::DiagnosisPrognosis.Properties.Resources.sti_logo;
            this.pbSTIlogo.Location = new System.Drawing.Point(12, 22);
            this.pbSTIlogo.Name = "pbSTIlogo";
            this.pbSTIlogo.Size = new System.Drawing.Size(67, 52);
            this.pbSTIlogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSTIlogo.TabIndex = 0;
            this.pbSTIlogo.TabStop = false;
            this.pbSTIlogo.Click += new System.EventHandler(this.pbSTIlogo_Click);
            // 
            // panelPatientInfo
            // 
            this.panelPatientInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPatientInfo.Controls.Add(this.label2);
            this.panelPatientInfo.Controls.Add(this.pictureBox2);
            this.panelPatientInfo.Controls.Add(this.btnPatientInfo);
            this.panelPatientInfo.Location = new System.Drawing.Point(17, 129);
            this.panelPatientInfo.Name = "panelPatientInfo";
            this.panelPatientInfo.Size = new System.Drawing.Size(146, 58);
            this.panelPatientInfo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Cambria", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Add Patient";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DiagnosisPrognosis.Properties.Resources.rsz_update_details;
            this.pictureBox2.Location = new System.Drawing.Point(7, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnPatientInfo
            // 
            this.btnPatientInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPatientInfo.Location = new System.Drawing.Point(3, 3);
            this.btnPatientInfo.Name = "btnPatientInfo";
            this.btnPatientInfo.Size = new System.Drawing.Size(140, 52);
            this.btnPatientInfo.TabIndex = 0;
            this.btnPatientInfo.UseVisualStyleBackColor = false;
            this.btnPatientInfo.Click += new System.EventHandler(this.btnPatientInfo_Click);
            // 
            // panelDiagnosis
            // 
            this.panelDiagnosis.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelDiagnosis.Controls.Add(this.label3);
            this.panelDiagnosis.Controls.Add(this.pictureBox3);
            this.panelDiagnosis.Controls.Add(this.btnDiagnosis);
            this.panelDiagnosis.Location = new System.Drawing.Point(17, 218);
            this.panelDiagnosis.Name = "panelDiagnosis";
            this.panelDiagnosis.Size = new System.Drawing.Size(143, 58);
            this.panelDiagnosis.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Add Diagnosis";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DiagnosisPrognosis.Properties.Resources.add_diag;
            this.pictureBox3.Location = new System.Drawing.Point(7, 13);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 33);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // btnDiagnosis
            // 
            this.btnDiagnosis.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDiagnosis.Location = new System.Drawing.Point(3, 3);
            this.btnDiagnosis.Name = "btnDiagnosis";
            this.btnDiagnosis.Size = new System.Drawing.Size(137, 52);
            this.btnDiagnosis.TabIndex = 1;
            this.btnDiagnosis.UseVisualStyleBackColor = false;
            this.btnDiagnosis.Click += new System.EventHandler(this.btnDiagnosis_Click);
            // 
            // panelInventory
            // 
            this.panelInventory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelInventory.Controls.Add(this.label4);
            this.panelInventory.Controls.Add(this.pictureBox4);
            this.panelInventory.Controls.Add(this.btnInventory);
            this.panelInventory.Location = new System.Drawing.Point(17, 302);
            this.panelInventory.Name = "panelInventory";
            this.panelInventory.Size = new System.Drawing.Size(143, 58);
            this.panelInventory.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Inventory";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DiagnosisPrognosis.Properties.Resources.rsz_history1;
            this.pictureBox4.Location = new System.Drawing.Point(7, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(49, 33);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnInventory.Location = new System.Drawing.Point(3, 3);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(137, 52);
            this.btnInventory.TabIndex = 2;
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // panelLogout
            // 
            this.panelLogout.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelLogout.Controls.Add(this.label5);
            this.panelLogout.Controls.Add(this.pictureBox5);
            this.panelLogout.Controls.Add(this.btnLogout);
            this.panelLogout.Location = new System.Drawing.Point(23, 475);
            this.panelLogout.Name = "panelLogout";
            this.panelLogout.Size = new System.Drawing.Size(128, 58);
            this.panelLogout.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Logout";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DiagnosisPrognosis.Properties.Resources.exit;
            this.pictureBox5.Location = new System.Drawing.Point(7, 13);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(49, 33);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLogout.Location = new System.Drawing.Point(3, 3);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(122, 52);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // pbSTICampus
            // 
            this.pbSTICampus.Image = global::DiagnosisPrognosis.Properties.Resources.global;
            this.pbSTICampus.Location = new System.Drawing.Point(175, 96);
            this.pbSTICampus.Name = "pbSTICampus";
            this.pbSTICampus.Size = new System.Drawing.Size(800, 449);
            this.pbSTICampus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSTICampus.TabIndex = 2;
            this.pbSTICampus.TabStop = false;
            // 
            // inventoryUC1
            // 
            this.inventoryUC1.Location = new System.Drawing.Point(175, 96);
            this.inventoryUC1.Name = "inventoryUC1";
            this.inventoryUC1.Size = new System.Drawing.Size(800, 449);
            this.inventoryUC1.TabIndex = 8;
            // 
            // diagnosisUC1
            // 
            this.diagnosisUC1.Location = new System.Drawing.Point(175, 96);
            this.diagnosisUC1.Name = "diagnosisUC1";
            this.diagnosisUC1.Size = new System.Drawing.Size(800, 449);
            this.diagnosisUC1.TabIndex = 7;
            // 
            // addPatientForm1
            // 
            this.addPatientForm1.Location = new System.Drawing.Point(173, 96);
            this.addPatientForm1.Name = "addPatientForm1";
            this.addPatientForm1.Size = new System.Drawing.Size(800, 449);
            this.addPatientForm1.TabIndex = 6;
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(975, 545);
            this.Controls.Add(this.inventoryUC1);
            this.Controls.Add(this.diagnosisUC1);
            this.Controls.Add(this.addPatientForm1);
            this.Controls.Add(this.panelLogout);
            this.Controls.Add(this.panelInventory);
            this.Controls.Add(this.panelDiagnosis);
            this.Controls.Add(this.panelPatientInfo);
            this.Controls.Add(this.pbSTICampus);
            this.Controls.Add(this.PanelCeiling);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Homepage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.PanelCeiling.ResumeLayout(false);
            this.PanelCeiling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSTIlogo)).EndInit();
            this.panelPatientInfo.ResumeLayout(false);
            this.panelPatientInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelDiagnosis.ResumeLayout(false);
            this.panelDiagnosis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelInventory.ResumeLayout(false);
            this.panelInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelLogout.ResumeLayout(false);
            this.panelLogout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSTICampus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelCeiling;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbSTIlogo;
        private System.Windows.Forms.PictureBox pbSTICampus;
        private System.Windows.Forms.Panel panelPatientInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnPatientInfo;
        private System.Windows.Forms.Panel panelDiagnosis;
        private System.Windows.Forms.Button btnDiagnosis;
        private System.Windows.Forms.Panel panelInventory;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Panel panelLogout;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private AddPatientForm addPatientForm1;
        private DiagnosisUC diagnosisUC1;
        private InventoryUC inventoryUC1;
    }
}

