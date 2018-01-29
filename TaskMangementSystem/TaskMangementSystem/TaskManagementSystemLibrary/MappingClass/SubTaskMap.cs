using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystemLibrary.Model;

namespace TaskManagementSystemLibrary.MappingClass
{
    public class SubTaskMap:ClassMap<SubTask>
    {
        public SubTaskMap()
        {
            Id(m => m.Id).GeneratedBy.Identity();
            Map(m => m.Name);
            Map(m => m.StartTime);
            Map(m => m.EndTime);
            References(m => m.MainTask).Class<MainTask>().Columns("MainTask_Id");
        }
    }
}
