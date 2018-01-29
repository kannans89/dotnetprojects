//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FluentNHibernate.Mapping;
//using SCMProfitCore.Model.CustomerModule;

//namespace SCMProfitCore.MappingClass
//{
//    public class SubscriptionModuleMap: ClassMap<SubscriptionModule>
//    {
//        public SubscriptionModuleMap()
//        {
//            CompositeId().KeyReference(x => x.Subscription, "SubscriptionID")
//                      .KeyReference(x => x.Module, "ModuleID");
           
//        }
//    }
//}
