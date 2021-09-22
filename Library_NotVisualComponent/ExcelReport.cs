using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2013.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Library_NotVisualComponent.HelperModels;

namespace Library_NotVisualComponent
{
    public partial class ExcelReport : Component
    {
        public ExcelReport()
        {
            InitializeComponent();
        }

        public ExcelReport(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateDoc<T>(string Path, List<T> Data, List<int> LineNumbersToCombine) 
        {
            if (!string.IsNullOrEmpty(Path))
            {

                using (SpreadsheetDocument spreadsheetDocument =
               SpreadsheetDocument.Create(Path, SpreadsheetDocumentType.Workbook))
                {
                    // Создаем книгу (в ней хранятся листы)
                    WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                    workbookpart.Workbook = new Workbook();
                    CreateStyles(workbookpart);

                    // Получаем/создаем хранилище текстов для книги
                    SharedStringTablePart shareStringPart =
                   spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0
                    ?
                   spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First()
                    :
                   spreadsheetDocument.WorkbookPart.AddNewPart<SharedStringTablePart>();

                    // Создаем SharedStringTable, если его нет
                    if (shareStringPart.SharedStringTable == null)
                    {
                        shareStringPart.SharedStringTable = new SharedStringTable();
                    }
                    // Создаем лист в книгу
                    WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    // Добавляем лист в книгу
                    Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Лист"
                    };
                    sheets.Append(sheet);
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                    if (LineNumbersToCombine.Count % 2 == 0)
                    {
                        for (int index = 0; index < LineNumbersToCombine.Count; index += 2) //объединение строк в шапке
                        {
                            MergeCells(new ExcelMergeParameters
                            {
                                Worksheet = worksheetPart.Worksheet,
                                CellFromName = "A" + LineNumbersToCombine[index],
                                CellToName = "A" + LineNumbersToCombine[index + 1]
                            });
                        }
                    }
                    else
                    {
                        throw new MyException("Вводить пары значений начала и конца объединения строк");
                    }

                    uint buf = 1;
                    int columnIndex = 3;
                    foreach (var elem in Data)// ЗАПОЛНЕНИЕ ФАЙЛА
                    {
                        var properties = elem.GetType().GetProperties();
                        var countProperties = properties.Length;
                        for (uint i = 0; i < countProperties; i++)//название класса
                        {
                            PropertyInfo property = properties[i];
                            InsertCellInWorksheet(new ExcelCellParameters
                            {
                                Worksheet = worksheetPart.Worksheet,
                                ShareStringPart = shareStringPart,
                                ColumnName = "A",
                                RowIndex = i + buf,
                                Text = elem.GetType().Name,
                                StyleIndex = 2U,
                            });
                        }
                        for (uint i = 0; i < countProperties; i++)//названия свойств
                        {

                            PropertyInfo property = properties[i];
                            InsertCellInWorksheet(new ExcelCellParameters
                            {
                                Worksheet = worksheetPart.Worksheet,
                                ShareStringPart = shareStringPart,
                                ColumnName = "B",
                                RowIndex = i + buf,
                                Text = property.Name.ToString(),
                                StyleIndex = 2U,

                            });
                        }

                        for (uint i = 0; i < countProperties; i++)//значения
                        {

                            PropertyInfo property = properties[i];
                            InsertCellInWorksheet(new ExcelCellParameters
                            {
                                Worksheet = worksheetPart.Worksheet,
                                ShareStringPart = shareStringPart,
                                ColumnName = NumberToLetters(checked((int)columnIndex)),
                                RowIndex = i + buf,
                                Text = property.GetValue(elem).ToString(),
                                StyleIndex = 0U
                            });
                        }
                        columnIndex++;
                    }
                    workbookpart.Workbook.Save();
                }
            }
            else
            {
                throw new MyException("Строка пути до файла пустая");
            }
        }
        static string NumberToLetters(int number)
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

