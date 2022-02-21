using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO.Response;
using GodPay_CMS.Services.DTO.Request;
using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.Implements
{
    public class AuthorityService : IAuthorityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepostioryWrapper _repostioryWrapper;
        private readonly IMapper _mapper;
        public AuthorityService(IRepostioryWrapper repostioryWrapper, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _repostioryWrapper = repostioryWrapper;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel> GetListOfFunctionsForAuthority()
        {
            var funcCalss = await _repostioryWrapper.funcClassRepository.GetAllByFuncClassAndFunc();
           
            var functionListViewModel = _mapper.Map<IEnumerable<AuthorityFuncClassRsp>>(funcCalss);

            return new ResponseViewModel() { RtnData = functionListViewModel };
        }

        public async Task<ResponseViewModel> GetListOfFunctionsFilter(FunctionParams functionParams)
        {
            var getFuncFilterReq = _mapper.Map<GetByFuncClassAndFuncFilterReq>(functionParams);
            getFuncFilterReq.Role = (int)(RoleEnum)Enum.Parse(typeof(RoleEnum), _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role).Value);
            getFuncFilterReq.FuncFlag = int.Parse(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "FuncFlag").Value);

            var funcCalss = await _repostioryWrapper.funcClassRepository.GetByFuncClassAndFuncFilter(getFuncFilterReq);

            var functionListViewModel = _mapper.Map<IEnumerable<AuthorityFuncClassRsp>>(funcCalss);

            return new ResponseViewModel() { RtnData = functionListViewModel };
        }

        public async Task<ResponseViewModel> UpdateRoleMaxAuthority(IEnumerable<PutAuthorityClassReq> putAuthorityClassReq)
        {
            if (putAuthorityClassReq.Count() == 0)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnMessage= ReturnCodeEnum.AuthenticationLogicFail.GetEnumDescription(), RtnData = "修改角色資訊個數不能為0" };

            // 取得原資料與新資料做差異對比
            var funcCalsses = await _repostioryWrapper.funcClassRepository.GetAllByFuncClassAndFunc();
            List<Func> oldAuthority = new List<Func>();
            foreach (var funClass in funcCalsses)
            {
                oldAuthority.AddRange(_mapper.Map<IEnumerable<Func>>(funClass.Funcs));
            }

            List<Func> newAuthority = new List<Func>();
            foreach (var funClass in putAuthorityClassReq)
            {
                newAuthority.AddRange(_mapper.Map<IEnumerable<Func>>(funClass.PutAuthorityFuncRequests));
            }
            var updateRoleAuthorityReqs = newAuthority.Where(c => !oldAuthority.Any(n => n.Fid == c.Fid && n.FuncCode == c.FuncCode && n.RoleFlag == c.RoleFlag));
            
            if (updateRoleAuthorityReqs.Count() == 0)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnMessage = ReturnCodeEnum.AuthenticationLogicFail.GetEnumDescription(), RtnData = "與原權限相同，不做修改" };

            var result =  await _repostioryWrapper.funcRepository.BatchUpdateRoleFlag(updateRoleAuthorityReqs);
            if (result)
                return new ResponseViewModel();
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail,RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };
        }

        public async Task<ResponseViewModel> GetListOfFuncClass()
        {
            var allFunc = await _repostioryWrapper.funcClassRepository.GetAll();

            return new ResponseViewModel() { RtnData = allFunc };
        }

        public async Task<ResponseViewModel> PostFuncClass(PostFuncClassReq postFuncClassReq)
        {
            var funClass = _mapper.Map<FuncClass>(postFuncClassReq);
            var response = await _repostioryWrapper.funcClassRepository.Add(funClass);
            if(response)
                return new ResponseViewModel { RtnCode = ReturnCodeEnum.Ok, RtnMessage = ReturnCodeEnum.Ok.GetEnumDescription() };
            return new ResponseViewModel { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription()};
        }

        public async Task<ResponseViewModel> GetFuncClassDetailById(string funcCode)
        {
            var response = await _repostioryWrapper.funcClassRepository.GetById(funcCode);
            if(response==null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };
            var funcClassRsp = _mapper.Map<FuncClassRsp>(response);
            return new ResponseViewModel() { RtnData = funcClassRsp };

        }

        public async Task<ResponseViewModel> UpdateFuncClass(PutFuncClassReq putFuncClassReq)
        {
            var funcClass = _mapper.Map<FuncClass>(putFuncClassReq);
            var response = await _repostioryWrapper.funcClassRepository.Update(funcClass);
            if (response)
                return new ResponseViewModel { RtnCode = ReturnCodeEnum.Ok, RtnMessage = ReturnCodeEnum.Ok.GetEnumDescription() };
            return new ResponseViewModel { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };
        }

        public async Task<ResponseViewModel> GetListOfFunc()
        {
            var allFunc = await _repostioryWrapper.funcRepository.GetByFuncClassAndFunc();
            if (allFunc == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };
            var allFuncRsp = _mapper.Map<IEnumerable<FuncAndFuncClassRsp>>(allFunc);
            return new ResponseViewModel() { RtnData = allFuncRsp };
        }

        public async Task<ResponseViewModel> GetFuncDetailById(int fid)
        {
            var response = await _repostioryWrapper.funcRepository.GetById(fid);
            if (response == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnMessage = ReturnCodeEnum.NotFound.GetEnumDescription() };
            var funcRsp = _mapper.Map<FuncRsp>(response);
            return new ResponseViewModel() { RtnData = funcRsp };
        }

        public async Task<ResponseViewModel> UpdateFunc(PutFuncReq putFuncReq)
        {
            var isExsit = await _repostioryWrapper.funcClassRepository.GetById(putFuncReq.FuncClassCode);
            if (isExsit == null)
                return new ResponseViewModel { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnMessage= ReturnCodeEnum.AuthenticationLogicFail.GetEnumDescription(), RtnData = "此代碼並不存在" };

            putFuncReq.FuncEnName = putFuncReq.FuncEnName.ToUpperForFirst();           
            var func = _mapper.Map<Func>(putFuncReq);
            var response = await _repostioryWrapper.funcRepository.Update(func);
            
            if(response)
                return new ResponseViewModel { RtnCode = ReturnCodeEnum.Ok, RtnMessage = ReturnCodeEnum.Ok.GetEnumDescription() };
            return new ResponseViewModel { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };
        }

        public async Task<ResponseViewModel> PostFunc(PostFuncReq postFuncReq)
        {
            var isExsit = await _repostioryWrapper.funcClassRepository.GetById(postFuncReq.FuncClassCode);
            if(isExsit==null)
                return new ResponseViewModel { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnMessage = ReturnCodeEnum.AuthenticationLogicFail.GetEnumDescription(), RtnData = "此代碼並不存在" };
            postFuncReq.FuncEnName = postFuncReq.FuncEnName.ToUpperForFirst();
            var func = _mapper.Map<Func>(postFuncReq);
            var response = await _repostioryWrapper.funcRepository.Add(func);
            if (response)
                return new ResponseViewModel { RtnCode = ReturnCodeEnum.Ok, RtnMessage = ReturnCodeEnum.Ok.GetEnumDescription() };
            return new ResponseViewModel { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = ReturnCodeEnum.ExecutionFail.GetEnumDescription() };
        }
    }
}
