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

namespace GodPay_CMS.Repositories.Implements
{
    public class FuncClassRepository : IFuncClassRepository
    {
        private readonly IConfiguration _config;
        public FuncClassRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<bool> Add(FuncClass model)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
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
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
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

        public Task<FuncClass> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(FuncClass mdoel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FuncClass>> GetByFuncClassAndFunc()
        {
            using (IDbConnection _connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
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
            using (IDbConnection _connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
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
    }
}
