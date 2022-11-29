namespace DiagnosisPrognosis
{
    partial class LandingForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.symptomList = new System.Windows.Forms.ListView();
            this.illnessList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "add Symptom";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Headache",
            "Runny Nose",
            "Weakness in the body",
            "Cough",
            "Difficulty Breathing",
            "Stomach Pains"});
            this.comboBox1.Location = new System.Drawing.Point(64, 134);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(64, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // symptomList
            // 
            this.symptomList.Location = new System.Drawing.Point(212, 27);
            this.symptomList.Name = "symptomList";
            this.symptomList.Size = new System.Drawing.Size(117, 257);
            this.symptomList.TabIndex = 6;
            this.symptomList.UseCompatibleStateImageBehavior = false;
            this.symptomList.View = System.Windows.Forms.View.List;
            // 
            // illnessList
            // 
            this.illnessList.Location = new System.Drawing.Point(335, 27);
            this.illnessList.Name = "illnessList";
            this.illnessList.Size = new System.Drawing.Size(302, 257);
            this.illnessList.TabIndex = 7;
            this.illnessList.UseCompatibleStateImageBehavior = false;
            // 
            // LandingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 349);
            this.Controls.Add(this.illnessList);
            this.Controls.Add(this.symptomList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "LandingForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private Button button1;
        private ComboBox comboBox1;
        private Button button2;
        private ListView symptomList;
        private ListView illnessList;
    }
}