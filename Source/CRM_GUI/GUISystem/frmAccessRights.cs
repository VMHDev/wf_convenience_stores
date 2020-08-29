using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using CRM_GUI.CRMUtility.Messages;
using CRM_BLL.BLLCategories;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using CRM_DTO.CRMConfig;
using CRM_BLL.BLLSystem;
using CRM_DTO.CRMUtility;

namespace CRM_GUI.GUISystem
{
    public partial class frmAccessRights : DevExpress.XtraEditors.XtraForm
    {
        #region Form
        public frmAccessRights()
        {
            InitializeComponent();
            DesignControls();
        }

        private void frmAccessRights_Load(object sender, EventArgs e)
        {
            LoadDataToDropDownList();
            LoadDataDefault();
            LoadDataToTreeView();            
        }
        #endregion

        #region DesignControls
        #region Declare Controls
        #region cboUserGroup
        public GridView grvCboUserGroup { get; set; }
        public GridColumn colCboGroupID { get; set; }
        public GridColumn colCboGroupCode { get; set; }
        public GridColumn colCboGroupName { get; set; }
        #endregion

        #region treeListAccessRights
        public TreeListColumn colMenuCode { get; set; }
        public TreeListColumn colGroupID { get; set; }
        public TreeListColumn colMenuDesc { get; set; }
        public TreeListColumn colMenuParent { get; set; }
        public TreeListColumn colAccessRights { get; set; }
        public TreeListColumn colCheckState { get; set; }
        public RepositoryItemCheckEdit rchkCheckState { get; set; }
        #endregion
        #endregion

        private void DesignControls()
        {
            #region Form
            this.Text = "Phân quyền người dùng";
            this.Load += new System.EventHandler(this.frmAccessRights_Load);
            this.StartPosition = FormStartPosition.CenterParent;
            #endregion

            DesignGridLookUpEdit();
            DesignTreeList();
        }

