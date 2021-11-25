using System;
using System.Collections.Generic;
using System.Text;

namespace Library_BusinessLogic.PluginLogic.Models
{
    public class ChartConfigModel
    {
        public struct DiagramSeries
        {
            public string Name { get; set; }
            public double[] Values { get; set; }
        }

        public string DiagTitle { get; set; }

        public List<DiagramSeries> Data { get; set; }
    }
}
