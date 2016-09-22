using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using System.Drawing;
namespace SimpleWare.BaseClass
{
    class MyGridTextBox:GridTextBoxXEditControl
    {
        public MyGridTextBox()
        {
            //if (!Convert.IsDBNull(Text) && Text != "" &&  Convert.ToDouble(Text) > 5)
            {
                BackColor = Color.Red;
            }
        }
    }
}
