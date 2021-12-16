using GodPay_CMS.Common.Enums;
using GodPay_CMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dapper;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Services.DTO;
using GodPay_CMS.Common.Helpers.Decipher;
using Microsoft.Extensions.Options;

namespace GodPay_CMS.Repositories.Implements
{
    public class FuncClassRepository : IFuncClassRepository
    {
        private readonly IDecipherHelper _decipherHelper;
        private readonly IOptionsSnapshot<SettingConfig> _settings;

        public FuncClassRepository(IDecipherHelper decipherHelper, IOptionsSnapshot<SettingConfig> settings)
        {
            _decipherHelper = decipherHelper;
            _settings = settings;
        }

        public async Task<bool> Add(FuncClass model)
        {
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @"INSERT INTO [dbo].[FuncClass](FuncClassEnName,FuncClassChName)
                                  VALUES (@FuncClassEnName,@FuncClassChName)";
                bool result = false;
                connection.Open();
                using (var tran = connection.BeginTransaction())
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

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FuncClass>> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                try
                {
                    string sql = @"SELECT *
                              FROM [IPASS].[dbo].[FuncClass]";
                    var funcClass = await connection.QueryAsync<FuncClass>(sql);
                    return funcClass.ToList();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }             
        }

        public async Task<FuncClass> GetById(string funcClassCode)
        {
            string sql = @"SELECT * FROM [IPASS].[dbo].[FuncClass]
                         WHERE FuncClassCode=@funcClassCode";
            using (IDbConnection connection =new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                try
                {
                    var funcClass = await connection.QuerySingleOrDefaultAsync<FuncClass>(sql,new { FuncClassCode = funcClassCode });
                    return funcClass;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public async Task<bool> Update(FuncClass funcClass)
        {
            bool result = false;
            string sql = @"UPDATE [dbo].[FuncClass]
                          SET FuncClassEnName=@FuncClassEnName,
                              FuncClassChName=@FuncClassChName
                          WHERE FuncClassCode=@FuncClassCode";
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                connection.Open();
                using(var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var rowCounts = await connection.ExecuteAsync(sql, funcClass, transaction: tran);
                        if (rowCounts > 0) { result = true; }
                        tran.Commit();
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message.ToString());
                    }
                }
                return result;
            }
        }

        public async Task<IEnumerable<FuncClass>> GetByFuncClassAndFunc()
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sqlString = @"Select * 
                                    From [dbo].[FuncClass] A
                                    Join [dbo].[Func] B on A.FuncClassCode = B.FuncClassCode";

                // 偽1對多
                var funcClass = await _connection.QueryAsync<FuncClass, Func, FuncClass>(sqlString, (funcClass, func) =>
                {
                    funcClass.Funcs.Add(func);
                    return funcClass;
                }, splitOn: "Fid");

                // 重做一份真1對多
                var result = funcClass.GroupBy(f => f.FuncClassCode).Select(g =>
                {
                    var groupedfuncClass = g.First();
                    groupedfuncClass.Funcs = g.Select(p => p.Funcs.Single()).ToList();
                    return groupedfuncClass;
                });

                return result;
            }
        }

        public async Task<IEnumerable<FuncClass>> GetByFuncClassAndFuncFilter(GetFuncFilterReq getFuncFilterReq)
        {
            using (IDbConnection _connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sqlString = @"Select * 
                                    From [dbo].[FuncClass] A
                                    Join [dbo].[Func] B on A.FuncClassCode = B.FuncClassCode
                                    Where 1=1";
                sqlString += "And B.RoleFlag & @Role <> 0 ";
                sqlString += "And B.FuncCode & @FuncFlag <> 0 ";

                if (!String.IsNullOrEmpty(getFuncFilterReq.IsWebSite))
                {
                    sqlString += "And B.IsWebsite = @IsWebSite ";
                }
                
                if (!String.IsNullOrEmpty(getFuncFilterReq.FuncClassEnName))
                {
                    sqlString += "And A.FuncClassEnName = @FuncClassEnName ";
                }

                sqlString = sqlString.TrimEnd(' ');
                sqlString += ";";

               // 偽1對多
               var funcClass = await _connection.QueryAsync<FuncClass, Func, FuncClass>(sqlString, (funcClass, func) =>
                {
                    funcClass.Funcs.Add(func);
                    return funcClass;
                }, getFuncFilterReq, splitOn: "Fid");

                // 重做一份真1對多
                var result = funcClass.GroupBy(f => f.FuncClassCode).Select(g =>
                {
                    var groupedfuncClass = g.First();
                    groupedfuncClass.Funcs = g.Select(p => p.Funcs.Single()).ToList();
                    return groupedfuncClass;
                });

                return result;
            }
        }

        public async Task<IEnumerable<UserAuthorityFuncClassRsp>> GetRoleAuthority(GetRoleAuthorityReq getRoleAuthorityReq)
        {
            using (IDbConnection connection = new SqlConnection(_decipherHelper.ConnDecryptorAES(_settings.Value.ConnectionSettings.IPASS)))
            {
                string sql = @"Select A.FuncClassCode,A.FuncClassChName,A.FuncClassEnName,
	                           B.Fid,B.FuncEnName,B.FuncChName,B.FuncCode,
	                         Case
	                          when (B.FuncCode & @FuncFlag) <> 0 then 1
	                          when (B.FuncCode & @FuncFlag) =  0 then 0 
	                         END  as  'IsAuthority'
                            From [dbo].[FuncClass] A
                            Join [dbo].[Func] B on A.FuncClassCode = B.FuncClassCode
                            Where B.RoleFlag & @Role <> 0";
                // 偽1對多
                var funcClass = await connection.QueryAsync<UserAuthorityFuncClassRsp, UserAuthorityFuncRsp, UserAuthorityFuncClassRsp>(sql, (funcClass, func) =>
                {
                    funcClass.UserAuthorityFuncRsps.Add(func);
                    return funcClass;
                }, getRoleAuthorityReq, splitOn: "Fid");

                // 重做一份真1對多
                var result = funcClass.GroupBy(f => f.FuncClassCode).Select(g =>
                {
                    var groupedfuncClass = g.First();
                    groupedfuncClass.UserAuthorityFuncRsps = g.Select(p => p.UserAuthorityFuncRsps.Single()).ToList();
                    return groupedfuncClass;
                });
                return result;
            }
        }
    }
}
