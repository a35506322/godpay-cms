using AutoMapper;
using Dapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.Parameters;
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
                                    LastModifier =   @ModifierId,
                                    LastModifyDate = GETDATE()
                                WHERE UserId = @UserId";

                var entity = await _connection.ExecuteAsync(sql, updateUserReq);
                return entity;
            }
        }

        public async Task<bool> PostUserAndInsider(PostUserAndInsiderReq userAndInsiderReq)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
            {
                // 新增User主表
                string sqlString = @"Insert Into [dbo].[User] (UserId,UserKey,Email,Func,Status,Role,CreateDate)
                                    Values (@UserId,@UserKey,@Email,@Func,@Status,@Role,@CreateDate);";

                // 新增業務詳細資料子表
                sqlString += @"Insert Into [dbo].[Insider] (Uid,Name,Department)
                                Select A.Uid,'',''
                                From [dbo].[User] A
                                Where A.UserId = @UserId;";

                sqlString += @"Update T
                                Set T.Name = @Name,
	                                T.Department = @Department
                                From
                                (
	                                Select *
	                                From [dbo].[Insider] A
	                                Where A.Uid = (Select A.Uid
					                                From [dbo].[User] A
					                                Where A.UserId = @UserId)
                                )T;";

                connection.Open();
                bool result = false;
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        int rowCounts =  await connection.ExecuteAsync(sqlString, userAndInsiderReq, transaction: tran);
                        if (rowCounts > 0) { result = true; }                        
                        tran.Commit();
                    }
                    catch (Exception exception)
                    {
                        tran.Rollback();
                        throw new Exception(exception.Message.ToString());                      
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
	                                 Join [dbo].[Insider] B On A.Uid = B.Uid
	                                 Where A.UserId = @userId";

                var users = await connection.QueryAsync<User, Insider, User>(sqlString, (user, insider) =>
                 {
                     user.Insider = insider;
                     return user;
                 }, new { userId = userId }, splitOn: "Iid");

                return users;
            }
        }

        public async Task<bool> UpdateUserAndInsider(UpdateUserAndInsiderReq updateUserAndInsiderReq)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
            {
                string sqlString = @"Update T
                                    SET T.Status = @Status,
	                                    T.Email = @Email,
	                                    T.LastModifier = @LastModifier,
	                                    T.LastModifyDate = @LastModifyDate
                                    From
                                    (
                                        Select A.Status, A.Email, A.LastModifier, A.LastModifyDate
                                        From [dbo].[User] A
                                        Where A.Uid = @Uid
                                    )T;

                                    Update T2
                                    SET T2.Name = @Name,
	                                    T2.Department = @Department
                                    From
                                    (
                                        Select A.Name, A.Department
                                        From [dbo].[Insider] A
                                        Where A.Uid = @Uid
                                    )T2;";
                connection.Open();
                bool result = false;
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        int rowCounts = await connection.ExecuteAsync(sqlString, updateUserAndInsiderReq, transaction: tran);
                        if (rowCounts > 0) { result = true; }
                        tran.Commit();
                    }
                    catch (Exception exception)
                    {
                        tran.Rollback();
                        throw new Exception(exception.Message.ToString());
                    }
                }
                return result;
            }
        }

        public async Task<bool> PostUserAndStore(PostUserAndStoreReq postUserAndStoreReq)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
            {
                // 新增User主表
                string sqlString = @"Insert Into [dbo].[User] (UserId,UserKey,Email,Func,Status,Role,CreateDate)
                                    Values (@UserId,@UserKey,@Email,@Func,@Status,@Role,@CreateDate);";

                // 新增特店詳細資料子表
                sqlString += @"Insert Into [dbo].[Store] (Uid,FullName,ShortName,StoreData1,StoreData2)
                                Select A.Uid,'','','',''
                                From [dbo].[User] A
                                Where A.UserId = @UserId;";

                sqlString += @"Update T
                                Set T.FullName = @FullName,
	                                T.ShortName = @ShortName,
	                                T.StoreData1 = @StoreData1,
	                                T.StoreData2 = @StoreData2
                                From
                                (
	                                Select *
	                                From [dbo].[Store] A
	                                Where A.Uid = (Select A.Uid
					                                From [dbo].[User] A
					                                Where A.UserId = @UserId)
                                )T;";

                connection.Open();
                bool result = false;
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        int rowCounts = await connection.ExecuteAsync(sqlString, postUserAndStoreReq, transaction: tran);
                        if (rowCounts > 0) { result = true; }
                        tran.Commit();
                    }
                    catch (Exception exception)
                    {
                        tran.Rollback();
                        throw new Exception(exception.Message.ToString());
                    }
                    return result;
                }
            }
        }

        public async Task<IEnumerable<User>> GetUsersFilter(BusinessmanParams businessmanParams)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
            {
               
                string sqlString = @"Select *
                                    From [dbo].[User] A
                                    Where 1=1";

                if (!String.IsNullOrEmpty(businessmanParams.UserId))
                {
                    sqlString += "And A.UserId = @UserId ";
                }

                if (!String.IsNullOrEmpty(businessmanParams.Status))
                {
                    sqlString += "And A.Status = @Status ";
                }

                if (!String.IsNullOrEmpty(businessmanParams.Role))
                {
                    sqlString += "And A.Role = @Role ";
                }

                sqlString = sqlString.TrimEnd(' ');
                sqlString += ";";

                var users = await connection.QueryAsync<User>(sqlString, businessmanParams);

                return users;
            }
        }
    }
}
