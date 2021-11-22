﻿using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IFuncClassRepository : IGenericRepository<FuncClass>, IGenericRepositoryById<FuncClass, string>
    {
        /// <summary>
        /// 取得功能列表(1對多)
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<FuncClass>> GetByFuncClassAndFunc();
    }
}
