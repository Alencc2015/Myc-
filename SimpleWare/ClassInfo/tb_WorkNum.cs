using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWare.ClassInfo
{
    public class tb_WorkNum
    {
        private string WorkNumID;
        public string strWorkNumID
        {
            get { return WorkNumID; }
            set { WorkNumID = value; }
        }
        private string WorkNumName;
        public string strWorkNumName
        {
            get { return WorkNumName; }
            set { WorkNumName= value; }
        }
        private string remark;
        public string strremark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
