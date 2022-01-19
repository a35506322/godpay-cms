using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Common.Helpers.Decipher;
using Microsoft.Extensions.Options;
using GodPay_CMS.Common;

namespace GodPay_CMS.Repositories.Implements
{
    public class FuncRepository : IFuncRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDecipherHelper _decipherHelper;
        private readonly IOptionsSnapshot<SettingConfig> _settings;
        public FuncRepository(IHttpContextAccessor httpContextAccessor,IDecipherHelper decipherHelper, IOptionsSnapshot<SettingConfig> settings)
        {
            _httpContextAccessor = httpContextAccessor;
            _decipherHelper = decipherHelper;
            _settings = settings;
        }

        public async Task<bool> Add(Func model)
        {
            bool result=false;
            string sql = @"INSERT INTO [dbo].[Func](FuncClassCode,FuncEnName,FuncChName,RoleFlag,IsWebSite)
                         VALUES(@FuncClassCode,@FuncEnName,@FuncChName,@RoleFlag,@IsWebSite)";
            using(IDbConnection connection=new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                connection.Open();
                using(var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var response = await connection.ExecuteAsync(sql, model, transaction: tran);
                        if (response > 0) { result = true; }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message.ToString());
                    }
                    return result;                
                }
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Func>> GetAll()
        {
            string sql = @"SELECT * 
                         FROM [dbo].[Func]";
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                var func = await connection.QueryAsync<Func>(sql);
                return func.ToList();
            }
        }

        public async Task<Func> GetById(int fid)
        {
            string sql = @"SELECT * 
                        FROM [dbo].[Func]
                        WHERE Fid=@Fid";
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                var func = await connection.QueryFirstOrDefaultAsync<Func>(sql, new { Fid = fid });
                return func;
            }
        }

        public async Task<bool> Update(Func func)
        {
            bool result = false;
            string sql = @"UPDATE [dbo].[Func]
                           SET FuncClassCode=@FuncClassCode,
                               FuncEnName=@FuncEnName,
                               FuncChName=@FuncChName,
                               IsWebSite=@IsWebSite
                           WHERE Fid=@Fid";
            using(IDbConnection connection=new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var rowCount = await connection.ExecuteAsync(sql, func, transaction: tran);
                        if (rowCount > 0) { result = true; }
                        tran.Commit();
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                            throw ex;
                    }
                }
                return result;
            }
        }

        public async Task<IEnumerable<Func>> GetByFuncClassAndFunc()
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sqlString = @"Select * 
                                    From [dbo].[Func] A
                                    Join [dbo].[FuncClass]	B on A.FuncClassCode = B.FuncClassCode
                                    Order By B.FuncClassCode";
                var funcs = await _connection.QueryAsync<Func, FuncClass, Func>(sqlString, (func, funcClass) =>
                {
                    func.FuncClass = funcClass;
                    return func;
                }, splitOn: "FuncClassCode");
                return funcs;
            }
        }

        public async Task<bool> BatchUpdateRoleFlag(IEnumerable<UpdateRoleAuthorityReq> updateRoleAuthorityReqs)
        {
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sqlString = @"Update T
                                    Set	    T.RoleFlag = @RoleFlag
                                    From 
                                    (
	                                    Select * 
	                                    From [dbo].[Func] A
	                                    Where A.Fid = @Fid
                                    )T;

                                    Update T2
                                    Set	   T2.Func = T2.Func - @FuncCode
                                    From 
                                    (
	                                    Select *
	                                    From [dbo].[User] A
	                                    Where A.Role & @RoleFlag = 0
	                                    And A.Func & @FuncCode <> 0
                                    )T2;";
                connection.Open();
                using (var tran = connection.BeginTransaction())
                {
                    bool result = false;
                    try
                    {
                        int rowConunts = await connection.ExecuteAsync(sqlString, updateRoleAuthorityReqs, transaction: tran);
                        if (rowConunts > 0)
                            result = true;
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
    }
}
