﻿import axios from '/StaticFiles/Vue/Services/Axios.js'

// SigninOperateController
export const PostSignin = data => axios.post('/SigninOperate/SignIn', data).then(respone => { console.log(' GetBusinessmens'); return respone; }).catch(error => error);

// ProfileApiController
export const GetUserById = query => axios.get('/ProfileApi/Get', query).then(respone => { console.log('GetUserById'); return respone; }).catch(error => error);
export const EditUser = data => axios.post('/ProfileApi/Edit', data).then(respone => { console.log('EditUser'); return respone; }).catch(error => error);

// BusinessManagementApiController
export const GetBusinessmens = () => axios.get('/BusinessManagementApi/GetBusinessmens').then(respone => { console.log(' GetBusinessmens'); return respone; }).catch(error => error);
export const GetBusinessmanDetail = query => axios.get('/BusinessManagementApi/GetBusinessmenDeatil', query).then(respone => { console.log('GetBusinessmanDetail'); return respone; }).catch(error => error);
export const PostBusinessmen = data => axios.post('/BusinessManagementApi/PostBusinessmen', data).then(respone => { console.log('PostBusinessmen'); return respone; }).catch(error => error);
export const UpdateBusinessmen = data => axios.put('/BusinessManagementApi/UpdateBusinessmen', data).then(respone => { console.log('UpdateBusinessmen'); return respone; }).catch(error => error);
export const GetBusinessmen = query => axios.get('/BusinessManagementApi/GetBusinessmen', query).then(respone => { console.log('PostBusinessmen'); return respone; }).catch(error => error);
export const GetBusinessmensFilter = query => axios.get('/BusinessManagementApi/GetBusinessmensFilter', query).then(respone => { console.log('GetBusinessmensFilter'); return respone; }).catch(error => error);

// StoreManagementApi
export const GetStores = () => axios.get('/StoreManagementApi/GetStores').then(respone => { console.log(' StoreManagementApi'); return respone; }).catch(error => error);
export const GetStoreDetail = (query) => axios.get('/StoreManagementApi/GetStoreDeatil', query).then(respone => { console.log('GetStoreDeatil'); return respone; }).catch(error => error);

// EnumApi
export const GetRoleEnum = () => axios.get('/EnumApi/GetRoleEnum').then(respone => { console.log('GetRoleEnum'); return respone; }).catch(error => error);
export const GetAccountStatusEnum = () => axios.get('/EnumApi/GetAccountStatusEnum').then(respone => { console.log('GetAccountStatusEnum'); return respone; }).catch(error => error);
