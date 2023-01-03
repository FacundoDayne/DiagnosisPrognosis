
namespace DiagnosisPrognosisClient
{
    partial class AddPatientForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbSearchPatient = new System.Windows.Forms.ComboBox();
			this.lblPatient = new System.Windows.Forms.Label();
			this.lblAge = new System.Windows.Forms.Label();
			this.lblGender = new System.Windows.Forms.Label();
			this.lblCourse = new System.Windows.Forms.Label();
			this.btnAddSymp = new System.Windows.Forms.Button();
			this.dgPatients = new System.Windows.Forms.DataGridView();
			this.btnEditPatient = new System.Windows.Forms.Button();
			this.btnDeletePatient = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.dgSymptoms = new System.Windows.Forms.DataGridView();
			this.btnNewPatient = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgPatients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgSymptoms)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(28, 36);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Search Patient";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(28, 111);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Patient Name:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label3.Location = new System.Drawing.Point(28, 249);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 19);
			this.label3.TabIndex = 3;
			this.label3.Text = "Patient Course:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label4.Location = new System.Drawing.Point(28, 180);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 19);
			this.label4.TabIndex = 2;
			this.label4.Text = "Patient Age:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label5.Location = new System.Drawing.Point(28, 388);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(147, 19);
			this.label5.TabIndex = 5;
			this.label5.Text = "Patient Symptoms:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label6.Location = new System.Drawing.Point(28, 317);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 19);
			this.label6.TabIndex = 4;
			this.label6.Text = "Gender:";
			// 
			// cmbSearchPatient
			// 
			this.cmbSearchPatient.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.cmbSearchPatient.FormattingEnabled = true;
			this.cmbSearchPatient.Location = new System.Drawing.Point(29, 67);
			this.cmbSearchPatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.cmbSearchPatient.Name = "cmbSearchPatient";
			this.cmbSearchPatient.Size = new System.Drawing.Size(345, 27);
			this.cmbSearchPatient.TabIndex = 6;
			this.cmbSearchPatient.SelectionChangeCommitted += new System.EventHandler(this.cmbSearchPatient_SelectionChangeCommitted);
			// 
			// lblPatient
			// 
			this.lblPatient.AutoSize = true;
			this.lblPatient.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblPatient.Location = new System.Drawing.Point(38, 143);
			this.lblPatient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPatient.Name = "lblPatient";
			this.lblPatient.Size = new System.Drawing.Size(98, 15);
			this.lblPatient.TabIndex = 7;
			this.lblPatient.Text = "*None Selected";
			this.lblPatient.Click += new System.EventHandler(this.label7_Click);
			// 
			// lblAge
			// 
			this.lblAge.AutoSize = true;
			this.lblAge.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblAge.Location = new System.Drawing.Point(38, 215);
			this.lblAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(98, 15);
			this.lblAge.TabIndex = 8;
			this.lblAge.Text = "*None Selected";
			this.lblAge.Click += new System.EventHandler(this.label8_Click);
			// 
			// lblGender
			// 
			this.lblGender.AutoSize = true;
			this.lblGender.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblGender.Location = new System.Drawing.Point(38, 351);
			this.lblGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblGender.Name = "lblGender";
			this.lblGender.Size = new System.Drawing.Size(98, 15);
			this.lblGender.TabIndex = 10;
			this.lblGender.Text = "*None Selected";
			this.lblGender.Click += new System.EventHandler(this.label9_Click);
			// 
			// lblCourse
			// 
			this.lblCourse.AutoSize = true;
			this.lblCourse.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblCourse.Location = new System.Drawing.Point(38, 285);
			this.lblCourse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCourse.Name = "lblCourse";
			this.lblCourse.Size = new System.Drawing.Size(98, 15);
			this.lblCourse.TabIndex = 9;
			this.lblCourse.Text = "*None Selected";
			this.lblCourse.Click += new System.EventHandler(this.label10_Click);
			// 
			// btnAddSymp
			// 
			this.btnAddSymp.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnAddSymp.Location = new System.Drawing.Point(287, 463);
			this.btnAddSymp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnAddSymp.Name = "btnAddSymp";
			this.btnAddSymp.Size = new System.Drawing.Size(88, 35);
			this.btnAddSymp.TabIndex = 12;
			this.btnAddSymp.Text = "ADD";
			this.btnAddSymp.UseVisualStyleBackColor = true;
			// 
			// dgPatients
			// 
			this.dgPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgPatients.Location = new System.Drawing.Point(442, 111);
			this.dgPatients.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dgPatients.Name = "dgPatients";
			this.dgPatients.Size = new System.Drawing.Size(464, 345);
			this.dgPatients.TabIndex = 14;
			// 
			// btnEditPatient
			// 
			this.btnEditPatient.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnEditPatient.Location = new System.Drawing.Point(572, 463);
			this.btnEditPatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnEditPatient.Name = "btnEditPatient";
			this.btnEditPatient.Size = new System.Drawing.Size(88, 35);
			this.btnEditPatient.TabIndex = 15;
			this.btnEditPatient.Text = "EDIT";
			this.btnEditPatient.UseVisualStyleBackColor = true;
			this.btnEditPatient.VisibleChanged += new System.EventHandler(this.btnEditPatient_VisibleChanged);
			this.btnEditPatient.Click += new System.EventHandler(this.btnEditPatient_Click);
			// 
			// btnDeletePatient
			// 
			this.btnDeletePatient.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnDeletePatient.Location = new System.Drawing.Point(454, 463);
			this.btnDeletePatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnDeletePatient.Name = "btnDeletePatient";
			this.btnDeletePatient.Size = new System.Drawing.Size(88, 35);
			this.btnDeletePatient.TabIndex = 16;
			this.btnDeletePatient.Text = "DELETE";
			this.btnDeletePatient.UseVisualStyleBackColor = true;
			this.btnDeletePatient.Click += new System.EventHandler(this.btnDeletePatient_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label11.Location = new System.Drawing.Point(449, 76);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(119, 19);
			this.label11.TabIndex = 17;
			this.label11.Text = "List of Patients";
			// 
			// dgSymptoms
			// 
			this.dgSymptoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgSymptoms.Location = new System.Drawing.Point(29, 413);
			this.dgSymptoms.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dgSymptoms.Name = "dgSymptoms";
			this.dgSymptoms.Size = new System.Drawing.Size(345, 43);
			this.dgSymptoms.TabIndex = 18;
			// 
			// btnNewPatient
			// 
			this.btnNewPatient.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnNewPatient.Location = new System.Drawing.Point(818, 463);
			this.btnNewPatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnNewPatient.Name = "btnNewPatient";
			this.btnNewPatient.Size = new System.Drawing.Size(88, 35);
			this.btnNewPatient.TabIndex = 19;
			this.btnNewPatient.Text = "NEW";
			this.btnNewPatient.UseVisualStyleBackColor = true;
			this.btnNewPatient.Click += new System.EventHandler(this.btnNewPatient_Click);
			// 
			// AddPatientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnNewPatient);
			this.Controls.Add(this.dgSymptoms);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.btnDeletePatient);
			this.Controls.Add(this.btnEditPatient);
			this.Controls.Add(this.dgPatients);
			this.Controls.Add(this.btnAddSymp);
			this.Controls.Add(this.lblGender);
			this.Controls.Add(this.lblCourse);
			this.Controls.Add(this.lblAge);
			this.Controls.Add(this.lblPatient);
			this.Controls.Add(this.cmbSearchPatient);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "AddPatientForm";
			this.Size = new System.Drawing.Size(933, 518);
			((System.ComponentModel.ISupportInitialize)(this.dgPatients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgSymptoms)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSearchPatient;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Button btnAddSymp;
        private System.Windows.Forms.DataGridView dgPatients;
        private System.Windows.Forms.Button btnEditPatient;
        private System.Windows.Forms.Button btnDeletePatient;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgSymptoms;
		private Button btnNewPatient;
	}
}
