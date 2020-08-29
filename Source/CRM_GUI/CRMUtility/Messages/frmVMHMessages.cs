using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Timers;

namespace Messages
{
    public enum ListButton
    {
        Close, OkCancel, YesNo
    };

    public enum ICon
    {
        QuestionMark, Information, Error, Warning, None
    };
    public enum Result
    {
        Close, Ok, Cancel, Abort, Yes, No, Back, Next
    };

    public partial class frmVMHMessages : DevExpress.XtraEditors.XtraForm
    {
        private System.Timers.Timer aTimer;

        public frmVMHMessages()
        {
            InitializeComponent();
        }

        public frmVMHMessages(string Title, string Message, string OKButton, string CancelButton, ICon icon, bool bAutoClose = false, long Time = 1000)
        {
            InitializeComponent();
            this.Text = Title;
            btnOK.Text = OKButton;
            btnCancel.Text = CancelButton;
            lblMessage.Text = Message;

            if (OKButton == "")
            {
                btnOK.Dispose();
            }

            if (CancelButton == "")
            {
                btnCancel.Dispose();
                btnOK.Location = new System.Drawing.Point(203, 56);
            }

            SetIcon(icon);

            if (bAutoClose)
            {
                aTimer = new System.Timers.Timer(Time);
                aTimer.Enabled = true;
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            }
        }

        #region Functions
        private void SetIcon(ICon icon)
        {
            switch (icon)
            {
                case ICon.Information:
                    pictureBox.Image = imageCollection.Images[0];
                    break;
                case ICon.Error:
                    pictureBox.Image = imageCollection.Images[1];
                    break;
                case ICon.QuestionMark:
                    pictureBox.Image = imageCollection.Images[2];
                    break;
                case ICon.Warning:
                    pictureBox.Image = imageCollection.Images[3];
                    break;
                default:
                    pictureBox.Image = imageCollection.Images[0];
                    break;
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            aTimer.Dispose();
            btnOK_Click(null, null);
        }
        #endregion

        #region Button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}