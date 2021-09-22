using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Library_NotVisualComponent
{
    public partial class BinaryBackUp : Component
    {
        public BinaryBackUp()
        {
            InitializeComponent();
        }

        public BinaryBackUp(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void SaveData<T>(string directorypath, string filename, List<T> data) 
        {
            string addFilename = "/" + filename;
            if (!string.IsNullOrEmpty(directorypath))
            {
                T item = Activator.CreateInstance<T>();
                if (item.GetType().GetCustomAttribute(typeof(SerializableAttribute)) != null)
                {
                    Directory.CreateDirectory(string.Concat(directorypath, addFilename));
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    using (FileStream fileStream = new FileStream(string.Concat(new string[] { directorypath, addFilename, addFilename, ".bin" }), FileMode.OpenOrCreate))
                    {
                        binaryFormatter.Serialize(fileStream, data);
                    }
                    string sourceDirectory = string.Concat(directorypath, addFilename);
                    string[] destinationArchieve = new string[] { directorypath, addFilename, ".zip" };
                    ZipFile.CreateFromDirectory(sourceDirectory, string.Concat(destinationArchieve));
                    Directory.Delete(string.Concat(directorypath, addFilename), true);
                }
                else
                {
                    throw new MyException("Передаваемый объект не может быть сериализован");
                }
            }
            else
            {
                throw new MyException("Строка пути до файла пустая");
            }
        }
    }
    class MyException : Exception
    {
        public MyException(string message)
            : base(message)
        { }
    }
}
