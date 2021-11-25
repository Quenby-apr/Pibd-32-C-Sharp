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
            if (config.ApiHash == null || config.PhoneNumber == null)
            {
                return;
            }
            string path = Directory.GetCurrentDirectory();
            path += @"\session.dat";
            if (File.Exists(path)) File.Delete(path);

            client = new TelegramClient(config.ApiId, config.ApiHash);
            await client.ConnectAsync();
            hash = await client.SendCodeRequestAsync(config.PhoneNumber);

        }
        public async Task<TeleSharp.TL.Contacts.TLContacts> GetContacts()
        {
            return await client.GetContactsAsync();
        }

        public async Task MakeAuthAsync(SenderConfiguratorModel config, string _code)
        {
            if (_code == null || config.PhoneNumber == null)
            {
                return;
            }
            await client.MakeAuthAsync(config.PhoneNumber, hash, _code);
        }
        public async Task SendMessage(SendMessageModel message)
        {
            if (message.Text == null)
            {
                return;
            }
            await client.SendMessageAsync(new TLInputPeerUser() { UserId = message.TargetUserId }, message.Text);
        }
    }
}
