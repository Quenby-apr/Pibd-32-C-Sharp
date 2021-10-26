namespace Library_Forms
{
    partial class FormBook
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
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelGenre = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDescript = new System.Windows.Forms.TextBox();
            this.userControlTextBox1 = new WindowsFormsControlLibrary.UserControlTextBox();
            this.buttonGenre = new System.Windows.Forms.Button();
            this.selectionComponent = new Library_VisualComponents.SelectionComponent();
            this.selectionComponent1 = new Library_VisualComponents.SelectionComponent();
            this.userControlTextBox2 = new WindowsFormsControlLibrary.UserControlTextBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(18, 23);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(89, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Название книги";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(21, 91);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(223, 156);
            this.textBoxDescription.TabIndex = 3;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(21, 75);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(89, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Описание книги";
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Location = new System.Drawing.Point(21, 274);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(68, 13);
            this.labelGenre.TabIndex = 5;
            this.labelGenre.Text = "Жанр книги";
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(19, 381);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(62, 13);
            this.labelCost.TabIndex = 7;
            this.labelCost.Text = "Стоимость";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(150, 451);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(89, 43);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(19, 451);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(90, 43);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(21, 40);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(223, 20);
            this.textBoxName.TabIndex = 10;
            // 
            // textBoxDescript
            // 
            this.textBoxDescript.Location = new System.Drawing.Point(21, 94);
            this.textBoxDescript.Multiline = true;
            this.textBoxDescript.Name = "textBoxDescript";
            this.textBoxDescript.Size = new System.Drawing.Size(223, 156);
            this.textBoxDescript.TabIndex = 3;
            // 
            // userControlTextBox1
            // 
            this.userControlTextBox1.Location = new System.Drawing.Point(11, 355);
            this.userControlTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userControlTextBox1.Name = "userControlTextBox1";
            this.userControlTextBox1.Size = new System.Drawing.Size(250, 43);
            this.userControlTextBox1.TabIndex = 11;
            // 
            // buttonGenre
            // 
            this.buttonGenre.Location = new System.Drawing.Point(92, 332);
            this.buttonGenre.Name = "buttonGenre";
            this.buttonGenre.Size = new System.Drawing.Size(75, 23);
            this.buttonGenre.TabIndex = 12;
            this.buttonGenre.Text = "Изменить";
            this.buttonGenre.UseVisualStyleBackColor = true;
            this.buttonGenre.Click += new System.EventHandler(this.buttonGenre_Click);
            // 
            // selectionComponent
            // 
            this.selectionComponent.Location = new System.Drawing.Point(21, 293);
            this.selectionComponent.Name = "selectionComponent";
            this.selectionComponent.SelectedValue = "";
            this.selectionComponent.Size = new System.Drawing.Size(223, 33);
            this.selectionComponent.TabIndex = 2;
            // 
            // selectionComponent1
            // 
            this.selectionComponent1.Location = new System.Drawing.Point(21, 293);
            this.selectionComponent1.Name = "selectionComponent1";
            this.selectionComponent1.SelectedValue = "";
            this.selectionComponent1.Size = new System.Drawing.Size(223, 33);
            this.selectionComponent1.TabIndex = 2;
            // 
            // userControlTextBox2
            // 
            this.userControlTextBox2.Location = new System.Drawing.Point(11, 403);
            this.userControlTextBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userControlTextBox2.Name = "userControlTextBox2";
            this.userControlTextBox2.Size = new System.Drawing.Size(250, 43);
            this.userControlTextBox2.TabIndex = 13;
            // 
            // FormBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 516);
            this.Controls.Add(this.userControlTextBox2);
            this.Controls.Add(this.buttonGenre);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.selectionComponent);
            this.Controls.Add(this.labelName);
            this.Name = "FormBook";
            this.Text = "Форма редактирования";
            this.Load += new System.EventHandler(this.FormBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Library_VisualComponents.InputComponent inputComponent1;
        private System.Windows.Forms.Label labelName;
        private Library_VisualComponents.SelectionComponent selectionComponent;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDescript;
        private Library_VisualComponents.SelectionComponent selectionComponent1;
        private WindowsFormsControlLibrary.UserControlTextBox userControlTextBox1;
        private System.Windows.Forms.Button buttonGenre;
        private WindowsFormsControlLibrary.UserControlTextBox userControlTextBox2;
    }
}