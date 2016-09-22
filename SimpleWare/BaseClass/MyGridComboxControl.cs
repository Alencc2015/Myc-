using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;
using System.Data;
namespace SimpleWare.BaseClass
{
    class MyGridComboxControl : GridComboBoxExEditControl
    {
        public MyGridComboxControl()
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select FBaseID,FBaseName from tb_base where FClass =  'worknum' order by FBaseID";
            ds = dbl.GetDatasetReport(sql, "tb_base");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataSource = ds.Tables[0];
                    DisplayMember = "FBaseName";
                    ValueMember = "FBaseID";
                }

            }
        }

    }
    class MaterialComboxControl : GridComboBoxExEditControl
    {
        public MaterialComboxControl()
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select FBaseID,FBaseName from tb_base where FClass =  'material' order by FBaseID";
            ds = dbl.GetDatasetReport(sql, "tb_base");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataSource = ds.Tables[0];
                    DisplayMember = "FBaseName";
                    ValueMember = "FBaseID";
                }

            }
        }

    }
    class WareComboxControl : GridComboBoxExEditControl
    {
        public WareComboxControl()
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select WareID,WareName from tb_WareHouse order by WareID";
            ds = dbl.GetDatasetReport(sql, "tb_base");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataSource = ds.Tables[0];
                    DisplayMember = "WareName";
                    ValueMember = "WareID";
                }

            }
        }

    }
    class KilnNoComboxControl : GridComboBoxExEditControl
    {
        public KilnNoComboxControl()
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select FBaseID,FBaseName from tb_base where FClass =  'KilnNO' order by FBaseID";
            ds = dbl.GetDatasetReport(sql, "tb_base");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataSource = ds.Tables[0];
                    DisplayMember = "FBaseName";
                    ValueMember = "FBaseID";
                }

            }
        }

    }
    class RoleComboxControl : GridComboBoxExEditControl
    {
        public RoleComboxControl()
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select FBaseID,FBaseName from tb_base where FClass =  'Role' order by FBaseID";
            ds = dbl.GetDatasetReport(sql, "tb_base");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataSource = ds.Tables[0];
                    DisplayMember = "FBaseName";
                    ValueMember = "FBaseID";
                }

            }
        }

    }
    class BaseGroupComboxControl : GridComboBoxExEditControl
    {
        public BaseGroupComboxControl()
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select Groupid,Name from BaseGroup where isstop = 0 order by Groupid";
            ds = dbl.GetDatasetReport(sql, "BaseGroup");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataSource = ds.Tables[0];
                    DisplayMember = "Name";
                    ValueMember = "Groupid";
                }

            }
        }

    }
    class InvoiceTypeComboxControl : GridComboBoxExEditControl
    {
        public InvoiceTypeComboxControl()
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select FBaseID,FBaseName from tb_base where FClass =  'InvoiceType' order by FBaseID";
            ds = dbl.GetDatasetReport(sql, "tb_base");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataSource = ds.Tables[0];
                    DisplayMember = "FBaseName";
                    ValueMember = "FBaseID";
                }

            }
        }

    }
    class InvoiceTypeInComboxControl : GridComboBoxExEditControl
    {
        public InvoiceTypeInComboxControl()
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select FBaseID,FBaseName from tb_base where FClass =  'InvoiceTypeIn' order by FBaseID";
            ds = dbl.GetDatasetReport(sql, "tb_base");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataSource = ds.Tables[0];
                    DisplayMember = "FBaseName";
                    ValueMember = "FBaseID";
                }

            }
        }

    }
    class TypeStepComboxControl : GridComboBoxExEditControl
    {
        public TypeStepComboxControl()
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select FBaseID,FBaseName from tb_base where FClass =  'TypeStep' order by FBaseID";
            ds = dbl.GetDatasetReport(sql, "tb_base");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataSource = ds.Tables[0];
                    DisplayMember = "FBaseName";
                    ValueMember = "FBaseID";
                }

            }
        }

    }
    class ProdlineComboxControl : GridComboBoxExEditControl
    {
        public ProdlineComboxControl()
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select FBaseID,FBaseName from tb_base where FClass =  'ProdLine' order by FBaseID";
            ds = dbl.GetDatasetReport(sql, "tb_base");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataSource = ds.Tables[0];
                    DisplayMember = "FBaseName";
                    ValueMember = "FBaseID";
                }

            }
        }

    }
    class ModelNoComboxControl : GridComboBoxExEditControl
    {
        public ModelNoComboxControl()
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select ModelNo,ModelName from tb_modelinfo where fisstop = 0  order by ModelNo";
            ds = dbl.GetDatasetReport(sql, "tb_base");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataSource = ds.Tables[0];
                    DisplayMember = "ModelName";
                    ValueMember = "ModelNo";
                }

            }
        }

    }
    class ColorComboxControl : GridComboBoxExEditControl
    {
        public ColorComboxControl()
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select ColorNo,ColorName from tb_ColorInfo where fisstop = 0  order by ColorNo";
            ds = dbl.GetDatasetReport(sql, "tb_base");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    DataSource = ds.Tables[0];
                    DisplayMember = "ColorName";
                    ValueMember = "ColorNo";
                }

            }
        }

    }
}
