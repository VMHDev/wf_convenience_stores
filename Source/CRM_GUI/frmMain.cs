using CRM_BLL.BLLSystem;
using CRM_DTO.DTOSystem;
using CRM_GUI.CRMFunctions;
using CRM_GUI.CRMUtility.Messages;
using CRM_GUI.GUICategories;
using CRM_GUI.GUICounter;
using CRM_GUI.GUIProduct;
using CRM_GUI.GUIQuery;
using CRM_GUI.GUISystem;
using CRM_GUI.GUISystem.Database;
using CRM_GUI.GUISystem.User;
using CRM_GUI.GUITemplate;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRM_GUI
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        #region Form
        public frmMain()
        {
            InitializeComponent();
            DesignGUI();
            InitSkins();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadSkins(DTOAttributeSystem.SkinName, DTOAttributeSystem.SkinPaintStyle);
        }
        #endregion

        #region Design
        private void DesignGUI()
        {
            #region Form
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            #endregion

            #region Bar
            this.barTopToolbox.OptionsBar.AllowQuickCustomization = false;
            this.barTopToolbox.OptionsBar.DrawDragBorder = false;
            this.barTopToolbox.OptionsBar.MultiLine = true;
            this.barTopToolbox.OptionsBar.UseWholeRow = true;

            this.barTopMenu.OptionsBar.AllowQuickCustomization = false;
            this.barTopMenu.OptionsBar.DrawDragBorder = false;
            this.barTopMenu.OptionsBar.MultiLine = true;
            this.barTopMenu.OptionsBar.UseWholeRow = true;
            #endregion

            if (!DTOAttributeSystem.CurrentUser.IsAdmin)
            {
                DisposeMenuWithAccessRights();
            }
        }

        #region Skins
        private void InitSkins()
        {
            barManagerMain.ForceInitialize();
            BarButtonItem item;
            foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
            {
                item = new BarButtonItem(barManagerMain, "Giao diện: " + cnt.SkinName);
                item.Tag = "NotSecurity";
                item.ItemClick += new ItemClickEventHandler(EventClickSkins);
                mnuRootSkins.AddItem(item);
            }
        }

        private void EventClickSkins(object sender, ItemClickEventArgs e)
        {
            string skinName = e.Item.Caption.Replace("Giao diện: ", "");
            LoadSkins(skinName, "Skin");
            BLLAttributeSystem.AttributeSystem_SkinSave(skinName, "Skin");
            DTOAttributeSystem.SkinPaintStyle = "Skin";
            DTOAttributeSystem.SkinName = skinName;
        }

        public void LoadSkins(string _SkinName, string _PaintStyle)
        {
            FuncSkin.LoadSkins(_SkinName, _PaintStyle);
            if (_PaintStyle == "Skin")
            {
                barManagerMain.GetController().PaintStyleName = _PaintStyle;
            }
            else
            {
                barManagerMain.GetController().PaintStyleName = _SkinName;
                barManagerMain.GetController().ResetStyleDefaults();
            }
            mnuRootSkins.Caption = mnuRootSkins.Hint = "Giao diện: " + _SkinName;
        }
        #endregion
        #endregion

        #region Functions
        private void DisposeMenuWithAccessRights()
        {
            DataSet ds = new DataSet();
            string sMessage = string.Empty;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = BLLSysRights.SYS_RIGHTS_GetAccessRights(DTOAttributeSystem.CurrentUser.ID, out sMessage); 
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dtMenu = ds.Tables[0].Copy();
                    // Xử lý trên thanh menu
                    for (int i = 0; i < barManagerMain.Items.Count; i++)
                    {
                        if (barManagerMain.Items[i].GetType().Name == "BarSubItem" || barManagerMain.Items[i].GetType().Name == "BarButtonItem")
                        {
                            if (dtMenu.Select("MenuCode = '" + barManagerMain.Items[i].Name + "'").Length > 0 || barManagerMain.Items[i].Tag != null)
                            {
                                barManagerMain.Items[i].Enabled = true;
                            }
                            else
                            {
                                barManagerMain.Items[i].Enabled = false;
                            }
                        }
                    }

                    // Xử lý trên thanh ToolBar
                    for (int i = 0; i < barManagerMain.Items.Count; i++)
                    {
                        if (barManagerMain.Items[i].GetType().Name == "BarLargeButtonItem" && barManagerMain.Items[i].Tag != null)
                        {
                            if (!String.IsNullOrEmpty(barManagerMain.Items[i].Tag.ToString()) && barManagerMain.Items[barManagerMain.Items[i].Tag.ToString()] != null)
                            {
                                barManagerMain.Items[i].Enabled = barManagerMain.Items[barManagerMain.Items[i].Tag.ToString()].Enabled;
                            }
                        }
                    }
                }

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

        private void ProductInClick()
        {
            frmProductIn frm = new frmProductIn();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ProductOutClick()
        {
            frmProductOut frm = new frmProductOut();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ProductTransferClick()
        {
            frmProductTransfer frm = new frmProductTransfer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ProductSellClick()
        {
            this.Hide();
            frmProductSell frm = new frmProductSell();
            frm.ShowDialog();
            this.Close();
        }

        private void CounterOpenCloseClick()
        {
            frmCounterOpenClose frm = new frmCounterOpenClose();
            frm.ShowDialog();
        }

        private void CounterInOutClick()
        {
            frmCounterInOut frm = new frmCounterInOut();
            frm.MdiParent = this;
            frm.Show();
        }

        private void CounterTransferClick()
        {
            frmCounterTransfer frm = new frmCounterTransfer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void QueryInStockCounterClick()
        {
            frmQueryInStockCounter frm = new frmQueryInStockCounter();
            frm.ShowDialog();
        }

        private void QueryInfoProductClick()
        {
            frmQueryProduct frm = new frmQueryProduct();
            frm.MdiParent = this;
            frm.Show();
        }

        private void QueryTransactionClick()
        {
            frmQueryTransaction frm = new frmQueryTransaction();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AccessRightsClick()
        {
            frmAccessRights frm = new frmAccessRights();
            frm.ShowDialog();
        }

        private void AccountUpdateClick()
        {
            frmAccountUpdate frm = new frmAccountUpdate();
            frm.ShowDialog();
        }

        private void LoginClick()
        {
            Application.Restart();
        }
        #endregion

        #region Product
        private void mnuProductIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProductInClick();
        }

        private void mnuProductOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProductOutClick();
        }

        private void mnuProductTransfer_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProductTransferClick();
        }

        private void mnuProductSell_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProductSellClick();
        }

        private void mnuProductUpdateRate_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProductUpdateRate frm = new frmProductUpdateRate();
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion

        #region Counter
        private void mnuCounterOpenClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            CounterOpenCloseClick();
        }

        private void mnuCounterInOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            CounterInOutClick();
        }

        private void mnuCounterTransfer_ItemClick(object sender, ItemClickEventArgs e)
        {
            CounterTransferClick();
        }
        #endregion

        #region Query
        private void mnuQueryInStockCounter_ItemClick(object sender, ItemClickEventArgs e)
        {
            QueryInStockCounterClick();
        }

        private void mnuQueryInfoProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            QueryInfoProductClick();
        }

        private void mnuQueryTransaction_ItemClick(object sender, ItemClickEventArgs e)
        {
            QueryTransactionClick();
        }
        #endregion

        #region Categories
        private void mnuCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuCustomerType_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCustomerType frm = new frmCustomerType();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuCustomerGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCustomerGroup frm = new frmCustomerGroup();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuProductType_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuProductGroup_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuProductCat_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProductCat frm = new frmProductCat();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuShop_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuCounter_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCounter frm = new frmCounter();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuStalls_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuUser_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuUserGroup_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuSupplier_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuUnitSell_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuUnitWeight_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuUnitIn_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mnuCurrency_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion

        #region System
        private void mnuConfigDatabase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmConfigDatabase frm = new frmConfigDatabase();
            frm.ShowDialog();
        }

        private void mnuLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoginClick();
        }

        private void mnuPasswordChange_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPasswordChange frm = new frmPasswordChange();
            frm.ShowDialog();
        }
       
        private void mnuPasswordReset_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPasswordReset frm = new frmPasswordReset();
            frm.ShowDialog();
        }

        private void mnuAccountUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            AccountUpdateClick();
        }

        private void mnuAccountBlock_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAccountBlock frm = new frmAccountBlock();
            frm.ShowDialog();
        }

        private void mnuAccessRights_ItemClick(object sender, ItemClickEventArgs e)
        {
            AccessRightsClick();
        }

        private void mnuCustomerService_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion

        #region Toolbox
        private void btnBarProductIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProductInClick();
        }

        private void btnBarProductOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProductOutClick();
        }

        private void btnBarProductTransfer_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProductTransferClick();
        }

        private void btnBarProductSell_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProductSellClick();
        }

        private void btnBarCounterOpenClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            CounterOpenCloseClick();
        }

        private void btnBarCounterInOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            CounterInOutClick();
        }

        private void btnBarCounterTransfer_ItemClick(object sender, ItemClickEventArgs e)
        {
            CounterTransferClick();
        }

        private void btnBarQueryInStockCounter_ItemClick(object sender, ItemClickEventArgs e)
        {
            QueryInStockCounterClick();
        }

        private void btnBarQueryInfoProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            QueryInfoProductClick();
        }

        private void btnBarQueryTransaction_ItemClick(object sender, ItemClickEventArgs e)
        {
            QueryTransactionClick();
        }

        private void btnBarAccessRights_ItemClick(object sender, ItemClickEventArgs e)
        {
            AccessRightsClick();
        }

        private void btnBarAccountUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            AccountUpdateClick();
        }

        private void btnBarLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoginClick();
        }
        #endregion

        #region Test
        private void mnuLookUpEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTemplateLookUpEdit frm = new frmTemplateLookUpEdit();
            frm.ShowDialog();
        }
        #endregion
    }
}
