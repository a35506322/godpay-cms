using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GodPay_CMS.Common.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// 取得[Description]屬性
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(this T value) where T : Enum
        {
            // 取得value欄位屬性
            FieldInfo filedInfo = value.GetType().GetField(value.ToString());
            // GetCustomAttributes可以取得需要什麼樣的屬性標籤
            var descriptionAttributes = (DescriptionAttribute[])filedInfo.GetCustomAttributes(typeof(DescriptionAttribute));
            // 如果大於0的話返回Description
            if (descriptionAttributes.Length > 0)
            {
                return descriptionAttributes[0].Description.ToString();
            }
            // 如果小於0的話返回Name
            else
            {
                return value.ToString();
            }
        }

    }
}
