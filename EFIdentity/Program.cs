using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFIdentity
{
   
    class Program
    {
        static void Main(string[] args)
        {
            DbContext context = (DbContext)new Database1Entities();
            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;

            MetadataWorkspace metadataWorkspace =
     ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;
            ReadOnlyCollection<EdmType> edmTypes =
                metadataWorkspace.GetItems<EdmType>(DataSpace.OSpace);



            var entityTypes = metadataWorkspace.GetItems<EntityType>(DataSpace.CSpace);
            var properties = entityTypes.SelectMany(type => type.Properties);
            foreach (var item in properties)
            {
                Console.WriteLine(item.Name + "是否自增" + item.StoreGeneratedPattern2());
            }
            Console.ReadKey();



        }
    }
}
