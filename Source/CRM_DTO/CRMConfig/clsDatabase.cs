using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CRM_DTO.CRMFunctions;
using System.Windows.Forms;

namespace CRM_DTO.CRMConfig
{
    public class clsDatabase
    {
        #region Attribute
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public SqlConnection Connection { get; set; }
        #endregion

        #region Constructor
        public clsDatabase()
        {
        }
        public clsDatabase(string _ServerName, string _DatabaseName, string _UserName, string _Password, SqlConnection _Connection)
        {
            this.ServerName = _ServerName;
            this.DatabaseName = _DatabaseName;
            this.UserName = _UserName;
            this.Password = _Password;
            this.Connection = _Connection;
        }
        public clsDatabase(clsDatabase _objDatabase)
        {
            this.ServerName = _objDatabase.ServerName;
            this.DatabaseName = _objDatabase.DatabaseName;
            this.UserName = _objDatabase.UserName;
            this.Password = _objDatabase.Password;
            this.Connection = _objDatabase.Connection;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy chuỗi kết nối database
        /// </summary>
        /// <returns>Chuỗi kết nối database</returns>
        private string GetConnectionString()
        {
            string sConnectionString = "";
            try
            {
                if (string.IsNullOrWhiteSpace(this.UserName) && string.IsNullOrWhiteSpace(this.Password))
                {
                    sConnectionString = "Data source = " + this.ServerName + "; Initial Catalog = " + this.DatabaseName + "; User ID= " + this.UserName + "; Password = " + this.Password + "; Trusted_Connection=True";
                }
                else
                {
                    sConnectionString = "Data source = " + this.ServerName + "; Initial Catalog = " + this.DatabaseName + "; Persist Security Info=True;User ID= " + this.UserName + "; Password = " + this.Password;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không lấy được chuỗi kết nối. Chi tiết: " + ex.Message);
            }
            return sConnectionString;
        }

        /// <summary>
        /// Kết nối cơ sở dữ liệu
        /// </summary>
        /// <param name="_Exception">Thông tin Exception</param>
        /// <returns>true: Kết nối thành công | false: Kết nối thất bại</returns>
        public bool ConnectDatabase(out Exception _Exception)
        {
            bool bResult = false;
            _Exception = null;
            if (Connection == null)
            {
                try
                {
                    string sConnectionString = this.GetConnectionString();
                    this.Connection = new SqlConnection(sConnectionString);
                    this.Connection.Open();
                    bResult = true;
                }
                catch (Exception ex)
                {
                    this.Connection.Dispose();
                    this.Connection = null;
                    _Exception = ex;
                    bResult = false;
                }
            }
            return bResult;
        }

        /// <summary>
        /// Ngắt kết nối cơ sở dữ liệu
        /// </summary>
        /// <returns>true: Ngắt kết nối thành công | false: Ngắt kết nối thất bại</returns>
        public bool DisconnectDatabase(out Exception _Exception)
        {
            try
            {
                _Exception = null;
                if (this.Connection == null)
                {
                    return true;
                }                
                this.Connection.Close();
                this.Connection.Dispose();
                this.Connection = null;
            }
            catch (Exception ex)
            {                
                _Exception = ex;
                return false;
            }
            return true;
        }
        #endregion
    }
}
