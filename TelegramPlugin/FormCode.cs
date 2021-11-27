using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelegramPlugin
{
    public partial class FormCode : Form
    {
        public string Code { get; set; }
        public FormCode()
        {
            InitializeComponent();
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            Code = textBoxHash.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
