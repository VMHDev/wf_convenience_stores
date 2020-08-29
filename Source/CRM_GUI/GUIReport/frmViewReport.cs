using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CRM_GUI.GUIReport
{
    public partial class frmViewReport : Form
    {
        public ReportDocument Report = new ReportDocument();
        private int ZoomSize = 100;

        public frmViewReport()
        {
            InitializeComponent();
        }

        public frmViewReport(int _ZoomSize)
        {
            InitializeComponent();
            ZoomSize = _ZoomSize;
        }

        private void frmViewReport_Load(object sender, EventArgs e)
        {            
            crystalReportViewer.ReportSource = Report;
            //crystalReportViewer1.ParameterFieldInfo = pfs;
            crystalReportViewer.Zoom(ZoomSize);
            crystalReportViewer.Refresh();
        }

        private void crystalReportViewer_Resize(object sender, EventArgs e)
        {
            crystalReportViewer.Refresh();
        }
    }
}