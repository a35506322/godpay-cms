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