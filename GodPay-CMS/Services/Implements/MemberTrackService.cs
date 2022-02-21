using AutoMapper;
using GodPay.Domain.Dto;
using GodPay.Domain.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO.Response;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class MemberTrackService : IMemberTrackService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _clientFactory;

        public MemberTrackService(IMapper mapper, IHttpContextAccessor httpContextAccessor, IHttpClientFactory clientFactory)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _clientFactory = clientFactory;
        }
        public async Task<ResponseViewModel> GetMemberTrack(GLBDQueryMemberTracksReq gLBDQueryMemberTracksReq)
        {
            var path = "/api/glbd/querymembertrack";
            var queryStrings = new Dictionary<string, string>();
            queryStrings.Add("phone", gLBDQueryMemberTracksReq.Phone);
            queryStrings.Add("startdate", gLBDQueryMemberTracksReq.StartDate);
            queryStrings.Add("enddate", gLBDQueryMemberTracksReq.EndDate);
            var queryStringsFilter = queryStrings.Where(q => !String.IsNullOrEmpty(q.Value)).ToDictionary(d=>d.Key,d=>d.Value);
            var url = QueryHelpers.AddQueryString(path, queryStringsFilter);

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient("godapi");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultModel<IEnumerable<GLBD_Member_TrackRsp>>>(responseString);

                // 要使用TreeTable 須按照下面格式分類資料
                #region 範例資料

                /*
                [
                {
                   "key": "0",
                   "data": {
                       "storeName": "",
                       "actionDate": 2022,
                       "action": "",
                       "amount": 20000,
                       "blance": 10000,
                   },
                   "children": [
                       {
                           "key": "0-0",
                           "data": {
                               "storeName": "",
                               "actionDate": 1,
                               "action": "",
                               "amount": 10000,
                               "blance": 10000,
                           },
                           "children": [
                               {
                                   "key": "0-0-0",
                                   "data": {
                                       "rid": 1,
                                       "id": "A123456789",
                                       "storeName": "Yesgogo",
                                       "phone": "0988123452",
                                       "actionDate": "2022-01-19T17:55:55.347",
                                       "action": "取消",
                                       "amount": 5000,
                                       "blance": 9500
                                   }
                               },
                               {
                                   "key": "0-0-1",
                                   "data": {
                                       "rid": 2,
                                       "iD": "A123456789",
                                       "storeName": "Yesgogo",
                                       "phone": "0988123452",
                                       "actionDate": "2022-01-20T17:55:55.347",
                                       "action": "繳費",
                                       "amount": 5000,
                                       "blance": 9500
                                   }

                               },
                           ]

                       },
                       {
                           "key": "0-1",
                           "data": {
                               "storeName": "",
                               "actionDate": 2,
                               "action": "",
                               "amount": 10000,
                               "blance": 10000,
                           },
                           "children": [
                               {
                                   "key": "0-1-0",
                                   "data": {
                                       "rid": 3,
                                       "id": "A123456789",
                                       "storeName": "Yesgogo",
                                       "phone": "0988123452",
                                       "actionDate": "2022-02-20T17:55:55.347",
                                       "action": "繳費",
                                       "amount": 5000,
                                       "blance": 9500
                                   }
                               },
                               {
                                   "key": "0-1-1",
                                   "data": {
                                       "rid": 4,
                                       "id": "A123456789",
                                       "storeName": "Yesgogo",
                                       "phone": "0988123452",
                                       "actionDate": "2022-02-20T17:55:55.347",
                                       "action": "取消",
                                       "amount": 5000,
                                       "blance": 9500
                                   }
                               },
                           ]
                       },
                   ]
                */

                #endregion

                if (result.RtnCode == "0000")
                {
                    List<TreeTableRsp<GLBD_Member_TrackRsp>> treeTableRsps = new List<TreeTableRsp<GLBD_Member_TrackRsp>>();

                    // 按照年分組
                    var glbd_Member_TrackGroupByYears = from glbd_Member_TrackRsp in result.Info
                                                        group glbd_Member_TrackRsp by new { year = DateTime.Parse(glbd_Member_TrackRsp.ActionDate).Year } into newGroup
                                                        orderby newGroup.Key.year descending
                                                        select newGroup;
                    var yearKey = 0;
                    foreach (var glbd_Member_TrackGroupByYear in glbd_Member_TrackGroupByYears)
                    {
                        // 放置年軌跡
                        TreeTableRsp<GLBD_Member_TrackRsp> yearTrack = new TreeTableRsp<GLBD_Member_TrackRsp>();
                        yearTrack.Data = new GLBD_Member_TrackRsp();
                        yearTrack.Children = new List<TreeTableRsp<GLBD_Member_TrackRsp>>();

                        yearTrack.Key = $"{yearKey}";
                        yearTrack.Data.ActionDate = $"{glbd_Member_TrackGroupByYear.Key.year}";
                        yearTrack.Data.Amount = glbd_Member_TrackGroupByYear.Sum(g => g.Amount);
                        yearTrack.Data.Blance = glbd_Member_TrackGroupByYear.OrderByDescending(g => DateTime.Parse(g.ActionDate)).FirstOrDefault().Blance;

                        // 按照月分組
                        var glbd_Member_TrackGroupByMonths = from item in glbd_Member_TrackGroupByYear
                                                             group item by new { month = DateTime.Parse(item.ActionDate).Month } into newGroup
                                                             orderby newGroup.Key.month descending
                                                             select newGroup;
                        var monthKey = 0;
                        foreach (var glbd_Member_TrackGroupByMonth in glbd_Member_TrackGroupByMonths)
                        {
                            TreeTableRsp<GLBD_Member_TrackRsp> monthTrack = new TreeTableRsp<GLBD_Member_TrackRsp>();
                            monthTrack.Data = new GLBD_Member_TrackRsp();
                            monthTrack.Children = new List<TreeTableRsp<GLBD_Member_TrackRsp>>();

                            // 放置月軌跡
                            monthTrack.Key = $"{yearKey}-{monthKey}";
                            monthTrack.Data.ActionDate = $"{glbd_Member_TrackGroupByMonth.Key.month}";
                            monthTrack.Data.Amount = glbd_Member_TrackGroupByMonth.Sum(g => g.Amount);
                            monthTrack.Data.Blance = glbd_Member_TrackGroupByMonth.OrderByDescending(g => DateTime.Parse(g.ActionDate)).FirstOrDefault().Blance;

                            var dayKey = 0;
                            foreach (var glbd_Member_Track in glbd_Member_TrackGroupByMonth)
                            {
                                TreeTableRsp<GLBD_Member_TrackRsp> dayTrack = new TreeTableRsp<GLBD_Member_TrackRsp>();
                                dayTrack.Data = new GLBD_Member_TrackRsp();

                                dayTrack.Key = $"{yearKey}-{monthKey}-{dayKey}";
                                dayTrack.Data.Rid = glbd_Member_Track.Rid;
                                dayTrack.Data.StoreName = glbd_Member_Track.StoreName;
                                dayTrack.Data.Action = ((GLBDActionCode)Enum.Parse(typeof(GLBDActionCode),glbd_Member_Track.Action)).ToString();
                                dayTrack.Data.ActionDate = DateTime.Parse(glbd_Member_Track.ActionDate).ToString("MM/dd mm:s");
                                dayTrack.Data.Amount = glbd_Member_Track.Amount;
                                dayTrack.Data.Blance = glbd_Member_Track.Blance;
                                dayTrack.Data.ID = glbd_Member_Track.ID;
                                dayTrack.Data.Phone = glbd_Member_Track.Phone;

                                // 將日放置月軌跡
                                monthTrack.Children.Add(dayTrack);
                                dayKey++;
                            }
                            // 將月放置年軌跡
                            yearTrack.Children.Add(monthTrack);
                            monthKey++;
                        }
                        // 將年放進結果
                        treeTableRsps.Add(yearTrack);
                        yearKey++;
                    }
                    return new ResponseViewModel() { RtnData = treeTableRsps };
                }
            }
            return new ResponseViewModel() { RtnCode = Common.Enums.ReturnCodeEnum.CallApiFail, RtnMessage = Common.Enums.ReturnCodeEnum.CallApiFail.GetEnumDescription() };

        }

    }
}
