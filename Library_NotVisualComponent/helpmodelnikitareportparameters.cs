using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_NotVisualComponent
{
    class helpmodelnikitareportparameters
    {
        public class ReportParameters<T>
        {
            /// <summary>
            /// Абсолютный путь папки, в которой будет создан отчет
            /// </summary>
            public string Path { get; set; }
            /// <summary>
            /// Список данных, который будет выведен в отчете.
            /// </summary>
            public List<T> Data { get; set; }
        }
    }
}
