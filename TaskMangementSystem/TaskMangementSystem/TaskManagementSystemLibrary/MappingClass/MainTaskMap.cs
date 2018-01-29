using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystemLibrary.Model;

namespace TaskManagementSystemLibrary.MappingClass
{
    public class MainTaskMap : ClassMap<MainTask>
    {
        public MainTaskMap()
        {
            Id(m => m.Id).GeneratedBy.Identity();
            Map(m => m.Name);
            Map(m => m.Date);
            Map(m => m.StartTime);
            Map(m => m.EndTime);
            Map(m => m.Priority);

            HasMany<SubTask>(m => m.SubTasks).Inverse().KeyColumns.Add("MainTask_Id", m => m.Name("MainTask_Id"));
            References(m => m.User).Class<User>().Columns("User_Id");
        }

    }
}
