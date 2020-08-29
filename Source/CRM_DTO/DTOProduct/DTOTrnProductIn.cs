using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOProduct
{
    public class DTOTrnProductIn
    {
        public long TrnID { get; set; }
        public string TrnCode { get; set; }
        public DateTime TrnDate { get; set; }
        public TimeSpan TrnTime { get; set; }
        public DTOCatStalls Stalls { get; set; }
        public string Notes { get; set; }
        public DTOCatEmployee Employee { get; set; }
        public string StatusCode { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }
        public List<DTOTrnProductInDT> LstTrnProductInDT { get; set; }

        public DTOTrnProductIn()
        {
            this.TrnID = -1;
            this.TrnCode = "{Tự động}";
            this.TrnDate = DateTime.MinValue;
            this.TrnTime = TimeSpan.MinValue;
            this.Stalls = new DTOCatStalls();
            this.Notes = string.Empty;
            this.Employee = new DTOCatEmployee();
            this.StatusCode = string.Empty;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
            this.LstTrnProductInDT = new List<DTOTrnProductInDT>();
        }

        public DTOTrnProductIn(DTOTrnProductIn _TrnProductIn)
        {
            this.TrnID = _TrnProductIn.TrnID;
            this.TrnCode = _TrnProductIn.TrnCode;
            this.TrnDate = _TrnProductIn.TrnDate;
            this.TrnTime = _TrnProductIn.TrnTime;
            this.Stalls = _TrnProductIn.Stalls;
            this.Notes = _TrnProductIn.Notes;
            this.Employee = _TrnProductIn.Employee;
            this.StatusCode = _TrnProductIn.StatusCode;
            this.UpdateDate = _TrnProductIn.UpdateDate;
            this.UpdateBy = _TrnProductIn.UpdateBy;
            this.IsDelete = _TrnProductIn.IsDelete;
            this.LstTrnProductInDT = _TrnProductIn.LstTrnProductInDT;
        }

        public DTOTrnProductIn(long _TrnID, string _TrnCode, DateTime _TrnDate, TimeSpan _TrnTime, DTOCatStalls _Stalls, string _Notes, DTOCatEmployee _Employee, string _StatusCode, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete, List<DTOTrnProductInDT> _LstTrnProductInDT)
        {
            this.TrnID = _TrnID;
            this.TrnCode = _TrnCode;
            this.TrnDate = _TrnDate;
            this.TrnTime = _TrnTime;
            this.Stalls = _Stalls;
            this.Notes = _Notes;
            this.Employee = _Employee;
            this.StatusCode = _StatusCode;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
            this.LstTrnProductInDT = _LstTrnProductInDT;
        }
    }
}
