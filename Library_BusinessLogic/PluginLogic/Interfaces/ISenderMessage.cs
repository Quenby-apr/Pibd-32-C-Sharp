using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Library_BusinessLogic.PluginLogic.Models;

namespace Library_BusinessLogic.PluginLogic.Interfaces
{
    public interface ISenderMessage
    {
        string PluginType { get; }
        Task Connect(SenderConfiguratorModel config);
        Task SendMessage(SendMessageModel message);
        Task MakeAuthAsync(SenderConfiguratorModel config, string _code);
        Task<TeleSharp.TL.Contacts.TLContacts> GetContacts();
    }
}
