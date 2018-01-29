using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystemLibrary.Model;

namespace TaskManagementSystemLibrary.MappingClass
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(m=>m.Id).GeneratedBy.Identity();
            Map(m=>m.FirstName).Not.Nullable();
            Map(m => m.LastName).Not.Nullable();
            Map(m => m.MobileNumber);
            Map(m => m.Email).Not.Nullable();
            Map(m => m.UserName).Not.Nullable();
            Map(m => m.Password).Not.Nullable();

            HasMany<MainTask>(m => m.MainTasks).Inverse().KeyColumns.Add("User_Id",m=>m.Name("User_Id"));
        }
    }
}
