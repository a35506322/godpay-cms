using Dapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using GodPay_CMS.Common.Util;
using GodPay_CMS.Common.Helpers.Decipher;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace GodPay_CMS.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly IDecipherHelper _decipherHelper;
        private readonly IOptionsSnapshot<SettingConfig> _settings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(IDecipherHelper decipherHelper, IOptionsSnapshot<SettingConfig> settings, IHttpContextAccessor httpContextAccessor)
        {
            _decipherHelper = decipherHelper;
            _settings = settings;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Add(User model)
        {
            string sqlString = @"Insert into [dbo].[User] (UserId,UserKey,Email,Role,Func,Status,CreateDate)
                                Values(@UserId,@UserKey,@Email,@Role,@Func,@Status,@CreateDate)";

            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                bool result = false;
                try
                {
                    var rowCount = await connection.ExecuteAsync(sqlString, model);
                    result = rowCount > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;
            }
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

        public async Task<User> GetByUserIdAndUserKey(User userReq)
        {
            userReq.UserKey = RNGCrypto.HMACSHA256(userReq.UserKey, userReq.UserId);

            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @"SELECT * FROM [dbo].[User] 
                               WHERE UserId = @UserId 
                               AND UserKey  = @UserKey";
                var entity = await _connection.QuerySingleOrDefaultAsync<User>(sql, userReq);

                if (entity == null)
                    return null;

                return entity;
            }
        }

        public async Task<int> UpdateLoginTime(User userReq)
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @" UPDATE [dbo].[User] 
                                SET LastLoginDate = GETDATE()
                                WHERE UserId = @UserId";

                var entity = await _connection.ExecuteAsync(sql, userReq);
                return entity;
            }
        }

        public async Task<User> GetByUserId(string userId)
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @"SELECT * FROM [dbo].[User]
                               WHERE UserId = @UserId";
                var entity = await _connection.QuerySingleOrDefaultAsync<User>(sql, new { UserId = userId });

                if (entity == null)
                    return null;

                return entity;
            }
        }

        public async Task<int> UpdateUser(UpdateUserReq updateUserReq)
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
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

        public async Task<int> UpdateKey(EditKeyViewModel editKeyViewModel)
        {
            editKeyViewModel.NewKey = RNGCrypto.HMACSHA256(editKeyViewModel.NewKey, editKeyViewModel.UserId);

            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @" UPDATE [dbo].[User] 
                                SET UserKey = @NewKey, 
                                    LastChangePwdDate = GETDATE()
                                WHERE UserId = @UserId";

                var entity = await _connection.ExecuteAsync(sql, editKeyViewModel);
                return entity;
            }
        }

        public async Task<bool> PostUserAndInsider(PostUserAndInsiderReq userAndInsiderReq)
        {
            userAndInsiderReq.UserKey = RNGCrypto.HMACSHA256("p@ssw0rd", userAndInsiderReq.UserId);
            userAndInsiderReq.Role = RoleEnum.Manager;
            userAndInsiderReq.Func = 1795;
            userAndInsiderReq.Status = AccountStatusEnum.Activate;
            userAndInsiderReq.CreateDate = DateTime.Now;

            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
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
                        int rowCounts = await connection.ExecuteAsync(sqlString, userAndInsiderReq, transaction: tran);
                        if (rowCounts > 0) { result = true; }
                        tran.Commit();
                    }
                    catch (Exception exception)
                    {
                        tran.Rollback();
                        throw exception;
                    }
                    return result;
                }
            }
        }

        public async Task<IEnumerable<User>> GetUserAndInsiderByUserId(string userId)
        {
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
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
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
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
                        throw exception;
                    }
                }
                return result;
            }
        }

        public async Task<bool> PostUserAndStore(PostUserAndStoreReq postUserAndStoreReq)
        {
            postUserAndStoreReq.UserKey = RNGCrypto.HMACSHA256("p@ssw0rd", postUserAndStoreReq.UserId);
            postUserAndStoreReq.Role = RoleEnum.Store;
            postUserAndStoreReq.Func = 14339;
            postUserAndStoreReq.Status = AccountStatusEnum.Activate;
            postUserAndStoreReq.CreateDate = DateTime.Now;
            postUserAndStoreReq.StoreId = Guid.NewGuid();

            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                // 新增User主表
                string sqlString = @"Insert Into [dbo].[User] (UserId,UserKey,Email,Func,Status,Role,CreateDate)
                                    Values (@UserId,@UserKey,@Email,@Func,@Status,@Role,@CreateDate);";

                // 新增特店詳細資料子表
                sqlString += @"Insert Into [dbo].[Customer_Store] (Uid,CustomerId,StoreId,StoreName,TaxId,Owner,Address,Risk,TransLimit,OwnerEmail)
                                Select A.Uid,@CustomerId,@StoreId,@StoreName,@TaxId,@Owner,@Address,'B',500000.0000,@OwnerEmail
                                From [dbo].[User] A
                                Where A.UserId = @UserId;";

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
                        throw exception;
                    }
                    return result;
                }
            }
        }

        public async Task<IEnumerable<User>> GetUsersFilter(UserParams userParams)
        {
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {

                string sqlString = @"Select *
                                    From [dbo].[User] A
                                    Where 1=1";

                if (!String.IsNullOrEmpty(userParams.UserId))
                {
                    sqlString += "And A.UserId = @UserId ";
                }

                if (!String.IsNullOrEmpty(userParams.Status))
                {
                    sqlString += "And A.Status = @Status ";
                }

                if (userParams.Role != 0)
                {
                    sqlString += "And A.Role = @Role ";
                }

                sqlString = sqlString.TrimEnd(' ');
                sqlString += ";";

                var users = await connection.QueryAsync<User>(sqlString, userParams);

                return users;
            }
        }

        public async Task<IEnumerable<User>> GetUserAndStoreByUserId(string userId)
        {
            string sql = @"Select *
                         From [dbo].[User] U
                         Join [dbo].[Customer_Store] S
                         On U.Uid=S.Uid
                         Where U.UserId=@userId";
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                var users = await connection.QueryAsync<User, Store, User>(sql, (user, store) =>
                {
                    user.Store = store;
                    return user;
                }, new { userId = userId }, splitOn: "SeqNo");
                return users;
            }
        }

        public async Task<bool> UpateUserAndStore(UpdateUserAndStoreReq updateUserAndStoreReq)
        {
            string sql = @"Update T
                                    SET T.Status = @Status,
	                                    T.Email = @Email,
	                                    T.LastModifier = @LastModifier,
	                                    T.LastModifyDate = @LastModifyDate
                                    From
                                    (
                                        Select U.Status, U.Email, U.LastModifier, U.LastModifyDate
                                        From [dbo].[User] U
                                        Where U.Uid = @Uid
                                    )T;

                                    Update T2
                                    SET T2.StoreName = @StoreName,
	                                    T2.TaxId = @TaxId,
                                        T2.Owner = @Owner,
                                        T2.Address = @Address,
                                        T2.OwnerEmail = @OwnerEmail,
                                        T2.CustomerId = @CustomerId
                                    From
                                    (
                                        Select S.StoreName, S.TaxId, S.Owner, S.Address, S.OwnerEmail,S.CustomerId
                                        From [dbo].[Customer_Store] S
                                        Where S.Uid = @Uid
                                    )T2;";
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                bool result = false;
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var response = await connection.ExecuteAsync(sql, updateUserAndStoreReq, transaction: tran);
                        if (response > 0)
                            result = true;
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception (ex.ToString());
                    }
                    return result;
                }
            }
        }

        public async Task<bool> UpdateUserAuthority(User updateUserAuthorityReq)
        {
            string sqlString = @"Update T
                                Set	T.Func = @Func,
                                        T.LastModifier = @LastModifier,
                                        T.LastModifyDate = @LastModifyDate
                                From
                                (
	                                Select *
	                                From [dbo].[User] A
	                                Where A.Uid = @Uid
                                )T";

            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                bool result = false;
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var rowCount = await connection.ExecuteAsync(sqlString, updateUserAuthorityReq, transaction: tran);
                        result = rowCount > 0 ? true : false;
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.ToString());
                    }
                }
                return result;
            }
        }

        public async Task<bool> PostStorePersonnel(User user)
        {
            string insertUser = @"Insert into [dbo].[User] (UserId,UserKey,Email,Role,Func,Status,CreateDate)
                                    Values(@UserId,@UserKey,@Email,@Role,@Func,@Status,@CreateDate)";
            insertUser += "Select CAST(SCOPE_IDENTITY() as int)";

            string insertPersonnel = @"Insert into [dbo].[Customer_Personnel](Uid,StoreId)
                                        Values(@Uid,@StoreId)";

            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                bool result = false;
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var userId = await connection.QueryAsync<int>(insertUser, user, transaction:tran);
                        var rowCount = await connection.ExecuteAsync(insertPersonnel, new { Uid = userId.FirstOrDefault() , StoreId = user.Personnel.StoreId }, transaction: tran);
                        result = rowCount > 0 ? true : false;
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.ToString());
                    }
                    return result;
                }
            }

        }

        public async Task<bool> UpdateStorePersonnel(User user)
        {
            string sqlString = @"Update T
                                Set	T.Email = @Email,
	                                T.Status = @Status
                                From
                                (
	                                Select *
	                                From [dbo].[User] A
	                                Where A.UserId = @UserId
                                )T";

            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                bool result = false;
                try
                {
                    var rowCount = await connection.ExecuteAsync(sqlString, user);
                    result = rowCount > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                return result;
            }
        }
    }
}
