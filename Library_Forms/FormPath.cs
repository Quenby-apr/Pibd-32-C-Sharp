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
    public partial class FormPath : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public string FileName { get; set; }
        public FormPath()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            FileName = textBoxFileName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            FileName = "|";
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
