using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Xls;
using System.Reflection;

namespace Library_NotVisualComponents
{
    public partial class DocumentWithCustomTable : Component
    {
        public DocumentWithCustomTable()
        {
            InitializeComponent();
        }

        public DocumentWithCustomTable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// для заголовков используется двумерный массив (1-e измерение - главные заголовки, 2-е измерение - подзаголовки)
        /// для ширины колонок необязательный к заполнению список, если член списка null, то ширина не изменится
        /// </summary>
        /// <param name="path"></param>
        /// <param name="titleName">главый заголовок</param>
        /// <param name="titles">названия свойств и полей. Первый элемент главный заголовок, 2+ подзаголовки</param>
        /// <param name="text"></param>
        /// <param name="columnWidth">тип данных double?</param>
        public void CreateFile<T>(string path, string titleName, List<List<string>> titles, List<T> text, List<double?> columnWidth = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new MyException("Строка пути до файла пуста");
            }
            if (string.IsNullOrEmpty(titleName))
            {
                throw new MyException("Строка заголовка пуста");
            }
            if (titles==null)
            {
                throw new MyException("Список заголовков пуст");
            }
            if (text==null)
            {
                throw new MyException("Список передаваемых классов пуст");
            }
            if (!File.Exists(path))
            {
                Application excel = new Application { SheetsInNewWorkbook = 1, Visible = false, DisplayAlerts = false };
                Microsoft.Office.Interop.Excel.Workbook workBook = excel.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.Worksheets.get_Item(1);
                sheet.Cells[1, 1] = titleName;
                List<string> textProperties = new List<string>();
                int indexX = 1;
                foreach (var element in titles)
                {
                    int indexY = 2; 
                    if (element.Count() == 1)
                    {
                        sheet.Cells[indexY, indexX] = element.ElementAt(0);
                        var mergeCells = sheet.Range[sheet.Cells[indexY, indexX], sheet.Cells[indexY+1, indexX]];
                        mergeCells.Merge(Type.Missing);
                        textProperties.Add(element.ElementAt(0));
                        indexX++;
                    }
                    else
                    {
                        sheet.Cells[indexY, indexX] = element.ElementAt(0);
                        var mergeCells = sheet.Range[sheet.Cells[indexY, indexX], sheet.Cells[indexY, indexX+element.Count()-2]];
                        mergeCells.Merge(Type.Missing);
                        indexY++;
                        for (int number = 1; number < element.Count(); number++) 
                        { 
                            sheet.Cells[indexY, indexX] = element.ElementAt(number);
                            textProperties.Add(element.ElementAt(number));
                            indexX++;
                        }
                    }
                }
                int indexO = 4;
                foreach (var element in text)
                {
                    var properties = element.GetType().GetProperties();
                    var countProperties = properties.Length;
                    for (int i = 0; i < countProperties; i++)//значения
                    {
                        PropertyInfo property = properties[i];
                        sheet.Cells[indexO, i+1] = property.GetValue(element).ToString();
                    }
                    indexO++;
                }
                
                var rangeTitle = sheet.Range[sheet.Cells[1, 1], sheet.Cells[3, textProperties.Count()]];
                var rangeText = sheet.Range[sheet.Cells[4, 1], sheet.Cells[text.Count + 3, textProperties.Count()]];
                rangeTitle.Cells.Style.VerticalAlignment = VerticalAlignType.Bottom;
                rangeTitle.Cells.Style.HorizontalAlignment = HorizontalAlignType.Right;
                rangeTitle.Cells.Font.Size = 12;
                rangeTitle.Cells.Font.Bold = true;
                rangeText.Cells.Font.Size = 12;
                sheet.Columns.EntireColumn.AutoFit();
                if (columnWidth != null)
                {
                    for (int indexColumn = 1; indexColumn <= textProperties.Count(); indexColumn++)
                    {
                        if (columnWidth.ElementAt(indexColumn - 1) != null)
                        {
                            string index = NumberToLetters(indexColumn);
                            index = index + ":" + index;
                            sheet.Columns[index].ColumnWidth = columnWidth.ElementAt(indexColumn - 1);
                        }
                    }                            
                }
                excel.Application.ActiveWorkbook.SaveAs(path, XlSaveAsAccessMode.xlNoChange);
                excel.Quit();
                ReformateFile(path);
                File.Delete(path);
            }
            else
            {
                throw new MyException("Файл с таким именем уже существует");
            }
        }
        private void ReformateFile(string path)
        {
            Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
            workbook.LoadFromFile(path);
            workbook.SaveToFile(path + "x", ExcelVersion.Version2013);
        }
        private string NumberToLetters(int number)
        {
            string result;
            if (number > 0)
            {
                int alphabets = (number - 1) / 26;
                int remainder = (number - 1) % 26;
                result = ((char)('A' + remainder)).ToString();
                if (alphabets > 0)
                    result = NumberToLetters(alphabets) + result;
            }
            else
                result = null;
            return result;
        }
        class MyException : Exception
        {
            public MyException(string message)
                : base(message)
            { }
        }
    }
}
