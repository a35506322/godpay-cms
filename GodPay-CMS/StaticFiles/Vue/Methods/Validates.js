export function VerifyAccount  (value) {
    const regexs = /^(?=.*\d)(?=.*[a-zA-Z]).{6,20}$/;
    const result = regexs.test(value);
    return result ? true :'請至少輸入大小寫英文1位、1位數字1位及6-20位帳號'
};

export function VerifyEnClass(value) {
    const regexs = /^[a-zA-Z0-9]*$/;
    const result = regexs.test(value);
    return result ? true : '只能輸入英文與數字'
};

export function VerifyChClass(value) {
    const regexs = /^[\u4e00-\u9fa5]*$/;
    const result = regexs.test(value);
    return result ? true : '只能輸入中文'
};

export function VerifyNumber(value) {
    const regexs = /^[0-9]*$/;
    const result = regexs.test(value);
    return result ? true : '只能輸入數字'
};
