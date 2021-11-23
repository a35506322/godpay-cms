import axios from '/StaticFiles/Vue/Services/Axios.js'

export const PostSignin = data => axios.post('/SigninOperate/SignIn', data);
export const GetUsersByRole = data => axios.get('/BusinessManagementOperate/GetUsersByRole', data);