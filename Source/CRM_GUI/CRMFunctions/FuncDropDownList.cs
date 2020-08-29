using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_DTO.CRMConfig;

namespace CRM_DTO.CRMFunctions
{
    public class FuncDropDownList
    {
        #region ComboBoxEdit
        public static int GetSelectedIndexCombo(string strID, ComboBoxEdit objCombo, int Method)
        {
            int i = 0, index = 0;

            if (Method == 0)
            {
                foreach (clsKeyValue item in objCombo.Properties.Items)
                {
                    if (item.ID == strID)
                    {
                        index = i;
                        break;
                    }
                    ++i;
                }
            }
            else
            {
                foreach (clsKeyValue item in objCombo.Properties.Items)
                {
                    if (item.Value == strID)
                    {
                        index = i;
                        break;
                    }
                    ++i;
                }
            }
            return index;
        }

        public static void BindDropDownList(ComboBoxEdit Ddl, object MyObject, string Text, string Value, string ItemSelected, bool OptNull)
        {
            Ddl.Properties.Items.Clear();
            DataTable dt = new DataTable();
            if (MyObject.GetType() == typeof(DataSet))
            {
                if (((DataSet)MyObject).Tables.Count > 0)
                    dt = ((DataSet)MyObject).Tables[0];
            }
            else if (MyObject.GetType() == typeof(DataTable))
            {
                dt = (DataTable)MyObject;
            }

            if (OptNull)
                Ddl.Properties.Items.Add(new clsKeyValue("", ""));

            List<clsKeyValue> lst = new List<clsKeyValue>();
            lst = (from DataRow row in dt.Rows
                   select new clsKeyValue(row[Value].ToString(), row[Text].ToString())).ToList();
            Ddl.Properties.Items.AddRange(lst);

            Ddl.SelectedIndex = GetSelectedIndexCombo(ItemSelected, Ddl, 0);

            dt.Dispose();
        }

        public static void BindDropDownList(ComboBoxEdit Ddl, object MyObject, string Text, string Value, string ItemSelected, bool OptNull, string NullText, string NullValue)
        {
            Ddl.Properties.Items.Clear();
            DataTable dt = new DataTable();
            if (MyObject.GetType() == typeof(DataSet))
            {
                if (((DataSet)MyObject).Tables.Count > 0)
                    dt = ((DataSet)MyObject).Tables[0];
            }
            else if (MyObject.GetType() == typeof(DataTable))
            {
                dt = (DataTable)MyObject;
            }

            if (OptNull)
                Ddl.Properties.Items.Add(new clsKeyValue(NullValue, NullText));

            foreach (DataRow row in dt.Rows)
            {
                Ddl.Properties.Items.Add(new clsKeyValue(row[Value].ToString(), row[Text].ToString()));
            }

            Ddl.SelectedIndex = GetSelectedIndexCombo(ItemSelected, Ddl, 0);

            dt.Dispose();
        }
        #endregion

        #region RepositoryItemComboBox
        public static void BindDropDownList(RepositoryItemComboBox Ddl, object MyObject, string Text, string Value, bool OptNull)
        {
            Ddl.Items.Clear();
            DataTable dt = new DataTable();
            if (MyObject.GetType() == typeof(DataSet))
            {
                if (((DataSet)MyObject).Tables.Count > 0)
                    dt = ((DataSet)MyObject).Tables[0];
            }
            else if (MyObject.GetType() == typeof(DataTable))
            {
                dt = (DataTable)MyObject;
            }

            if (OptNull)
                Ddl.Items.Add(new ImageComboBoxItem("", ""));

            foreach (DataRow row in dt.Rows)
            {
                Ddl.Items.Add(new ImageComboBoxItem(row[Text].ToString(), row[Value].ToString()));
            }

            dt.Dispose();
        }
        #endregion

        #region GridLookUpEdit
        /// <summary>
        /// Lấy dữ liệu của GridLookUpEdit
        /// </summary>
        /// <param name="_TableGrid">DataTable chứa datasource của GridLookUpEdit</param>
        /// <param name="_FieldID">Tên của trường dữ liệu ID</param>/// 
        /// <param name="_Value">Giá trị ID</param>
        /// <returns>Dữ liệu</returns>
        public static DataRow GetItemGridLookUp(DataTable _TableGrid, string _FieldID, object _Value)
        {
            foreach (DataRow dr in _TableGrid.Rows)
            {
                if (dr[_FieldID].Equals(_Value))
                {
                    return dr;
                }
            }
            return null;
        }

        /// <summary>
        /// Lấy dữ liệu của GridLookUpEdit
        /// </summary>
        /// <param name="_TableGrid">DataTable chứa datasource của GridLookUpEdit</param>
        /// <param name="_FieldID">Tên của trường dữ liệu ID</param>/// 
        /// <param name="_Value">Giá trị ID</param>
        /// <param name="_FieldName">Tên của trường dữ liệu muốn lấy dữ liệu</param>
        /// <returns>Dữ liệu</returns>
        public static object GetItemGridLookUp(DataTable _TableGrid, string _FieldID, object _Value, string _FieldName)
        {
            foreach (DataRow dr in _TableGrid.Rows)
            {
                if (dr[_FieldID].Equals(_Value))
                {
                    return dr[_FieldName];
                }                    
            }
            return null;
        }
        #endregion
    }
}
