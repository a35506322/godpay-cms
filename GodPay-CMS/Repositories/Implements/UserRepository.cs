using AutoMapper;
using Dapper;
using GodPay_CMS.Common.Util;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public UserRepository(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public Task<bool> Add(User model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(User mdoel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 以帳號密碼驗證使用者
        /// </summary>
        /// <param name="signinReq"></param>
        /// <returns></returns>
        public async Task<UserRsp> GetByUserIdAndUserKey(SigninReq signinReq)
        {
            using (IDbConnection _connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("UserId", new DbString { Value = signinReq.UserId });
                parameter.Add("UserKey", new DbString { Value = RNGCrypto.HMACSHA256(signinReq.UserKey, signinReq.UserId) });

                string sql = @"SELECT * FROM [dbo].[User] WHERE UserId = @UserId AND UserKey = @UserKey ";
                var entity = await _connection.QuerySingleOrDefaultAsync<User>(sql, parameter);

                if (entity == null)
                    return null;

                var userRsp = _mapper.Map<UserRsp>(entity);

                return userRsp;
            }
        }
    }
}
