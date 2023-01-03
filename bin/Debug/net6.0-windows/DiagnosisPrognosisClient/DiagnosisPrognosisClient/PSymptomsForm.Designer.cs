
namespace DiagnosisPrognosisClient
{
    partial class PSymptomsForm
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
            this.cmbSympList = new System.Windows.Forms.ComboBox();
            this.btnAddSymp = new System.Windows.Forms.Button();
            this.dgSympResultList = new System.Windows.Forms.DataGridView();
            this.btnSubmitSymp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgSympResultList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSympList
            // 
            this.cmbSympList.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSympList.FormattingEnabled = true;
            this.cmbSympList.Items.AddRange(new object[] {
            "cough",
            "cold",
            "headache",
            "muscle pain",
            "dizziness",
            "fever"});
            this.cmbSympList.Location = new System.Drawing.Point(12, 53);
            this.cmbSympList.Name = "cmbSympList";
            this.cmbSympList.Size = new System.Drawing.Size(312, 33);
            this.cmbSympList.TabIndex = 0;
            // 
            // btnAddSymp
            // 
            this.btnAddSymp.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSymp.Location = new System.Drawing.Point(348, 53);
            this.btnAddSymp.Name = "btnAddSymp";
            this.btnAddSymp.Size = new System.Drawing.Size(75, 33);
            this.btnAddSymp.TabIndex = 1;
            this.btnAddSymp.Text = "ADD";
            this.btnAddSymp.UseVisualStyleBackColor = true;
            // 
            // dgSympResultList
            // 
            this.dgSympResultList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSympResultList.Location = new System.Drawing.Point(12, 109);
            this.dgSympResultList.Name = "dgSympResultList";
            this.dgSympResultList.Size = new System.Drawing.Size(411, 316);
            this.dgSympResultList.TabIndex = 2;
            // 
            // btnSubmitSymp
            // 
            this.btnSubmitSymp.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitSymp.Location = new System.Drawing.Point(33, 443);
            this.btnSubmitSymp.Name = "btnSubmitSymp";
            this.btnSubmitSymp.Size = new System.Drawing.Size(369, 43);
            this.btnSubmitSymp.TabIndex = 3;
            this.btnSubmitSymp.Text = "Submit";
            this.btnSubmitSymp.UseVisualStyleBackColor = true;
            this.btnSubmitSymp.Click += new System.EventHandler(this.btnSubmitSymp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Add Symptoms Here:";
            // 
            // pbClose
            // 
            this.pbClose.Image = global::DiagnosisPrognosisClient.Properties.Resources.Close;
            this.pbClose.Location = new System.Drawing.Point(403, 5);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(35, 31);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClose.TabIndex = 5;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // PSymptomsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 545);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmitSymp);
            this.Controls.Add(this.dgSympResultList);
            this.Controls.Add(this.btnAddSymp);
            this.Controls.Add(this.cmbSympList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PSymptomsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QueueingForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgSympResultList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSympList;
        private System.Windows.Forms.Button btnAddSymp;
        private System.Windows.Forms.DataGridView dgSympResultList;
        private System.Windows.Forms.Button btnSubmitSymp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbClose;
    }
}