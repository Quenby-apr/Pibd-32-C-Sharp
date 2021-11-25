using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace Library_Forms
{
    public partial class FormHashTelegram : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public string Hash { get; set; }
        public FormHashTelegram()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            Hash = textBoxHash.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
