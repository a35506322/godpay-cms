﻿using GodPay_CMS.Services.DTO;
using GodPay_CMS.Services.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class UpdateStoreViewModel : IValidatableObject
    {
        // <summary>
        /// 流水號(PK)
        /// </summary>
        [Required]
        public int Uid { get; set; }

        /// <summary>
        /// 特店名稱
        /// </summary>
        [Required(ErrorMessage = "特店名稱為必填")]
        public string StoreName { get; set; }

        /// <summary>
        /// 統一編號
        /// </summary>
        [Required(ErrorMessage = "統一編號為必填")]
        [StringLength(8, ErrorMessage = "統一編號長度為8碼")]
        public string TaxId { get; set; }

        /// <summary>
        /// 負責人
        /// </summary>    
        [Required(ErrorMessage = "負責人為必填")]
        public string Owner { get; set; } = string.Empty;

        /// <summary>
        /// 公司地址
        /// </summary>
        [Required(ErrorMessage = "公司地址為必填")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        ///  負責人電子信箱
        /// </summary>
        [Required(ErrorMessage = "負責人電子信箱為必填")]
        [EmailAddress(ErrorMessage = "請輸入正確Email格式")]
        public string OwnerEmail { get; set; }
        /// <summary>
        /// 收款銀行帳號
        /// </summary>
        [Required(ErrorMessage = "收款銀行帳號為必填")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "收款銀行帳號需皆為數字")]
        public string ReceivingAccount { get; set; }

        /// <summary>
        /// 收款銀行代碼
        /// </summary>
        [Required(ErrorMessage = "收款銀行代碼為必填")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "收款銀行代碼需皆為數字")]
        public string ReceivingBankCode { get; set; }

        /// <summary>
        /// 收款銀行分行
        /// </summary>
        [Required(ErrorMessage = "收款銀行分行為必填")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "收款銀行分行需皆為數字")]
        public string ReceivingBranch { get; set; }

        /// <summary>
        /// 匯款天數
        /// </summary>
        [Range(1, 30, ErrorMessage = "匯款天數需介於1-30天")]
        public int MoneyTransferDay { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // 取得Service
            var _serviceWrapper = (IServiceWrapper)validationContext.GetService(typeof(IServiceWrapper));

            var reponse = _serviceWrapper.bankService.GetBankDetailById(this.ReceivingBankCode).GetAwaiter().GetResult();

            if (reponse.RtnCode == Common.Enums.ReturnCodeEnum.NotFound)
            {
                yield return new ValidationResult("收款銀行代碼不存在", new string[] { "ReceivingBankCode" });
            }

            if (reponse.RtnCode == Common.Enums.ReturnCodeEnum.Ok)
            {
                BankDetailRsp bankDetailRsp = (BankDetailRsp)reponse.RtnData;

                switch (bankDetailRsp.AccounLength.Length)
                {
                    // 範例:12
                    case 2:
                        if (int.Parse(bankDetailRsp.AccounLength) != this.ReceivingAccount.Length)
                        {
                            yield return new ValidationResult("收款銀行帳號位數錯誤", new string[] { "ReceivingAccount" });
                        }
                        break;
                    default:
                        // 範例:14碼內，星展銀行較為特殊
                        if (this.ReceivingAccount == "14碼內")
                        {
                            if (this.ReceivingAccount.Length > 14)
                            {
                                yield return new ValidationResult("收款銀行帳號位數錯誤", new string[] { "ReceivingAccount" });
                            }
                        }
                        // 範例:11,12
                        string[] accountLengths = bankDetailRsp.AccounLength.Split(',');
                        bool compareResult = accountLengths.ToList().Contains(this.ReceivingAccount.Length.ToString());
                        if (compareResult == false)
                        {
                            yield return new ValidationResult("收款銀行帳號位數錯誤", new string[] { "ReceivingAccount" });
                        }
                        break;
                }
            }
        }
    }
}
