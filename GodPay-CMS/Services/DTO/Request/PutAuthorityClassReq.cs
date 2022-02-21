using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO.Request
{
    public class PutAuthorityClassReq
    {
        /// <summary>
        /// 功能類別代碼Code(PK)
        /// </summary>
        [Required(ErrorMessage = "功能類別代碼必填")]
        public string FuncClassCode { get; set; }
        /// <summary>
        /// 英文名字(action)
        /// </summary>
        [Required(ErrorMessage = "action(英文)必填")]
        public string FuncClassEnName { get; set; }
        /// <summary>
        /// 中文名字(action)
        /// </summary>
        [Required(ErrorMessage = "action(中文)必填")]
        public string FuncClassChName { get; set; }
        [JsonProperty("Functions")]
        public IEnumerable<PutAuthorityFuncReq> PutAuthorityFuncRequests { get; set; }
    }
}
