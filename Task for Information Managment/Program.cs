using System;
using System.Runtime.InteropServices; // Для AllocConsole
using System.Windows.Forms;

namespace Task_for_Information_Managment
{
    static class Program
    {
        // Импортируем функцию AllocConsole из kernel32.dll
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [STAThread]
        static void Main()
        {
            // Открываем консольное окно
            AllocConsole();

            // Создаем и вызываем подключение к БД
            DB db = new DB();
            Console.WriteLine("ehehehehhe");
            Console.WriteLine(db.GetConnectionString());

            // Запускаем форму
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}