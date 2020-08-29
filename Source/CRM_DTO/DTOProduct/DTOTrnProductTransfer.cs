using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOProduct
{
    public class DTOTrnProductTransfer
    {
        public long TrnID { get; set; }
        public string TrnCode { get; set; }
        public DateTime TrnDate { get; set; }
        public TimeSpan TrnTime { get; set; }
        public DTOCatStalls StallsFrom { get; set; }
        public DTOCatStalls StallsTo { get; set; }
        public string Notes { get; set; }
        public DTOCatEmployee Employee { get; set; }
        public string StatusCode { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }
        public List<DTOTrnProductTransferDT> LstTrnProductTransferDT { get; set; }

        public DTOTrnProductTransfer()
        {
            this.TrnID = -1;
            this.TrnCode = "{Tự động}";
            this.TrnDate = DateTime.MinValue;
            this.TrnTime = TimeSpan.MinValue;
            this.StallsFrom = new DTOCatStalls();
            this.StallsTo = new DTOCatStalls();
            this.Notes = string.Empty;
            this.Employee = new DTOCatEmployee();
            this.StatusCode = string.Empty;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
            this.LstTrnProductTransferDT = new List<DTOTrnProductTransferDT>();
        }

        public DTOTrnProductTransfer(DTOTrnProductTransfer _TrnProductTransfer)
        {
            this.TrnID = _TrnProductTransfer.TrnID;
            this.TrnCode = _TrnProductTransfer.TrnCode;
            this.TrnDate = _TrnProductTransfer.TrnDate;
            this.TrnTime = _TrnProductTransfer.TrnTime;
            this.StallsFrom = _TrnProductTransfer.StallsFrom;
            this.StallsTo = _TrnProductTransfer.StallsTo;
            this.Notes = _TrnProductTransfer.Notes;
            this.Employee = _TrnProductTransfer.Employee;
            this.StatusCode = _TrnProductTransfer.StatusCode;
            this.UpdateDate = _TrnProductTransfer.UpdateDate;
            this.UpdateBy = _TrnProductTransfer.UpdateBy;
            this.IsDelete = _TrnProductTransfer.IsDelete;
            this.LstTrnProductTransferDT = _TrnProductTransfer.LstTrnProductTransferDT;
        }

        public DTOTrnProductTransfer(long _TrnID, string _TrnCode, DateTime _TrnDate, TimeSpan _TrnTime, DTOCatStalls _StallsFrom, DTOCatStalls _StallsTo, string _Notes, DTOCatEmployee _Employee, string _StatusCode, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete, List<DTOTrnProductTransferDT> _TrnProductTransferDT)
        {
            this.TrnID = _TrnID;
            this.TrnCode = _TrnCode;
            this.TrnDate = _TrnDate;
            this.TrnTime = _TrnTime;
            this.StallsFrom = _StallsFrom;
            this.StallsTo = _StallsTo;
            this.Notes = _Notes;
            this.Employee = _Employee;
            this.StatusCode = _StatusCode;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
            this.LstTrnProductTransferDT = _TrnProductTransferDT;
        }
    }
}
