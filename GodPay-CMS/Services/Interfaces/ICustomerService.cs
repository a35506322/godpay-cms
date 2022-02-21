﻿using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.DTO.Request;
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
        /// <param name="postCustomerReq">postCustomerReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> Add(PostCustomerReq postCustomerReq);

        /// <summary>
        /// 編輯公司
        /// </summary>
        /// <param name="putCustomerReq">putCustomerReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> Edit(PutCustomerReq putCustomerReq);
    }
}
