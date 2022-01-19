﻿import axios from './Axios.js'

// SigninApiController
export const PostSignin = data => axios.post('/SigninApi/SignIn', data).then(respone => { console.log(' PostSignin'); return respone; }).catch(error => error);

// ProfileApiController
export const GetUserById = query => axios.get('/ProfileApi/Get', query).then(respone => { console.log('GetUserById'); return respone; }).catch(error => error);
export const EditUser = data => axios.post('/ProfileApi/Edit', data).then(respone => { console.log('EditUser'); return respone; }).catch(error => error);
export const EditKey = data => axios.post('/ProfileApi/EditKey', data).then(respone => { console.log('EditKey'); return respone; }).catch(error => error);
export const GetStoreProfile = (query) => axios.get('/ProfileApi/GetStoreDeatil', query).then(respone => { console.log('GetStoreDeatil'); return respone; }).catch(error => error);
export const UpateStore = data => axios.put('/ProfileApi/UpdateStoreDeatil', data).then(respone => { console.log('UpateStore'); return respone; }).catch(error => error);

// ManagerSetApiController
export const GetManagerAll = () => axios.get('/ManagerSetApi/GetManagerAll').then(respone => { console.log(' GetManagerAll'); return respone; }).catch(error => error);
export const GetManagerDeatil = query => axios.get('/ManagerSetApi/GetManagerDeatil', query).then(respone => { console.log('GetManagerDeatil'); return respone; }).catch(error => error);
export const PostManagerAndInsider = data => axios.post('/ManagerSetApi/PostManagerAndInsider', data).then(respone => { console.log('PostManagerAndInsider'); return respone; }).catch(error => error);
export const UpdateManagerAndInsider = data => axios.put('/ManagerSetApi/UpdateManagerAndInsider', data).then(respone => { console.log('UpdateManagerAndInsider'); return respone; }).catch(error => error);
export const GetManager = query => axios.get('/ManagerSetApi/GetManager', query).then(respone => { console.log('GetManager'); return respone; }).catch(error => error);
export const GetManagerAuthority = query => axios.get('/ManagerSetApi/GetManagerAuthority', query).then(respone => { console.log('GetManagerAuthority'); return respone; }).catch(error => error);
export const UpdateManagerAuthority = data => axios.put('/ManagerSetApi/UpdateManagerAuthority', data).then(respone => { console.log('UpdateManagerAuthority'); return respone; }).catch(error => error);

// StoreSetApi
export const GetStores = () => axios.get('/StoreSetApi/GetStores').then(respone => { console.log(' StoreSetApi'); return respone; }).catch(error => error);
export const GetStoreDetail = (query) => axios.get('/StoreSetApi/GetStoreDeatil', query).then(respone => { console.log('GetStoreDeatil'); return respone; }).catch(error => error);
export const PostUserAndStore = data => axios.post('/StoreSetApi/PostUserAndStore', data).then(respone => { console.log('PostUserAndStore'); return respone; }).catch(error => error);
export const GetStore = (query) => axios.get('/StoreSetApi/GetStore', query).then(respone => { console.log('GetStore'); return respone; }).catch(error => error);
export const UpateUserAndStore = data => axios.post('/StoreSetApi/UpateUserAndStore', data).then(respone => { console.log('UpateUserAndStore'); return respone; }).catch(error => error);
export const GetStoreAuthority = query => axios.get('/StoreSetApi/GetStoreAuthority', query).then(respone => { console.log('GetStoreAuthority'); return respone; }).catch(error => error);
export const UpdateStoreAuthority = data => axios.put('/StoreSetApi/UpdateStoreAuthority', data).then(respone => { console.log('UpdateStoreAuthority'); return respone; }).catch(error => error);

// EnumApi
export const GetRoleEnum = () => axios.get('/EnumApi/GetRoleEnum').then(respone => { console.log('GetRoleEnum'); return respone; }).catch(error => error);
export const GetAccountStatusEnum = () => axios.get('/EnumApi/GetAccountStatusEnum').then(respone => { console.log('GetAccountStatusEnum'); return respone; }).catch(error => error);

