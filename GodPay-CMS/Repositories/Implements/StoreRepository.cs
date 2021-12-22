using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using GodPay_CMS.Common.Helpers.Decipher;
using Microsoft.Extensions.Options;
using GodPay_CMS.Services.DTO;

namespace GodPay_CMS.Repositories.Implements
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDecipherHelper _decipherHelper;
        private readonly IOptionsSnapshot<SettingConfig> _settings;
        public StoreRepository(IHttpContextAccessor httpContextAccessor, IDecipherHelper decipherHelper, IOptionsSnapshot<SettingConfig> settings)
        {
            _httpContextAccessor = httpContextAccessor;
            _decipherHelper = decipherHelper;
            _settings = settings;
        }

        public Task<bool> Add(Store model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Store>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Store> GetById(int id)
        {
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sqlString = @"Select * 
                                    From [dbo].[Customer_Store] S
                                    Join [dbo].[Customer] C
                                    On S.CustomerId = C.CustomerId
                                    Where S.Uid = @id";
                var stores = await connection.QueryAsync<Store, Customer, Store>(sqlString, (store, customer) =>
                {
                    store.Customer = customer;
                    return store;
                }, new { id = id }, splitOn: "CustomerId");
                var store = stores.AsList().FindLast(p=>p.Uid == id);
                return store;
            }
        }

        public Task<bool> Update(Store mdoel)
        {
            throw new NotImplementedException();
        }        
    }
}
