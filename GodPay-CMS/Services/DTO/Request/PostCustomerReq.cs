﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO.Request
{
    public class PostCustomerReq
    {
        /// <summary>
        /// 公司名稱
        /// </summary>
        [Required(ErrorMessage = "公司名稱為必填")]
        public string CustomerName { get; set; }
    }
}
