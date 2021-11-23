// 設定domian
axios.defaults.baseURL = window.baseURL;
// 設定header
axios.defaults.headers.post['Content-Type'] = 'application/json; charset=utf-8';

// Error Handle
const errorHandle = (status) => {
    switch (status) {
        case 400:
            console.log("400")
            alert('Bad Request');
            break;
        case 401:
            console.log("401")
            alert('認證失敗');
            break;
        default:
            alert('伺服器發生內部問題');
            break;
    }
}
// doing something with the request
axios.interceptors.request.use(
    (request) => {
        // do something with request meta data, configuration, etc
        // dont forget to return request object, otherwise your app will get no answer
        return request;
    }
);

// doing something with the response
axios.interceptors.response.use(
    (response) => {
        console.log('success', response);
        return response;
    },
    (error) => {
        console.log('error', response);
        console.log('error', error);
        const { response } = error;
        if (response) {
            // 成功發出請求且收到 response, 但有 error
            errorHandle(response.status);
            return Promise.reject(error);
        } else {
            // 成功發出請求但沒收到 response
            if (!window.navigator.onLine) {
                //如果是網路斷線
                alert('網路出了問題, 請重新連線');
            } else {
                // 其它問題 
                alert('主機伺服器發生問題, 請連絡資訊單位');
                return Promise.reject(error);
            }
        }
    }
);

export default axios;