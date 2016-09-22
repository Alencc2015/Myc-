using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWare.Menu;
using SimpleWare.SelPorcelain;
namespace SimpleWare
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            //Application.Run(new frmEmpMenu());
            //Application.Run(new frmModel());
            //Application.Run(new frmSelPorcelain());
        }
    }
}
