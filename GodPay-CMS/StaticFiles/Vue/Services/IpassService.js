import axios from '/StaticFiles/Vue/Services/Axios.js'

export const PostSignin = data => axios.post('/SigninOperate/SignIn', data);
export const GetBusinessmens = () => axios.get('/BusinessManagementApi/GetBusinessmens');
export const GetBusinessmanDetail = data => axios.get('/BusinessManagementApi/GetBusinessmenDeatil',data);