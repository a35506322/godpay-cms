import axios from './Axios.js'

// SigninApiController
export const PostSignin = data => axios.post('/SigninApi/SignIn', data).then(response => { console.log(' PostSignin'); return response; }).catch(error => error);

// ProfileApiController
export const GetUserById = query => axios.get('/ProfileApi/Get', query).then(response => { console.log('GetUserById'); return response; }).catch(error => error);
export const EditUser = data => axios.post('/ProfileApi/Edit', data).then(response => { console.log('EditUser'); return response; }).catch(error => error);
export const EditKey = data => axios.post('/ProfileApi/EditKey', data).then(response => { console.log('EditKey'); return response; }).catch(error => error);
export const GetStoreProfile = (query) => axios.get('/ProfileApi/GetStoreDeatil', query).then(response => { console.log('GetStoreDeatil'); return response; }).catch(error => error);
export const UpateStore = data => axios.put('/ProfileApi/UpdateStoreDeatil', data).then(response => { console.log('UpateStore'); return response; }).catch(error => error);

// ManagerSetApiController
export const GetManagerAll = () => axios.get('/ManagerSetApi/GetManagerAll').then(response => { console.log(' GetManagerAll'); return response; }).catch(error => error);
export const GetManagerDeatil = query => axios.get('/ManagerSetApi/GetManagerDeatil', query).then(response => { console.log('GetManagerDeatil'); return response; }).catch(error => error);
export const PostManagerAndInsider = data => axios.post('/ManagerSetApi/PostManagerAndInsider', data).then(response => { console.log('PostManagerAndInsider'); return response; }).catch(error => error);
export const UpdateManagerAndInsider = data => axios.put('/ManagerSetApi/UpdateManagerAndInsider', data).then(response => { console.log('UpdateManagerAndInsider'); return response; }).catch(error => error);
export const GetManager = query => axios.get('/ManagerSetApi/GetManager', query).then(response => { console.log('GetManager'); return response; }).catch(error => error);
export const GetManagerAuthority = query => axios.get('/ManagerSetApi/GetManagerAuthority', query).then(response => { console.log('GetManagerAuthority'); return response; }).catch(error => error);
export const UpdateManagerAuthority = data => axios.put('/ManagerSetApi/UpdateManagerAuthority', data).then(response => { console.log('UpdateManagerAuthority'); return response; }).catch(error => error);

// StoreSetApi
export const GetStores = () => axios.get('/StoreSetApi/GetStores').then(response => { console.log(' StoreSetApi'); return response; }).catch(error => error);
export const GetStoreDetail = (query) => axios.get('/StoreSetApi/GetStoreDeatil', query).then(response => { console.log('GetStoreDeatil'); return response; }).catch(error => error);
export const PostUserAndStore = data => axios.post('/StoreSetApi/PostUserAndStore', data).then(response => { console.log('PostUserAndStore'); return response; }).catch(error => error);
export const GetStoreById = (query) => axios.get('/StoreSetApi/GetStoreById', query).then(response => { console.log('GetStoreById'); return response; }).catch(error => error);
export const UpateUserAndStore = data => axios.post('/StoreSetApi/UpateUserAndStore', data).then(response => { console.log('UpateUserAndStore'); return response; }).catch(error => error);
export const GetStoreAuthority = query => axios.get('/StoreSetApi/GetStoreAuthority', query).then(response => { console.log('GetStoreAuthority'); return response; }).catch(error => error);
export const UpdateStoreAuthority = data => axios.put('/StoreSetApi/UpdateStoreAuthority', data).then(response => { console.log('UpdateStoreAuthority'); return response; }).catch(error => error);
export const GetStoreForDDL = query => axios.get('/StoreSetApi/GetStoreForDDL', query).then(response => { console.log('GetStoreForDDL'); return response; }).catch(error => error);

// EnumApi
export const GetRoleEnum = () => axios.get('/EnumApi/GetRoleEnum').then(response => { console.log('GetRoleEnum'); return response; }).catch(error => error);
export const GetAccountStatusEnum = () => axios.get('/EnumApi/GetAccountStatusEnum').then(response => { console.log('GetAccountStatusEnum'); return response; }).catch(error => error);

