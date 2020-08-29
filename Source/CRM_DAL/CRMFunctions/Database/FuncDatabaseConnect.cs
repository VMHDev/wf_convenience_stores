using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CRM_DTO.CRMFunctions;

namespace CRM_DAL.CRMFunctions.Database
{
    public class FuncDatabaseConnect
    {
        public string ConnectionString { get; set; }

        public SqlConnection Connection { get; set; }

        public FuncDatabaseConnect()
        {
        }

        public string[] GetDatabaseInfo(string _PathFile)
        {
            if (!File.Exists(_PathFile))
            {
                throw new Exception("Không tìm thấy file cấu hình");
            }

            string sException;
            string[] retValue = new string[0];
            try
            {
                int count = 0;

                //Đọc dữ liệu từ file cấu hình
                XmlDocument xmlDoc;
                xmlDoc = new XmlDocument();
                xmlDoc.Load(_PathFile);
                XmlNode xmlnut = xmlDoc.SelectSingleNode("DATA");
                count = xmlnut.ChildNodes.Count;
                retValue = new string[count];
                retValue[0] = xmlnut.SelectSingleNode("SERVER").InnerText;
                retValue[1] = xmlnut.SelectSingleNode("DATABASE").InnerText;
                retValue[2] = xmlnut.SelectSingleNode("USER").InnerText;
                retValue[2] = FuncEncryption.DecryptText(xmlnut.SelectSingleNode("PASSWORD").InnerText, out sException);
                bool checkNullOrEmpty = true;
                foreach (string value in retValue)
                {
                    if (String.IsNullOrEmpty(value))
                    {
                        checkNullOrEmpty = false;
                        break;
                    }
                }
                if (!checkNullOrEmpty)
                {
                    return retValue;  
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File cấu hình không hợp lệ. Detail: " + ex.Message);
            }
            return retValue;        
        }

        public string GetConnectionString(string _PathFile)
        {
            string[] arrDatabaseInfo;
            string sConnectionString = "";
            try
            {
                arrDatabaseInfo = GetDatabaseInfo(_PathFile);
                if (string.IsNullOrWhiteSpace(arrDatabaseInfo[2]) && string.IsNullOrWhiteSpace(arrDatabaseInfo[3]))
                {
                    sConnectionString = "Data source = " + arrDatabaseInfo[0] + "; Initial Catalog = " + arrDatabaseInfo[1] + "; User ID= " + arrDatabaseInfo[2] + "; Password = " + arrDatabaseInfo[3] + "; Trusted_Connection=True";
                }
                else
                {
                    sConnectionString = "Data source = " + arrDatabaseInfo[0] + "; Initial Catalog = " + arrDatabaseInfo[1] + "; Persist Security Info=True;User ID= " + arrDatabaseInfo[2] + "; Password = " + arrDatabaseInfo[3];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không lấy được chuỗi kết nối. Detail: " + ex.Message);
            }
            return sConnectionString;           
        }

        public bool ConnectDatabase()
        {
            bool result = false;
            if (Connection == null)
            {
                try
                {
                    Connection = new SqlConnection(ConnectionString);
                    Connection.Open();
                    result = true;
                }
                catch
                {
                    Connection.Dispose();
                    Connection = null;
                    result = false;
                }
            }
            return result;
        }

        public bool DisconnectDatabase()
        {
            try
            {                
                Connection.Close();
                Connection.Dispose();
                Connection = null;
            }
            catch
            {
                return false;
                throw new Exception("Không đóng được kết nối cơ sở dữ liệu");
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra có kết nối CSDL được không?
        /// </summary>
        /// <param name="_ConnectString">Chuỗi kết nối</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        public bool TestConnection(string _ConnectString)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(_ConnectString);
                Conn.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }        
    }
}
