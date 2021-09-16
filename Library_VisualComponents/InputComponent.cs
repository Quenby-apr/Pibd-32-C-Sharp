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

        private string value = string.Empty;
        public string Value
        {
            get
            {
                string outputText;
                if (!string.IsNullOrEmpty(value))
                {
                    if (!Regex.IsMatch(value, Pattern))
                    {
                        throw new ArgumentException();
                    }
                    outputText = value;
                }
                else
                {
                    outputText = null;
                }
                return outputText;
            }
            set
            {
                this.value = value;
            }
        }
        public void SetToolTip(string value)
        {
            toolTip.SetToolTip(textBox, value);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Value = ((TextBox)sender).Text;
        }
    }
}
