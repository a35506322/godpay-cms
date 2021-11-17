using System.ComponentModel;

namespace GodPay_CMS.Common.Enums
{
    /// <summary>角色資訊</summary>
    public enum RoleEnum
    {
        /// <summary>管理員</summary>
        [Description("管理員")]
        Admin = 9,

        /// <summary>業務</summary>
        [Description("業務")]
        Manager = 7,

        /// <summary>特店</summary>
        [Description("特店")]
        Store = 5,

        /// <summary>特店人員</summary>
        [Description("特店人員")]
        Personnel = 3,
    }
}
