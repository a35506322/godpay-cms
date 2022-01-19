using AutoMapper;
using GodPay.Domain.Dto;
using GodPay.Domain.Enums;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class GLBDOperationAndTransactionRecordService : IGLBDOperationAndTransactionRecordService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _clientFactory;

        public GLBDOperationAndTransactionRecordService(IMapper mapper, IHttpContextAccessor httpContextAccessor, IHttpClientFactory clientFactory)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _clientFactory = clientFactory;
        }
        public async Task<ResponseViewModel> GetOrdersCondition(GLBDQueryOrdersReq glbdQueryOrdersReq)
        {
            var role = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Role).Value;

            var path = "/api/glbd/queryordersforpagination";
            var queryStrings = new Dictionary<string, string>
            {
                {"OrderNo", glbdQueryOrdersReq.OrderNo },
                {"MemberID", glbdQueryOrdersReq.MemberID },
                {"Phone", glbdQueryOrdersReq.Phone },
                {"Email", glbdQueryOrdersReq.Email},
                {"StartDate", glbdQueryOrdersReq.StartDate },
                {"EndDate", glbdQueryOrdersReq.EndDate },
                {"PageNumber", glbdQueryOrdersReq.PageNumber.ToString() },
                {"PageSize", glbdQueryOrdersReq.PageSize.ToString() },
            };
            var queryStringsFilter = queryStrings.Where(q => !String.IsNullOrEmpty(q.Value)).ToDictionary(c=>c.Key,c=>c.Value);
            var url = QueryHelpers.AddQueryString(path, queryStringsFilter);

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            if (role == RoleEnum.Store.ToString())
            {
                var cutomerId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(s => s.Type == "CustomerId").Value;
                var storeId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(s => s.Type == "StoreId").Value;
                request.Headers.Add("X-Api-CustomerId", cutomerId);
                request.Headers.Add("X-Api-StoreId", storeId);
            }
            
            var client = _clientFactory.CreateClient("godapi");

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModel<PageRsp<GLBDQueryOrdersRsp>>>(responseString);
                if (result.RtnCode == "0000")
                {
                    return new ResponseViewModel() { RtnData = result.Info };
                }
            }
            return new ResponseViewModel() { RtnCode = Common.Enums.ReturnCodeEnum.ExecutionFail, RtnData = "查詢失敗" };
        }

        public async Task<ResponseViewModel> Refund(GLBDRefundReq glbdRefundReq)
        {
            var role = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Role).Value;

            var url = "/api/glbd/refund";            
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            string content = JsonConvert.SerializeObject(glbdRefundReq);
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            
            var cutomerId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(s => s.Type == "CustomerId").Value;
            var storeId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(s => s.Type == "StoreId").Value;
            var apiNonce = "b67a9258df5514758e863eea0fa548e47dde1ac0afdfaf8a33a24feeff6aa93c";
            var apiMac = "b67a9258df5514758e863eea0fa548e47dde1ac0afdfaf8a33a24feeff6aa93c";

            request.Headers.Add("X-Api-CustomerId", cutomerId);
            request.Headers.Add("X-Api-StoreId", storeId);
            request.Headers.Add("X-Api-Nonce", apiNonce);
            request.Headers.Add("X-Api-Mac", apiMac);

            var client = _clientFactory.CreateClient("godapi");

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModel>(responseString);
                if (result.RtnCode == statusCode.成功.ToEString())
                {
                    return new ResponseViewModel() { RtnMessage = result.RtnMsg };
                }
                if (result.RtnCode == statusCode.授權失敗.ToEString())
                {
                    return new ResponseViewModel() { RtnData = result.Info, RtnMessage = result.RtnMsg , RtnCode = ReturnCodeEnum.ExecutionFail};
                }
            }
            return new ResponseViewModel() { RtnCode = Common.Enums.ReturnCodeEnum.ExecutionFail, RtnData = "執行失敗" };
        }
    }
}
