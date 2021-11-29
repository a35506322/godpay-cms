using GodPay_CMS.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IStoreRepository : IGenericRepository<Store>, IGenericRepositoryById<Store, int>
    {
        /// <summary>
        /// 查詢單筆業務及特約商店詳細資料
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<IEnumerable<User>> GetUserAndStoreByUserId(string userId);
    }
}
