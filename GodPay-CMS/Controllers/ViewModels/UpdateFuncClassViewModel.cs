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
    public class UpdateFuncClassViewModel
    {
        /// <summary>
        /// 英文名子(action)
        /// </summary>
        [Required]
        public string FuncClassEnName { get; set; }
        /// <summary>
        /// 中文名子(action)
        /// </summary>
        [Required]
        public string FuncClassChName { get; set; }
        [JsonProperty("Functions")]
        public IEnumerable<UpdateFuncViewModel> UpdateFuncViewModel { get; set; }
    }
}
