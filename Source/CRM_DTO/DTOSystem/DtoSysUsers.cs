using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOSystem
{
    public class DTOSysUsers
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        public DTOSysUsers()
        {
            this.ID = int.MinValue;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsAdmin = false;
            this.IsActive = false;
        }

        public DTOSysUsers(DTOSysUsers _User)
        {
            this.ID = _User.ID;
            this.UserName = _User.UserName;
            this.Password = string.Empty;
            this.IsAdmin = _User.IsAdmin;
            this.IsActive = true;
        }

        public DTOSysUsers(long _ID, string _UserName, string _Password, bool _IsAdmin, bool _IsActive)
        {
            this.ID = _ID;
            this.UserName = _UserName;
            this.Password = _Password;
            this.IsAdmin = _IsAdmin;
            this.IsActive = _IsActive;
        }
    }
}
