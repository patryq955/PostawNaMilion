using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.ViewModel
{
    public class UsersRoleView
    {
        public int Id { get; set; }
        public String Surname { get; set; }
        public String Name { get; set; }
        public String Login { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public int RoleId { get; set; }
        public bool IsAtive { get; set; }
        public String RoleName { get; set; }
    }
}