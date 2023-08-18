using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoApp.Models;

namespace ToDoApp
{
    public partial class ToDoDetailsForm : Form
    {
        private ToDoModel _selectedItem;
        public ToDoDetailsForm(ToDoModel selectedItem)
        {
            InitializeComponent();
            _selectedItem = selectedItem;

            label1.Text = _selectedItem.Title;
            richTextBox1.Text = _selectedItem.ToDoText;
        }
    }
}
