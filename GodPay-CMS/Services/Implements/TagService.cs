using GodPay_CMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class TagService : ITagService
    {
        private Dictionary<string, string> iconDic { get; set; }
        public TagService()
        {
            iconDic = new Dictionary<string, string>();
            iconDic.Add("profile", "bi bi-people");
            iconDic.Add("storeset", "bi bi-house");
            iconDic.Add("authorityset", "bi bi-gear");
            iconDic.Add("managerset", "bi bi-clipboard");
            iconDic.Add("customer", "bi bi-building");
            
        }
        public string GetIcon(string icon)
        {
            string result = string.Empty;
            result += iconDic.SingleOrDefault(p => p.Key == icon).Value ?? "bi bi-layers";
            return result;
        }

    }
}