// AuthoritySetApi
export const GetListOfFunctionsForAuthority = () => axios.get('/AuthoritySetApi/GetListOfFunctionsForAuthority').then(response => { console.log('GetListOfFunctionsForAuthority'); return response; }).catch(error => error);
export const GetListOfFunctionFilter = query => axios.get('/AuthoritySetApi/GetListOfFunctionFilter', query).then(response => { console.log('GetListOfFunctionFilter'); return response; }).catch(error => error);
export const UpdateRoleMaxAuthority = data => axios.put('/AuthoritySetApi/UpdateRoleMaxAuthority', data).then(response => { console.log('UpdateRoleMaxAuthority'); return response; }).catch(error => error);
export const GetListOfFuncClass = () => axios.get('/AuthoritySetApi/GetListOfFuncClass').then(response => { console.log('GetListOfFuncClass'); return response; }).catch(error => error);
export const PostFuncClass = data => axios.post('/AuthoritySetApi/PostFuncClass', data).then(response => { console.log('PostFuncClass'); return response; }).catch(error => error);
export const GetFuncClassDetailById = data => axios.get(`/AuthoritySetApi/GetFuncClassDetailById`, data).then(response => { console.log('GetFuncClassDetailById'); return response; }).catch(error => error);
export const UpdateFuncClass = data => axios.put('/AuthoritySetApi/UpdateFuncClass', data).then(response => { console.log('UpdateFuncClass'); return response; }).catch(error => error);
export const GetListOfFunc = () => axios.get('/AuthoritySetApi/GetListOfFunc').then(response => { console.log('GetListOfFunc'); return response; }).catch(error => error);
export const GetFuncDetailById = query => axios.get('/AuthoritySetApi/GetFuncDetailById', query).then(response => { console.log('GetFuncDetailById'); return response; }).catch(error => error);
export const UpdateFunc = data => axios.put('/AuthoritySetApi/UpdateFunc', data).then(response => { console.log('UpdateFunc'); return response; }).catch(error => error);
export const PostFunc = data => axios.post('/AuthoritySetApi/PostFunc', data).then(response => { console.log('UpdateFunc'); return response; }).catch(error => error);

// CustomerApi
export const GetCustomers = () => axios.get('/CustomerApi/GetAll').then(response => { console.log('GetCustomers'); return response; }).catch(error => error);
export const PostCustomer = data => axios.post('/CustomerApi/Post', data).then(response => { console.log('PostCustomer'); return response; }).catch(error => error);
export const UpdateCustomer = data => axios.put('/CustomerApi/Edit', data).then(response => { console.log('UpdateCustomer'); return response; }).catch(error => error);

// PersonnelSetApi
export const GetStorePersonnels = () => axios.get('/PersonnelSetApi/GetStorePersonnels').then(response => { console.log('GetStorePersonnels'); return response; }).catch(error => error);
export const PostStorePersonnel = data => axios.post('/PersonnelSetApi/PostStorePersonnel', data).then(response => { console.log('PostStorePersonnel'); return response; }).catch(error => error);
export const UpdateStorePersonnel = data => axios.put('/PersonnelSetApi/UpdateStorePersonnel', data).then(response => { console.log('UpdateStorePersonnel'); return response; }).catch(error => error);
export const GetStorePersonnelAuthority = query => axios.get('/PersonnelSetApi/GetStorePersonnelAuthority', query).then(response => response).catch(error => error);
export const UpdateStorePersonnelAuthority = data => axios.put('/PersonnelSetApi/UpdateStorePersonnelAuthority', data).then(response => response).catch(error => error);

// TransactionRecordApi
export const GetOrdersCondition = query => axios.get('/TransactionRecordApi/GetOrdersCondition', query).then(response => response).catch(error => error);
export const Refund = data => axios.post('/TransactionRecordApi/Refund', data).then(response => response).catch(error => error);
export const Void = data => axios.post('/TransactionRecordApi/Void', data).then(response => response).catch(error => error);

// MemberTrackApi
export const GetMemberTrack = query => axios.get('/MemberTrackApi/GetMemberTrack', query).then(response => response).catch(error => error);
