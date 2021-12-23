using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T :class
    {
        /// <summary>
        /// 查詢全部資料
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<bool> Add(T model);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="mdoel"></param>
        /// <returns></returns>
        public Task<bool> Update(T model);

    }
}
