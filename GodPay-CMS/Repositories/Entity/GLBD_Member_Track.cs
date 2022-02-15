using GodPay.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Entity
{
    public class GLBD_Member_Track
    {
        /// <summary>
        /// 流水號(PK)
        /// </summary>
        public int Rid { get; set; }
        /// <summary>
        /// 會員手機
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 動作時間
        /// </summary>
        public DateTime ActionDate { get; set; }
        /// <summary>
        /// 動作
        /// </summary>
        public GLBDActionCode Action { get; set; }
        /// <summary>
        /// 訂單金額
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 會員信用額度
        /// </summary>
        public int Blance { get; set; }
    }
}
