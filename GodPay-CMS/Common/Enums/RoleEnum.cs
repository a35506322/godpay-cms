using System;
using System.ComponentModel;

namespace GodPay_CMS.Common.Enums
{
    /// <summary>角色資訊</summary>
    [Flags]
    public enum RoleEnum
    {
        /// <summary>管理員</summary>
        [Description("管理員")]
        Admin = 1 << 0,

        /// <summary>業務</summary>
        [Description("業務")]
        Manager = 1 << 1,

        /// <summary>特店</summary>
        [Description("特店")]
        Store = 1 << 2,

        /// <summary>特店人員</summary>
        [Description("特店人員")]
        Personnel = 1 << 3,

        /// <summary>所有角色</summary>
        [Description("所有角色")]
        All = Admin | Manager | Store | Personnel
    }
}
