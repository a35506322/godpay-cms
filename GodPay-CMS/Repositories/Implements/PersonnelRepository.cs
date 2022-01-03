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

        public async Task<IEnumerable<PersonnelByStore>> GetAllPersonnelByStore()
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @"SELECT * FROM [dbo].[PersonnelByStore]
                                WHERE StoreId=@StoreId";
                var entity = await _connection.QueryAsync<PersonnelByStore>(sql, new { StoreId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "StoreId").Value });

                if (entity.Count() == 0)
                    return null;

                return entity;
            }
        }
    }
}
