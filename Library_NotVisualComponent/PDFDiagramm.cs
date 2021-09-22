using PdfSharp.Charting;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library_NotVisualComponent
{
    public partial class PDFDiagramm : Component
    {
        public PDFDiagramm()
        {
            InitializeComponent();
        }

        public PDFDiagramm(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CreateDiagram<T>(string path, List<T> data,  string propertyName)
        {
            if (!string.IsNullOrEmpty(path))
            {
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();

                var property = typeof(T).GetProperty(propertyName);
                Dictionary<string, int> dict = new Dictionary<string, int>();
                if (property != null)
                {
                    dict = new Dictionary<string, int>();
                    foreach (var elem in data)
                    {
                        var propertyValue = property.GetValue(elem);
                        string propertyValueString = propertyValue.ToString();
                        if (!string.IsNullOrEmpty(propertyValueString))
                        {
                            if (dict.ContainsKey(propertyValueString))
                            {
                                dict[propertyValueString]++;
                            }
                            else
                            {
                                dict.Add(propertyValueString, 1);
                            }
                        }
                    }
                }
                
                ChartFrame chartFrame = new ChartFrame();
                chartFrame.Location = new XPoint(30, 30);
                chartFrame.Size = new XSize(300, 600);
                chartFrame.Add(ColumnChart(dict));

                XGraphics g = XGraphics.FromPdfPage(page);
                chartFrame.Draw(g);

                document.Save(path);
            }
        }

        Chart ColumnChart(Dictionary<string, int> dict) 
        {
            Chart chart = new Chart(ChartType.Column2D);

            foreach (var el in dict)
            {
                Series series = chart.SeriesCollection.AddSeries();
                series.Name = el.Key;
                series.Add(el.Value);
            }

            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            chart.Legend.Docking = DockingType.Right;

            chart.DataLabel.Type = DataLabelType.Value;
            chart.DataLabel.Position = DataLabelPosition.OutsideEnd;

            return chart;
        }

    }
}
