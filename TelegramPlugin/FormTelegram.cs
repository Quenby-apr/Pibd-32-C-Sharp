using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_BusinessLogic.PluginLogic.Models;

namespace TelegramPlugin
{
    public partial class FormTelegram : Form
    {
        public SenderConfiguratorModel config { get; set; }
        public FormTelegram(SenderConfiguratorModel _config)
        {
            InitializeComponent();
            config = _config;
        }
        private async void buttonAuth_Click(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == null)
            {
                Console.WriteLine("Номер не введён");
                return;
            }
            string phoneNumber = textBoxPhone.Text;
            if (config.ApiId == 0)
            {
                config.ApiId = 9153033;
            }
            if (config.ApiHash == null)
            {
                config.ApiHash = "99d35646363829a80ab8c28cd2044655";
            }
            config.PhoneNumber = textBoxPhone.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
