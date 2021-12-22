using AutoMapper;
using GodPay_CMS.Common.Enums;
using GodPay_CMS.Common.Helpers;
using GodPay_CMS.Controllers.Parameters;
using GodPay_CMS.Controllers.ViewModels;
using GodPay_CMS.Repositories.Entity;
using GodPay_CMS.Repositories.Interfaces;
using GodPay_CMS.Services.DTO;
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

        public async Task<ResponseViewModel> GetListOfFunctions()
        {
            var funcCalss = await _repostioryWrapper.funcClassRepository.GetByFuncClassAndFunc();

            if (funcCalss == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnData = "取得功能資料失敗" };

            var functionListViewModel = _mapper.Map<IEnumerable<AuthorityFuncClassRsp>>(funcCalss);

            return new ResponseViewModel() { RtnData = functionListViewModel };
        }

        public async Task<ResponseViewModel> GetListOfFunctionsFilter(FunctionParams functionParams)
        {
            var getFuncFilterReq = _mapper.Map<GetFuncFilterReq>(functionParams);
            getFuncFilterReq.Role = (int)(RoleEnum)Enum.Parse(typeof(RoleEnum), _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role).Value);
            getFuncFilterReq.FuncFlag = int.Parse(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "FuncFlag").Value);

            var funcCalss = await _repostioryWrapper.funcClassRepository.GetByFuncClassAndFuncFilter(getFuncFilterReq);

            if (funcCalss == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnData = "取得功能資料失敗" };

            var functionListViewModel = _mapper.Map<IEnumerable<AuthorityFuncClassRsp>>(funcCalss);

            return new ResponseViewModel() { RtnData = functionListViewModel };
        }

        public async Task<ResponseViewModel> UpdateRoleMaxAuthority(IEnumerable<UpdateAuthorityClassViewModel> updateAuthorityClassViewModels)
        {
            if (updateAuthorityClassViewModels.Count() == 0)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.AuthenticationLogicFail, RtnData = "修改角色資訊個數不能為0" };

            // 取得原資料與新資料做差異對比
            var funcCalsses = await _repostioryWrapper.funcClassRepository.GetByFuncClassAndFunc();
            List<UpdateRoleAuthorityReq> oldAuthority = new List<UpdateRoleAuthorityReq>();
            foreach (var funClass in funcCalsses)
            {
                oldAuthority.AddRange(_mapper.Map<IEnumerable<UpdateRoleAuthorityReq>>(funClass.Funcs));
            }

            List<UpdateRoleAuthorityReq> newAuthority = new List<UpdateRoleAuthorityReq>();
            foreach (var funClass in updateAuthorityClassViewModels)
            {
                newAuthority.AddRange(_mapper.Map<IEnumerable<UpdateRoleAuthorityReq>>(funClass.UpdateFuncViewModel));
            }
            var updateRoleAuthorityReqs = newAuthority.Where(c => !oldAuthority.Any(n => n.Fid == c.Fid && n.FuncCode == c.FuncCode && n.RoleFlag == c.RoleFlag));

            var result =  await _repostioryWrapper.funcRepository.BatchUpdateRoleFlag(updateRoleAuthorityReqs);
            if (result)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.Ok, RtnData = "修改角色最大權限成功" };
            else
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.ExecutionFail, RtnData = "修改角色最大權限失敗" };
        }

        public async Task<ResponseViewModel> GetListOfFuncClass()
        {
            var allFunc = await _repostioryWrapper.funcClassRepository.GetAll();
            if (allFunc == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.GetFail, RtnData = "查無資料" };
            var allFuncRsp = _mapper.Map<IEnumerable<FuncClassRsp>>(allFunc);
            return new ResponseViewModel() { RtnData = allFuncRsp };
        }

        public async Task<ResponseViewModel> PostFuncClass(PostFuncClassViewModel postFuncClassViewModel)
        {
            var funClass = _mapper.Map<FuncClass>(postFuncClassViewModel);
            var response = await _repostioryWrapper.funcClassRepository.Add(funClass);
            if(response)
                return new ResponseViewModel { RtnCode = ReturnCodeEnum.Ok, RtnMessage = "新增成功" };
            return new ResponseViewModel { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "執行失敗" };
        }

        public async Task<ResponseViewModel> GetFuncClassDetailById(string funcCode)
        {
            var response = await _repostioryWrapper.funcClassRepository.GetById(funcCode);
            if(response==null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnData = "查無資料" };
            var funcClassRsp = _mapper.Map<FuncClassRsp>(response);
            return new ResponseViewModel() { RtnData = funcClassRsp };

        }

        public async Task<ResponseViewModel> UpdateFuncClass(UpdateFuncClassViewModel updateFuncClassViewModel)
        {
            var funcClass = _mapper.Map<FuncClass>(updateFuncClassViewModel);
            var response = await _repostioryWrapper.funcClassRepository.Update(funcClass);
            if (response)
                return new ResponseViewModel { RtnCode = ReturnCodeEnum.Ok, RtnMessage = "修改成功" };
            return new ResponseViewModel { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "執行失敗" };
        }

        public async Task<ResponseViewModel> GetListOfFunc()
        {
            var allFunc = await _repostioryWrapper.funcRepository.GetByFuncClassAndFunc();
            if (allFunc == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnData = "查無資料" };
            var allFuncRsp = _mapper.Map<IEnumerable<FuncAndFuncClassRsp>>(allFunc);
            return new ResponseViewModel() { RtnData = allFuncRsp };
        }

        public async Task<ResponseViewModel> GetFuncDetailById(int fid)
        {
            var response = await _repostioryWrapper.funcRepository.GetById(fid);
            if (response == null)
                return new ResponseViewModel() { RtnCode = ReturnCodeEnum.NotFound, RtnData = "查無資料" };
            var funcRsp = _mapper.Map<FuncRsp>(response);
            return new ResponseViewModel() { RtnData = response };
        }

        public async Task<ResponseViewModel> UpdateFunc(UpdateFuncViewModel updateFuncViewModel)
        {
            var isExsit = _repostioryWrapper.funcClassRepository.GetById(updateFuncViewModel.FuncClassCode);
            if (isExsit == null)
                return new ResponseViewModel { RtnCode = ReturnCodeEnum.GetFail, RtnMessage = "此代碼並不存在" };
            updateFuncViewModel.FuncEnName = updateFuncViewModel.FuncEnName.ToUpperForFirst();           
            var func = _mapper.Map<Func>(updateFuncViewModel);
            var response = await _repostioryWrapper.funcRepository.Update(func);
            if(response)
                return new ResponseViewModel { RtnCode = ReturnCodeEnum.Ok, RtnMessage = "修改成功" };
            return new ResponseViewModel { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "執行失敗" };
        }

        public async Task<ResponseViewModel> PostFunc(PostFuncViewModel postFuncViewModel)
        {
            var isExsit = _repostioryWrapper.funcClassRepository.GetById(postFuncViewModel.FuncClassCode);
            if(isExsit==null)
                return new ResponseViewModel { RtnCode = ReturnCodeEnum.GetFail, RtnMessage = "此代碼並不存在" };
            postFuncViewModel.FuncEnName = postFuncViewModel.FuncEnName.ToUpperForFirst();
            var func = _mapper.Map<Func>(postFuncViewModel);
            var response = await _repostioryWrapper.funcRepository.Add(func);
            if (response)
                return new ResponseViewModel { RtnCode = ReturnCodeEnum.Ok, RtnMessage = "新增成功" };
            return new ResponseViewModel { RtnCode = ReturnCodeEnum.ExecutionFail, RtnMessage = "執行失敗" };
        }
    }
}