        private void DesignGridLookUpEdit()
        {
            #region cboUserGroup
            //
            // colCboGroupID
            //
            this.colCboGroupID = new GridColumn();
            this.colCboGroupID.Caption = "ID nhóm";
            this.colCboGroupID.FieldName = "GroupID";
            this.colCboGroupID.Name = "colCboGroupID";
            this.colCboGroupID.Visible = false;
            //this.colCboGroupID.VisibleIndex = -1;
            //
            // colCboGroupCode
            //
            this.colCboGroupCode = new GridColumn();
            this.colCboGroupCode.Caption = "Mã nhóm";
            this.colCboGroupCode.FieldName = "GroupCode";
            this.colCboGroupCode.Name = "colCboGroupCode";
            this.colCboGroupCode.Visible = true;
            this.colCboGroupCode.VisibleIndex = 0;
            //
            // colCboGroupName
            //
            this.colCboGroupName = new GridColumn();
            this.colCboGroupName.Caption = "Tên nhóm";
            this.colCboGroupName.FieldName = "GroupName";
            this.colCboGroupName.Name = "colCboGroupName";
            this.colCboGroupName.Visible = true;
            this.colCboGroupName.VisibleIndex = 1;
            // 
            // grvCboUserGroup
            // 
            this.grvCboUserGroup = new GridView();
            this.grvCboUserGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colCboGroupID,
                this.colCboGroupCode,
                this.colCboGroupName});
            this.grvCboUserGroup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboUserGroup.Name = "grvCboUserGroup";
            this.grvCboUserGroup.OptionsBehavior.Editable = false;
            this.grvCboUserGroup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboUserGroup.OptionsView.ShowAutoFilterRow = true;
            this.grvCboUserGroup.OptionsView.ShowGroupPanel = false;
            this.grvCboUserGroup.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUserGroup.Appearance.Row.Options.UseFont = true;
            this.grvCboUserGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.grvCboUserGroup.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCboUserGroup.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCboUserGroup.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvCboUserGroup.Appearance.HeaderPanel.Options.UseTextOptions = true;
            // 
            // cboUserGroup
            // 
            this.cboUserGroup.Name = "cboUserGroup";
            this.cboUserGroup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUserGroup.Properties.Appearance.Options.UseFont = true;
            this.cboUserGroup.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUserGroup.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboUserGroup.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUserGroup.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboUserGroup.Properties.AppearanceFocused.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUserGroup.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboUserGroup.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 12F);
            this.cboUserGroup.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cboUserGroup.Properties.NullText = "";
            this.cboUserGroup.Properties.ShowFooter = false;
            this.cboUserGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboUserGroup.Properties.PopupFormSize = new System.Drawing.Size(500, 0);
            this.cboUserGroup.Properties.View = this.grvCboUserGroup;
            this.cboUserGroup.EditValueChanged += new System.EventHandler(this.cboUserGroup_EditValueChanged);
            #endregion
        }
        
        private void DesignTreeList()
        {
            #region treeListAccessRights
            // 
            // rchkCheckState
            // 
            this.rchkCheckState = new RepositoryItemCheckEdit();
            this.rchkCheckState.AutoHeight = false;
            this.rchkCheckState.Name = "rchkCheckState";
            this.rchkCheckState.ValueChecked = "Checked";
            this.rchkCheckState.ValueUnchecked = "Unchecked";
            // 
            // colMenuCode
            // 
            this.colMenuCode = new TreeListColumn();
            this.colMenuCode.Caption = "Mã chức năng";
            this.colMenuCode.FieldName = "MenuCode";
            this.colMenuCode.Name = "colMenuCode";
            this.colMenuCode.Visible = false;
            this.colMenuCode.VisibleIndex = -1;
            // 
            // colGroupID
            // 
            this.colGroupID = new TreeListColumn();
            this.colGroupID.Caption = "Nhóm người dùng";
            this.colGroupID.FieldName = "GroupID";
            this.colGroupID.Name = "colGroupID";
            this.colGroupID.Visible = false;
            this.colGroupID.VisibleIndex = -1;
            // 
            // colMenuDesc
            // 
            this.colMenuDesc = new TreeListColumn();
            this.colMenuDesc.Caption = "Chức năng";
            this.colMenuDesc.FieldName = "MenuDesc";
            this.colMenuDesc.Name = "colMenuDesc";
            this.colMenuDesc.OptionsColumn.AllowEdit = false;
            this.colMenuDesc.OptionsColumn.AllowFocus = false;
            this.colMenuDesc.OptionsColumn.AllowMove = false;
            this.colMenuDesc.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colMenuDesc.Visible = true;
            this.colMenuDesc.VisibleIndex = 0;
            // 
            // colMenuParent
            // 
            this.colMenuParent = new TreeListColumn();
            this.colMenuParent.Caption = "Menu cha";
            this.colMenuParent.FieldName = "MenuParent";
            this.colMenuParent.Name = "colMenuParent";
            this.colMenuParent.Visible = false;
            this.colMenuParent.VisibleIndex = -1;
            // 
            // colAccessRights
            // 
            this.colAccessRights = new TreeListColumn();
            this.colAccessRights.Caption = "Menu cha";
            this.colAccessRights.FieldName = "AccessRights";
            this.colAccessRights.Name = "colAccessRights";
            this.colAccessRights.Visible = false;
            this.colAccessRights.VisibleIndex = -1;
            // 
            // colCheckState
            //             
            this.colCheckState = new TreeListColumn();
            this.colCheckState.Caption = "Quyền truy xuất";
            this.colCheckState.ColumnEdit = this.rchkCheckState;
            this.colCheckState.FieldName = "CheckState";
            this.colCheckState.Name = "colCheckState";
            this.colCheckState.Visible = true;
            this.colCheckState.VisibleIndex = 1;
            // 
            // treeListAccessRights
            // 
            this.treeListAccessRights.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.Empty.Options.UseFont = true;
            this.treeListAccessRights.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.EvenRow.Options.UseFont = true;
            this.treeListAccessRights.Appearance.FixedLine.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.FixedLine.Options.UseFont = true;
            this.treeListAccessRights.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.FocusedCell.Options.UseFont = true;
            this.treeListAccessRights.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.FocusedRow.Options.UseFont = true;
            this.treeListAccessRights.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.FooterPanel.Options.UseFont = true;
            this.treeListAccessRights.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.GroupButton.Options.UseFont = true;
            this.treeListAccessRights.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.GroupFooter.Options.UseFont = true;
            this.treeListAccessRights.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeListAccessRights.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treeListAccessRights.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.HorzLine.Options.UseFont = true;
            this.treeListAccessRights.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.OddRow.Options.UseFont = true;
            this.treeListAccessRights.Appearance.Preview.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.Preview.Options.UseFont = true;
            this.treeListAccessRights.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.Row.Options.UseFont = true;
            this.treeListAccessRights.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.SelectedRow.Options.UseFont = true;
            this.treeListAccessRights.Appearance.TreeLine.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.TreeLine.Options.UseFont = true;
            this.treeListAccessRights.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 12F);
            this.treeListAccessRights.Appearance.VertLine.Options.UseFont = true;
            this.treeListAccessRights.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colMenuCode,
            this.colMenuDesc,
            this.colCheckState});
            this.treeListAccessRights.KeyFieldName = "MenuCode";
            this.treeListAccessRights.Location = new System.Drawing.Point(5, 43);
            this.treeListAccessRights.Name = "treeListAccessRights";
            this.treeListAccessRights.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rchkCheckState});
            this.treeListAccessRights.RootValue = "";
            this.treeListAccessRights.ParentFieldName = "MenuParent";
            this.treeListAccessRights.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeListAccessRights_CellValueChanging);            
            #endregion
        }
        #endregion

        #region Function
        /// <summary>
        /// Khởi tạo datasource cho TreeList
        /// </summary>
        /// <returns>DataTable</returns>
        private DataTable fn_InitMenus()
        {
            DataTable table = new DataTable("MENU");
            table.Columns.Add("MenuCode", typeof(string));
            table.Columns.Add("GroupID", typeof(long));
            table.Columns.Add("MenuDesc", typeof(string));
            table.Columns.Add("MenuParent", typeof(string));
            table.Columns.Add("AccessRights", typeof(int));
            table.Columns.Add("CheckState", typeof(string));
            return table;
        }

        /// <summary>
        /// Load dữ liệu lên DropDownList
        /// </summary>
        private void LoadDataToDropDownList()
        {
            DataSet ds = new DataSet();
            string sMessages;
            try
            {
                ds = BLLCatUserGroup.LoadDataCombobox(out sMessages);
                if (string.IsNullOrWhiteSpace(sMessages))
                {
                    cboUserGroup.Properties.DataSource = ds.Tables[0].Copy();
                    cboUserGroup.Properties.DisplayMember = "GroupName";
                    cboUserGroup.Properties.ValueMember = "GroupID";
                    ds.Clear();
                }
                else
                {
                    VMHMessages.ShowWarning(sMessages);
                }
                ds.Clear();                
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
            }
        }

        /// <summary>
        /// Load dữ liệu lên cây menu
        /// </summary>
        private void LoadDataToTreeView()
        {            
            long lGroupID = cboUserGroup.EditValue == null ? -1 : Convert.ToInt64(cboUserGroup.EditValue);
            
            DataSet ds = new DataSet();
            string sMessage = string.Empty;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = BLLSysMenus.SYS_MENUS_GetAccessRights(lGroupID, out sMessage);
                treeListAccessRights.DataSource = ds.Tables[0].Copy();
                treeListAccessRights.CollapseAll();
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Load dữ liệu mặc định
        /// </summary>
        private void LoadDataDefault()
        {
            cboUserGroup.EditValue = cboUserGroup.Properties.GetKeyValue(1);
            treeListAccessRights.DataSource = fn_InitMenus();
        }

        /// <summary>
        /// Lấy danh sách các node con (Kể cả con của con)
        /// Các node lúc này sẽ có Checked = true
        /// </summary>
        /// <param name="_Node">Node muốn lấy</param>
        private void SelectChildNodes(TreeListNode _Node)
        {
            _Node.Checked = true;
            foreach (TreeListNode childNode in _Node.Nodes)
            {
                if (childNode.HasChildren)
                {
                    childNode.CheckAll();
                }
                else
                {
                    childNode.Checked = true;
                }
            }
        }

        /// <summary>
        /// Thiết lập trạng thái node cha
        /// </summary>
        /// <param name="_Node">Node cần thiết lập</param>
        /// <param name="_CheckState">Trạng thái</param>
        private void SetCheckedParentNodes(TreeListNode _Node, CheckState _CheckState)
        {
            try
            {
                if (_Node.ParentNode != null)
                {
                    bool bSetParent = false;
                    for (int i = 0; i < _Node.ParentNode.Nodes.Count; i++)
                    {
                        if (_CheckState.ToString() != _Node.ParentNode.Nodes[i]["CheckState"].ToString())
                        {
                            bSetParent = !bSetParent;
                            break;
                        }
                    }
                    _Node.ParentNode["CheckState"] = bSetParent ? CheckState.Indeterminate : _CheckState;
                    SetCheckedParentNodes(_Node.ParentNode, _CheckState);
                }
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
        }

        /// <summary>
        /// Thiết lập trạng thái các node
        /// </summary>
        private void SetCheckedNode()
        {
            treeListAccessRights.BeginUpdate();
            try
            {
                CheckState csCheck = CheckState.Unchecked;
                TreeListNode tlnNode = treeListAccessRights.FocusedNode;
                string sValue = tlnNode.GetValue("CheckState").ToString();
                switch (sValue)
                {
                    case "Unchecked":
                        csCheck = CheckState.Unchecked;
                        break;
                    case "Checked":
                        csCheck = CheckState.Checked;
                        break;
                    default:
                        csCheck = CheckState.Indeterminate;
                        break;
                }

                if (csCheck == CheckState.Indeterminate || csCheck == CheckState.Unchecked)
                {
                    csCheck = CheckState.Checked;
                }
                else
                {
                    csCheck = CheckState.Unchecked;
                }

                // Thiết lập trạng thái các node con
                SelectChildNodes(tlnNode);
                List<TreeListNode> lstAllNodes = treeListAccessRights.GetNodeList();
                foreach (TreeListNode item in lstAllNodes)
                {
                    if (item.Checked)
                    {
                        item.SetValue(colCheckState, csCheck);
                    }
                }
                tlnNode.UncheckAll();

                // Thiết lập trạng thái các node cha
                SetCheckedParentNodes(tlnNode, csCheck);
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            finally
            {
                treeListAccessRights.EndUpdate();
            }
        }

        /// <summary>
        /// Cập nhật phân quyền trước khi lưu
        /// </summary>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool UpdateAccessRightsBeforeSave()
        {
            bool bResult = true;
            try
            {
                List<TreeListNode> lstAllNodes = treeListAccessRights.GetNodeList();
                foreach (TreeListNode item in lstAllNodes)
                {
                    string sCheckState = item.GetValue(colCheckState) == DBNull.Value ? string.Empty : item.GetValue(colCheckState).ToString();
                    if (sCheckState == "Checked")
                    {
                        item.SetValue(colAccessRights, 1);
                    }
                    else if (sCheckState == "Unchecked")
                    {
                        item.SetValue(colAccessRights, 0);
                    }
                    else
                    {
                        item.SetValue(colAccessRights, 2);
                    }
                }
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
                bResult = false;
            }
            return bResult;
        }

        /// <summary>
        /// Lưu
        /// </summary>
        /// <param name="_Message">Thông báo</param>
        /// <returns>true: Thành công | false: Thất bại</returns>
        private bool SaveClick(out string _Message)
        {
            _Message = string.Empty;
            DataSet ds = new DataSet();
            bool bResult = false;
            try
            {
                if(!UpdateAccessRightsBeforeSave())
                {
                    return false;
                }

                DataTable dtTempMenus = new DataTable("MENU");
                dtTempMenus = (DataTable)treeListAccessRights.DataSource;
                dtTempMenus.TableName = "MENU";
                ds.Tables.Add(dtTempMenus);
                string inputXML = ds.GetXml();

                bResult = BLLSysRights.SYS_RIGHTS_UpdAccessRights(inputXML, out _Message);
            }
            catch (Exception ex)
            {
                VMHMessages.ShowErrorException(ex);
            }
            finally
            {
                ds.Dispose();
            }
            return bResult;
        }
        #endregion

        #region Combobox
        private void cboUserGroup_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            if (SaveClick(out sMessage))
            {
                VMHMessages.ShowInformation(MessagesText.HandlerSuccess(this.Text));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    VMHMessages.ShowWarning(sMessage);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataToTreeView();
        }
        #endregion

        #region TreeList
        private void treeListAccessRights_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            SetCheckedNode();
        }
        #endregion
    }
}