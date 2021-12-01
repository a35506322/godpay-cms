using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
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

namespace GodPay_CMS.Repositories.Implements
{
    public class FuncClassRepository : IFuncClassRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public FuncClassRepository(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _config = config;
        }
        public Task<bool> Add(FuncClass model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FuncClass>> GetAll()
        {
            throw new NotImplementedException();
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
               var Role = (RoleEnum)Enum.Parse(typeof(RoleEnum), _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role).Value);

                string sqlString = @"Select * 
                                    From [dbo].[FuncClass] A
                                    Join [dbo].[Func] B on A.FuncClassCode = B.FuncClassCode
                                    Where B.RoleFlag & @Role <> 0";

                // 偽1對多
                var funcClass = await _connection.QueryAsync<FuncClass, Func, FuncClass>(sqlString, (funcClass, func) =>
                {
                    funcClass.Funcs.Add(func);
                    return funcClass;
                }, new { Role = Role }, splitOn: "Fid");

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
