using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_VisualComponents
{
    public partial class SelectionComponent : UserControl
    {
        public SelectionComponent()
        {
            InitializeComponent();
            comboBox.SelectedIndexChanged += (sender, e) =>
            {
                comboBoxSelectedElementChange?.Invoke(sender, e);
            };
        }
        public void ClearList()
        {
            comboBox.Items.Clear();
        }
      
        public string SelectedValue { 
            get => comboBox.SelectedItem == null ? string.Empty : comboBox.SelectedItem.ToString();
            set => comboBox.SelectedItem = value; }

        private event EventHandler comboBoxSelectedElementChange;

        public event EventHandler ComboBoxSelectedElementChange
        {
            add { comboBoxSelectedElementChange += value; }
            remove { comboBoxSelectedElementChange -= value; }
        }
        public void AddItem(string itemToAdd)
        {
            comboBox.Items.Add(itemToAdd);
        }
    }
}

