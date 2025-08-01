using System;
using System.Runtime.InteropServices; // Для AllocConsole
using System.Windows.Forms;

namespace Task_for_Information_Managment
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}