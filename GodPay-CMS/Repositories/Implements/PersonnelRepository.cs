using Dapper;
using GodPay_CMS.Common.Helpers.Decipher;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Implements
{
    public class PersonnelRepository : IPersonnelRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDecipherHelper _decipherHelper;
        private readonly IOptionsSnapshot<SettingConfig> _settings;
        public PersonnelRepository(IHttpContextAccessor httpContextAccessor, IDecipherHelper decipherHelper, IOptionsSnapshot<SettingConfig> settings)
        {
            _httpContextAccessor = httpContextAccessor;
            _decipherHelper = decipherHelper;
            _settings = settings;
        }

        public async Task<IEnumerable<User>> GetAllPersonnelByStore()
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @"select U.* 
                                from (select * from [dbo].[User] where Role=8) U
                                join [dbo].[Customer_Personnel] P
                                on U.Uid=P.Uid
                                where P.StoreId=@StoreId";
                var entity = await _connection.QueryAsync<User>(sql, new { StoreId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "StoreId").Value });

                if (entity.Count() == 0)
                    return null;

                return entity;
            }
        }
    }
}
