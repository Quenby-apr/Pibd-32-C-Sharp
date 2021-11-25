using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_BusinessLogic.PluginLogic.Interfaces;
using Library_BusinessLogic.PluginLogic.Managers;
using Library_BusinessLogic.PluginLogic.Models;
using Unity;
using static Library_BusinessLogic.PluginLogic.Models.ChartConfigModel;

namespace Library_Forms
{
    public partial class FormReport : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private IReportBuilder _reporter;
        private ExcelPluginManager _manager;
        public FormReport(ExcelPluginManager manager)
        {
            _manager = manager;
            InitializeComponent();
            _reporter = _manager.plugins["Report"];
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            _reporter.OpenFile();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            _reporter.AddImage(new ImageConfigModel()
            {
                
                Path = path+"Monkee.jpg",
                Coordinates = new int[] { 350, 50, 500, 200 }
            });;
            List<DiagramSeries> thatlist = new List<DiagramSeries>();
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
            _reporter.AddChart(new ChartConfigModel()
            {
                DiagTitle = "Диаграмма",
                Data = thatlist
            });
            _reporter.AddTable(new TableConfigModel()
            {
                TitleName = "Таблица",
                Text = new List<string> { "Маугли и Каа сидят под пальмой.", "Каа только что поел и наслаждается ситуацией а Маугли к нему пристает с дурацкими вопросами:", "— Каа, а видишь вон на высокой пальме банан ?", "— Ну, вижу...", "— А Багира сможет его достать ?", "— Нет, Маугли, не сможет.", "— А Балу сможет его достать ?", "— Нет, Маугли, не сможет.", "— А ты, Каа, сможешь его достать ?", "— Нет, Маугли, не смогу.", "— А я смогу его достать ?", "— Ты, Маугли, кого хочешь достанешь..." }
            });
            _reporter.AddParagraph(new ParagraphConfigModel()
            {
                Text = "Новый абзац",
                Cells = new int[] { 3, 1 }
            });

            var fbd = new SaveFileDialog();
            fbd.FileName = "File.xls";
            fbd.Filter = "xls file | *.xls";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _reporter.SaveDocument(fbd.FileName);
                    {
                        MessageBox.Show("Файл был создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
