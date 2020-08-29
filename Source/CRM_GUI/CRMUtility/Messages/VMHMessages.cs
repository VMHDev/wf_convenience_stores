using DevExpress.XtraEditors;
using Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_GUI.CRMUtility.Messages
{
    class VMHMessages
    {
        /// <summary>
        /// Hiện hộp thoại
        /// </summary>
        /// <param name="Title">Tiêu đề hộp thoại</param>
        /// <param name="Message">Nội dung</param>
        /// <param name="OKButton">Nút OK</param>
        /// <param name="CancelButton">Nút Hủy</param>
        /// <param name="icon">Icon</param>
        /// <returns>DialogResult.OK | DialogResult.Cancel</returns>
        public static DialogResult Show(string Title, string Message, string OKButton, string CancelButton, ICon icon)
        {
            frmVMHMessages frm = new frmVMHMessages(Title, Message, OKButton, CancelButton, icon);
            return frm.ShowDialog();
        }

        /// <summary>
        /// Hiện hộp thoại thông báo
        /// </summary>
        /// <param name="Message">Thông báo</param>
        /// <returns>DialogResult.OK</returns>
        public static DialogResult ShowInformation(string Message)
        {
            frmVMHMessages frm = new frmVMHMessages("Thông báo", Message, "OK", "", ICon.Information);
            return frm.ShowDialog();
        }

        /// <summary>
        /// Hiện hộp thoại thông báo không giới hạn text
        /// </summary>
        /// <param name="Message">Thông báo</param>
        public static void ShowInformationFull(string Message)
        {
            XtraMessageBox.Show(Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Hiện hộp thoại cảnh báo
        /// </summary>
        /// <param name="Message">Cảnh báo</param>
        /// <returns>DialogResult.OK</returns>
        public static DialogResult ShowWarning(string Message)
        {
            frmVMHMessages frm = new frmVMHMessages("Cảnh báo", Message, "OK", "", ICon.Warning);
            return frm.ShowDialog();
        }

        /// <summary>
        /// Hiện hộp thoại cảnh báo không giới hạn text
        /// </summary>
        /// <param name="Message">Cảnh báo</param>
        public static void ShowWarningFull(string Message)
        {
            XtraMessageBox.Show(Message, "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Hiện hộp thoại thông báo lỗi
        /// </summary>
        /// <param name="Message">Thông báo lỗi</param>
        /// <returns>DialogResult.OK</returns>
        public static DialogResult ShowError(string Message)
        {
            frmVMHMessages frm = new frmVMHMessages("Lỗi", Message, "OK", "", ICon.Error);
            return frm.ShowDialog();
        }

        /// <summary>
        /// Hiện hộp thoại thông báo lỗi không giới hạn text
        /// </summary>
        /// <param name="Message">Thông báo lỗi</param>
        public static void ShowErrorFull(string Message)
        {
            XtraMessageBox.Show(Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Hiện hộp thoại xác nhận
        /// </summary>
        /// <param name="Message">Thông báo</param>
        /// <returns>DialogResult.OK | DialogResult.Cancel</returns>
        /// Example: if (ThongBao.ShowConfirm("") == DialogResult.OK) {}
        public static DialogResult ShowConfirm(string Message)
        {
            frmVMHMessages frm = new frmVMHMessages("Xác nhận", Message, "Có", "Không", ICon.QuestionMark);
            return frm.ShowDialog();
        }

        /// <summary>
        /// Hiện hộp thoại xác nhận không giới hạn text
        /// </summary>
        /// <param name="Message">Thông báo</param>
        /// <param name="bShowCancel">true: Hiển thị nút Cancel | false: Không hiển thị nút Cancel</param>
        /// <returns>DialogResult.Yes | DialogResult.No | DialogResult.Cancel</returns>
        /// Example: if (ThongBao.ShowConfirmFull("") == DialogResult.Yes) {}
        public static DialogResult ShowConfirmFull(string Message, bool bShowCancel = false)
        {
            if (bShowCancel)
                return XtraMessageBox.Show(Message, "Xác Nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            else
                return XtraMessageBox.Show(Message, "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Hiển thị lỗi với ngoại lệ
        /// </summary>
        /// <param name="ex">Biến Exception</param>
        /// <param name="bWithoutWriteLog">True: Ghi log | False: Không ghi log</param>
        public static void ShowErrorException(Exception ex, bool bWriteLog = false)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                string sNameMethod = stackTrace.GetFrame(1).GetMethod().Name;
                string sNameFile = stackTrace.GetFrame(1).GetMethod().ReflectedType.Name;
                XtraMessageBox.Show("Lỗi hàm " + sNameFile + "." + sNameMethod + ": " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                VMHMessages.Show("Lỗi", "Lỗi hàm ThongBao.ShowErrorException: " + exc.Message, "OK", "", ICon.Error);
            }
        }

        /// <summary>
        /// Hiển thị lỗi với ngoại lệ tùy chỉnh text thông báo
        /// </summary>
        /// <param name="Message">Text thồng báo</param>
        /// <param name="ex">Biến Exception</param>
        /// <param name="bWriteLog"></param>
        public static void ShowErrorExceptionMessage(string Message, Exception ex, bool bWriteLog = false)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                string sNameMethod = stackTrace.GetFrame(1).GetMethod().Name;
                string sNameFile = stackTrace.GetFrame(1).GetMethod().ReflectedType.Name;
                XtraMessageBox.Show(Message + " Lỗi hàm " + sNameFile + "." + sNameMethod + ": " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                VMHMessages.Show("Lỗi", "Lỗi hàm ThongBao.ShowErrorExceptionMessage: " + exc.Message, "OK", "", ICon.Error);
            }
        }

        /// <summary>
        /// Hiện hộp thoại thông báo tự tắt
        /// </summary>
        /// <param name="Message">Thông báo</param>
        /// <param name="Time">Thời gian tự tắt</param>
        /// <returns>DialogResult.OK</returns>
        public static DialogResult ShowInformationAutoClose(string Message, long Time)
        {
            frmVMHMessages frm = new frmVMHMessages("Thông báo", Message, "OK", "", ICon.Information, true, Time);
            return frm.ShowDialog();
        }

        /// <summary>
        /// Hiện hộp thoại tự tắt
        /// </summary>
        /// <param name="Message">Nội dung</param>
        /// <param name="Time">Thời gian tự tắt</param>
        public static void ShowPopup(string Message, long Time)
        {
            frmVMHPopup frm = new frmVMHPopup(Message, Time);
            frm.ShowDialog();
        }
    }
}
