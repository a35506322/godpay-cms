// 設定domian
axios.defaults.baseURL = window.baseURL;
// 設定header
axios.defaults.headers.post['Content-Type'] = 'application/json; charset=utf-8';

// Error Handle
const errorHandle = (response, status) => {
    // vue
    const vue = app.__vue_app__.config;
    let deatil = ''
    if (typeof (response.data) === 'string') {
        deatil = response.data;
    }
    switch (status) {
        case 400:
            vue.globalProperties.$toast.add({ severity: 'error', summary: 'Bad Request', detail: deatil, life: 5000, group: window.layout });
            break;
        case 401:
            vue.globalProperties.$toast.add({ severity: 'error', summary: '認證失敗', detail: deatil, life: 5000, group: window.layout });
            break;
        case 500:       
            vue.globalProperties.$toast.add({ severity: 'error', summary: '伺服器內部錯誤', detail:'請與資訊部聯絡', life: 5000, group: window.layout});
            break;
        default:
            vue.globalProperties.$toast.add({ severity: 'error', summary: '意外狀況', detail: '請與資訊部聯絡', life: 5000, group: window.layout });
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
        // vue
        const vue = app.__vue_app__.config;
        const { response } = error;       
        if (response) {
            // 按照狀態發出訊息
            errorHandle(response,response.status);
            // 成功發出請求且收到 response
            console.log('error', response);
            return Promise.reject(response);
        } else {
            // 成功發出請求但沒收到 response
            if (!window.navigator.onLine) {
                //如果是網路斷線
                vue.globalProperties.$toast.add({ severity: 'error', summary: '網路出了問題, 請重新連線', detail: '', life: 5000, group: 'backend-laoout' });
            } else {
                // 其它問題 
                vue.globalProperties.$toast.add({ severity: 'error', summary: '主機伺服器發生問題, 請連絡資訊單位', detail: '', life: 5000, group: 'backend-laoout' });
                let errorResponse = {
                    message: error.message,
                    request: error.request
                }
                console.log('errorResponse',errorResponse);
                return Promise.reject(errorResponse);
            }
        }
    }
);

export default axios;