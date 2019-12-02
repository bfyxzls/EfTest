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
        /// <summary>
        /// 某个实体表是否存在自增键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <returns></returns>
        static bool IsHasIdentityKey<T>(DbContext context)
        {
            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;

            MetadataWorkspace metadataWorkspace =
     ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;
            var entityType = metadataWorkspace.GetItems<EntityType>(DataSpace.CSpace)
                .FirstOrDefault(i => i.Name == typeof(T).Name);
            var properties = entityType.Properties.Where(
                i => EdmMemberExtensions.StoreGeneratedPattern3(i) == StoreGeneratedPattern.Identity);
            return properties != null && properties.Any();

        }

        static void Main(string[] args)
        {
            DbContext context = (DbContext)new Database1Entities();

            Console.WriteLine("User是否自增" + IsHasIdentityKey<User>(context));

            Console.ReadKey();



        }
    }
}
