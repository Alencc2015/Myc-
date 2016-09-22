using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWare.ClassInfo
{
    class tb_settings
    {
        /// <summary>
        /// id
        /// </summary>		
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// PicSaveStyle
        /// </summary>		
        private int _picsavestyle;
        public int PicSaveStyle
        {
            get { return _picsavestyle; }
            set { _picsavestyle = value; }
        }
        /// <summary>
        /// PicPath
        /// </summary>		
        private string _picpath;
        public string PicPath
        {
            get { return _picpath; }
            set { _picpath = value; }
        }
        private int isNeedRate;
        public int IsNeedRate
        {
            get { return isNeedRate; }
            set { isNeedRate = value; }
        } 
    }
}
