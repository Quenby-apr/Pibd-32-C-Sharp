using System;
using System.Collections.Generic;
using System.Text;

namespace Library_BusinessLogic.PluginLogic.Models
{
    public class SendMessageModel
    {
        public int TargetUserId { get; set; }
        public string Text { get; set; }
    }
}
