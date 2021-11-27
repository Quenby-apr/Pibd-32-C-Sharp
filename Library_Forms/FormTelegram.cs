using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_BusinessLogic.PluginLogic.Interfaces;
using Library_BusinessLogic.PluginLogic.Managers;
using Library_BusinessLogic.PluginLogic.Models;
using Unity;

namespace Library_Forms
{
    public partial class FormTelegram : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private ISenderMessage messanger;
        private TelegramPluginManager manager;
        public FormTelegram(TelegramPluginManager _manager)
        {
            manager = _manager;
            InitializeComponent();
            messanger = manager.plugins["Telegram"];
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            messanger.Connect(new SenderConfiguratorModel()
            {
                ApiId = 9153033,
                ApiHash = "99d35646363829a80ab8c28cd2044655"
            });
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            messanger.SendMessage();
        }
    }
}
