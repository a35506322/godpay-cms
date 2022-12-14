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
using GodPay_CMS.Common;

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

        public Task<bool> Add(Customer_Store model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer_Store>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer_Store> GetById(int id)
        {
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sqlString = @"Select * 
                                    From [dbo].[Customer_Store] S
                                    Join [dbo].[Customer] C
                                    On S.CustomerId = C.CustomerId
                                    Where S.Uid = @id";
                var stores = await connection.QueryAsync<Customer_Store, Customer, Customer_Store>(sqlString, (store, customer) =>
                {
                    store.Customer = customer;
                    return store;
                }, new { id = id }, splitOn: "CustomerId");
                var store = stores.AsList().FindLast(p=>p.Uid == id);
                return store;
            }
        }

        public async Task<IEnumerable<Customer_Store>> GetStoresCondition(Customer_Store customer_Store)
        {
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sqlString = @"Select *
                                    From [dbo].[Customer_Store]  A
                                    Where 1=1";

                if (customer_Store.CustomerId != Guid.Empty)
                {
                    sqlString += "and A.CustomerId = @CustomerId ";
                }

                if (customer_Store.StoreId != Guid.Empty)
                {
                    sqlString += "and A.StoreId = @StoreId ";
                }

                var stores = await connection.QueryAsync<Customer_Store>(sqlString, customer_Store);
                return stores;
            }
        }

        public async Task<bool> Update(Customer_Store model)
        {
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                bool result = false;
                string sqlString = string.Empty;
                var parameters = new 
                {
                    ReceivingAccount = model.ReceivingAccount,
                    ReceivingBankCode = model.ReceivingBankCode,
                    ReceivingBranch = model.ReceivingBranch,
                    MoneyTransferDay = model.MoneyTransferDay,
                    StoreName = model.StoreName,
                    TaxId = model.TaxId,
                    Owner=model.Owner,
                    Address = model.Address,
                    OwnerEmail = model.OwnerEmail,
                    Uid = model.Uid,
                    LastModifier = model.User.LastModifier,
                    LastModifyDate = model.User.LastModifyDate
                };
                sqlString += @"Update T
                                    Set T.StoreName = @StoreName,
	                                    T.TaxId     = @TaxId,
	                                    T.Owner     = @Owner,
	                                    T.Address   = @Address,
	                                    T.OwnerEmail = @OwnerEmail,
                                        T.ReceivingAccount = @ReceivingAccount,
                                        T.ReceivingBankCode = @ReceivingBankCode,
                                        T.ReceivingBranch = @ReceivingBranch,
                                        T.MoneyTransferDay = @MoneyTransferDay
                                    From
                                    (
	                                    Select *
	                                    From [dbo].[Customer_Store]A
	                                    Where A.Uid = @Uid
                                    )T;";
                sqlString += @"Update T2
                                Set T2.LastModifier = @LastModifier,
	                                T2.LastModifyDate = @LastModifyDate
                                From
                                (
	                                Select *
	                                From [dbo].[User]A
	                                Where A.Uid = @Uid
                                )T2";

                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var rowCount = await connection.ExecuteAsync(sqlString, parameters, transaction: tran);
                        tran.Commit();
                        if (rowCount > 0) { result = true; }

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }

                    return result;
                }
            }
        }
           
    }
}
