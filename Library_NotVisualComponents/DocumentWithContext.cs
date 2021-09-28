using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Spire.Xls;

namespace Library_NotVisualComponents
{
    public partial class DocumentWithContext : Component
    {
        public DocumentWithContext()
        {
            InitializeComponent();
        }

        public DocumentWithContext(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CreateFile(string path, string titleName, List<string> text)
        {
            if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(titleName) && text!=null) 
            {
                if (!File.Exists(path))
                {
                    Application excel = new Application { SheetsInNewWorkbook = 1, Visible = false, DisplayAlerts = false };
                    Microsoft.Office.Interop.Excel.Workbook workBook = excel.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.Worksheets.get_Item(1);
                    sheet.Cells[1, 1] = titleName;
                    int index = 3;
                    foreach (var element in text)
                    {
                        sheet.Cells[index, 1] = element;
                        index++;
                    }
                    var rangeTitle = sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 1]];
                    var rangeText = sheet.Range[sheet.Cells[3, 1], sheet.Cells[1, text.Count + 2]];
                    rangeTitle.Cells.Font.Size = 12;
                    rangeTitle.Cells.Font.Bold = true;
                    rangeText.Cells.Font.Size = 12;
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
            else
            {
                throw new MyException("Минимум один из передаваемых аргументов пуст");
            }
        }
        
        private void ReformateFile(string path)
        {
            Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
            workbook.LoadFromFile(path);
            workbook.SaveToFile(path+"x", ExcelVersion.Version2013);
        }
        class MyException : Exception
        {
            public MyException(string message)
                : base(message)
            { }
        }
    }
}
