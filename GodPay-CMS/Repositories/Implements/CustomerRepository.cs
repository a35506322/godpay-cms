using Dapper;
using GodPay_CMS.Common.Helpers.Decipher;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Implements
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDecipherHelper _decipherHelper;
        private readonly IOptionsSnapshot<SettingConfig> _settings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerRepository(IDecipherHelper decipherHelper, IOptionsSnapshot<SettingConfig> settings, IHttpContextAccessor httpContextAccessor)
        {
            _decipherHelper = decipherHelper;
            _settings = settings;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @"SELECT * FROM [dbo].[Customer]";
                var entity = await _connection.QueryAsync<Customer>(sql);
                return entity;
            }
        }

        public async Task<Customer> Get(CustomerParams customerParams)
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @"SELECT * FROM [dbo].[Customer] WHERE 1=1";

                if (customerParams.SeqNo != null)
                    sql += "And SeqNo = @SeqNo ";

                if (customerParams.CustomerId != null)
                    sql += "And CustomerId = @CustomerId ";

                sql = sql.TrimEnd(' ');
                sql += ";";

                var entity = await _connection.QueryFirstOrDefaultAsync<Customer>(sql, customerParams);
                return entity;
            }
        }

        public async Task<Customer> Get(string customerName)
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @"SELECT * FROM [dbo].[Customer] WHERE CustomerName = @customerName";
                var entity = await _connection.QueryFirstOrDefaultAsync<Customer>(sql, new { customerName = customerName });
                return entity;
            }
        }

        public async Task<int> AddCustomer(CustomerReq customerReq)
        {
            customerReq.CustomerId = Guid.NewGuid();
            customerReq.SecretKey = _decipherHelper.SHA256(customerReq.CustomerId.ToString() + DateTime.Now);
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @"Insert Into [dbo].[Customer] (CustomerId,CustomerName,SecretKey)
                                    Values (@CustomerId,@CustomerName,@SecretKey)";
                var count = await _connection.ExecuteAsync(sql, customerReq);
                return count;
            }
        }
    }
}
