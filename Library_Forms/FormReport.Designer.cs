namespace Library_Forms
{
    partial class FormReport
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
            this.buttonReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(67, 52);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(163, 47);
            this.buttonReport.TabIndex = 0;
            this.buttonReport.Text = "Создать отчёт";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 147);
            this.Controls.Add(this.buttonReport);
            this.Name = "FormReport";
            this.Text = "Форма репорта";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonReport;
    }
}