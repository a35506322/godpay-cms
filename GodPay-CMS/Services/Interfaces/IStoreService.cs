﻿using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
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

        /// <summary>
        /// 取得特店及詳細資料
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetUserAndStoreByUserId(string userId);

        /// <summary>
        /// 更新特店及詳細資料
        /// </summary>
        /// <param name="updateUserAndStoreViewModel"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpateUserAndStore(UpdateUserAndStoreViewModel updateUserAndStoreViewModel);

        /// <summary>
        /// 更新特店
        /// </summary>
        /// <param name="updateStoreViewModel"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> UpateStore(UpdateStoreViewModel updateStoreViewModel);

    }
}
