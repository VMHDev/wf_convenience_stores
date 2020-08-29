using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_DTO.CRMConfig;
using CRM_DTO.DTOSystem;

namespace CRM_DAL.CRMFunctions.Database
{
    public class FuncDatabaseExecute
    {
        public static DataSet ExecuteDatasetSP(string _StoreName, params object[] _Params)
        {
            return SqlHelper.ExecuteDataset(DTOAttributeSystem.objDatabase.Connection, _StoreName, _Params);
        }

        public static DataSet ExecuteDatasetSP(string _StoreName)
        {
            return SqlHelper.ExecuteDataset(DTOAttributeSystem.objDatabase.Connection, CommandType.Text, _StoreName);
        }

        public static int ExecuteNonQuerySP(string _StoreName, params object[] _Params)
        {
            return SqlHelper.ExecuteNonQuery(DTOAttributeSystem.objDatabase.Connection, _StoreName, _Params);
        }

        public static SqlDataReader ExecuteReaderSP(string _StoreName, params object[] _Params)
        {
            return SqlHelper.ExecuteReader(DTOAttributeSystem.objDatabase.Connection, _StoreName, _Params);
        }

        public static string ExecuteScalarSP(string _StoreName, params object[] _Params)
        {
            return SqlHelper.ExecuteScalar(DTOAttributeSystem.objDatabase.Connection, _StoreName, _Params).ToString();
        }

        public static DataSet LoadDataToDropDownList(params object[] _Params)
        {
            return SqlHelper.ExecuteDataset(DTOAttributeSystem.objDatabase.Connection, "LoadDataToDropDownList", _Params);
        }
    }
}
