using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFIdentity
{
    /// <summary>
    /// 获取自增的扩展方法
    /// </summary>
    public static class EdmMemberExtensions
    {
        public static StoreGeneratedPattern StoreGeneratedPattern2(this EdmMember @this)
        {
            const string name = "http://schemas.microsoft.com/ado/2009/02/edm/annotation:StoreGeneratedPattern";
            var metaDataProperty = @this.MetadataProperties.FirstOrDefault(m => m.Name == name);

            if (metaDataProperty == null)
            {
                return StoreGeneratedPattern.None;
            }

            return (StoreGeneratedPattern)Enum.Parse(typeof(StoreGeneratedPattern), (string)metaDataProperty.Value);
        }

        public static bool IsStoreGeneratedIdentity2(EdmMember @this)
        {
            return StoreGeneratedPattern2(@this) == StoreGeneratedPattern.Identity;
        }

        public static bool IsStoreGeneratedComputed2(EdmMember @this)
        {
            return StoreGeneratedPattern2(@this) == StoreGeneratedPattern.Computed;
        }
    }
}
