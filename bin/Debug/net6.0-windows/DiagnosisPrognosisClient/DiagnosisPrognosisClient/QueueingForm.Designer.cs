
namespace DiagnosisPrognosisClient
{
    partial class QueueingForm
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
            this.btnGetNumber = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQueueingNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGetNumber
            // 
            this.btnGetNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(87)))), ((int)(((byte)(155)))));
            this.btnGetNumber.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetNumber.Location = new System.Drawing.Point(21, 68);
            this.btnGetNumber.Name = "btnGetNumber";
            this.btnGetNumber.Size = new System.Drawing.Size(149, 102);
            this.btnGetNumber.TabIndex = 0;
            this.btnGetNumber.Text = "Get Number";
            this.btnGetNumber.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Position in Queue:";
            // 
            // lblQueueingNumber
            // 
            this.lblQueueingNumber.AutoSize = true;
            this.lblQueueingNumber.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueueingNumber.Location = new System.Drawing.Point(234, 104);
            this.lblQueueingNumber.Name = "lblQueueingNumber";
            this.lblQueueingNumber.Size = new System.Drawing.Size(151, 41);
            this.lblQueueingNumber.TabIndex = 2;
            this.lblQueueingNumber.Text = "P - 1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(56)))), ((int)(((byte)(23)))));
            this.label3.Location = new System.Drawing.Point(37, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "*Click to get a number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(56)))), ((int)(((byte)(23)))));
            this.label2.Location = new System.Drawing.Point(210, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "*Please wait for your number to be called";
            // 
            // QueueingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(444, 232);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblQueueingNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QueueingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QueueingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQueueingNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}