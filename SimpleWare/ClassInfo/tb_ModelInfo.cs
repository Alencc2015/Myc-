using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWare.ClassInfo
{
    class tb_ModelInfo
    {
        private string ModelNo;
        public string strModelNo
        {
            get { return ModelNo; }
            set { ModelNo = value; }
        }
        private string ModelName;
        public string strModelName
        {
            get { return ModelName; }
            set { ModelName = value; }
        }
        private string FCreater;
        public string strFCreater
        {
            get { return FCreater; }
            set { FCreater = value; }
        }
        private string FModifier;
        public string strFModifier
        {
            get { return FModifier; }
            set { FModifier = value; }
        }
        private string FImagePath;
        public string strFImagePath
        {
            get { return FImagePath; }
            set { FImagePath = value; }
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

        private string FMaterialQty;
        public string strFMaterialQty
        {
            get { return FMaterialQty; }
            set { FMaterialQty = value; }
        }
        private DateTime FCreateDate;
        public DateTime dFCreateDate
        {
            get { return FCreateDate; }
            set { FCreateDate = value; }
        }
        private DateTime FModifydate;
        public DateTime dFModifydate
        {
            get { return FModifydate; }
            set { FModifydate = value; }
        }
        private int FIsStop;
        public int iFIsStop
        {
            get { return FIsStop; }
            set { FIsStop = value; }
        }
    }
}
