using CRM_DTO.CRMFunctions;
using CRM_GUI.GUIReport;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_GUI.CRMFunctions
{
    public class FuncReportGUI
    {
        public static void ShowReport(DataSet _ReportDataSet, string _ReportName, string _Parameters, string _Values, out string _Messages)
        {
            _Messages = string.Empty;
            string sReportPath = Application.StartupPath + "\\Reports\\" + _ReportName;
            if (!File.Exists(sReportPath))
            {
                _Messages = "Không tìm thấy đường dẫn " + sReportPath;
            }
            ReportDocument rpReport = FuncReport.fn_ShowReport(_ReportDataSet, sReportPath, _Parameters, _Values, out _Messages);
            frmViewReport frm = new frmViewReport(100);
            frm.WindowState = FormWindowState.Maximized;
            frm.Report = rpReport;
            frm.Show();
        }
    }
}
