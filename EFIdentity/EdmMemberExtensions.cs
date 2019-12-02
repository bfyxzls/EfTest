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
        /// <summary>
        /// 扩展方法，它需要写在静态类里，使用时需要引用命名空间
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 普通方法
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static StoreGeneratedPattern StoreGeneratedPattern3(EdmMember @this)
        {
            return @this.StoreGeneratedPattern2();
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
