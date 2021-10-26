using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_BusinessLogic.BindingModels;
using Library_BusinessLogic.BusinessLogic;
using Library_BusinessLogic.ViewModels;
using NonVisualComponentsLibrary.Enums;
using NonVisualComponentsLibrary.HelperModels;
using Unity;
using WindowsFormsComponentLibrary;

namespace Library_Forms
{
    public partial class MainForm : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly BookLogic bookLogic;
        private readonly GenreLogic genreLogic;
        public string FileName = null;
        public MainForm(BookLogic _bookLogic, GenreLogic _genreLogic)
        {
            InitializeComponent();
            bookLogic = _bookLogic;
            genreLogic = _genreLogic;
        }
        private void LoadData()
        {
            outputUserControl1.SetHierarchy(new List<string> { "BookGenre", "Cost","Id", "BookName", });
            try
            {
                outputUserControl1.ClearTree();
                var list = bookLogic.Read(null);
                foreach (var book in list)
                {
                    outputUserControl1.AddItem(book);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
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
                    case Keys.A:
                        {
                            CreateBook(null, null);
                            break;
                        }
                    case Keys.U:
                        {
                            UpdateBook(null, null);
                            break;
                        }
                    case Keys.D:
                        {
                            DeleteBook(null, null);
                            break;
                        }
                    case Keys.S:
                        {
                            CreateSimpleDocument(null, null);
                            break;
                        }
                    case Keys.T:
                        {
                            CreateDocumentTable(null, null);
                            break;
                        }
                    case Keys.C:
                        {
                            CreateDocumentChart(null, null);
                            break;
                        }
                }
            }
        }
        private void CreateBook(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormBook>();
            form.ShowDialog();
            LoadData();
        }
        private void UpdateBook(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormBook>();
            form.Id = outputUserControl1.SelectedBranchIndex;
            form.ShowDialog();
            LoadData();
        }
        private void DeleteBook(object sender, EventArgs e)
        {
            var selectedItem = outputUserControl1.GetSelectedNode<BookViewModel>();
            if (selectedItem is null || (string.IsNullOrEmpty(selectedItem[1]) && selectedItem[0] is null)) return;

            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(selectedItem[1]);
                try
                {
                    bookLogic.Delete(new BookBindingModel() { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadData();
            }
        }

        private void CreateSimpleDocument(object sender, EventArgs e)
        {
            List<string> books = new List<string>();
            var myList = bookLogic.Read(new BookBindingModel{ 
                Cost = 0
            });
            foreach (var book in myList)
            {
                books.Add(book.BookName + " : " + book.Description);
            }
            var form = Container.Resolve<FormPath>();
            form.ShowDialog();
            FileName = "/"+form.FileName;
            if (FileName == "|")
            {
                return;
            }
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                documentWithContext1.CreateFile(fbd.SelectedPath + FileName + ".xls", "Бесплатные книги", books);
                MessageBox.Show("Отчёт создан", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CreateDocumentTable(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPath>();
            form.ShowDialog();
            FileName = "/" + form.FileName;
            if (FileName == "|")
            {
                return;
            }
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var listData = bookLogic.Read(null);
                foreach (var element in listData)
                {
                    if (element.Cost.Equals("0"))
                    {
                        element.Cost = "Бесплатная";
                    }
                }
                componentWordMultyTable1.CreateTable(fbd.SelectedPath + FileName +".docx", "Книги",new int[] { 20,20,20,20,20,20,20}, new List<WordTableColumn>
                {
                    new WordTableColumn {Header = "ID", Width = 40, PropertyName = "Id"},
                    new WordTableColumn {Header = "Название", Width = 100, PropertyName = "BookName"},
                    new WordTableColumn {Header = "Описание", Width = 180, PropertyName = "Description"},
                    new WordTableColumn {Header = "Жанр", Width = 100, PropertyName = "BookGenre"},
                    new WordTableColumn {Header = "Стоимость", Width = 80, PropertyName = "Cost"}
                }, listData);
                MessageBox.Show("Отчёт создан", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void CreateDocumentChart(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPath>();
            form.ShowDialog();
            FileName = "/" + form.FileName;
            if (FileName == "|")
            {
                return;
            }
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var listData = bookLogic.Read(null);
                for (int i =0;i<listData.Count();i++)
                {
                    if (!listData[i].Cost.Equals("0"))
                    {
                        listData.RemoveAt(i);
                        i--;
                    } 
                }
                var listGenres = genreLogic.Read(null);
                Dictionary<string, double> books = new Dictionary<string, double>();
                Dictionary<string, double> _books = new Dictionary<string, double>();
                foreach (var element in listGenres)
                {
                    books.Add(element.GenreName, 0);
                }
                foreach (var element in listData)
                {
                    if (books.ContainsKey(element.BookGenre))
                    {
                        books[element.BookGenre]++;
                    }
                }
                foreach (var element in books)
                {
                    if (books[element.Key]!=0)
                    {
                        _books.Add(element.Key,element.Value);
                    }
                }
                List<double> series = new List<double>();
                List<string> xseries = new List<string>();
                foreach (var element in _books)
                {
                    series.Add(element.Value);
                    xseries.Add(element.Key);
                }
                chartComponent1.CreateDocument(new ChartParameters()
                {
                    Path = fbd.SelectedPath + FileName + ".pdf",
                    Title = "Бесплатные книги",
                    ChartName = "Диаграмма книг",
                    ChartLegendLocation = ChartLegendLocation.Right,
                    Series = series.ToArray(),
                    XSeries = xseries.ToArray()
                });
                MessageBox.Show("Отчёт создан", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
