using GodPay_CMS.Controllers.ViewModels;
using System;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        ///  取得所有公司
        /// </summary>
        /// <returns></returns>
        public Task<ResponseViewModel> GetAll();

        /// <summary>
        /// 以流水號取得公司
        /// </summary>
        /// <param name="seqNo"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> Get(int seqNo);

        /// <summary>
        /// 以customerId取得公司
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> Get(Guid customerId);
    }
}
