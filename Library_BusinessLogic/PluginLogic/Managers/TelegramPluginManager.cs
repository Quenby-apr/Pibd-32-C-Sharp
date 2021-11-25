using System;
using System.Collections.Generic;
using Library_BusinessLogic.PluginLogic.Interfaces;
using System.Linq;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Text;
using System.IO;

namespace Library_BusinessLogic.PluginLogic.Managers
{
    public class TelegramPluginManager
    {
        [ImportMany(typeof(ISenderMessage))]
        private List<ISenderMessage> Plugins { get; set; }

        public readonly Dictionary<string, ISenderMessage> plugins = new Dictionary<string, ISenderMessage>();
        public List<string> Headers { get; set; }
        public TelegramPluginManager()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            var pa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            if (!Directory.Exists(pa)) Directory.CreateDirectory(pa);
            catalog.Catalogs.Add(new DirectoryCatalog(pa));
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            Headers = new List<string>();
            Plugins.ForEach(x =>
            {
                if (!plugins.ContainsKey(x.PluginType))
                    plugins.Add(x.PluginType, x);
            });
            Headers.AddRange(plugins.Keys.ToList());
        }
    }
}
