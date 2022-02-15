using GodPay_CMS.Controllers.ViewModels;

namespace GodPay_CMS.Services.Interfaces
{
    public interface IEnumService
    {
        /// <summary>
        /// 取得角色
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetRoleEnum();
        /// <summary>
        /// 取得帳號狀態
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetAccountStatusEnum();
        /// <summary>
        /// 取得訂單狀態
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetGLBDStatusCodeEnum();
    }
}
