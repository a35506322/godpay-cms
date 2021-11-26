import axios from '/StaticFiles/Vue/Services/Axios.js'

// SigninOperateController
export const PostSignin = data => axios.post('/SigninOperate/SignIn', data).then(respone => { console.log(' GetBusinessmens'); return respone; }).catch(error => error);

// ProfileApiController
export const GetUserById = query => axios.get('/ProfileApi/Get', query).then(respone => { console.log('GetUserById'); return respone; }).catch(error => error);
export const EditUser = data => axios.post('/ProfileApi/Edit', data).then(respone => { console.log('EditUser'); return respone; }).catch(error => error);


// BusinessManagementApiController
export const GetBusinessmens = () => axios.get('/BusinessManagementApi/GetBusinessmens').then(respone => { console.log(' GetBusinessmens'); return respone; }).catch(error => error);
export const GetBusinessmanDetail = query => axios.get('/BusinessManagementApi/GetBusinessmenDeatil', query).then(respone => { console.log('GetBusinessmanDetail'); return respone; }).catch(error => error);
export const PostBusinessmen = data => axios.post('/BusinessManagementApi/PostBusinessmen', data).then(respone => { console.log('PostBusinessmen'); return respone; }).catch(error => error);