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
        405: 'error',
        417: 'warn',
        423: 'warn',
        424: 'error'
    })

    if (returnCode === null) {
        return statusEnum[200]
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