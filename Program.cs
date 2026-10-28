using System;
using System.Windows.Forms;

namespace baitap12_10
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Dashboard());
        }
    }
}