using AutoMapper;
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
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Common.Helpers.Decipher;
using Microsoft.Extensions.Options;

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

        public Task<bool> Add(Func model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Func>> GetAll()
        {
            string sql = @"SELECT * 
                         FROM [dbo].[Func]";
            using(IDbConnection connection=new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                try
                {
                    var func = await connection.QueryAsync<Func>(sql);
                    return func.ToList();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
        public async Task<Func> GetById(int fid)
        {
            string sql = @"SELECT * 
                        FROM [dbo].[Func]
                        WHERE Fid=@Fid";
            using (IDbConnection connection=new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                try
                {
                    var func = await connection.QueryFirstOrDefaultAsync<Func>(sql, new { Fid = fid });
                    return func;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public Task<bool> Update(Func mdoel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Func>> GetByFuncClassAndFunc()
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                var Role = (RoleEnum)Enum.Parse(typeof(RoleEnum), _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role).Value);

                string sqlString = @"Select * 
                                    From [dbo].[Func] A
                                    Join [dbo].[FuncClass]	B on A.FuncClassCode = B.FuncClassCode
                                    Where A.Role = @Role ";

                var funcs = await _connection.QueryAsync<Func, FuncClass, Func>(sqlString, (func, funcClass) =>
                {
                    func.FuncClass = funcClass;
                    return func;
                }, new { Role = Role }, splitOn: "FuncClassCode");

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
