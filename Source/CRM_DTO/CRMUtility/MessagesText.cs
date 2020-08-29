using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.CRMUtility
{
    public static class MessagesText
    {
        #region Information
        /// <summary>Đăng nhập thành công</summary>
        public const string TextLoginSuccess = "Đăng nhập thành công";
        /// <summary>Thao tác thành công</summary>
        public const string TextHandlerSuccess = "Thao tác thành công!";
        /// <summary>
        /// Thao tác thành công
        /// </summary>
        /// <param name="_HandlerSuccess">Tên của thao tác</param>
        /// <returns>Thao tác thành công</returns>
        public static string HandlerSuccess(string _HandlerName)
        {
            return _HandlerName + " thành công!";
        }

        #endregion

        #region Error
        /// <summary>Thao tác thất bại</summary>
        public const string TextHandlerFailure = "Thao tác thất bại!";
        /// <summary> Không lấy được thông tin giao dịch!</summary>
        public const string TextGetTrnInfoFailure = "Không lấy được thông tin giao dịch!";
        /// <summary>
        /// Thao tác thất bại
        /// </summary>
        /// <param name="_HandlerName">Tên của thao tác</param>
        /// <returns>Thao tác thất bại</returns>
        public static string HandlerFailure(string _HandlerName)
        {
            return _HandlerName + " thất bại!";
        }
        /// <summary>
        /// Không lấy được thông tin giao dịch ...
        /// </summary>
        /// <param name="_TrnCode">ID giao dịch</param>
        /// <returns>Không lấy được thông tin giao dịch ...</returns>
        public static string GetTrnInfoFailure(string _TrnCode)
        {
            return "Không lấy được thông tin giao dịch " + _TrnCode;
        }
        #endregion

        #region Warning
        /// <summary>Truy xuất cơ sở dữ liệu thất bại!</summary>
        public const string TextExcuteProcedureFailure = "Truy xuất cơ sở dữ liệu thất bại!";
        /// <summary>Mật khẩu mới và mật khẩu nhập lại không khớp!</summary>
        public const string TextPasswordReenterNoneMatch = "Mật khẩu mới và mật khẩu nhập lại không khớp!";
        /// <summary>Không phát sinh được mã!</summary>
        public const string TextGenCodeFailure = "Không phát sinh được mã";
        /// <summary>Không có dữ liệu</summary>
        public const string TextNoData = "Không có dữ liệu";
        /// <summary>Vui lòng mở quầy thu ngân để tiếp tục thao tác!</summary>
        public const string TextNotOpenCounter = "Vui lòng mở quầy thu ngân để tiếp tục thao tác!";
        /// <summary>
        /// Trường dữ liệu không được để trống! Vui lòng nhập!
        /// </summary>
        /// <param name="_FieldName">Trường dữ liệu</param>
        /// <returns>Trường dữ liệu không được để trống! Vui lòng nhập!</returns>
        public static string FieldIsEmpty(string _FieldName)
        {
            return _FieldName + " không được để trống! Vui lòng nhập!";
        }
        #endregion
    }
}
