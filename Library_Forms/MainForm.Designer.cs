namespace Library_Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.сохранитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьПростойДокументToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьДокументСТаблицейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьДокументСДиаграммойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.записьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьПростойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьСТаблицейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьСДиаграммойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentWithContext1 = new Library_NotVisualComponents.DocumentWithContext(this.components);
            this.outputUserControl1 = new VisualComponentsLibrary.OutputUserControl();
            this.componentWordMultyTable1 = new WindowsFormsComponentLibrary.ComponentWordMultyTable(this.components);
            this.chartComponent1 = new NonVisualComponentsLibrary.ChartComponent(this.components);
            this.плагиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.телеграммToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // сохранитьЗаписьToolStripMenuItem
            // 
            this.сохранитьЗаписьToolStripMenuItem.Name = "сохранитьЗаписьToolStripMenuItem";
            this.сохранитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // редактироватьЗаписьToolStripMenuItem
            // 
            this.редактироватьЗаписьToolStripMenuItem.Name = "редактироватьЗаписьToolStripMenuItem";
            this.редактироватьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // удалитьЗаписьToolStripMenuItem
            // 
            this.удалитьЗаписьToolStripMenuItem.Name = "удалитьЗаписьToolStripMenuItem";
            this.удалитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // создатьПростойДокументToolStripMenuItem
            // 
            this.создатьПростойДокументToolStripMenuItem.Name = "создатьПростойДокументToolStripMenuItem";
            this.создатьПростойДокументToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // создатьДокументСТаблицейToolStripMenuItem
            // 
            this.создатьДокументСТаблицейToolStripMenuItem.Name = "создатьДокументСТаблицейToolStripMenuItem";
            this.создатьДокументСТаблицейToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // создатьДокументСДиаграммойToolStripMenuItem
            // 
            this.создатьДокументСДиаграммойToolStripMenuItem.Name = "создатьДокументСДиаграммойToolStripMenuItem";
            this.создатьДокументСДиаграммойToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.записьToolStripMenuItem,
            this.документToolStripMenuItem,
            this.плагиныToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // записьToolStripMenuItem
            // 
            this.записьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.записьToolStripMenuItem.Name = "записьToolStripMenuItem";
            this.записьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.записьToolStripMenuItem.Text = "Запись";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.CreateBook);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.UpdateBook);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.DeleteBook);
            // 
            // документToolStripMenuItem
            // 
            this.документToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьПростойToolStripMenuItem,
            this.создатьСТаблицейToolStripMenuItem,
            this.создатьСДиаграммойToolStripMenuItem});
            this.документToolStripMenuItem.Name = "документToolStripMenuItem";
            this.документToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.документToolStripMenuItem.Text = "Документ";
            // 
            // создатьПростойToolStripMenuItem
            // 
            this.создатьПростойToolStripMenuItem.Name = "создатьПростойToolStripMenuItem";
            this.создатьПростойToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.создатьПростойToolStripMenuItem.Text = "Создать простой";
            this.создатьПростойToolStripMenuItem.Click += new System.EventHandler(this.CreateSimpleDocument);
            // 
            // создатьСТаблицейToolStripMenuItem
            // 
            this.создатьСТаблицейToolStripMenuItem.Name = "создатьСТаблицейToolStripMenuItem";
            this.создатьСТаблицейToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.создатьСТаблицейToolStripMenuItem.Text = "Создать с таблицей";
            this.создатьСТаблицейToolStripMenuItem.Click += new System.EventHandler(this.CreateDocumentTable);
            // 
            // создатьСДиаграммойToolStripMenuItem
            // 
            this.создатьСДиаграммойToolStripMenuItem.Name = "создатьСДиаграммойToolStripMenuItem";
            this.создатьСДиаграммойToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.создатьСДиаграммойToolStripMenuItem.Text = "Создать с диаграммой";
            this.создатьСДиаграммойToolStripMenuItem.Click += new System.EventHandler(this.CreateDocumentChart);
            // 
            // outputUserControl1
            // 
            this.outputUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputUserControl1.Location = new System.Drawing.Point(0, 0);
            this.outputUserControl1.Margin = new System.Windows.Forms.Padding(2);
            this.outputUserControl1.Name = "outputUserControl1";
            this.outputUserControl1.Size = new System.Drawing.Size(449, 385);
            this.outputUserControl1.TabIndex = 1;
            // 
            // chartComponent1
            // 
            this.chartComponent1.ErrorMessage = null;
            // 
            // плагиныToolStripMenuItem
            // 
            this.плагиныToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.телеграммToolStripMenuItem,
            this.excelToolStripMenuItem});
            this.плагиныToolStripMenuItem.Name = "плагиныToolStripMenuItem";
            this.плагиныToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.плагиныToolStripMenuItem.Text = "Плагины";
            // 
            // телеграммToolStripMenuItem
            // 
            this.телеграммToolStripMenuItem.Name = "телеграммToolStripMenuItem";
            this.телеграммToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.телеграммToolStripMenuItem.Text = "Телеграм";
            this.телеграммToolStripMenuItem.Click += new System.EventHandler(this.телеграммToolStripMenuItem_Click);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 385);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.outputUserControl1);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Главная форма";
            this.Activated += new System.EventHandler(this.MainForm_Load);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem сохранитьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьПростойДокументToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьДокументСТаблицейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьДокументСДиаграммойToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem записьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьПростойToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьСТаблицейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьСДиаграммойToolStripMenuItem;
        private Library_NotVisualComponents.DocumentWithContext documentWithContext1;
        private VisualComponentsLibrary.OutputUserControl outputUserControl1;
        private WindowsFormsComponentLibrary.ComponentWordMultyTable componentWordMultyTable1;
        private NonVisualComponentsLibrary.ChartComponent chartComponent1;
        private System.Windows.Forms.ToolStripMenuItem плагиныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem телеграммToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
    }
}