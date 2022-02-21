using GodPay_CMS.Common.Enums;
using GodPay_CMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GodPay_CMS.Services.DTO.Response;

namespace GodPay_CMS.Services.DTO.Request
{
    /// <summary>
    /// User And Store Request
    /// </summary>
    public class PostUserAndStoreReq : IValidatableObject
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required(ErrorMessage = "帳號為必填")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z]).{6,20}$", ErrorMessage = "請至少輸入大小寫英文1位、數字1位及6-20位帳號")]
        public string UserId { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Email為必填")]
        [EmailAddress(ErrorMessage = "請輸入正確Email格式")]
        public string Email { get; set; }

        /// <summary>
        /// CustomerId
        /// </summary>
        [Required(ErrorMessage = "公司代碼為必填")]
        public string CustomerId { get; set; }

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
        public string Owner { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        [Required(ErrorMessage = "公司地址為必填")]
        public string Address { get; set; }

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

        /// <summary>
        /// 密碼
        /// </summary>
        public string UserKey { get; set; } = string.Empty;

        /// <summary>
        /// 角色
        /// </summary>
        public RoleEnum Role { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public int Func { get; set; }

        /// <summary>
        /// 目前狀態
        /// </summary>
        public AccountStatusEnum Status { get; set; }

        /// <summary>
        /// 創造時間
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 特店Id
        /// </summary>
        public Guid StoreId { get; set; }

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
                        if (bankDetailRsp.AccounLength == "14碼內")
                        {
                            if (this.ReceivingAccount.Length > 14)
                            {
                                yield return new ValidationResult("收款銀行帳號位數錯誤", new string[] { "ReceivingAccount" });
                            }
                        }
                        else
                        {
                            // 範例:11,12
                            string[] accountLengths = bankDetailRsp.AccounLength.Split(',');
                            bool compareResult = accountLengths.ToList().Contains(this.ReceivingAccount.Length.ToString());
                            if (compareResult == false)
                            {
                                yield return new ValidationResult("收款銀行帳號位數錯誤", new string[] { "ReceivingAccount" });
                            }
                        }
                        break;
                }
            }
        }
    }
}
