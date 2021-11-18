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
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public FuncRepository(IHttpContextAccessor httpContextAccessor, IMapper mapper, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _config = config;
        }

        public Task<bool> Add(FuncRsp model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FuncRsp>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<FuncRsp> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(FuncRsp mdoel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得功能列表 (1對1)
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<FuncRsp>> GetByFuncClassAndFunc()
        {
            using (IDbConnection _connection = new SqlConnection(_config.GetConnectionString("IPASS_Conn")))
            {
                var  Role = (RoleEnum)Enum.Parse(typeof(RoleEnum), _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role).Value);

                string sqlString = @"Select * 
                                    From [dbo].[Func] A
                                    Join [dbo].[FuncClass]	B on A.FuncClassCode = B.FuncClassCode
                                    Where A.Role = @Role ";

                var funcs = await _connection.QueryAsync<Func,FuncClass,Func>(sqlString, (func,funcClass) =>
                            {
                                func.FuncClass = funcClass;
                                return func;
                            }, new { Role = Role }, splitOn: "FuncClassCode");

                var funcRsp =_mapper.Map<IEnumerable<FuncRsp>>(funcs);

                return funcRsp;
            }
        }

    }
}
