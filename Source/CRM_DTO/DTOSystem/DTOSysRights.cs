using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOSystem
{
    public class DTOSysRights
    {
        public string MenuCode { get; set; }
        public DTOCatUserGroup Group { get; set; }
        public int AccessRights { get; set; }

        public DTOSysRights()
        {
            this.MenuCode = string.Empty;
            this.Group = new DTOCatUserGroup();
            this.AccessRights = -1;
        }
    }
}
