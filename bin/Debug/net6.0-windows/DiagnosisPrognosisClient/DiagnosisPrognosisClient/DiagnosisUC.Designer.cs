
namespace DiagnosisPrognosisClient
{
    partial class DiagnosisUC
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
			this.lblDiagAge = new System.Windows.Forms.Label();
			this.lblDiagPatient = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.btnSubmitDiagnosis = new System.Windows.Forms.Button();
			this.dgPossibleDiagnosis = new System.Windows.Forms.DataGridView();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.chkAllergies = new System.Windows.Forms.CheckBox();
			this.chkConsultation = new System.Windows.Forms.CheckBox();
			this.chkCheckup = new System.Windows.Forms.CheckBox();
			this.chkMedical = new System.Windows.Forms.CheckBox();
			this.btnSelectPatient = new System.Windows.Forms.Button();
			this.dgPatientsSymptoms = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.lblDiagnosis = new System.Windows.Forms.Label();
			this.pnlPatientPanel = new System.Windows.Forms.Panel();
			this.label12 = new System.Windows.Forms.Label();
			this.dgResultIllness = new System.Windows.Forms.DataGridView();
			this.label10 = new System.Windows.Forms.Label();
			this.btnSubmitSymptom = new System.Windows.Forms.Button();
			this.dgSelectedSymptoms = new System.Windows.Forms.DataGridView();
			this.dgSymptomsList = new System.Windows.Forms.DataGridView();
			this.btnRemoveSymptom = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.lblUserPatientName = new System.Windows.Forms.Label();
			this.pnlDoctorPanel = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.lblSex = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.btnSaveDiagnosis = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgPossibleDiagnosis)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgPatientsSymptoms)).BeginInit();
			this.pnlPatientPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgResultIllness)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgSelectedSymptoms)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgSymptomsList)).BeginInit();
			this.pnlDoctorPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblDiagAge
			// 
			this.lblDiagAge.AutoSize = true;
			this.lblDiagAge.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblDiagAge.Location = new System.Drawing.Point(42, 165);
			this.lblDiagAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDiagAge.Name = "lblDiagAge";
			this.lblDiagAge.Size = new System.Drawing.Size(136, 21);
			this.lblDiagAge.TabIndex = 22;
			this.lblDiagAge.Text = "*None Selected";
			// 
			// lblDiagPatient
			// 
			this.lblDiagPatient.AutoSize = true;
			this.lblDiagPatient.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblDiagPatient.Location = new System.Drawing.Point(42, 110);
			this.lblDiagPatient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDiagPatient.Name = "lblDiagPatient";
			this.lblDiagPatient.Size = new System.Drawing.Size(136, 21);
			this.lblDiagPatient.TabIndex = 20;
			this.lblDiagPatient.Text = "*None Selected";
			this.lblDiagPatient.Click += new System.EventHandler(this.label7_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label5.Location = new System.Drawing.Point(17, 0);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(194, 21);
			this.label5.TabIndex = 18;
			this.label5.Text = "Submitted Symptoms:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label3.Location = new System.Drawing.Point(31, 140);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 21);
			this.label3.TabIndex = 16;
			this.label3.Text = "Age:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(31, 85);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(129, 21);
			this.label2.TabIndex = 14;
			this.label2.Text = "Patient Name:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label11.Location = new System.Drawing.Point(346, 0);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(184, 21);
			this.label11.TabIndex = 29;
			this.label11.Text = "Suggested Diagnosis:";
			// 
			// btnSubmitDiagnosis
			// 
			this.btnSubmitDiagnosis.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnSubmitDiagnosis.Location = new System.Drawing.Point(330, 317);
			this.btnSubmitDiagnosis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnSubmitDiagnosis.Name = "btnSubmitDiagnosis";
			this.btnSubmitDiagnosis.Size = new System.Drawing.Size(138, 36);
			this.btnSubmitDiagnosis.TabIndex = 28;
			this.btnSubmitDiagnosis.Text = "Select Diagnosis";
			this.btnSubmitDiagnosis.UseVisualStyleBackColor = true;
			// 
			// dgPossibleDiagnosis
			// 
			this.dgPossibleDiagnosis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgPossibleDiagnosis.Location = new System.Drawing.Point(330, 28);
			this.dgPossibleDiagnosis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dgPossibleDiagnosis.Name = "dgPossibleDiagnosis";
			this.dgPossibleDiagnosis.Size = new System.Drawing.Size(295, 281);
			this.dgPossibleDiagnosis.TabIndex = 26;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label4.Location = new System.Drawing.Point(461, 85);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(85, 21);
			this.label4.TabIndex = 30;
			this.label4.Text = "Allergies";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label6.Location = new System.Drawing.Point(571, 85);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(117, 21);
			this.label6.TabIndex = 31;
			this.label6.Text = "Consultation";
			this.label6.Click += new System.EventHandler(this.label6_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label7.Location = new System.Drawing.Point(461, 140);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 21);
			this.label7.TabIndex = 32;
			this.label7.Text = "Check-up";
			this.label7.Click += new System.EventHandler(this.label7_Click_1);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label8.Location = new System.Drawing.Point(567, 140);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(131, 21);
			this.label8.TabIndex = 33;
			this.label8.Text = "Medical Needs";
			this.label8.Click += new System.EventHandler(this.label8_Click);
			// 
			// chkAllergies
			// 
			this.chkAllergies.AutoSize = true;
			this.chkAllergies.Location = new System.Drawing.Point(492, 112);
			this.chkAllergies.Name = "chkAllergies";
			this.chkAllergies.Size = new System.Drawing.Size(15, 14);
			this.chkAllergies.TabIndex = 34;
			this.chkAllergies.UseVisualStyleBackColor = true;
			this.chkAllergies.CheckedChanged += new System.EventHandler(this.chkConsultation_CheckedChanged);
			// 
			// chkConsultation
			// 
			this.chkConsultation.AutoSize = true;
			this.chkConsultation.Location = new System.Drawing.Point(617, 112);
			this.chkConsultation.Name = "chkConsultation";
			this.chkConsultation.Size = new System.Drawing.Size(15, 14);
			this.chkConsultation.TabIndex = 35;
			this.chkConsultation.UseVisualStyleBackColor = true;
			this.chkConsultation.CheckedChanged += new System.EventHandler(this.chkConsultation_CheckedChanged);
			// 
			// chkCheckup
			// 
			this.chkCheckup.AutoSize = true;
			this.chkCheckup.Location = new System.Drawing.Point(492, 167);
			this.chkCheckup.Name = "chkCheckup";
			this.chkCheckup.Size = new System.Drawing.Size(15, 14);
			this.chkCheckup.TabIndex = 36;
			this.chkCheckup.UseVisualStyleBackColor = true;
			this.chkCheckup.CheckedChanged += new System.EventHandler(this.chkConsultation_CheckedChanged);
			// 
			// chkMedical
			// 
			this.chkMedical.AutoSize = true;
			this.chkMedical.Location = new System.Drawing.Point(617, 167);
			this.chkMedical.Name = "chkMedical";
			this.chkMedical.Size = new System.Drawing.Size(15, 14);
			this.chkMedical.TabIndex = 37;
			this.chkMedical.UseVisualStyleBackColor = true;
			this.chkMedical.CheckedChanged += new System.EventHandler(this.chkConsultation_CheckedChanged);
			// 
			// btnSelectPatient
			// 
			this.btnSelectPatient.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnSelectPatient.Location = new System.Drawing.Point(31, 25);
			this.btnSelectPatient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnSelectPatient.Name = "btnSelectPatient";
			this.btnSelectPatient.Size = new System.Drawing.Size(129, 45);
			this.btnSelectPatient.TabIndex = 38;
			this.btnSelectPatient.Text = "Select Patient";
			this.btnSelectPatient.UseVisualStyleBackColor = true;
			// 
			// dgPatientsSymptoms
			// 
			this.dgPatientsSymptoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgPatientsSymptoms.Location = new System.Drawing.Point(0, 28);
			this.dgPatientsSymptoms.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dgPatientsSymptoms.Name = "dgPatientsSymptoms";
			this.dgPatientsSymptoms.Size = new System.Drawing.Size(292, 279);
			this.dgPatientsSymptoms.TabIndex = 39;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(742, 85);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(171, 21);
			this.label1.TabIndex = 40;
			this.label1.Text = "Selected Diagnosis:";
			// 
			// lblDiagnosis
			// 
			this.lblDiagnosis.AutoSize = true;
			this.lblDiagnosis.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblDiagnosis.Location = new System.Drawing.Point(777, 112);
			this.lblDiagnosis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDiagnosis.Name = "lblDiagnosis";
			this.lblDiagnosis.Size = new System.Drawing.Size(136, 21);
			this.lblDiagnosis.TabIndex = 41;
			this.lblDiagnosis.Text = "*None Selected";
			// 
			// pnlPatientPanel
			// 
			this.pnlPatientPanel.Controls.Add(this.btnSaveDiagnosis);
			this.pnlPatientPanel.Controls.Add(this.label12);
			this.pnlPatientPanel.Controls.Add(this.dgResultIllness);
			this.pnlPatientPanel.Controls.Add(this.label10);
			this.pnlPatientPanel.Controls.Add(this.btnSubmitSymptom);
			this.pnlPatientPanel.Controls.Add(this.dgSelectedSymptoms);
			this.pnlPatientPanel.Controls.Add(this.dgSymptomsList);
			this.pnlPatientPanel.Controls.Add(this.btnRemoveSymptom);
			this.pnlPatientPanel.Controls.Add(this.label9);
			this.pnlPatientPanel.Location = new System.Drawing.Point(31, 237);
			this.pnlPatientPanel.Name = "pnlPatientPanel";
			this.pnlPatientPanel.Size = new System.Drawing.Size(970, 351);
			this.pnlPatientPanel.TabIndex = 45;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label12.Location = new System.Drawing.Point(686, 0);
			this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(158, 21);
			this.label12.TabIndex = 41;
			this.label12.Text = "Suggested Illness:";
			// 
			// dgResultIllness
			// 
			this.dgResultIllness.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgResultIllness.Location = new System.Drawing.Point(674, 28);
			this.dgResultIllness.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dgResultIllness.Name = "dgResultIllness";
			this.dgResultIllness.Size = new System.Drawing.Size(292, 278);
			this.dgResultIllness.TabIndex = 40;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label10.Location = new System.Drawing.Point(347, 0);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(168, 21);
			this.label10.TabIndex = 18;
			this.label10.Text = "Patient Symptoms:";
			// 
			// btnSubmitSymptom
			// 
			this.btnSubmitSymptom.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnSubmitSymptom.Location = new System.Drawing.Point(448, 315);
			this.btnSubmitSymptom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnSubmitSymptom.Name = "btnSubmitSymptom";
			this.btnSubmitSymptom.Size = new System.Drawing.Size(191, 36);
			this.btnSubmitSymptom.TabIndex = 25;
			this.btnSubmitSymptom.Text = "Submit Symptoms";
			this.btnSubmitSymptom.UseVisualStyleBackColor = true;
			this.btnSubmitSymptom.Click += new System.EventHandler(this.btnSubmitSymptom_Click);
			// 
			// dgSelectedSymptoms
			// 
			this.dgSelectedSymptoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgSelectedSymptoms.Location = new System.Drawing.Point(347, 28);
			this.dgSelectedSymptoms.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dgSelectedSymptoms.Name = "dgSelectedSymptoms";
			this.dgSelectedSymptoms.Size = new System.Drawing.Size(292, 278);
			this.dgSelectedSymptoms.TabIndex = 39;
			// 
			// dgSymptomsList
			// 
			this.dgSymptomsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgSymptomsList.Location = new System.Drawing.Point(0, 26);
			this.dgSymptomsList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dgSymptomsList.Name = "dgSymptomsList";
			this.dgSymptomsList.Size = new System.Drawing.Size(304, 280);
			this.dgSymptomsList.TabIndex = 26;
			// 
			// btnRemoveSymptom
			// 
			this.btnRemoveSymptom.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnRemoveSymptom.Location = new System.Drawing.Point(151, 315);
			this.btnRemoveSymptom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnRemoveSymptom.Name = "btnRemoveSymptom";
			this.btnRemoveSymptom.Size = new System.Drawing.Size(153, 36);
			this.btnRemoveSymptom.TabIndex = 28;
			this.btnRemoveSymptom.Text = "Select Symptom";
			this.btnRemoveSymptom.UseVisualStyleBackColor = true;
			this.btnRemoveSymptom.Click += new System.EventHandler(this.btnAddSymptom_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label9.Location = new System.Drawing.Point(16, 0);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(151, 21);
			this.label9.TabIndex = 29;
			this.label9.Text = "Select Symptoms";
			// 
			// lblUserPatientName
			// 
			this.lblUserPatientName.AutoSize = true;
			this.lblUserPatientName.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblUserPatientName.Location = new System.Drawing.Point(42, 37);
			this.lblUserPatientName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblUserPatientName.Name = "lblUserPatientName";
			this.lblUserPatientName.Size = new System.Drawing.Size(136, 21);
			this.lblUserPatientName.TabIndex = 45;
			this.lblUserPatientName.Text = "*None Selected";
			// 
			// pnlDoctorPanel
			// 
			this.pnlDoctorPanel.Controls.Add(this.button2);
			this.pnlDoctorPanel.Controls.Add(this.dgPossibleDiagnosis);
			this.pnlDoctorPanel.Controls.Add(this.btnSubmitDiagnosis);
			this.pnlDoctorPanel.Controls.Add(this.dgPatientsSymptoms);
			this.pnlDoctorPanel.Controls.Add(this.label11);
			this.pnlDoctorPanel.Controls.Add(this.label5);
			this.pnlDoctorPanel.Location = new System.Drawing.Point(31, 210);
			this.pnlDoctorPanel.Name = "pnlDoctorPanel";
			this.pnlDoctorPanel.Size = new System.Drawing.Size(970, 353);
			this.pnlDoctorPanel.TabIndex = 46;
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.button2.Location = new System.Drawing.Point(496, 317);
			this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(129, 36);
			this.button2.TabIndex = 40;
			this.button2.Text = "View Diagnosis";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// lblSex
			// 
			this.lblSex.AutoSize = true;
			this.lblSex.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblSex.Location = new System.Drawing.Point(263, 165);
			this.lblSex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSex.Name = "lblSex";
			this.lblSex.Size = new System.Drawing.Size(136, 21);
			this.lblSex.TabIndex = 48;
			this.lblSex.Text = "*None Selected";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label14.Location = new System.Drawing.Point(252, 140);
			this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(43, 21);
			this.label14.TabIndex = 47;
			this.label14.Text = "Sex:";
			// 
			// btnSaveDiagnosis
			// 
			this.btnSaveDiagnosis.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnSaveDiagnosis.Location = new System.Drawing.Point(775, 315);
			this.btnSaveDiagnosis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnSaveDiagnosis.Name = "btnSaveDiagnosis";
			this.btnSaveDiagnosis.Size = new System.Drawing.Size(191, 36);
			this.btnSaveDiagnosis.TabIndex = 42;
			this.btnSaveDiagnosis.Text = "Save Diagnosis";
			this.btnSaveDiagnosis.UseVisualStyleBackColor = true;
			this.btnSaveDiagnosis.Click += new System.EventHandler(this.btnSaveDiagnosis_Click);
			// 
			// DiagnosisUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.lblSex);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.pnlPatientPanel);
			this.Controls.Add(this.pnlDoctorPanel);
			this.Controls.Add(this.lblUserPatientName);
			this.Controls.Add(this.lblDiagnosis);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSelectPatient);
			this.Controls.Add(this.chkMedical);
			this.Controls.Add(this.chkCheckup);
			this.Controls.Add(this.chkConsultation);
			this.Controls.Add(this.chkAllergies);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblDiagAge);
			this.Controls.Add(this.lblDiagPatient);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "DiagnosisUC";
			this.Size = new System.Drawing.Size(1069, 606);
			this.Load += new System.EventHandler(this.DiagnosisUC_Load);
			this.VisibleChanged += new System.EventHandler(this.DiagnosisUC_VisibleChanged);
			((System.ComponentModel.ISupportInitialize)(this.dgPossibleDiagnosis)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgPatientsSymptoms)).EndInit();
			this.pnlPatientPanel.ResumeLayout(false);
			this.pnlPatientPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgResultIllness)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgSelectedSymptoms)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgSymptomsList)).EndInit();
			this.pnlDoctorPanel.ResumeLayout(false);
			this.pnlDoctorPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDiagAge;
        private System.Windows.Forms.Label lblDiagPatient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSubmitDiagnosis;
        private System.Windows.Forms.DataGridView dgPossibleDiagnosis;
		private Label label4;
		private Label label6;
		private Label label7;
		private Label label8;
		private CheckBox chkAllergies;
		private CheckBox chkConsultation;
		private CheckBox chkCheckup;
		private CheckBox chkMedical;
		private Button btnSelectPatient;
		private DataGridView dgPatientsSymptoms;
		private Label label1;
		private Label lblDiagnosis;
		private Panel pnlPatientPanel;
		private DataGridView dgSymptomsList;
		private Button btnRemoveSymptom;
		private Label label9;
		private Label lblUserPatientName;
		private Panel pnlDoctorPanel;
		private DataGridView dgSelectedSymptoms;
		private Button btnSubmitSymptom;
		private Label label10;
		private Label label12;
		private DataGridView dgResultIllness;
		private Button button2;
		private Label lblSex;
		private Label label14;
		private Button btnSaveDiagnosis;
	}
}
