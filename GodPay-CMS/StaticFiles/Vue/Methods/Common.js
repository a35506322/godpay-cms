export function CheckValueOfObjectIsNotEmpty(object) {
    for (let key in object) {
        if (object[key] === '') {
            return false;
        }
    }
    return true;
}