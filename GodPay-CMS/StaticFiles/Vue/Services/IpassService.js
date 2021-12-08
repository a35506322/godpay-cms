import axios from '/StaticFiles/Vue/Services/Axios.js'

// SigninApiController
export const PostSignin = data => axios.post('/SigninApi/SignIn', data).then(respone => { console.log(' PostSignin'); return respone; }).catch(error => error);

// ProfileApiController
export const GetUserById = query => axios.get('/ProfileApi/Get', query).then(respone => { console.log('GetUserById'); return respone; }).catch(error => error);
export const EditUser = data => axios.post('/ProfileApi/Edit', data).then(respone => { console.log('EditUser'); return respone; }).catch(error => error);
export const EditKey = data => axios.post('/ProfileApi/EditKey', data).then(respone => { console.log('EditKey'); return respone; }).catch(error => error);

// ManagerSetApiController
export const GetManagerAll = () => axios.get('/ManagerSetApi/GetManagerAll').then(respone => { console.log(' GetManagerAll'); return respone; }).catch(error => error);
export const GetManagerDeatil = query => axios.get('/ManagerSetApi/GetManagerDeatil', query).then(respone => { console.log('GetManagerDeatil'); return respone; }).catch(error => error);
export const PostManager = data => axios.post('/ManagerSetApi/PostManager', data).then(respone => { console.log('PostManager'); return respone; }).catch(error => error);
export const UpdateManager = data => axios.put('/ManagerSetApi/UpdateManager', data).then(respone => { console.log('UpdateManager'); return respone; }).catch(error => error);
export const GetManager = query => axios.get('/ManagerSetApi/GetManager', query).then(respone => { console.log('PostManager'); return respone; }).catch(error => error);
export const GetManagerFilter = query => axios.get('/ManagerSetApi/GetManagerFilter', query).then(respone => { console.log('GetManagerFilter'); return respone; }).catch(error => error);

// StoreSetApi
export const GetStores = () => axios.get('/StoreSetApi/GetStores').then(respone => { console.log(' StoreSetApi'); return respone; }).catch(error => error);
export const GetStoreDetail = (query) => axios.get('/StoreSetApi/GetStoreDeatil', query).then(respone => { console.log('GetStoreDeatil'); return respone; }).catch(error => error);
export const PostStore = data => axios.post('/StoreSetApi/PostStore', data).then(respone => { console.log('PostStore'); return respone; }).catch(error => error);
export const GetStore = (query) => axios.get('/StoreSetApi/GetStore', query).then(respone => { console.log('PostStore'); return respone; }).catch(error => error);
export const UpdateStore = data => axios.post('/StoreSetApi/UpdateStore', data).then(respone => { console.log('UpdateStore'); return respone; }).catch(error => error);

// EnumApi
export const GetRoleEnum = () => axios.get('/EnumApi/GetRoleEnum').then(respone => { console.log('GetRoleEnum'); return respone; }).catch(error => error);
export const GetAccountStatusEnum = () => axios.get('/EnumApi/GetAccountStatusEnum').then(respone => { console.log('GetAccountStatusEnum'); return respone; }).catch(error => error);

// AuthoritySetApi
export const GetListOfFunction = () => axios.get('/AuthoritySetApi/GetListOfFunction').then(respone => { console.log('GetListOfFunction'); return respone; }).catch(error => error);
export const GetListOfFunctionFilter = query => axios.get('/AuthoritySetApi/GetListOfFunctionFilter', query).then(respone => { console.log('GetListOfFunctionFilter'); return respone; }).catch(error => error);
export const UpdateRoleMaxAuthority = data => axios.put('/AuthoritySetApi/UpdateRoleMaxAuthority', data).then(respone => { console.log('UpdateRoleMaxAuthority'); return respone; }).catch(error => error);
export const GetListOfFuncClass = () => axios.get('/AuthorityApi/GetListOfFuncClass').then(respone => { console.log('GetListOfFuncClass'); return respone; }).catch(error => error);