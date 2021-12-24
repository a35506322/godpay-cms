﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GodPay_CMS.Controllers.Parameters
{
    /// <summary>
    /// Customer Query
    /// </summary>
    public class CustomerParams : IValidatableObject
    {
        /// <summary>
        /// 流水號
        /// </summary>
        [Range(1, int.MaxValue)]
        public int? SeqNo { get; set; }

        /// <summary>
        /// CustomerId
        /// </summary>
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// 公司名稱
        /// </summary>
        public string CustomerName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.SeqNo == null && this.CustomerId == null && string.IsNullOrEmpty(this.CustomerName))
                yield return new ValidationResult("流水號、CustomerId和公司名稱不可皆為空值",
                                                  new[] { "驗證錯誤" });
        }
    }
}
