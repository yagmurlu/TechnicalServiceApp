using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TechnicalServiceApp.Roles
{
    public class AdminRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            //using (var userContext = new Context())
            //{
            //    return userContext.Roles.Select(r => r.RoleName).ToArray();
            //}
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            //using (var userContext = new Context())
            //{
            //    var user = userContext.Roles.FirstOrDefault(u => u.RoleName == username);
            //    var userRoles = userContext.Roles.Select(r => r.RoleName);

            //    if (user == null)
            //        return new string[] { };
            //    return user.RoleName == null ? new string[] { } :
            //        userRoles.ToArray();
            //}
            // deneme 2
            Context c = new Context();
            var admin = c.Admins.FirstOrDefault(a => a.AdminMail == username);
            return new string[] { admin.Role.RoleName };

            // deneme 3

            //using (Context _Context = new Context())
            //{
            //    var userRoles = (from user in _Context.Users
            //                     join roleMapping in _Context.UserRoleMappings
            //                     on user.Id equals roleMapping.UserId
            //                     join role in _Context.Roles
            //                     on roleMapping.RoleId equals role.Id
            //                     where user.Username == username
            //                     select role.RoleName).ToArray();

            //    var adminRoles= (from user in _Context.Admins
            //            join roleMapping in _Context.UserRoleMappings
            //            on user.Id equals roleMapping.UserId
            //            join role in _Context.Roles
            //            on roleMapping.RoleId equals role.Id
            //            where user.Username == username
            //            select role.RoleName).ToArray();

            //    return userRoles && adminRoles;
            //}
           
        }
        
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            //using (var userContext = new Context())
            //{
            //    var user = userContext.Roles.FirstOrDefault(u => u.RoleName == username);
            //    var userRoles = userContext.Roles.Select(r => r.RoleName);

            //    if (user == null)
            //        return false;
            //    return user.RoleName != null &&
            //        userRoles.Any(r => r == roleName);
            //}
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}