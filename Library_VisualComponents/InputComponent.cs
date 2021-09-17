using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Library_VisualComponents
{
    public partial class InputComponent : UserControl
    {
        public InputComponent()
        {
            InitializeComponent();
        }
        public string Pattern { get; set; }

        public string Value
        {
            get
            {
                string outputText;
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    if (!Regex.IsMatch(textBox.Text, Pattern))
                    {
                        throw new ArgumentException();
                    }
                    outputText = textBox.Text;
                }
                else
                {
                    outputText = null;
                }
                return outputText;
            }
            set
            {
                textBox.Text = value;
            }
        }
        public void SetToolTip(string value)
        {
            toolTip.SetToolTip(textBox, value);
        }
    }
}
