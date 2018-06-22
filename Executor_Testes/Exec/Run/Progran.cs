using Executor_Testes.Exec.For;
using System;
using System.Windows.Forms;

namespace QA_Run
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}