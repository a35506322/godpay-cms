/**
 * 驗證是否物件空白
 * @param {any} object
 */
export function CheckValueOfObjectIsNotEmpty(object) {
    for (let key in object) {
        if (object[key] === '') {
            return false;
        }
    }
    return true;
}
/**
 * ReturnCode轉BS代碼
 * @param {any} returnCode Response回傳代碼
 */
export function ChangeReturnCode(returnCode) {
    const statusEnum = Object.freeze({
        /*
         success : 成功
         error:失敗
         warn:警告
         */
        200: 'success',
        401: 'error',
        402: 'error',
        404: 'warn',
        405: 'warn',
        417: 'error',
        423: 'warn',
        424: 'warn',
        430: 'error'
    })

    if (returnCode === null) {
        return statusEnum['200']
    }
    return statusEnum[returnCode]
}
/**
 * 權限驗證
 * @param {any} array 篩選過的權限陣列
 * @param {any} action 想篩選哪個action
 */
export function CheckAuthority(array, action) {
    for (let i = 0; i < array.length; i++) {
        if (array[i]['funcEnName'] === action) {
            return true;
        }
    }
    return false;
}
/**
 * 設定日期
 * @param {any} status 狀態
 */
export function setDate(status) {
    let dat = new Date();
    let tempdat = {
        start: null,
        end: null
    }
    switch (status) {
        case 'today':
            tempdat.start = new Date(dat.getFullYear(), dat.getMonth(), dat.getDate(), 0, 0);
            tempdat.end = new Date(dat.getFullYear(), dat.getMonth(), dat.getDate() + 1, 0, 0);
            break;
        case 'yesterday':
            tempdat.start = new Date(dat.getFullYear(), dat.getMonth(), dat.getDate() - 1, 0, 0);
            tempdat.end = new Date(dat.getFullYear(), dat.getMonth(), dat.getDate(), 0, 0);
            break;
        case 'last-week':
            tempdat.start = new Date(dat.getFullYear(), dat.getMonth(), dat.getDate() - 7, 0, 0);
            tempdat.end = new Date(dat.getFullYear(), dat.getMonth(), dat.getDate(), 0, 0);
            break;
        case 'last-month':
            tempdat.start = new Date(dat.getFullYear(), dat.getMonth() - 1, 1, 0, 0);
            tempdat.end = new Date(dat.getFullYear(), dat.getMonth(), 1, 0, 0);
            break;
    }

    return tempdat;
}