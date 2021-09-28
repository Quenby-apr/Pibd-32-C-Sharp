using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_NotVisualComponents.HelperModels;

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
                Name = "cat",
                Age = 5
            },
              new Pet() {
                Name = "cat",
                Age = 5
            },
              new Pet() {
                Name = "cat",
                Age = 5
            },
               new Pet() {
                Name = "cat",
                Age = 5
            },
               new Pet() {
                Name = "cat",
                Age = 5
            },
               new Pet() {
                Name = "cat",
                Age = 5
            },
               new Pet() {
                Name = "cat",
                Age = 5
            },
               new Pet() {
                Name = "cat",
                Age = 5
            },
               new Pet() {
                Name = "cat",
                Age = 5
            },
                new Pet() {
                Name = "cat",
                Age = 5
            },
                 new Pet() {
                Name = "cat",
                Age = 5
            },
                  new Pet() {
                Name = "cat",
                Age = 5
            },
                   new Pet() {
                Name = "cat",
                Age = 5
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
        List<List<string>> myList = new List<List<string>>();
        List<DiagramSeries> thatlist = new List<DiagramSeries>();
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
            myList.Add(new List<string>() { "первый" });
            myList.Add(new List<string>() { "большой", "мелкий1","мелкий2", "мелкий3"});
            myList.Add(new List<string>() { "второй"});
            myList.Add(new List<string>() { "третий", "мелкий" });
            thatlist.Add(new DiagramSeries
            {
                Name = "первое",
                Values = new double[] { 15, 18, 19.5, 23.45, 12, 17.5 }
            });
            thatlist.Add(new DiagramSeries
            {
                Name = "второе",
                Values = new double[] { 13, 16, 18.2, 21.72 }
            });

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

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            inputComponent.SetToolTip(textBoxHelp.Text);
            textBoxHelp.Clear();
        }

        private void selectionComponent_ComboBoxSelectedElementChange(object sender, EventArgs e)
        {
            MessageBox.Show("Событие работает", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static T Deserialize<T>(string pathOrFileName)
        {
            T items;

            using (Stream stream = File.Open(pathOrFileName, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();

                items = (T)bin.Deserialize(stream);
            }

            return items;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                documentWithContext1.CreateFile(fbd.SelectedPath + "/ExcelReport.xls", "Заголовок", new string[] { "раз", "два", "три", "четыре" }.ToList());
                MessageBox.Show("Отчёт создан", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                documentWithCustomTable2.CreateFile<Pet>(fbd.SelectedPath + "/ExcelReport2.xls", "Заголовок",myList, pets.ToList(), new double?[] { null,null,null,null,45,1,15}.ToList());
                MessageBox.Show("Отчёт создан", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                documentWithDiagram1.CreateFile(fbd.SelectedPath + "/Diagram.xls","Заголовок", "Заголовок диаг",thatlist, Library_NotVisualComponents.DocumentWithDiagram.LegendPosition.Top, _xSeries: new string[] { "Raf","YA", "VSIO","Sdelal"});
                MessageBox.Show("Отчёт создан", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
