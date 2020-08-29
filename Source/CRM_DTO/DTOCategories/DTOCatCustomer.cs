using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCategories
{
    public class DTOCatCustomer
    {
        public long ID { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public string IdentificationCard { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public DTOCatCustomerGroup CustGroup { get; set; }
        public DTOCatCustomerType CustType { get; set; }
        public long OrderBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdateBy { get; set; }
        public bool IsDelete { get; set; }

        public DTOCatCustomer()
        {
            this.ID = -1;
            this.CustCode = string.Empty;
            this.CustName = string.Empty;
            this.CustAddress = string.Empty;
            this.Phone = string.Empty;
            this.Notes = string.Empty;
            this.IdentificationCard = string.Empty;
            this.BirthDate = DateTime.MinValue;
            this.Gender = true;
            this.Email = string.Empty;
            this.CustGroup = new DTOCatCustomerGroup();
            this.CustType = new DTOCatCustomerType();
            this.OrderBy = -1;
            this.IsActive = true;
            this.UpdateDate = DateTime.MinValue;
            this.UpdateBy = -1;
            this.IsDelete = false;
        }

        public DTOCatCustomer(DTOCatCustomer _CatCustomer)
        {
            this.ID = _CatCustomer.ID;
            this.CustCode = _CatCustomer.CustCode;
            this.CustName = _CatCustomer.CustName;
            this.CustAddress = _CatCustomer.CustAddress;
            this.Phone = _CatCustomer.Phone;
            this.Notes = _CatCustomer.Notes;
            this.IdentificationCard = _CatCustomer.IdentificationCard;
            this.BirthDate = _CatCustomer.BirthDate;
            this.Gender = _CatCustomer.Gender;
            this.Email = _CatCustomer.Email;
            this.CustGroup = _CatCustomer.CustGroup;
            this.CustType = _CatCustomer.CustType;
            this.OrderBy = _CatCustomer.OrderBy;
            this.IsActive = _CatCustomer.IsActive;
            this.UpdateDate = _CatCustomer.UpdateDate;
            this.UpdateBy = _CatCustomer.UpdateBy;
            this.IsDelete = _CatCustomer.IsDelete;
        }

        public DTOCatCustomer(long _ID, string _CustCode, string _CustName, string _CustAddress, string _Phone, string _Notes, string _IdentificationCard, DateTime _BirthDate, bool _Gender, string _Email, DTOCatCustomerGroup _CustGroup, DTOCatCustomerType _CustType, long _OrderBy, bool _IsActive, DateTime _UpdateDate, long _UpdateBy, bool _IsDelete)
        {
            this.ID = _ID;
            this.CustCode = _CustCode;
            this.CustName = _CustName;
            this.CustAddress = _CustAddress;
            this.Phone = _Phone;
            this.Notes = _Notes;
            this.IdentificationCard = _IdentificationCard;
            this.BirthDate = _BirthDate;
            this.Gender = _Gender;
            this.Email = _Email;
            this.CustGroup = _CustGroup;
            this.CustType = _CustType;
            this.OrderBy = _OrderBy;
            this.IsActive = _IsActive;
            this.UpdateDate = _UpdateDate;
            this.UpdateBy = _UpdateBy;
            this.IsDelete = _IsDelete;
        }
    }
}
