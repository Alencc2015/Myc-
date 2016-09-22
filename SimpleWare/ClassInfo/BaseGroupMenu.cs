using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWare.ClassInfo
{
    class BaseGroupMenu
    {
        /// <summary>
        /// 编号
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 组编号
        /// </summary>		
        private int _groupid;
        public int GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
        }
        /// <summary>
        /// 模块编号
        /// </summary>		
        private int _moduleid;
        public int ModuleId
        {
            get { return _moduleid; }
            set { _moduleid = value; }
        }
        /// <summary>
        /// 菜单编号
        /// </summary>		
        private int _menuid;
        public int MenuId
        {
            get { return _menuid; }
            set { _menuid = value; }
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
