using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWare.ClassInfo
{
    class WareInOut
    {
        private DateTime FDate;
        public DateTime dFDate
        {
            get { return FDate; }
            set { FDate = value; }
        }
        private string FWorknum;
        public string strFWorknum
        {
            get { return FWorknum; }
            set { FWorknum = value; }
        }
        private string FOperator;
        public string strFOperator
        {
            get { return FOperator; }
            set { FOperator = value; }
        }
        private string FWareID;
        public string strFWareID
        {
            get { return FWareID; }
            set { FWareID = value; }
        }
        private string FGoodsID;
        public string strFGoodsID
        {
            get { return FGoodsID; }
            set { FGoodsID = value; }
        }
        private string FGoodsName;
        public string strFGoodsName
        {
            get { return FGoodsName; }
            set { FGoodsName = value; }
        }
        private int FHGSL;
        public int dFHGSL
        {
            get { return FHGSL; }
            set { FHGSL = value; }
        }
        private int FPSSL;
        public int dFPSSL
        {
            get { return FPSSL; }
            set { FPSSL = value; }
        }
        private int FKLSL;
        public int dFKLSL
        {
            get { return FKLSL; }
            set { FKLSL = value; }
        }
        private int FKHSL;
        public int dFKHSL
        {
            get { return FKHSL; }
            set { FKHSL = value; }
        }
        private string FCarNO;
        public string strFCarNO
        {
            get { return FCarNO; }
            set { FCarNO = value; }
        }
        private int FTYPE;
        public int intFTYPE
        {
            get { return FTYPE; }
            set { FTYPE = value; }
        }
        private string FSerialNum;//流水号
        public string strFSerialNum
        {
            get { return FSerialNum; }
            set { FSerialNum = value; }
        }
        private string FModelno;//器型编号
        public string strFModelno
        {
            get { return FModelno; }
            set { FModelno = value; }
        }
        private string FItemID;//货号
        public string strFItemID
        {
            get { return FItemID; }
            set { FItemID = value; }
        }
        private string FMaterial;//材质
        public string strFMaterial
        {
            get { return FMaterial; }
            set { FMaterial = value; }
        }
        private string FimagePath;
        public string strFimagePath
        {
            get { return FimagePath; }
            set { FimagePath = value; }
        }
        private double FPSL;
        public double dFPSL
        {
            get { return FPSL; }
            set { FPSL = value; }
        }
        private string FInvoiceType;
        public string strFInvoiceType
        {
            get { return FInvoiceType; }
            set { FInvoiceType = value; }
        }
    }
}
