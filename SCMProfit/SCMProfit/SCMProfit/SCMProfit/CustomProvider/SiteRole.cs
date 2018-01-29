using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfit.CustomProvider
{
    public class SiteRole : RoleProvider
    {
        private readonly IRepository<Customer> _customeRepository;

        public SiteRole()
        {
            _customeRepository =new CustomerDetailsRepository();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
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
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string userEmail)
        {
            var firstOrDefault = _customeRepository.Get().Where(x => x.Email == userEmail).FirstOrDefault();
            if (firstOrDefault != null)
            {
                string data = firstOrDefault.Role;
                string[] result = { data };
                return result;
            }
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
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