using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.DB
{
    public class DBcontext
    {
        public List<ToDoModel> ToDos { get; set; }

        public DBcontext() => ToDos = new List<ToDoModel>();
    }
}
