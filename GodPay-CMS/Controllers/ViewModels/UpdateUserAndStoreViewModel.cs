using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class UpdateUserAndStoreViewModel
    {
        // <summary>
        /// 流水號(PK)
        /// </summary>
        [Required]
        public int Uid { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        [Required]
        public string UserId { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// 目前狀態
        /// </summary>
        [Required]
        public string Status { get; set; }
        /// <summary>
        /// 特約商店全名
        /// </summary>
        [Required]
        public string FullName { get; set; }
        /// <summary>
        /// 特約商店別名
        /// </summary>
        [Required]
        public string ShortName { get; set; }
        /// <summary>
        /// 測試欄位1
        /// </summary>        
        public string StoreData1 { get; set; }
        /// <summary>
        /// 測試欄位2
        /// </summary>
        public string StoreData2 { get; set; }
    }
}
