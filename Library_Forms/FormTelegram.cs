using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_BusinessLogic.PluginLogic.Interfaces;
using Library_BusinessLogic.PluginLogic.Managers;
using Library_BusinessLogic.PluginLogic.Models;
using System.Windows.Forms;
using TeleSharp.TL;
using TLSharp.Core;
using Unity;

namespace Library_Forms
{
    public partial class FormTelegram : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        TelegramClient client;
        TeleSharp.TL.Contacts.TLContacts userContacts;

        private ISenderMessage _messenger;
        private TelegramPluginManager _manager;
        public FormTelegram(TelegramPluginManager manager)
        {
            _manager = manager;
            InitializeComponent();
            _messenger = _manager.plugins["Telegram"];
        }

        private async void buttonAuth_Click(object sender, EventArgs e)
        {
            if (textBoxMessage.Text == null)
            {
                Console.WriteLine("Номер не введён");
                return;
            }
            string phoneNumber = textBoxPhone.Text;
            int apiId = 9153033;
            string apiHash = "99d35646363829a80ab8c28cd2044655";
            var config = new SenderConfiguratorModel()
            {
                ApiId = apiId,
                ApiHash = apiHash,
                PhoneNumber = phoneNumber
            };
            await _messenger.Connect(config);

            var form = Container.Resolve<FormHashTelegram>();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                await _messenger.MakeAuthAsync(config, form.Hash);
                userContacts = await _messenger.GetContacts();
                List<string> listPhones = new List<String>();
                foreach (var user in userContacts.Users)
                {
                    var props = user.GetType().GetProperties();

                    foreach (var prop in props)
                    {
                        if (prop.Name == "Phone")
                        {
                            listPhones.Add(prop.GetValue(user).ToString());
                        }
                    }
                }
                listBox.DataSource = listPhones;
            }
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                Console.WriteLine("Не выбран номер");
                return;
            }
            if (textBoxMessage.Text == null)
            {
                Console.WriteLine("Пустое сообщение");
                return;
            }
            var selectUserForSendMessage = userContacts.Users
                                                            .Where(x => x.GetType() == typeof(TLUser))
                                                            .Cast<TLUser>()
                                                            .FirstOrDefault(x => x.Phone == listBox.SelectedItem.ToString());
            var message = new SendMessageModel()
            {
                TargetUserId = selectUserForSendMessage.Id,
                Text = textBoxMessage.Text
            };
            await _messenger.SendMessage(message);
        }
    }
}