        // Настройка стилей для файла
        private static void CreateStyles(WorkbookPart workbookpart)
        {
            WorkbookStylesPart sp = workbookpart.AddNewPart<WorkbookStylesPart>();
            sp.Stylesheet = new Stylesheet();
            Fonts fonts = new Fonts() { Count = (UInt32Value)2U, KnownFonts = true };
            Font fontUsual = new Font();
            fontUsual.Append(new FontSize() { Val = 12D });
            fontUsual.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color()
            {
                Theme = (UInt32Value)1U
            });
            fontUsual.Append(new FontName() { Val = "Times New Roman" });
            fontUsual.Append(new FontFamilyNumbering() { Val = 2 });
            fontUsual.Append(new FontScheme() { Val = FontSchemeValues.Minor });
            Font fontTitle = new Font();
            fontTitle.Append(new Bold());
            fontTitle.Append(new FontSize() { Val = 14D });
            fontTitle.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color()
            {
                Theme = (UInt32Value)1U
            });
            fontTitle.Append(new FontName() { Val = "Times New Roman" });
            fontTitle.Append(new FontFamilyNumbering() { Val = 2 });
            fontTitle.Append(new FontScheme() { Val = FontSchemeValues.Minor });
            fonts.Append(fontUsual);
            fonts.Append(fontTitle);
            Fills fills = new Fills() { Count = (UInt32Value)2U };
            Fill fill1 = new Fill();
            fill1.Append(new PatternFill() { PatternType = PatternValues.None });
            Fill fill2 = new Fill();
            fill2.Append(new PatternFill() { PatternType = PatternValues.Gray125 });
            fills.Append(fill1);
            fills.Append(fill2);
            Borders borders = new Borders() { Count = (UInt32Value)2U };
            Border borderNoBorder = new Border();
            borderNoBorder.Append(new LeftBorder());
            borderNoBorder.Append(new RightBorder());
            borderNoBorder.Append(new TopBorder());
            borderNoBorder.Append(new BottomBorder());
            borderNoBorder.Append(new DiagonalBorder());
            Border borderThin = new Border();
            LeftBorder leftBorder = new LeftBorder() { Style = BorderStyleValues.Thin };
            leftBorder.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color()
            {
                Indexed = (UInt32Value)64U
            });
            RightBorder rightBorder = new RightBorder()
            {
                Style = BorderStyleValues.Thin
            };
            rightBorder.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color()
            {
                Indexed = (UInt32Value)64U
            });
            TopBorder topBorder = new TopBorder() { Style = BorderStyleValues.Thin };
            topBorder.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color()
            {
                Indexed = (UInt32Value)64U
            });
            BottomBorder bottomBorder = new BottomBorder()
            {
                Style = BorderStyleValues.Thin
            };
            bottomBorder.Append(new DocumentFormat.OpenXml.Office2010.Excel.Color()
            {
                Indexed = (UInt32Value)64U
            });
            borderThin.Append(leftBorder);
            borderThin.Append(rightBorder);
            borderThin.Append(topBorder);
            borderThin.Append(bottomBorder);
            borderThin.Append(new DiagonalBorder());
            borders.Append(borderNoBorder);
            borders.Append(borderThin);
            CellStyleFormats cellStyleFormats = new CellStyleFormats()
            {
                Count = (UInt32Value)1U
            };
            CellFormat cellFormatStyle = new CellFormat()
            {
                NumberFormatId = (UInt32Value)0U,
                FontId = (UInt32Value)0U,
                FillId = (UInt32Value)0U,
                BorderId = (UInt32Value)0U
            };
            cellStyleFormats.Append(cellFormatStyle);
            CellFormats cellFormats = new CellFormats() { Count = (UInt32Value)3U };
            CellFormat cellFormatFont = new CellFormat()
            {
                NumberFormatId = (UInt32Value)0U,
                FontId = (UInt32Value)0U,
                FillId = (UInt32Value)0U,
                BorderId = (UInt32Value)0U,
                FormatId = (UInt32Value)0U,
                ApplyFont = true
            };
            CellFormat cellFormatFontAndBorder = new CellFormat()
            {
                NumberFormatId = (UInt32Value)0U,
                FontId = (UInt32Value)0U,
                FillId = (UInt32Value)0U,
                BorderId = (UInt32Value)1U,
                FormatId = (UInt32Value)0U,
                ApplyFont = true,
                ApplyBorder = true
            };
            CellFormat cellFormatTitle = new CellFormat()
            {
                NumberFormatId = (UInt32Value)0U,
                FontId = (UInt32Value)1U,
                FillId = (UInt32Value)0U,
                BorderId = (UInt32Value)0U,
                FormatId = (UInt32Value)0U,
                Alignment = new Alignment()
                {
                    Vertical = VerticalAlignmentValues.Center,
                    WrapText = true,
                    Horizontal = HorizontalAlignmentValues.Center
                },
                ApplyFont = true
            };

            cellFormats.Append(cellFormatFont);
            cellFormats.Append(cellFormatFontAndBorder);
            cellFormats.Append(cellFormatTitle);
            CellStyles cellStyles = new CellStyles() { Count = (UInt32Value)1U };
            cellStyles.Append(new CellStyle()
            {
                Name = "Normal",
                FormatId = (UInt32Value)0U,
                BuiltinId = (UInt32Value)0U
            });
            DocumentFormat.OpenXml.Office2013.Excel.DifferentialFormats
           differentialFormats = new DocumentFormat.OpenXml.Office2013.Excel.DifferentialFormats()
           {
               Count = (UInt32Value)0U
           };

            TableStyles tableStyles = new TableStyles()
            {
                Count = (UInt32Value)0U,
                DefaultTableStyle = "TableStyleMedium2",
                DefaultPivotStyle = "PivotStyleLight16"
            };
            StylesheetExtensionList stylesheetExtensionList = new
           StylesheetExtensionList();
            StylesheetExtension stylesheetExtension1 = new StylesheetExtension()
            {
                Uri =
           "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}"
            };
            stylesheetExtension1.AddNamespaceDeclaration("x14",
           "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
            stylesheetExtension1.Append(new SlicerStyles()
            {
                DefaultSlicerStyle =
           "SlicerStyleLight1"
            });
            StylesheetExtension stylesheetExtension2 = new StylesheetExtension()
            {
                Uri =
           "{9260A510-F301-46a8-8635-F512D64BE5F5}"
            };
            stylesheetExtension2.AddNamespaceDeclaration("x15",
           "http://schemas.microsoft.com/office/spreadsheetml/2010/11/main");
            stylesheetExtension2.Append(new TimelineStyles()
            {
                DefaultTimelineStyle =
           "TimeSlicerStyleLight1"
            });
            stylesheetExtensionList.Append(stylesheetExtension1);
            stylesheetExtensionList.Append(stylesheetExtension2);
            sp.Stylesheet.Append(fonts);
            sp.Stylesheet.Append(fills);
            sp.Stylesheet.Append(borders);
            sp.Stylesheet.Append(cellStyleFormats);
            sp.Stylesheet.Append(cellFormats);
            sp.Stylesheet.Append(cellStyles);
            sp.Stylesheet.Append(differentialFormats);
            sp.Stylesheet.Append(tableStyles);
            sp.Stylesheet.Append(stylesheetExtensionList);
        }

        // Добавляем новую ячейку в лист
        private static void InsertCellInWorksheet(ExcelCellParameters cellParameters)
        {
            SheetData sheetData = cellParameters.Worksheet.GetFirstChild<SheetData>();

            // Ищем строку, либо добавляем ее
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex ==
           cellParameters.RowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex ==
               cellParameters.RowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = cellParameters.RowIndex };
                sheetData.Append(row);
            }

            // Ищем нужную ячейку
            Cell cell;
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == cellParameters.CellReference).Count() > 0)
            {
                cell = row.Elements<Cell>().Where(c => c.CellReference.Value ==
               cellParameters.CellReference).First();
            }
            else
            {
                // Все ячейки должны быть последовательно друг за другом расположены
                // нужно определить, после какой вставлять
                Cell refCell = null;
                foreach (Cell rowCell in row.Elements<Cell>())
                {
                    if (string.Compare(rowCell.CellReference.Value,
                   cellParameters.CellReference, true) > 0)
                    {
                        refCell = rowCell;
                        break;
                    }
                }
                Cell newCell = new Cell()
                {
                    CellReference = cellParameters.CellReference
                };
                row.InsertBefore(newCell, refCell);
                cell = newCell;
            }
            // вставляем новый текст
            cellParameters.ShareStringPart.SharedStringTable.AppendChild(new
           SharedStringItem(new Text(cellParameters.Text)));
            cellParameters.ShareStringPart.SharedStringTable.Save();
            cell.CellValue = new
           CellValue((cellParameters.ShareStringPart.SharedStringTable.Elements<SharedStringItem>().
           Count() - 1).ToString());
            cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
            cell.StyleIndex = cellParameters.StyleIndex;
        }

        // Объединение ячеек
        private static void MergeCells(ExcelMergeParameters mergeParameters)
        {
            MergeCells mergeCells;
            if (mergeParameters.Worksheet.Elements<MergeCells>().Count() > 0)
            {
                mergeCells = mergeParameters.Worksheet.Elements<MergeCells>().First();
            }
            else
            {
                mergeCells = new MergeCells();
                if (mergeParameters.Worksheet.Elements<CustomSheetView>().Count() > 0)
                {
                    mergeParameters.Worksheet.InsertAfter(mergeCells,
                   mergeParameters.Worksheet.Elements<CustomSheetView>().First());
                }
                else
                {
                    mergeParameters.Worksheet.InsertAfter(mergeCells,
                        mergeParameters.Worksheet.Elements<SheetData>().First());
                }
            }
            MergeCell mergeCell = new MergeCell()
            {
                Reference = new StringValue(mergeParameters.Merge)
            };
            mergeCells.Append(mergeCell);
        }
        class MyException : Exception
        {
            public MyException(string message)
                : base(message)
            { }
        }
    }
}
