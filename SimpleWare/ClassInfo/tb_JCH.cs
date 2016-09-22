using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWare.ClassInfo
{
    public class tb_JCH
    {
        private DateTime JCDate;
        public DateTime dJCDate
        {
            get { return JCDate; }
            set { JCDate = value; }
        }
        private string JCWorknum;
        public string strJCWorknum
        {
            get { return JCWorknum; }
            set { JCWorknum = value; }
        }
        private string JCOperator;
        public string strJCOperator
        {
            get { return JCOperator; }
            set { JCOperator = value; }
        }
        private string JCWareID;
        public string strJCWareID
        {
            get { return JCWareID; }
            set { JCWareID = value; }
        }
        private string JCGoodsID;
        public string strJCGoodsID
        {
            get { return JCGoodsID; }
            set { JCGoodsID = value; }
        }
        private string JCGoodsName;
        public string strJCGoodsName
        {
            get { return JCGoodsName; }
            set { JCGoodsName = value; }
        }
        private int JCHGSL;
        public int dJCHGSL
        {
            get { return JCHGSL; }
            set { JCHGSL = value; }
        }
        private int JCPSSL;
        public int dJCPSSL
        {
            get { return JCPSSL; }
            set { JCPSSL = value; }
        }
        private int JCKLSL;
        public int dJCKLSL
        {
            get { return JCKLSL; }
            set { JCKLSL = value; }
        }
        private int JCKHSL;
        public int dJCKHSL
        {
            get { return JCKHSL; }
            set { JCKHSL = value; }
        }
        private string JCCarNO;
        public string strJCCarNO
        {
            get { return JCCarNO; }
            set { JCCarNO = value; }
        }
        private int JCTYPE;
        public int intJCTYPE
        {
            get { return JCTYPE; }
            set { JCTYPE = value; }
        }
        private string JCSerialNum;//流水号
        public string strJCSerialNum
        {
            get { return JCSerialNum; }
            set { JCSerialNum = value; }
        }
        private string JCModelno;//器型编号
        public string strJCModelno
        {
            get { return JCModelno; }
            set { JCModelno = value; }
        }
        private string JCItemID;//货号
        public string strJCItemID
        {
            get { return JCItemID; }
            set { JCItemID = value; }
        }
        private string JCMaterial;//材质
        public string strJCMaterial
        {
            get { return JCMaterial; }
            set { JCMaterial = value; }
        }
        private byte[] JCimage;
        public byte[] imJCimage
        {
            get { return JCimage; }
            set { JCimage = value; }
        }
        private string FImagePath;
        public string strFImagePath
        {
            get { return FImagePath; }
            set { FImagePath = value; }
        }
        private int FRYHGSL;
        public int dFRYHGSL
        {
            get { return FRYHGSL; }
            set { FRYHGSL = value; }
        }
        private double FHGL;
        public double dFHGL
        {
            get { return FHGL; }
            set { FHGL = value; }
        }
        private int FZYID;
        public int iFZYID
        {
            get { return FZYID; }
            set { FZYID = value; }
        }
        private int FPSSL;
        public int iFPSSL
        {
            get { return FPSSL; }
            set { FPSSL = value; }
        }
        private double FPSL;
        public double dFPSL
        {
            get { return FPSL; }
            set { FPSL = value; }
        }
        private string FKilnNo;
        public string strFKilnNo
        {
            get { return FKilnNo; }
            set { FKilnNo = value; }
        }
    }
}
