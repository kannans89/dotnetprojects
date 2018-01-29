using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMProfitCore.Model.CustomerModule;

namespace SCMProfitCore.Model.MasterModule
{
    public class Partner
    {
        public virtual Guid PartnerId { get; set; }
        public virtual string PartnerName { get; set; }

        public Partner()
        {
        }

        public Partner(Guid guid, string name)
            : this()
        {
            PartnerId = guid;
            PartnerName = name;
        }

        public static Partner Create(Guid guid, string name)
        {
            return new Partner(guid, name);
        }

    }
}
