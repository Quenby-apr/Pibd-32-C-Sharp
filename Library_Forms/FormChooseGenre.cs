﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_BusinessLogic.BindingModels;
using Library_BusinessLogic.BusinessLogic;
using Unity;

namespace Library_Forms
{
    public partial class FormChooseGenre : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly GenreLogic logic;
        public FormChooseGenre(GenreLogic _logic)
        {
            logic = _logic;
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list == null) return;
                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormChooseGenre_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.I:
                        {
                            logic.CreateOrUpdate(new GenreBindingModel
                            {
                                GenreName = ""
                            });
                            LoadData();
                            break;
                        }
                    case Keys.D:
                        {
                            if (dataGridView.SelectedRows.Count == 1)
                            {
                                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                                    try
                                    {
                                        logic.Delete(new GenreBindingModel { Id = id });
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    LoadData();
                                }
                            }
                            break;
                        }
                }
            }
        }
        private void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var typeName = dataGridView[e.ColumnIndex, e.RowIndex].Value as string;
            if (!string.IsNullOrEmpty(typeName))
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    try
                    {
                        var id = (int)dataGridView[0, e.RowIndex].Value;
                        logic.CreateOrUpdate(new GenreBindingModel { Id = id, GenreName = typeName });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }));
            }
            else
            {
                MessageBox.Show("Введена пустая строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }
    }
}
