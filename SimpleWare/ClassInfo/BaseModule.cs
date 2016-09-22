using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWare.ClassInfo
{
    class BaseModule
    {
        /// <summary>
        /// 编号
        /// </summary>		
        private int _moduleid;
        public int ModuleId
        {
            get { return _moduleid; }
            set { _moduleid = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        private string _memo;
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>		
        private int _sortid;
        public int SortId
        {
            get { return _sortid; }
            set { _sortid = value; }
        }
        /// <summary>
        /// ServerIP
        /// </summary>		
        private string _serverip;
        public string ServerIP
        {
            get { return _serverip; }
            set { _serverip = value; }
        }
        /// <summary>
        /// WorkId
        /// </summary>		
        private int _workid;
        public int WorkId
        {
            get { return _workid; }
            set { _workid = value; }
        }  
    }
}
