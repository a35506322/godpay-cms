using AutoMapper;
using Dapper;
using GodPay_CMS.Common.Enums;
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

        public UserRepository(IConfiguration config)
        {
            _config = config;
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

        public async Task<User> GetByUserIdAndUserKey(SigninReq signinReq)
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

                return entity;
            }
        }

        public async Task<User> GetByUserId(string userId)
        {
            using (IDbConnection _connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
            {
                string sql = @"SELECT * FROM [dbo].[User]
                               WHERE UserId = @UserId";
                var entity = await _connection.QuerySingleOrDefaultAsync<User>(sql, new { UserId = userId });

                if (entity == null)
                    return null;

                return entity;
            }
        }

        public async Task<IEnumerable<User>> GetByRole(RoleEnum role)
        {
            using (IDbConnection _connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
            {
                string sqlString = @"SELECT * FROM [dbo].[User]
                                     WHERE Role = @Role";
                var users = await _connection.QueryAsync<User>(sqlString, new { Role = role });

                if (users == null)
                    return null;

                return users;
            }
        }

        public async Task<int> UpdateUser(UpdateUserReq updateUserReq)
        {
            using (IDbConnection _connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
            {
                string sql = @" UPDATE [dbo].[User] 
                                SET Email = @Email, 
                                    LastModifier = (select Uid from [dbo].[User] where UserId= @ModifierId),
                                    LastModifyDate = GETDATE()
                                WHERE UserId = @UserId";

                var entity = await _connection.ExecuteAsync(sql, updateUserReq);
                return entity;
            }
        }

        public async Task<bool> PostBusinessmanAndInsider(PostUserAndInsiderReq userAndInsiderReq)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
            {
                
                string sqlString = @"Insert Into [dbo].[User] (UserId,UserKey,Email,Func,Status,Role,CreateDate)
                                    Values (@UserId,@UserKey,@Email,@Func,@Status,@Role,@CreateDate)";
                sqlString += @"Insert Into [dbo].[Insider] (UserId,Name,Department)
                               Values (@UserId,@Name,@Department)";

                connection.Open();
                bool result = false;
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        int rowCont =  await connection.ExecuteAsync(sqlString, userAndInsiderReq, transaction: tran);
                        if (rowCont > 0) { result = true; }                        
                        tran.Commit();
                    }
                    catch (Exception excpetion)
                    {
                        tran.Rollback();
                        throw new Exception(excpetion.Message.ToString());                      
                    }
                    return result;
                }
            }
        }

        public async Task<IEnumerable<User>> GetUserAndInsiderByUserId(string userId)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
            {
                string sqlString = @"Select *
	                                 From　[dbo].[User] A
	                                 Left Join [dbo].[Insider] B On A.UserId = B.UserId
	                                 Where B.UserId = @userId";

                var users = await connection.QueryAsync<User, Insider, User>(sqlString, (user, insider) =>
                 {
                     user.Insider = insider;
                     return user;
                 }, new { userId = userId }, splitOn: "Iid");

                return users;
            }
        }
    }
}
