export function VerifyAccount  (value) {
    const regexs = /^(?=.*\d)(?=.*[a-zA-Z]).{6,20}$/;
    const result = regexs.test(value);
    return result ? true :'請至少輸入大小寫英文1位、1位數字1位及6-20位帳號'
}