using CRM_DTO.CRMConfig;
using CRM_DTO.CRMFunctions;
using CRM_DTO.DTOSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CRM_DAL.DALSystem
{
    public class DALAttributeSystem
    {
        #region Config Database
        /// <summary>
        /// Lấy thông tin kết nối database
        /// </summary>
        /// <param name="_FileName">Đường dẫn file cấu hình</param>
        /// <returns>Thông tin kết nối</returns>
        private static string[] GetDatabaseInfo(string _FileName)
        {
            if (!FuncXML.IsXMLValid(_FileName))
            {
                return null;
            }
            string _Exception;
            string[] sarrResult = new string[0];
            try
            {
                int countNode = 0;
                string sPathFile = Application.StartupPath + "\\" + _FileName;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_FileName);
                // Note Root
                XmlNode xmlNodeRoot = xmlDoc.SelectSingleNode("DATA");
                // Kiểm tra file có node DATABASE
                if (xmlNodeRoot.SelectSingleNode("DATABASE") == null)
                {
                    throw new Exception("Không tìm thấy cấu hình cấu trúc XML database!");
                }
                // Lấy thông tin
                XmlNode xmlNodeChild = xmlNodeRoot.SelectSingleNode("DATABASE");
                countNode = xmlNodeChild.ChildNodes.Count;
                sarrResult = new string[countNode];
                sarrResult[0] = xmlNodeChild["SERVERNAME"] == null ? string.Empty : xmlNodeChild["SERVERNAME"].InnerText;
                sarrResult[1] = xmlNodeChild["DATABASENAME"] == null ? string.Empty : xmlNodeChild["DATABASENAME"].InnerText;
                sarrResult[2] = xmlNodeChild["USERNAME"] == null ? string.Empty : xmlNodeChild["USERNAME"].InnerText;
                sarrResult[2] = FuncEncryption.DecryptText(xmlNodeChild["PASSWORD"] == null ? string.Empty : xmlNodeChild["PASSWORD"].InnerText, out _Exception);

                // Kiểm tra các thông tin hợp lệ
                bool IsNullOrEmpty = true;
                foreach (string value in sarrResult)
                {
                    if (String.IsNullOrEmpty(value))
                    {
                        IsNullOrEmpty = false;
                        break;
                    }
                }
                if (!IsNullOrEmpty)
                {
                    return sarrResult;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File cấu hình không hợp lệ. Chi tiết: " + ex.Message);
            }
            return sarrResult;
        }

        /// <summary>
        /// Lấy chuỗi kết nối database
        /// </summary>
        /// <param name="_DatabaseInfo">Tên file cấu hình</param>
        /// <returns>Chuỗi kết nối database</returns>
        private static string GetConnectionString(clsDatabase _DatabaseInfo)
        {
            string sConnectionString = "";
            try
            {
                if (string.IsNullOrWhiteSpace(_DatabaseInfo.UserName) && string.IsNullOrWhiteSpace(_DatabaseInfo.Password))
                {
                    sConnectionString = "Data source = " + _DatabaseInfo.ServerName + "; Initial Catalog = " + _DatabaseInfo.DatabaseName + "; User ID= " + _DatabaseInfo.UserName + "; Password = " + _DatabaseInfo.Password + "; Trusted_Connection=True";
                }
                else
                {
                    sConnectionString = "Data source = " + _DatabaseInfo.ServerName + "; Initial Catalog = " + _DatabaseInfo.DatabaseName + "; Persist Security Info=True;User ID= " + _DatabaseInfo.UserName + "; Password = " + _DatabaseInfo.Password;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không lấy được chuỗi kết nối. Chi tiết: " + ex.Message);
            }
            return sConnectionString;
        }

        /// <summary>
        /// Lấy thông tin cấu hình database
        /// </summary>
        /// <returns>Thông tin cấu hình của user</returns>
        public static string[] AttributeSystem_DatabaseGetInfo()
        {        
            string[] sarrInfoDatabase = new string[0];
            try
            {
                sarrInfoDatabase = GetDatabaseInfo(DTOAttributeSystem.FileConfigName);
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return sarrInfoDatabase;
        }

        /// <summary>
        /// Kết nối cơ sở dữ liệu
        /// </summary>
        /// <returns>true: Kết nối thành công | false: Kết nối thất bại</returns>
        public static bool AttributeSystem_DatabaseConnect()
        {
            bool bSate = false;
            try
            {                
                Exception exException;
                string[] arrDatabaseInfo = GetDatabaseInfo(DTOAttributeSystem.FileConfigName);
                clsDatabase objDatabase = new clsDatabase(arrDatabaseInfo[0], arrDatabaseInfo[1], arrDatabaseInfo[2], arrDatabaseInfo[3], null);
                bSate = objDatabase.ConnectDatabase(out exException);
                if(bSate)
                {
                    DTOAttributeSystem.objDatabase = new clsDatabase(objDatabase);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return bSate;
        }

        /// <summary>
        /// Kiểm tra kết nối cơ sở dữ liệu
        /// </summary>
        /// <param name="_DatabaseInfo">Thông tin kết nối database</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static bool AttributeSystem_ConnectionTest(clsDatabase _DatabaseInfo)
        {
            bool bSate = false;
            try
            {
                Exception exException;
                bSate = _DatabaseInfo.ConnectDatabase(out exException);
                if (bSate)
                {
                    DTOAttributeSystem.objDatabase = new clsDatabase(_DatabaseInfo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return bSate;
        }

        /// <summary>
        /// Lưu thông tin kết nối cơ sở dữ liệu
        /// </summary>
        /// <param name="_DatabaseInfo">Thông tin kết nối database</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static bool AttributeSystem_ConnectionSave(clsDatabase _DatabaseInfo)
        {
            bool bResult = false;
            try
            {
                string sException;
                string sEncryptionPass = FuncEncryption.EncryptText(_DatabaseInfo.Password, out sException);
                XmlDocument XMLDoc = new XmlDocument();
                XMLDoc.Load(DTOAttributeSystem.FileConfigName);
                XMLDoc = FuncXML.UpdateNodeXMLValue(XMLDoc, "SERVERNAME", _DatabaseInfo.ServerName);
                XMLDoc = FuncXML.UpdateNodeXMLValue(XMLDoc, "DATABASENAME", _DatabaseInfo.DatabaseName);
                XMLDoc = FuncXML.UpdateNodeXMLValue(XMLDoc, "USERNAME", _DatabaseInfo.UserName);
                XMLDoc = FuncXML.UpdateNodeXMLValue(XMLDoc, "PASSWORD", _DatabaseInfo.Password);
                XMLDoc.Save(DTOAttributeSystem.FileConfigName);
                bResult = true;
            }
            catch (Exception ex)
            {
                bResult = false;
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return bResult;
        }
        #endregion

        #region Config User
        /// <summary>
        /// Lấy thông tin cấu hình của từng user
        /// </summary>
        /// <param name="_FileName">Đường dẫn file cấu hình</param>
        /// <returns>Thông tin kết nối</returns>
        private static string[] GetUserConfigInfo(string _FileName)
        {
            if (!FuncXML.IsXMLValid(_FileName))
            {
                return null;
            }
            string[] sarrResult = new string[0];
            try
            {
                string sPathFile = Application.StartupPath + "\\" + _FileName;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_FileName);
                // Note Root
                XmlNode xmlNodeRoot = xmlDoc.SelectSingleNode("DATA");
                // Kiểm tra file có node CONFIGUSER
                if (xmlNodeRoot.SelectSingleNode("CONFIGUSER") == null)
                {
                    throw new Exception("Không tìm thấy cấu hình cấu trúc XML database!");
                }
                // Lấy thông tin
                XmlNode xmlNodeChild = xmlNodeRoot.SelectSingleNode("CONFIGUSER");
                sarrResult = new string[3];
                sarrResult[0] = xmlNodeChild["USERLOGIN"] == null ? string.Empty : xmlNodeChild["USERLOGIN"].Attributes["UserName"].InnerText;
                sarrResult[1] = xmlNodeChild["SKININFO"] == null ? string.Empty : xmlNodeChild["SKININFO"].Attributes["SkinPaintStyle"].InnerText;
                sarrResult[2] = xmlNodeChild["SKININFO"] == null ? string.Empty : xmlNodeChild["SKININFO"].Attributes["SkinName"].InnerText;              
            }
            catch (Exception ex)
            {
                throw new Exception("File cấu hình không hợp lệ. Chi tiết: " + ex.Message);
            }
            return sarrResult;
        }

        /// <summary>
        /// Lấy thông tin cấu hình của user
        /// </summary>
        /// <returns>Thông tin cấu hình của user</returns>
        public static string[] AttributeSystem_ConfigUserGetInfo()
        {
            string[] sarrInfoConfigUser = new string[0];
            try
            {
                sarrInfoConfigUser = GetUserConfigInfo(DTOAttributeSystem.FileConfigName);
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return sarrInfoConfigUser;
        }

        /// <summary>
        /// Lưu thông tin skin
        /// </summary>
        /// <param name="_SkinName">Tên skin</param>
        /// <param name="_PaintStyle">Thông tin giao diện</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public static bool AttributeSystem_SkinSave(string _SkinName, string _PaintStyle)
        {
            bool bResult = false;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(DTOAttributeSystem.FileConfigName);
                XmlNode node = xmlDoc.SelectSingleNode("DATA").SelectSingleNode("CONFIGUSER").SelectSingleNode("SKININFO");
                node.Attributes["SkinPaintStyle"].Value = _PaintStyle;
                node.Attributes["SkinName"].Value = _SkinName;
                xmlDoc.Save(DTOAttributeSystem.FileConfigName);
                bResult = true;
            }
            catch (Exception ex)
            {
                bResult = false;
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return bResult;
        }
        #endregion

        #region Config Attributesystem
        /// <summary>
        /// Lấy thông tin cấu hình hệ thống
        /// </summary>
        /// <param name="_FileName">Đường dẫn file cấu hình</param>
        /// <returns>Thông tin kết nối</returns>
        private static string[] GetAttributesyStemConfigInfo(string _FileName)
        {
            if (!FuncXML.IsXMLValid(_FileName))
            {
                return null;
            }
            string[] sarrResult = new string[0];
            try
            {
                string sPathFile = Application.StartupPath + "\\" + _FileName;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_FileName);
                // Note Root
                XmlNode xmlNodeRoot = xmlDoc.SelectSingleNode("DATA");
                // Kiểm tra file có node ATTRIBUTESYSTEM
                if (xmlNodeRoot.SelectSingleNode("ATTRIBUTESYSTEM") == null)
                {
                    throw new Exception("Không tìm thấy cấu hình cấu trúc XML database!");
                }
                // Lấy thông tin
                XmlNode xmlNodeChild = xmlNodeRoot.SelectSingleNode("ATTRIBUTESYSTEM");
                sarrResult = new string[2];
                sarrResult[0] = xmlNodeChild["DEFAULTEMPID"] == null ? string.Empty : xmlNodeChild["DEFAULTEMPID"].InnerText;
                sarrResult[1] = xmlNodeChild["DEFAULTCUSTID"] == null ? string.Empty : xmlNodeChild["DEFAULTCUSTID"].InnerText;
            }
            catch (Exception ex)
            {
                throw new Exception("File cấu hình không hợp lệ. Chi tiết: " + ex.Message);
            }
            return sarrResult;
        }

        /// <summary>
        /// Lấy thông tin cấu hình của hệ thống
        /// </summary>
        /// <returns>Thông tin cấu hình của hệ thống</returns>
        public static string[] AttributeSystem_ConfigAttributeSystemGetInfo()
        {
            string[] sarrInfoConfigUser = new string[0];
            try
            {
                sarrInfoConfigUser = GetAttributesyStemConfigInfo(DTOAttributeSystem.FileConfigName);
            }
            catch (Exception ex)
            {
                throw new Exception(FuncException.GetDetailsException(ex));
            }
            return sarrInfoConfigUser;
        }
        #endregion
    }
}
