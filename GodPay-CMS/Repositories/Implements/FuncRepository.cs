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

namespace GodPay_CMS.Repositories.Implements
{
    public class FuncRepository : IFuncRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        public FuncRepository(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public Task<bool> Add(Func model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Func>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<Func> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Func mdoel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Func>> GetByFuncClassAndFunc()
        {
            using (IDbConnection _connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
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
    }
}
