using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_NotVisualComponents.HelperModels;
using Microsoft.Office.Interop.Excel;
using Spire.Xls;

namespace Library_NotVisualComponents
{
    public partial class DocumentWithDiagram : Component
    {
        public enum LegendPosition
        {
            Top = 1,
            Right = 2,
            Bottom = 3,
            Left = 4
        }
        public DocumentWithDiagram()
        {
            InitializeComponent();
        }

        public DocumentWithDiagram(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CreateFile(string path, string docTitle, string diagTitle, List<DiagramSeries> data, LegendPosition chartLocation = (LegendPosition)3, string Ox = "0x", string Oy = "0y", string[] _xSeries = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new MyException("Строка пути до файла пуста");
            }
            if (string.IsNullOrEmpty(docTitle))
            {
                throw new MyException("Строка заголовка пуста");
            }
            if (string.IsNullOrEmpty(diagTitle))
            {
                throw new MyException("Строка заголовка диаграммы пуста");
            }
            if (data == null)
            {
                throw new MyException("Список данных пуст");
            }
            Application excel = new Application();
            Microsoft.Office.Interop.Excel.Workbook book;
            Microsoft.Office.Interop.Excel.Worksheet sheet;
            book = excel.Workbooks.Add(System.Reflection.Missing.Value);
            sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets[1];         
            Microsoft.Office.Interop.Excel.Chart excelchart = (Microsoft.Office.Interop.Excel.Chart)excel.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelchart.Activate();
            excelchart.Select(Type.Missing);
            excel.ActiveChart.ChartType = XlChartType.xlLineMarkers;
            excel.ActiveChart.HasTitle = true;
            excel.ActiveChart.ChartTitle.Text = diagTitle;
            excel.ActiveChart.ChartTitle.Font.Size = 14;
            excel.ActiveChart.ChartTitle.Font.Color = 255;
            ((Axis)excel.ActiveChart.Axes(XlAxisType.xlCategory,
                XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Axis)excel.ActiveChart.Axes(XlAxisType.xlCategory,
                XlAxisGroup.xlPrimary)).AxisTitle.Text = Ox;
            ((Axis)excel.ActiveChart.Axes(XlAxisType.xlValue,
                XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Axis)excel.ActiveChart.Axes(XlAxisType.xlValue,
                XlAxisGroup.xlPrimary)).AxisTitle.Text = Oy;
            excel.ActiveChart.HasLegend = true;
            //Расположение легенды
            switch (chartLocation) {
                case LegendPosition.Top:
                    {
                        excel.ActiveChart.Legend.Position= XlLegendPosition.xlLegendPositionTop;
                        break;
                    }
                case LegendPosition.Right:
                    {
                        excel.ActiveChart.Legend.Position = XlLegendPosition.xlLegendPositionRight;
                        break;
                    }
                case LegendPosition.Bottom:
                    {
                        excel.ActiveChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom;
                        break;
                    }
                case LegendPosition.Left:
                    {
                        excel.ActiveChart.Legend.Position = XlLegendPosition.xlLegendPositionLeft;
                        break;
                    }
                default:
                    {
                        excel.ActiveChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom;
                        break;
                    }
            }

            SeriesCollection seriesCollection = (SeriesCollection)excel.ActiveChart.SeriesCollection(Type.Missing);
            int index = 1;
            foreach (var element in data)
            {
                var this_series = seriesCollection.NewSeries();
                this_series.Name = data.ElementAt(index - 1).Name;
                this_series.Values = data.ElementAt(index - 1).Values;
                if (_xSeries != null)
                {
                    this_series.XValues = _xSeries;
                }
                index++;
            }

            excel.ActiveChart.Location(XlChartLocation.xlLocationAsObject, "Лист1");
            var excelsheets = book.Worksheets;
            sheet = (Microsoft.Office.Interop.Excel.Worksheet)excelsheets.get_Item(1);
            sheet.Shapes.Item(1).Height = 450;
            sheet.Shapes.Item(1).Width = 500;
            sheet.Cells[1, 1] = docTitle;
            excel.Application.ActiveWorkbook.SaveAs(path, XlSaveAsAccessMode.xlNoChange);
            excel.Quit();
            ReformateFile(path);
            File.Delete(path);
        }
        private void ReformateFile(string path)
        {
            Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
            workbook.LoadFromFile(path);
            workbook.SaveToFile(path + "x", ExcelVersion.Version2013);
        }
        class MyException : Exception
        {
            public MyException(string message)
                : base(message)
            { }
        }
    }
}

