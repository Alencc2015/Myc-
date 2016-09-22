using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SimpleWare.BaseClass
{
    class WindowsUtil
    {
        static public string IP()
        {
            try
            {
                IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipa = ipe.AddressList[1];
                return ipa.ToString();
            }
            catch (Exception)
            {

                return "";
            }
            
        }
    }
}
