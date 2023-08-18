using ToDoApp.DB;

namespace ToDoApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
     

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            DBcontext dbContext = new DBcontext();

            Form1 form = new Form1(dbContext);

            Application.Run(form);
        }
    }
}