using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemLibrary.Model
{
    public class MainTask
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual PriorityType Priority { get; set; }

        public virtual List<SubTask> SubTasks { get; set; }
        public virtual User User { get; set; }

    }
}
