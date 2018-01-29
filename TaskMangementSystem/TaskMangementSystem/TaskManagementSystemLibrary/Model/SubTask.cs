using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemLibrary.Model
{
    public class SubTask
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }

        public virtual MainTask MainTask { get; set; }
    }
}
