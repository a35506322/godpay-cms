using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Data.SqlClient;
using GodPay_CMS.Common.Helpers.Decipher;
using Microsoft.Extensions.Options;

namespace GodPay_CMS.Repositories.Implements
{
    public class InsiderRepository : IInsiderRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDecipherHelper _decipherHelper;
        private readonly IOptionsSnapshot<SettingConfig> _settings;
        public InsiderRepository (IHttpContextAccessor httpContextAccessor, IDecipherHelper decipherHelper, IOptionsSnapshot<SettingConfig> settings)
        {
            _httpContextAccessor = httpContextAccessor;
            _decipherHelper = decipherHelper;
            _settings = settings;
        }

        public Task<bool> Add(Insider model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Insider>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Insider> GetById(int id)
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sqlString = @"Select *
                                    From[dbo].[Insider] A
                                    Where A.Uid = @id";
                var insider = await _connection.QuerySingleOrDefaultAsync<Insider>(sqlString, new { id = id });
                return insider;
            }
        }

        public Task<bool> Update(Insider mdoel)
        {
            throw new NotImplementedException();
        }

    }
}
