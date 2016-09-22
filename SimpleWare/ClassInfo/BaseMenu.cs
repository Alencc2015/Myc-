using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SimpleWare.ClassInfo
{
    public class BaseMenu
    {
        /// <summary>
        /// MenuId
        /// </summary>		
        private int _menuid;
        public int MenuId
        {
            get { return _menuid; }
            set { _menuid = value; }
        }
        /// <summary>
        /// SortId
        /// </summary>		
        private int _sortid;
        public int SortId
        {
            get { return _sortid; }
            set { _sortid = value; }
        }
        /// <summary>
        /// Name
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// DllName
        /// </summary>		
        private string _dllname;
        public string DllName
        {
            get { return _dllname; }
            set { _dllname = value; }
        }
        /// <summary>
        /// FunName
        /// </summary>		
        private string _funname;
        public string FunName
        {
            get { return _funname; }
            set { _funname = value; }
        }
        /// <summary>
        /// ModuleId
        /// </summary>		
        private int _moduleid;
        public int ModuleId
        {
            get { return _moduleid; }
            set { _moduleid = value; }
        }
        /// <summary>
        /// PMenuId
        /// </summary>		
        private int _pmenuid;
        public int PMenuId
        {
            get { return _pmenuid; }
            set { _pmenuid = value; }
        }
        /// <summary>
        /// MenuToolBar
        /// </summary>		
        private int _menutoolbar;
        public int MenuToolBar
        {
            get { return _menutoolbar; }
            set { _menutoolbar = value; }
        }
        /// <summary>
        /// MenuLookBar
        /// </summary>		
        private int _menulookbar;
        public int MenuLookBar
        {
            get { return _menulookbar; }
            set { _menulookbar = value; }
        }
        /// <summary>
        /// Memo
        /// </summary>		
        private string _memo;
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        /// <summary>
        /// Image
        /// </summary>		
        private string _image;
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        /// <summary>
        /// UrlId
        /// </summary>		
        private string _urlid;
        public string UrlId
        {
            get { return _urlid; }
            set { _urlid = value; }
        }
        /// <summary>
        /// UrlName
        /// </summary>		
        private string _urlname;
        public string UrlName
        {
            get { return _urlname; }
            set { _urlname = value; }
        }
        /// <summary>
        /// BindSQL
        /// </summary>		
        private string _bindsql;
        public string BindSQL
        {
            get { return _bindsql; }
            set { _bindsql = value; }
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
