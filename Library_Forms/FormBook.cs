using System;
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
    public partial class FormBook : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly BookLogic logic;
        private readonly GenreLogic logicG;
        private int? id;
        public FormBook(BookLogic _logic, GenreLogic _logicG)
        {
            InitializeComponent();
            logic = _logic;
            logicG = _logicG;
        }

        private void FormBook_Load(object sender, EventArgs e)
        {
            var genres = logicG.Read(null);
            foreach (var genre in genres)
            {
                selectionComponent.AddItem(genre.GenreName);
            }
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new BookBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.BookName;
                        textBoxDescription.Text = view.Description;
                        selectionComponent.SelectedValue = view.BookGenre;
                        if (view.Cost.Equals("0"))
                        {
                            userControlTextBox2.Value = null;
                        }
                        else if (double.TryParse(view.Cost, out double d))
                        {
                            userControlTextBox2.Value = Convert.ToDouble(view.Cost);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            try
            {
                int cost = 0;
                if (userControlTextBox2.Value == null)
                {
                    cost = 0;
                }
                else if (int.TryParse(userControlTextBox2.Value.ToString(), out int i))
                {
                    cost = Convert.ToInt32(userControlTextBox2.Value);
                }
                logic.CreateOrUpdate(new BookBindingModel {
                    Id = id,
                    BookName = textBoxName.Text,
                    Description = textBoxDescription.Text,
                    BookGenre = selectionComponent.SelectedValue,
                    Cost = cost
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonGenre_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormChooseGenre>();
            form.ShowDialog();
        }
    }
}
