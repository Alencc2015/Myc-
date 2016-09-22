using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWare.ClassInfo
{
    class curControl
    {
        // DLL调用注册
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr GetFocus();

        /// <summary>
        /// 当前拥有焦点的控件
        /// </summary>
        /// <param name="formControl"></param>
        /// <returns></returns>
        public static Control GetFocusedControl()
        {
            Control focusedControl = null;

            try
            {
                IntPtr focusedHandle = GetFocus();

                if (focusedHandle != IntPtr.Zero)
                {
                    focusedControl = Control.FromChildHandle(focusedHandle);
                }
            }
            catch { }

            return focusedControl;
        }
    }
}
