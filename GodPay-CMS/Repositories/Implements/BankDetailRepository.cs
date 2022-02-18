using GodPay_CMS.Common.Helpers.Decipher;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using GodPay_CMS.Common;

namespace GodPay_CMS.Repositories.Implements
{
    public class BankDetailRepository : IBankDetailRepository
    {
        private readonly IDecipherHelper _decipherHelper;
        private readonly IOptionsSnapshot<SettingConfig> _settings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BankDetailRepository(IDecipherHelper decipherHelper, IOptionsSnapshot<SettingConfig> settings, IHttpContextAccessor httpContextAccessor)
        {
            _decipherHelper = decipherHelper;
            _settings = settings;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task<bool> Add(BankDetail model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BankDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async  Task<BankDetail> GetById(string id)
        {
            using (IDbConnection _dbConnection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @"Select *
                              From [dbo].[BankDetail]
                              Where [Code] = @id";

                var bankDetail = await _dbConnection.QueryFirstOrDefaultAsync<BankDetail>(sql, new { id = id });

                return bankDetail;
            }
        }

        public Task<bool> Update(BankDetail model)
        {
            throw new NotImplementedException();
        }
    }
}
