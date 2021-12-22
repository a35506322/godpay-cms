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
        /// 使用者流水號(FK)
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 部門
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 使用者
        /// </summary>
        public User User { get; set; }
    }
}
