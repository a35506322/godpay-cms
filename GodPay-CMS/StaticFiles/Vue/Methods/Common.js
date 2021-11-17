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
         dnager:失敗
         warning:警告
         */
        200: 'success',
        401: 'dnager',
        402: 'danger'
    })

    if (returnCode === null) {
        return statusEnum[200]
    }
    return statusEnum[returnCode]
}