using ToDoApp.DB;
using ToDoApp.Models;

namespace ToDoApp
{
    public partial class Form1 : Form
    {
        public readonly DBcontext dbcontext;
        public Form1(DBcontext dbContext)
        {
            _dbcontext = dbContext;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string toDoTitle = textBox1.Text;
            string toDoText = richTextBox1.Text;

            if (!string.IsNullOrWhiteSpace(toDoTitle) && !string.IsNullOrWhiteSpace(toDoText) && _dbcontext != null)
            {
                var newToDo = new ToDoModel {
                    Title = toDoTitle,
                    ToDoText = toDoText,
                };
              
                _dbcontext.ToDos.Add(newToDo);
                listBox1.Items.Add(newToDo);
                richTextBox1.Clear();
                textBox1.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for(int i = listBox1.Items.Count -1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i))
                {
                    ToDoModel todoToRemove = _dbcontext.ToDos[i];
                    _dbcontext.ToDos.Remove(todoToRemove);

                    listBox1.Items.RemoveAt(i);
                }
            }

            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                if (listBox2.GetSelected(i))
                {
                    ToDoModel todoToRemove = _dbcontext.ToDos[i];
                    _dbcontext.ToDos.Remove(todoToRemove);

                    listBox2.Items.RemoveAt(i);
                }
            }
        }

        private void Done_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i))
                {
                    ToDoModel selectedItem = (ToDoModel)listBox1.Items[i];
                    listBox1.Items.RemoveAt(i);

                    listBox2.Items.Add(selectedItem);
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                ToDoModel selectedItem = (ToDoModel)listBox1.SelectedItem;

                ToDoDetailsForm detailsForm = new ToDoDetailsForm(selectedItem);
                listBox1.ClearSelected();
                detailsForm.ShowDialog();
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                ToDoModel selectedItem = (ToDoModel)listBox2.SelectedItem;

                ToDoDetailsForm detailsForm = new ToDoDetailsForm(selectedItem);
                listBox2.ClearSelected();
                detailsForm.ShowDialog();
            }
        }
    }
}