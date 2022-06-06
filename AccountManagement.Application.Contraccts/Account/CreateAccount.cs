using AccountManagement.Application.Contraccts.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contraccts.Account
{
    public class CreateAccount
    {
        
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Mobile { get; set; }
        public long RolId { get; set; }
        public string ProfilePhoto { get; set; }
        public List<RoleViewModel> Roles { get; set; }

    }

}
