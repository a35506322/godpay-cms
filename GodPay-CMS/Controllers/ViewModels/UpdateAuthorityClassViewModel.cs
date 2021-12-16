using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers.ViewModels
{
    /// <summary>
    /// 修改類別 ViewModel
    /// </summary>
    public class UpdateAuthorityClassViewModel
    {
        /// <summary>
        /// 功能類別代碼Code(PK)
        /// </summary>
        public string FuncClassCode { get; set; }

        /// <summary>
        /// 英文名字(action)
        /// </summary>
        [Required]
        public string FuncClassEnName { get; set; }
        /// <summary>
        /// 中文名字(action)
        /// </summary>
        [Required]
        public string FuncClassChName { get; set; }
        [JsonProperty("Functions")]
        public IEnumerable<UpdateAuthorityFuncViewModel> UpdateFuncViewModel { get; set; }
    }
}
