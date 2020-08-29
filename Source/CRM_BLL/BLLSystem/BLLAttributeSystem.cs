using CRM_DAL.DALSystem;
using CRM_DTO.CRMConfig;
using CRM_DTO.CRMFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_BLL.BLLSystem
{
    public class BLLAttributeSystem
    {
        public static string[] AttributeSystem_GetInfoDatabase()
        {
            string[] sarrInfoDatabase = new string[0];
            try
            {
                sarrInfoDatabase = DALAttributeSystem.AttributeSystem_DatabaseGetInfo();
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return sarrInfoDatabase;
        }

        public static bool AttributeSystem_DatabaseConnect()
        {
            bool bResult = false;
            try
            {
                bResult = DALAttributeSystem.AttributeSystem_DatabaseConnect();
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return bResult;
        }

        public static bool AttributeSystem_TestConnect(clsDatabase _DatabaseInfo)
        {
            bool bResult = false;
            try
            {
                bResult = DALAttributeSystem.AttributeSystem_ConnectionTest(_DatabaseInfo);
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return bResult;
        }

        public static bool AttributeSystem_ConnectionSave(clsDatabase _DatabaseInfo)
        {
            bool bResult = false;
            try
            {
                bResult = DALAttributeSystem.AttributeSystem_ConnectionSave(_DatabaseInfo);
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return bResult;
        }

        public static string[] AttributeSystem_ConfigUserGetInfo()
        {
            string[] sarrInfoDatabase = new string[0];
            try
            {
                sarrInfoDatabase = DALAttributeSystem.AttributeSystem_ConfigUserGetInfo();
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return sarrInfoDatabase;
        }

        public static bool AttributeSystem_SkinSave(string _SkinName, string _PaintStyle)
        {
            bool bResult = false;
            try
            {
                bResult = DALAttributeSystem.AttributeSystem_SkinSave(_SkinName, _PaintStyle);
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return bResult;
        }

        public static string[] AttributeSystem_ConfigAttributeSystemGetInfo()
        {
            string[] sarrInfoDatabase = new string[0];
            try
            {
                sarrInfoDatabase = DALAttributeSystem.AttributeSystem_ConfigAttributeSystemGetInfo();
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return sarrInfoDatabase;
        }
    }
}
