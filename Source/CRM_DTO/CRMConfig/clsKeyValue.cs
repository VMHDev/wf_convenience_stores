using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.CRMConfig
{
    public class clsKeyValue
    {
        public string ID { get; set; }
        public string Value { get; set; }

        public clsKeyValue(string _ID, string _Value)
        {
            ID = _ID;
            Value = _Value;
        }

        public override string ToString()
        {
            return this.ID != "" ? this.Value : "";
        }
    }
}
