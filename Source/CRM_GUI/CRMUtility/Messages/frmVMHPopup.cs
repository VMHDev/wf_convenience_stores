using System.Windows.Forms;
using System.Timers;

namespace Messages
{
    public partial class frmVMHPopup : DevExpress.XtraEditors.XtraForm
    {
        private System.Timers.Timer aTimer;

        public frmVMHPopup()
        {
            InitializeComponent();
        }

        public frmVMHPopup(string Message, long Time = 1000)
        {
            InitializeComponent();
            lblMessage.Text = Message;

            aTimer = new System.Timers.Timer(Time);
            aTimer.Enabled = true;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        #region Functions
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            aTimer.Dispose();
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}