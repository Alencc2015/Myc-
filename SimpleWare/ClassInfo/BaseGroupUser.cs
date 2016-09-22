using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWare.ClassInfo
{
    class BaseGroupUser
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
        /// 用户编号
        /// </summary>		
        private int _userid;
        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
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
        /// 备注
        /// </summary>		
        private string _memo;
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
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
