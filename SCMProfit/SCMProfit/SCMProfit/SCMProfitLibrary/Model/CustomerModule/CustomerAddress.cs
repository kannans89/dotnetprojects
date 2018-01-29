using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMProfitCore.Model.CustomerModule
{
    public class CustomerAddress
    {
        public virtual Guid AddressId { get; set; }
        public virtual string AddressLine1 { set; get; }
        public virtual string AddressLine2 { set; get; }
        public virtual string City { set; get; }
        public virtual string State { set; get; }
        public virtual string ZipCode { set; get; }
        public virtual string Country { set; get; }

        public virtual Customer Customer { set; get; }
    }
}
