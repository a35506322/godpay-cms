﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public IEnumerable<UpdateAuthorityFuncViewModel> UpdateFuncViewModel { get; set; }
    }
}
