using GodPay_CMS.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GodPay_CMS.Services.Implements
{
    public class TagService : ITagService
    {
        private Dictionary<string, string> iconDic { get; set; }

        /// <summary>
        /// 左側導覽列 icon 管理
        /// </summary>
        public TagService()
        {
            iconDic = new Dictionary<string, string>();
            iconDic.Add("Profile", "bi bi-person-fill");
            iconDic.Add("StoreSet", "bi bi-shop");
            iconDic.Add("AuthoritySet", "bi bi-gear");
            iconDic.Add("ManagerSet", "bi bi-person-video2");
            iconDic.Add("Customer", "bi bi-collection-fill");
            iconDic.Add("GlbdoperationAndtRansactionrecord", "pi pi-credit-card");
        }

        /// <summary>
        /// icon 的預設樣式
        /// </summary>
        public string GetIcon(string icon)
        {
            string result = string.Empty;
            result += iconDic.SingleOrDefault(p => p.Key.ToLower() == icon.ToLower()).Value ?? "bi bi-layers";
            return result;
        }

    }
}
