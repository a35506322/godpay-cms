using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO
{
    /// <summary>
    /// 修改User DTO
    /// </summary>
    public class UpdateUserReq
    {
        /// <summary>
        /// 修改者Id
        /// </summary>
        public string ModifierId { get; set; }
        /// <summary>
        /// 使用者Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 電子信箱
        /// </summary>
        public string Email { get; set; }
    }
}
