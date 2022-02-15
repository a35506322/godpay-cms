/**
 * 轉換台灣時區
 * @param {any} value 時間
 */
export function FormatTWDate(value) {
    if (value == null) {
        return ''
    }
    else {
        var localDate = new Date(value).toLocaleString("zh-Hans-TW")
        return localDate;
    }
}

/**
 * 轉換訂單狀態
 * @param {any} value 狀態
 */
export function FormatOrderStatus(value) {
    const statusEnum = Object.freeze({
        1: '訂單失敗',
        2: '訂單成功',
        3: '訂單取消',
        4: '訂單請款',
        5: '訂單退貨',
        99: '錯誤單號'
    })

    if (value === null || value === '') {
        return statusEnum['99']
    }

    return statusEnum[value]

}