using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWare.ClassInfo
{
    class tb_Base
    {
        private string FClass;
        public string strFClass
        {
            get { return FClass; }
            set { FClass = value; }
        }
        private string FBaseID;
        public string strFBaseID
        {
            get { return FBaseID; }
            set { FBaseID = value; }
        }
        private string FBaseName;
        public string strFBaseName
        {
            get { return FBaseName; }
            set { FBaseName = value; }
        }
        private string FRemark;
        public string strFRemark
        {
            get { return FRemark; }
            set { FRemark = value; }
        }
    }
}
