﻿using GodPay.Domain.Dto;
using GodPay_CMS.Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    public interface IGLBDOperationAndTransactionRecordService
    {
        /// <summary>
        /// 取得分頁訂單資訊
        /// </summary>
        /// <param name="glbdQueryOrdersReq"></param>
        /// <returns></returns>
        Task<ResponseViewModel> GetOrdersCondition(GLBDQueryOrdersReq glbdQueryOrdersReq);
        /// <summary>
        /// 退貨
        /// </summary>
        /// <param name="glbdRefundReq"></param>
        /// <returns></returns>
        Task<ResponseViewModel> Refund(GLBDRefundReq glbdRefundReq);
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="glbdVoidReq"></param>
        /// <returns></returns>
        Task<ResponseViewModel> Void(GLBDVoidReq glbdVoidReq);
    }
}
