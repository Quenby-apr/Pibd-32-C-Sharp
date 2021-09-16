using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest
{
    public partial class Form1 : Form
    {
        private string pattern = @"^\d{2}\.\d{2}\.\d{1,4}$";
        private Pet[] pets = {
            new Pet() {
                Name = "cat",
                Age = 5
            },
            new Pet() {
                Name = "dog",
                Age = 6
            },
            new Pet() {
                Name = "bunny",
                Age = 2
            }
        };
        Car myCar = new Car()
        {
            Age = 20,
            Color = "blue"
        };
        public Form1()
        {
            InitializeComponent();
            selectionComponent.AddItem("компонент работает");
            selectionComponent.AddItem("компонент 1");
            selectionComponent.AddItem("компонент 2");
            selectionComponent.AddItem("компонент 3");
            selectionComponent.SelectedValue = "компонент 2";

            inputComponent.Pattern = pattern;
            inputComponent.SetToolTip("11.05.1432");
            OutputComponent.setSeparatingCharacters("{,}");
            OutputComponent.LayoutLine = "Имя - {Name} , Возраст - {Age}";
            OutputComponent.AddItem(pets[0]);
            OutputComponent.AddItem(myCar);
            OutputComponent.AddItem(pets[1]);
            OutputComponent.AddItem(pets[2]);
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            selectionComponent.ClearList();
        }

        private void buttonCheck2_Click(object sender, EventArgs e)
        {
            string clon = selectionComponent.SelectedValue;
            selectionComponent.AddItem(clon);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {

                string value = inputComponent.Value;
                MessageBox.Show("Дата корректна", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Дата некорректна", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Неизвестная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonList_Click(object sender, EventArgs e)
        {
            var myobj = OutputComponent.GetSelectedItem<Pet>();
            Console.WriteLine(myobj.ToString());
        }
    }
}
