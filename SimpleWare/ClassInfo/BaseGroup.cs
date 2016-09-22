using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWare.ClassInfo
{
    class BaseGroup
    {
        /// <summary>
        /// 编号
        /// </summary>		
        private int _groupid;
        public int GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
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
        /// 删除标记
        /// </summary>		
        private int _isStop;
        public int IsStop
        {
            get { return _isStop; }
            set { _isStop = value; }
        }
        /// <summary>
        /// 是否高级管理员
        /// </summary>		
        private int _admin;
        public int Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }
        /// <summary>
        /// Everyone
        /// </summary>		
        private int _everyone;
        public int Everyone
        {
            get { return _everyone; }
            set { _everyone = value; }
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
        /// 属性
        /// </summary>		
        private string _property;
        public string Property
        {
            get { return _property; }
            set { _property = value; }
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
