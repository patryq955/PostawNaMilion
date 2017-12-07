using PostawNaMilionAzure.Models;
using PostawNaMilionAzure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Repository
{
    public class UsersRepository
    {
        public bool HasAccess(String login)
        {
            using (var db = new AzureContext())
                return (db.Users.Where(x => x.Login == login && x.IsAtive == true).FirstOrDefault() == null) ? true : false;
        }


        public List<UsersRoleView> GetUsersRole()
        {
            using (var db = new AzureContext())
            {
                var result =
                        db.Role.Join(db.Users,
                          role => role.Id,
                          users => users.RoleId,
                          (users, role) => new { users, role }
                           ).Select(m => new UsersRoleView
                           {
                               Id = m.users.Id,
                               RoleName = m.role.Name,
                               RoleId = m.role.Id
                           }).ToList();
                return result;
            }
        } 

    }
}