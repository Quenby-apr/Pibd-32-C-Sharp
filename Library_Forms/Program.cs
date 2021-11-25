using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_BusinessLogic.BusinessLogic;
using Library_BusinessLogic.Interfaces;
using Library_BusinessLogic.PluginLogic.Managers;
using LibraryDatabase.Implements;
using Unity;
using Unity.Lifetime;

namespace Library_Forms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<MainForm>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IBookStorage, BookStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGenreStorage, GenreStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<BookLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<GenreLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<TelegramPluginManager>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ExcelPluginManager>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
