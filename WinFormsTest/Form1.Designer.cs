﻿namespace WinFormsTest
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonCheck2 = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonList = new System.Windows.Forms.Button();
            this.OutputComponent = new Library_VisualComponents.OutputComponent();
            this.inputComponent = new Library_VisualComponents.InputComponent();
            this.selectionComponent = new Library_VisualComponents.SelectionComponent();
            this.SuspendLayout();
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(27, 62);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(223, 23);
            this.buttonCheck.TabIndex = 3;
            this.buttonCheck.Text = "Очистка списка";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // buttonCheck2
            // 
            this.buttonCheck2.Location = new System.Drawing.Point(12, 104);
            this.buttonCheck2.Name = "buttonCheck2";
            this.buttonCheck2.Size = new System.Drawing.Size(249, 23);
            this.buttonCheck2.TabIndex = 4;
            this.buttonCheck2.Text = "Клонирование выбора ";
            this.buttonCheck2.UseVisualStyleBackColor = true;
            this.buttonCheck2.Click += new System.EventHandler(this.buttonCheck2_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(692, 21);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Принять ";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonList
            // 
            this.buttonList.Location = new System.Drawing.Point(278, 319);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(267, 23);
            this.buttonList.TabIndex = 6;
            this.buttonList.Text = "Достать элемент";
            this.buttonList.UseVisualStyleBackColor = true;
            this.buttonList.Click += new System.EventHandler(this.buttonList_Click);
            // 
            // OutputComponent
            // 
            this.OutputComponent.Location = new System.Drawing.Point(278, 179);
            this.OutputComponent.Name = "OutputComponent";
            this.OutputComponent.SelectedIndex = -1;
            this.OutputComponent.Size = new System.Drawing.Size(267, 107);
            this.OutputComponent.TabIndex = 2;
            // 
            // inputComponent
            // 
            this.inputComponent.Location = new System.Drawing.Point(484, 23);
            this.inputComponent.Name = "inputComponent";
            this.inputComponent.Pattern = null;
            this.inputComponent.Size = new System.Drawing.Size(183, 22);
            this.inputComponent.TabIndex = 1;
            this.inputComponent.Value = null;
            // 
            // selectionComponent
            // 
            this.selectionComponent.Location = new System.Drawing.Point(27, 23);
            this.selectionComponent.Name = "selectionComponent";
            this.selectionComponent.SelectedValue = "";
            this.selectionComponent.Size = new System.Drawing.Size(223, 22);
            this.selectionComponent.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonList);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonCheck2);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.OutputComponent);
            this.Controls.Add(this.inputComponent);
            this.Controls.Add(this.selectionComponent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Library_VisualComponents.SelectionComponent selectionComponent;
        private Library_VisualComponents.InputComponent inputComponent;
        private Library_VisualComponents.OutputComponent OutputComponent;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonCheck2;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonList;
    }
}

