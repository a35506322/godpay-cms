﻿using GodPay_CMS.Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Interfaces
{
    public interface IStoreService
    {
        /// <summary>
        /// 取得特店們
        /// </summary>
        /// <param name="role">角色</param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetStores();
        /// <summary>
        /// 取得特店詳細資料
        /// </summary>
        /// <param name="sid">PK</param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetStoreDeatil(int uid);
        /// <summary>
        /// 新增特店及詳細資料
        /// </summary>
        /// <param name="postUserAndStoreViewModel"></param>
        /// <returns></returns>
        Task<ResponseViewModel> PostUserAndStore(PostUserAndStoreViewModel postUserAndStoreViewModel);
    }
}
