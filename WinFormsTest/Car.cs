using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTest
{
    class Car
    {
        public int Age { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            return string.Format("Age: {0}, Color: {1}", Age, Color);
        }
    }
}
