using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWare.ClassInfo
{
    public class tb_GoodsInfo
    {
        private string GoodsId;
        public string strGoodsId
        {
            get { return GoodsId;}
            set { GoodsId = value;  }
        }
        private string GoodsName;
        public string strGoodsName
        {
            get { return GoodsName; }
            set { GoodsName= value; }
        }
        private string ItemNO;
        public string strItemNO
        {
            get { return ItemNO; }
            set { ItemNO = value; }
        }
        private string ModelNO;
        public string strModelNO
        {
            get { return ModelNO; }
            set { ModelNO = value; }
        }
        private string GoodMaterial;
        public string strGoodMaterial
        {
            get { return GoodMaterial; }
            set { GoodMaterial= value; }
        }
        private byte[] fImage;
        public byte[] image
        {
            get { return fImage; }
            set { fImage = value; }
        }
        private string FCreater;
        public string strFCreater
        {
            get { return FCreater; }
            set { FCreater = value; }
        }
        private DateTime FCreateDate;
        public DateTime dFCreateDate
        {
            get { return FCreateDate; }
            set { FCreateDate = value; }
        }

        private string FModifier;
        public string strFModifier
        {
            get { return FModifier; }
            set { FModifier = value; }
        }
        private DateTime FModifydate;
        public DateTime dFModifydate
        {
            get { return FModifydate; }
            set { FModifydate = value; }
        }
        private Image fgoodimage;
        public Image goodimage
        {
            get { return fgoodimage; }
            set { fgoodimage = value; }
        }

        private string FImagePath;
        public string strFImagePath
        {
            get { return FImagePath; }
            set { FImagePath = value; }
        }

        private string FColor;
        public string strFColor
        {
            get { return FColor; }
            set { FColor = value; }
        }
        private string FTypeSteps1;
        public string strFTypeSteps1
        {
            get { return FTypeSteps1; }
            set { FTypeSteps1 = value; }
        }
        private string FTypeSteps2;
        public string strFTypeSteps2
        {
            get { return FTypeSteps2; }
            set { FTypeSteps2 = value; }
        }
        private string FTypeSteps3;
        public string strFTypeSteps3
        {
            get { return FTypeSteps3; }
            set { FTypeSteps3 = value; }
        }
        private string FColorSteps;
        public string strFColorSteps
        {
            get { return FColorSteps; }
            set { FColorSteps = value; }
        }
        private int FIsStop;

        public int iFIsStop
        {
            get { return FIsStop; }
            set { FIsStop = value; }
        }
    }
}
