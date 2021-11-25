using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Entity
{
    /// <summary>
    /// 內部人員詳細資料
    /// </summary>
    public class Insider
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int Iid { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 名子
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 部門
        /// </summary>
        public string Department { get; set; }
    }
}
