export function CheckValueOfObjectIsNotEmpty(values) {
    console.log(values)
    for (let key in values) {
        if (values[key] === '') {
            return false;
        }
    }
    return true;
}