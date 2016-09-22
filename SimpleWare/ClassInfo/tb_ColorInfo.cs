using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWare.ClassInfo
{
    class tb_ColorInfo
    {
        private string ColorNo;
        public string strColorNo
        {
            get { return ColorNo; }
            set { ColorNo = value; }
        }
        private string ColorName;
        public string strColorName
        {
            get { return ColorName; }
            set { ColorName = value; }
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
        private string FColorSteps;
        public string strFColorSteps
        {
            get { return FColorSteps; }
            set { FColorSteps = value; }
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
