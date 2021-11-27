using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Library_BusinessLogic.PluginLogic.Models;
using Library_BusinessLogic.PluginLogic.Interfaces;
using System.Threading.Tasks;
using TeleSharp.TL;
using TLSharp.Core;
using System.Windows.Forms;

namespace TelegramPlugin
{
    [Export(typeof(ISenderMessage))]
    class SenderMessageImplementation: ISenderMessage
    {
        private TelegramClient client;
        private TeleSharp.TL.Contacts.TLContacts userContacts;
        public string PluginType => "Telegram";

        private string hash;
        public async Task Connect(SenderConfiguratorModel config)
        {
            var form = new FormTelegram(config);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                string path = Directory.GetCurrentDirectory();
                path += @"\session.dat";
                if (File.Exists(path)) File.Delete(path);

                client = new TelegramClient(config.ApiId, config.ApiHash);
                await client.ConnectAsync();
                hash = await client.SendCodeRequestAsync(config.PhoneNumber);
                var formCode = new FormCode();
                formCode.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    await client.MakeAuthAsync(config.PhoneNumber, hash, formCode.Code);
                    userContacts = await client.GetContactsAsync();
                }
            }
        }

        public async Task SendMessage()
        {
            await client.GetContactsAsync();
            var form = new FormMessage(client, userContacts);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                var message = form.Model;
                if (message.Text == null)
                {
                    return;
                }
                await client.SendMessageAsync(new TLInputPeerUser() { UserId = message.TargetUserId }, message.Text);
            }
            
        }
    }
}
