using AutoMapper;
using Dapper;
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

        public Task<bool> Add(UserRsp model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserRsp>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserRsp> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Update(UserRsp mdoel)
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
                string sql = @"SELECT * FROM [dbo].[User] 
                               WHERE UserId = @UserId 
                               AND UserKey  = @UserKey
                               AND Status   = @Status";
                var entity = await _connection.QuerySingleOrDefaultAsync<User>(sql, signinReq);

                if (entity == null)
                    return null;

                var userRsp = _mapper.Map<UserRsp>(entity);

                return userRsp;
            }
        }

        /// <summary>
        /// 以帳號取得使用者資訊
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserRsp> GetByUserId(string userId)
        {
            using (IDbConnection _connection = new SqlConnection(_config.GetConnectionString("UBSEC_Conn")))
            {
                string sql = @"SELECT * FROM [dbo].[User] WHERE UserId = @UserId";
                var entity = await _connection.QuerySingleOrDefaultAsync<User>(sql, new { UserId = userId });

                if (entity == null)
                    return null;

                var userRsp = _mapper.Map<UserRsp>(entity);

                return userRsp;
            }
        }
    }
}
