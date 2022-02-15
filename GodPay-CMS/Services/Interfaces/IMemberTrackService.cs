using GodPay.Domain.Dto;
using GodPay_CMS.Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    public interface IMemberTrackService
    {
        /// <summary>
        /// 取得會員軌跡
        /// </summary>
        /// <param name="gLBDQueryMemberTracksReq">gLBDQueryMemberTracksReq</param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetMemberTrack(GLBDQueryMemberTracksReq gLBDQueryMemberTracksReq);
    }
}
