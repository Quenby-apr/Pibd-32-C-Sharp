﻿namespace Library_Forms
{
    partial class FormTelegram
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
            this.buttonAuth = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAuth
            // 
            this.buttonAuth.Location = new System.Drawing.Point(58, 41);
            this.buttonAuth.Name = "buttonAuth";
            this.buttonAuth.Size = new System.Drawing.Size(152, 54);
            this.buttonAuth.TabIndex = 0;
            this.buttonAuth.Text = "Авторизоваться";
            this.buttonAuth.UseVisualStyleBackColor = true;
            this.buttonAuth.Click += new System.EventHandler(this.buttonAuth_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(301, 41);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(175, 54);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "Отправить сообщение";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // FormTelegram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 128);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonAuth);
            this.Name = "FormTelegram";
            this.Text = "Телеграмм";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAuth;
        private System.Windows.Forms.Button buttonSend;
    }
}