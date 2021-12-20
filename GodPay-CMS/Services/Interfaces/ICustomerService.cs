using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
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
        /// 以流水號或CustomerId取得公司
        /// </summary>
        /// <param name="customerParams">流水號或CustomerId</param>
        /// <returns></returns>
        public Task<ResponseViewModel> Get(CustomerParams customerParams);

        /// <summary>
        /// 新增公司
        /// </summary>
        /// <param name="addCustomerViewModel">公司名稱</param>
        /// <returns></returns>
        public Task<ResponseViewModel> Add(AddCustomerViewModel addCustomerViewModel);

        /// <summary>
        /// 編輯公司
        /// </summary>
        /// <param name="editCustomerViewModel"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> Edit(EditCustomerViewModel editCustomerViewModel);
    }
}
