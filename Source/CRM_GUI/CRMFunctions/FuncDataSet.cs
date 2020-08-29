using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_GUI.CRMFunctions
{
    public class FuncDataSet
    {
        public static object GetItemGridLookUp(DataTable _Data, string _Value, string _FieldName)
        {
            foreach (DataRow dr in _Data.Rows)
            {
                if (dr[_FieldName].ToString() == _Value)
                    return _Value;
            }
            return null;
        }
    }
}