// AuthoritySetApi
export const GetListOfFunctionsForAuthority = () => axios.get('/AuthoritySetApi/GetListOfFunctionsForAuthority').then(respone => { console.log('GetListOfFunctionsForAuthority'); return respone; }).catch(error => error);
export const GetListOfFunctionFilter = query => axios.get('/AuthoritySetApi/GetListOfFunctionFilter', query).then(respone => { console.log('GetListOfFunctionFilter'); return respone; }).catch(error => error);
export const UpdateRoleMaxAuthority = data => axios.put('/AuthoritySetApi/UpdateRoleMaxAuthority', data).then(respone => { console.log('UpdateRoleMaxAuthority'); return respone; }).catch(error => error);
export const GetListOfFuncClass = () => axios.get('/AuthoritySetApi/GetListOfFuncClass').then(respone => { console.log('GetListOfFuncClass'); return respone; }).catch(error => error);
export const PostFuncClass = data => axios.post('/AuthoritySetApi/PostFuncClass', data).then(respone => { console.log('PostFuncClass'); return respone; }).catch(error => error);
export const GetFuncClassDetailById = data => axios.get(`/AuthoritySetApi/GetFuncClassDetailById`, data).then(respone => { console.log('GetFuncClassDetailById'); return respone; }).catch(error => error);
export const UpdateFuncClass = data => axios.put('/AuthoritySetApi/UpdateFuncClass', data).then(respone => { console.log('UpdateFuncClass'); return respone; }).catch(error => error);
export const GetListOfFunc = () => axios.get('/AuthoritySetApi/GetListOfFunc').then(respone => { console.log('GetListOfFunc'); return respone; }).catch(error => error);
export const GetFuncDetailById = query => axios.get('/AuthoritySetApi/GetFuncDetailById', query).then(respone => { console.log('GetFuncDetailById'); return respone; }).catch(error => error);
export const UpdateFunc = data => axios.put('/AuthoritySetApi/UpdateFunc', data).then(respone => { console.log('UpdateFunc'); return respone; }).catch(error => error);
export const PostFunc = data => axios.post('/AuthoritySetApi/PostFunc', data).then(respone => { console.log('UpdateFunc'); return respone; }).catch(error => error);

// CustomerApi
export const GetCustomers = () => axios.get('/CustomerApi/GetAll').then(respone => { console.log('GetCustomers'); return respone; }).catch(error => error);
export const PostCustomer = data => axios.post('/CustomerApi/Post', data).then(respone => { console.log('PostCustomer'); return respone; }).catch(error => error);
export const UpdateCustomer = data => axios.put('/CustomerApi/Edit', data).then(respone => { console.log('UpdateCustomer'); return respone; }).catch(error => error);

//PersonnelSetApi
export const GetStorePersonnels = () => axios.get('/PersonnelSetApi/GetStorePersonnels').then(respone => { console.log('GetStorePersonnels'); return respone; }).catch(error => error);
export const PostStorePersonnel = data => axios.post('/PersonnelSetApi/PostStorePersonnel', data).then(respone => { console.log('PostStorePersonnel'); return respone; }).catch(error => error);
export const UpdateStorePersonnel = data => axios.put('/PersonnelSetApi/UpdateStorePersonnel', data).then(respone => { console.log('UpdateStorePersonnel'); return respone; }).catch(error => error);
export const GetStorePersonnelAuthority = query => axios.get('/PersonnelSetApi/GetStorePersonnelAuthority', query).then(respone => { console.log('GetStorePersonnelAuthority'); return respone; }).catch(error => error);
export const UpdateStorePersonnelAuthority = data => axios.put('/PersonnelSetApi/UpdateStorePersonnelAuthority', data).then(respone => { console.log('UpdateStorePersonnelAuthority'); return respone; }).catch(error => error);

//TransactionRecordApi
export const GetOrdersCondition = query => axios.get('/TransactionRecordApi/GetOrdersCondition', query).then(respone => { console.log('GetOrdersCondition'); return respone; }).catch(error => error);
