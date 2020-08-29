using CRM_DTO.DTOSystem;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_DTO.CRMFunctions
{
    public class FuncReport
    {
        public static ReportDocument fn_ShowReport(DataSet _ReportDataset, string _ReportPath, string _Parameters, string _Values, out string _Messages)
        {
            _Messages = string.Empty;
            ReportDocument Report = new ReportDocument();
            try
            {
                Report.Load(_ReportPath);

                #region Load MainReport + SubReport
                Report.SetDataSource(_ReportDataset.Tables[0]);
                for (int i = 0; i < Report.Subreports.Count; i++)
                {
                    Report.Subreports[i].SetDataSource(_ReportDataset.Tables[i + 1]);

                }
                #endregion

                #region Load System Parameters
                for (int i = 0; i < Report.ParameterFields.Count; i++)
                {
                    switch (Report.ParameterFields[i].Name.ToUpper())
                    {
                        case "NGUOILAP":
                            if (Report.ParameterFields[i].ReportName == "")
                            {
                                Report.SetParameterValue(Report.ParameterFields[i].Name, DTOAttributeSystem.CurrentEmployee.EmpName);
                            }
                            else
                            {
                                Report.SetParameterValue(Report.ParameterFields[i].Name, DTOAttributeSystem.CurrentEmployee.EmpName, Report.ParameterFields[i].ReportName);
                            }
                            break;
                        case "NGAYLAP":
                            if (Report.ParameterFields[i].ReportName == "")
                            {
                                Report.SetParameterValue(Report.ParameterFields[i].Name, DateTime.Now.ToString("dd/MM/yyyy"));
                            }
                            else
                            {
                                Report.SetParameterValue(Report.ParameterFields[i].Name, DateTime.Now.ToString("dd/MM/yyyy"), Report.ParameterFields[i].ReportName);
                            }
                            break;
                        case "SHOPNAME":
                            if (Report.ParameterFields[i].ReportName == "")
                            {
                                Report.SetParameterValue(Report.ParameterFields[i].Name, DTOAttributeSystem.CurrentShop.ShopName);
                            }
                            else
                            {
                                Report.SetParameterValue(Report.ParameterFields[i].Name, DTOAttributeSystem.CurrentShop.ShopName, Report.ParameterFields[i].ReportName);
                            }
                            break;
                        case "SHOPADDRESS":
                            if (Report.ParameterFields[i].ReportName == "")
                            {
                                Report.SetParameterValue(Report.ParameterFields[i].Name, DTOAttributeSystem.CurrentShop.ShopAddress);
                            }
                            else
                            {
                                Report.SetParameterValue(Report.ParameterFields[i].Name, DTOAttributeSystem.CurrentShop.ShopAddress, Report.ParameterFields[i].ReportName);
                            }
                            break;
                        case "SHOPTEL":
                            if (Report.ParameterFields[i].ReportName == "")
                            {
                                Report.SetParameterValue(Report.ParameterFields[i].Name, DTOAttributeSystem.CurrentShop.ShopTel);
                            }
                            else
                            {
                                Report.SetParameterValue(Report.ParameterFields[i].Name, DTOAttributeSystem.CurrentShop.ShopTel, Report.ParameterFields[i].ReportName);
                            }
                            break;
                        default:
                            break;
                    }
                }
                #endregion

                #region Load Customize Parameters
                if (_Parameters != "")
                {
                    // Xử lý các parameter khác    
                    string[] aParams = _Parameters.Split('@');
                    string[] aValues = _Values.Split('@');
                    for (int j = 0; j < aParams.Length; j++)
                    {
                        if (Report.ParameterFields[aParams[j]] != null)
                        {
                            Report.SetParameterValue(Report.ParameterFields[aParams[j]].Name, aValues[j].ToString());
                        }
                    }
                }
                #endregion                
            }
            catch (Exception ex)
            {
                _Messages = FuncException.GetDetailsException(ex);
            }
            return Report;
        }
    }
}
