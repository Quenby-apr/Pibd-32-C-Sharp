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
using TeleSharp.TL;
using TLSharp.Core;

namespace TelegramPlugin
{
    public partial class FormMessage : Form
    {
        public SendMessageModel  Model {get;set;}
        private TelegramClient client;
        private TeleSharp.TL.Contacts.TLContacts userContacts;
        public FormMessage(TelegramClient _client, TeleSharp.TL.Contacts.TLContacts _userContacts)
        {
            client = _client;
            userContacts = _userContacts;
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
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
            Model = new SendMessageModel()
            {
                TargetUserId = selectUserForSendMessage.Id,
                Text = textBoxMessage.Text
            };
            DialogResult = DialogResult.OK;
        }
    }
}
