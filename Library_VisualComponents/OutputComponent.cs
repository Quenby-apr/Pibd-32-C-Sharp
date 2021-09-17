using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Text.RegularExpressions;

namespace Library_VisualComponents
{
    public partial class OutputComponent : UserControl
    {
        private string layoutLine;
        public string LayoutLine
        {
            set { layoutLine = value; }
        }
        public OutputComponent()
        {
            InitializeComponent();
        }
        public int SelectedIndex
        {
            get { return listBox.SelectedIndex; }
            set
            {
                if (value >= -1 && value < listBox.Items.Count)
                {
                    listBox.SelectedIndex = value;
                }
            }
        }

        string[] separatingCharacters = new string[2];
        public void setSeparatingCharacters(string inputLine)
        {
            string[] param = inputLine.Split(',');
            if (param.Length == 2)
                separatingCharacters = param;
            else if (param.Length == 1)
            {
                separatingCharacters[0] = param[0];
                separatingCharacters[1] = param[0];
            }
            else 
                return;

        }
        private string deleteSeparatingCharacters(string inputLine)
        {
            return inputLine.Replace(separatingCharacters[0], null).Replace(separatingCharacters[1], null);
        }
        /*public ArrayList getParams(string layoutLine)
        {
            string[] line = layoutLine.Split(',');
            ArrayList result = new ArrayList();
            for (int i = 0; i < line.Length; i++)
            {
                int start = line[i].IndexOf(separatingCharacters[0]);
                int end = line[i].IndexOf(separatingCharacters[1]);

                string param = line[i].Substring(start + 1, end - start - 1);
                result.Add(param);
            }
            return result;
        }*/
        public void AddItem<T>(T obj)
        {
            if (obj != null)
            {
                string[] line = layoutLine.Split(',');
                for (int i = 0; i < line.Length; i++)
                {
                    int start = line[i].IndexOf(separatingCharacters[0]);
                    int end = line[i].IndexOf(separatingCharacters[1]);

                    string param = line[i].Substring(start + 1, end - start - 1); 
                    var elem = obj.GetType().GetProperty(param);
                    Console.WriteLine(param);
                    if (elem != null) {
                        line[i] = line[i].Replace(param, null);
                        line[i] = line[i].Insert(start + 1, elem.GetValue(obj, null)?.ToString());
                    }
                }
                string result = string.Join(",", line);
                listBox.Items.Add(result);
            }
        }
        public T GetSelectedItem<T>() where T : class, new()
        {
            T restoreItem;
            if (listBox.SelectedIndex != -1 && layoutLine != null)
            {
                T itemT = Activator.CreateInstance<T>();
                string selectedItemString = listBox.SelectedItem.ToString();
                string regPropertyName = separatingCharacters[0] + "[\\w\\d]+" + separatingCharacters[1];
                string[] lines = Regex.Split(layoutLine, regPropertyName);
                var properties = Regex.Matches(layoutLine, regPropertyName);
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    int lineLength = lines[i].Length;
                    string propertyName = deleteSeparatingCharacters(properties[i].Value);
                    int indexNextParam = selectedItemString.IndexOf(lines[i + 1]);
                    string propertyValue;
                    if (indexNextParam == 0)
                    {
                        propertyValue = selectedItemString.Substring(lineLength);
                    }
                    else
                    {
                        propertyValue = selectedItemString.Substring(lineLength, indexNextParam - lineLength);
                        selectedItemString = selectedItemString.Substring(indexNextParam);
                    }
                    propertyValue= deleteSeparatingCharacters(propertyValue);
                    var property = itemT.GetType().GetProperty(propertyName);
                    if (property != null && propertyValue != separatingCharacters[0] + propertyName + separatingCharacters[1])
                    {
                        var propertyInfo = property;
                        var propertyType = property?.PropertyType;
                        propertyInfo.SetValue(itemT, Convert.ChangeType(propertyValue, propertyType));
                    }
                }
                restoreItem = itemT;
            }
            else
            {
                restoreItem = default;
            }
            return restoreItem;
        }
    }
}
