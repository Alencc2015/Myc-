using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWare.ClassInfo
{
    public class tb_WareHouse
    {
        private string WareID;
        public string strWareID
        { 
            get { return WareID; }
            set { WareID = value; }
        }
        private string WareName;
        public string strWareName
        {
            get { return WareName; }
            set { WareName = value; }
        }
        private string Remark;
        public string strRemark
        {
            get { return Remark; }
            set { Remark = value; }
        }
    }
}
