/**
  * vee-validate v4.5.3
  * (c) 2021 Abdelrahman Awad
  * @license MIT
  */
/* eslint-disable no-misleading-character-class */
/**
 * Some Alpha Regex helpers.
 * https://github.com/chriso/validator.js/blob/master/src/lib/alpha.js
 */
const alpha = {
    en: /^[A-Z]*$/i,
    cs: /^[A-ZÁČĎÉĚÍŇÓŘŠŤÚŮÝŽ]*$/i,
    da: /^[A-ZÆØÅ]*$/i,
    de: /^[A-ZÄÖÜß]*$/i,
    es: /^[A-ZÁÉÍÑÓÚÜ]*$/i,
    fr: /^[A-ZÀÂÆÇÉÈÊËÏÎÔŒÙÛÜŸ]*$/i,
    it: /^[A-Z\xC0-\xFF]*$/i,
    lt: /^[A-ZĄČĘĖĮŠŲŪŽ]*$/i,
    nl: /^[A-ZÉËÏÓÖÜ]*$/i,
    hu: /^[A-ZÁÉÍÓÖŐÚÜŰ]*$/i,
    pl: /^[A-ZĄĆĘŚŁŃÓŻŹ]*$/i,
    pt: /^[A-ZÃÁÀÂÇÉÊÍÕÓÔÚÜ]*$/i,
    ru: /^[А-ЯЁ]*$/i,
    sk: /^[A-ZÁÄČĎÉÍĹĽŇÓŔŠŤÚÝŽ]*$/i,
    sr: /^[A-ZČĆŽŠĐ]*$/i,
    sv: /^[A-ZÅÄÖ]*$/i,
    tr: /^[A-ZÇĞİıÖŞÜ]*$/i,
    uk: /^[А-ЩЬЮЯЄІЇҐ]*$/i,
    ar: /^[ءآأؤإئابةتثجحخدذرزسشصضطظعغفقكلمنهوىيًٌٍَُِّْٰ]*$/,
    az: /^[A-ZÇƏĞİıÖŞÜ]*$/i,
    ug: /^[A-Zچۋېرتيۇڭوپھسداەىقكلزشغۈبنمژفگخجۆئ]*$/i,
};
const alphaSpaces = {
    en: /^[A-Z\s]*$/i,
    cs: /^[A-ZÁČĎÉĚÍŇÓŘŠŤÚŮÝŽ\s]*$/i,
    da: /^[A-ZÆØÅ\s]*$/i,
    de: /^[A-ZÄÖÜß\s]*$/i,
    es: /^[A-ZÁÉÍÑÓÚÜ\s]*$/i,
    fr: /^[A-ZÀÂÆÇÉÈÊËÏÎÔŒÙÛÜŸ\s]*$/i,
    it: /^[A-Z\xC0-\xFF\s]*$/i,
    lt: /^[A-ZĄČĘĖĮŠŲŪŽ\s]*$/i,
    nl: /^[A-ZÉËÏÓÖÜ\s]*$/i,
    hu: /^[A-ZÁÉÍÓÖŐÚÜŰ\s]*$/i,
    pl: /^[A-ZĄĆĘŚŁŃÓŻŹ\s]*$/i,
    pt: /^[A-ZÃÁÀÂÇÉÊÍÕÓÔÚÜ\s]*$/i,
    ru: /^[А-ЯЁ\s]*$/i,
    sk: /^[A-ZÁÄČĎÉÍĹĽŇÓŔŠŤÚÝŽ\s]*$/i,
    sr: /^[A-ZČĆŽŠĐ\s]*$/i,
    sv: /^[A-ZÅÄÖ\s]*$/i,
    tr: /^[A-ZÇĞİıÖŞÜ\s]*$/i,
    uk: /^[А-ЩЬЮЯЄІЇҐ\s]*$/i,
    ar: /^[ءآأؤإئابةتثجحخدذرزسشصضطظعغفقكلمنهوىيًٌٍَُِّْٰ\s]*$/,
    az: /^[A-ZÇƏĞİıÖŞÜ\s]*$/i,
    ug: /^[A-Zچۋېرتيۇڭوپھسداەىقكلزشغۈبنمژفگخجۆئ\s]*$/i,
};
const alphanumeric = {
    en: /^[0-9A-Z]*$/i,
    cs: /^[0-9A-ZÁČĎÉĚÍŇÓŘŠŤÚŮÝŽ]*$/i,
    da: /^[0-9A-ZÆØÅ]$/i,
    de: /^[0-9A-ZÄÖÜß]*$/i,
    es: /^[0-9A-ZÁÉÍÑÓÚÜ]*$/i,
    fr: /^[0-9A-ZÀÂÆÇÉÈÊËÏÎÔŒÙÛÜŸ]*$/i,
    it: /^[0-9A-Z\xC0-\xFF]*$/i,
    lt: /^[0-9A-ZĄČĘĖĮŠŲŪŽ]*$/i,
    hu: /^[0-9A-ZÁÉÍÓÖŐÚÜŰ]*$/i,
    nl: /^[0-9A-ZÉËÏÓÖÜ]*$/i,
    pl: /^[0-9A-ZĄĆĘŚŁŃÓŻŹ]*$/i,
    pt: /^[0-9A-ZÃÁÀÂÇÉÊÍÕÓÔÚÜ]*$/i,
    ru: /^[0-9А-ЯЁ]*$/i,
    sk: /^[0-9A-ZÁÄČĎÉÍĹĽŇÓŔŠŤÚÝŽ]*$/i,
    sr: /^[0-9A-ZČĆŽŠĐ]*$/i,
    sv: /^[0-9A-ZÅÄÖ]*$/i,
    tr: /^[0-9A-ZÇĞİıÖŞÜ]*$/i,
    uk: /^[0-9А-ЩЬЮЯЄІЇҐ]*$/i,
    ar: /^[٠١٢٣٤٥٦٧٨٩0-9ءآأؤإئابةتثجحخدذرزسشصضطظعغفقكلمنهوىيًٌٍَُِّْٰ]*$/,
    az: /^[0-9A-ZÇƏĞİıÖŞÜ]*$/i,
    ug: /^[0-9A-Zچۋېرتيۇڭوپھسداەىقكلزشغۈبنمژفگخجۆئ]*$/i,
};
const alphaDash = {
    en: /^[0-9A-Z_-]*$/i,
    cs: /^[0-9A-ZÁČĎÉĚÍŇÓŘŠŤÚŮÝŽ_-]*$/i,
    da: /^[0-9A-ZÆØÅ_-]*$/i,
    de: /^[0-9A-ZÄÖÜß_-]*$/i,
    es: /^[0-9A-ZÁÉÍÑÓÚÜ_-]*$/i,
    fr: /^[0-9A-ZÀÂÆÇÉÈÊËÏÎÔŒÙÛÜŸ_-]*$/i,
    it: /^[0-9A-Z\xC0-\xFF_-]*$/i,
    lt: /^[0-9A-ZĄČĘĖĮŠŲŪŽ_-]*$/i,
    nl: /^[0-9A-ZÉËÏÓÖÜ_-]*$/i,
    hu: /^[0-9A-ZÁÉÍÓÖŐÚÜŰ_-]*$/i,
    pl: /^[0-9A-ZĄĆĘŚŁŃÓŻŹ_-]*$/i,
    pt: /^[0-9A-ZÃÁÀÂÇÉÊÍÕÓÔÚÜ_-]*$/i,
    ru: /^[0-9А-ЯЁ_-]*$/i,
    sk: /^[0-9A-ZÁÄČĎÉÍĹĽŇÓŔŠŤÚÝŽ_-]*$/i,
    sr: /^[0-9A-ZČĆŽŠĐ_-]*$/i,
    sv: /^[0-9A-ZÅÄÖ_-]*$/i,
    tr: /^[0-9A-ZÇĞİıÖŞÜ_-]*$/i,
    uk: /^[0-9А-ЩЬЮЯЄІЇҐ_-]*$/i,
    ar: /^[٠١٢٣٤٥٦٧٨٩0-9ءآأؤإئابةتثجحخدذرزسشصضطظعغفقكلمنهوىيًٌٍَُِّْٰ_-]*$/,
    az: /^[0-9A-ZÇƏĞİıÖŞÜ_-]*$/i,
    ug: /^[0-9A-Zچۋېرتيۇڭوپھسداەىقكلزشغۈبنمژفگخجۆئ_-]*$/i,
};
const getLocale = (params) => {
    if (!params) {
        return undefined;
    }
    return Array.isArray(params) ? params[0] : params.locale;
};

function getSingleParam(params, paramName) {
    return Array.isArray(params) ? params[0] : params[paramName];
}
function isEmpty(value) {
    if (value === null || value === undefined || value === '') {
        return true;
    }
    if (Array.isArray(value) && value.length === 0) {
        return true;
    }
    return false;
}

const alphaValidator = (value, params) => {
    if (isEmpty(value)) {
        return true;
    }
    const locale = getLocale(params);
    if (Array.isArray(value)) {
        return value.every(val => alphaValidator(val, { locale }));
    }
    const valueAsString = String(value);
    // Match at least one locale.
    if (!locale) {
        return Object.keys(alpha).some(loc => alpha[loc].test(valueAsString));
    }
    return (alpha[locale] || alpha.en).test(valueAsString);
};

const alphaDashValidator = (value, params) => {
    if (isEmpty(value)) {
        return true;
    }
    const locale = getLocale(params);
    if (Array.isArray(value)) {
        return value.every(val => alphaDashValidator(val, { locale }));
    }
    const valueAsString = String(value);
    // Match at least one locale.
    if (!locale) {
        return Object.keys(alphaDash).some(loc => alphaDash[loc].test(valueAsString));
    }
    return (alphaDash[locale] || alphaDash.en).test(valueAsString);
};

const alphaNumValidator = (value, params) => {
    if (isEmpty(value)) {
        return true;
    }
    const locale = getLocale(params);
    if (Array.isArray(value)) {
        return value.every(val => alphaNumValidator(val, { locale }));
    }
    const valueAsString = String(value);
    // Match at least one locale.
    if (!locale) {
        return Object.keys(alphanumeric).some(loc => alphanumeric[loc].test(valueAsString));
    }
    return (alphanumeric[locale] || alphanumeric.en).test(valueAsString);
};

const alphaSpacesValidator = (value, params) => {
    if (isEmpty(value)) {
        return true;
    }
    const locale = getLocale(params);
    if (Array.isArray(value)) {
        return value.every(val => alphaSpacesValidator(val, { locale }));
    }
    const valueAsString = String(value);
    // Match at least one locale.
    if (!locale) {
        return Object.keys(alphaSpaces).some(loc => alphaSpaces[loc].test(valueAsString));
    }
    return (alphaSpaces[locale] || alphaSpaces.en).test(valueAsString);
};

function getParams$1(params) {
    if (!params) {
        return {
            min: 0,
            max: 0,
        };
    }
    if (Array.isArray(params)) {
        return { min: params[0], max: params[1] };
    }
    return params;
}
const betweenValidator = (value, params) => {
    if (isEmpty(value)) {
        return true;
    }
    const { min, max } = getParams$1(params);
    if (Array.isArray(value)) {
        return value.every(val => !!betweenValidator(val, { min, max }));
    }
    const valueAsNumber = Number(value);
    return Number(min) <= valueAsNumber && Number(max) >= valueAsNumber;
};

const confirmedValidator = (value, params) => {
    const target = getSingleParam(params, 'target');
    return String(value) === String(target);
};

const digitsValidator = (value, params) => {
    if (isEmpty(value)) {
        return true;
    }
    const length = getSingleParam(params, 'length');
    if (Array.isArray(value)) {
        return value.every(val => digitsValidator(val, { length }));
    }
    const strVal = String(value);
    return /^[0-9]*$/.test(strVal) && strVal.length === Number(length);
};

const validateImage = (file, width, height) => {
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const URL = window.URL || window.webkitURL;
    return new Promise(resolve => {
        const image = new Image();
        image.onerror = () => resolve(false);
        image.onload = () => resolve(image.width === width && image.height === height);
        image.src = URL.createObjectURL(file);
    });
};
function getParams(params) {
    if (!params) {
        return { width: 0, height: 0 };
    }
    if (Array.isArray(params)) {
        return { width: Number(params[0]), height: Number(params[1]) };
    }
    return {
        width: Number(params.width),
        height: Number(params.height),
    };
}
const dimensionsValidator = (files, params) => {
    if (isEmpty(files)) {
        return true;
    }
    const { width, height } = getParams(params);
    const list = [];
    const fileList = Array.isArray(files) ? files : [files];
    for (let i = 0; i < fileList.length; i++) {
        // if file is not an image, reject.
        if (!/\.(jpg|svg|jpeg|png|bmp|gif)$/i.test(fileList[i].name)) {
            return Promise.resolve(false);
        }
        list.push(fileList[i]);
    }
    return Promise.all(list.map(file => validateImage(file, width, height))).then(values => {
        return values.every(v => v);
    });
};

/* eslint-disable no-useless-escape */
const emailValidator = (value) => {
    if (isEmpty(value)) {
        return true;
    }
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (Array.isArray(value)) {
        return value.every(val => re.test(String(val)));
    }
    return re.test(String(value));
};

const extValidator = (files, extensions) => {
    if (isEmpty(files)) {
        return true;
    }
    if (!extensions) {
        extensions = [];
    }
    const regex = new RegExp(`.(${extensions.join('|')})$`, 'i');
    if (Array.isArray(files)) {
        return files.every(file => regex.test(file.name));
    }
    return regex.test(files.name);
};

const imageValidator = (files) => {
    if (isEmpty(files)) {
        return true;
    }
    const regex = /\.(jpg|svg|jpeg|png|bmp|gif|webp)$/i;
    if (Array.isArray(files)) {
        return files.every(file => regex.test(file.name));
    }
    return regex.test(files.name);
};

const integerValidator = (value) => {
    if (isEmpty(value)) {
        return true;
    }
    if (Array.isArray(value)) {
        return value.every(val => /^-?[0-9]+$/.test(String(val)));
    }
    return /^-?[0-9]+$/.test(String(value));
};

const isValidator = (value, params) => {
    const other = getSingleParam(params, 'other');
    return value === other;
};

const isNotValidator = (value, params) => {
    const other = getSingleParam(params, 'other');
    return value !== other;
};

function isNullOrUndefined(value) {
    return value === null || value === undefined;
}
function isEmptyArray(arr) {
    return Array.isArray(arr) && arr.length === 0;
}

const lengthValidator = (value, params) => {
    // Normalize the length value
    const length = getSingleParam(params, 'length');
    if (isNullOrUndefined(value)) {
        return false;
    }
    if (typeof value === 'number') {
        value = String(value);
    }
    if (!value.length) {
        value = Array.from(value);
    }
    return value.length === Number(length);
};

const maxLengthValidator = (value, params) => {
    if (isEmpty(value)) {
        return true;
    }
    const length = getSingleParam(params, 'length');
    if (Array.isArray(value)) {
        return value.every(val => maxLengthValidator(val, { length }));
    }
    return String(value).length <= Number(length);
};

const maxValueValidator = (value, params) => {
    if (isEmpty(value)) {
        return true;
    }
    const max = getSingleParam(params, 'max');
    if (Array.isArray(value)) {
        return value.length > 0 && value.every(val => maxValueValidator(val, { max }));
    }
    return Number(value) <= Number(max);
};

const mimesValidator = (files, mimes) => {
    if (isEmpty(files)) {
        return true;
    }
    if (!mimes) {
        mimes = [];
    }
    const regex = new RegExp(`${mimes.join('|').replace('*', '.+')}$`, 'i');
    if (Array.isArray(files)) {
        return files.every(file => regex.test(file.type));
    }
    return regex.test(files.type);
};

const minValidator = (value, params) => {
    if (isEmpty(value)) {
        return true;
    }
    const length = getSingleParam(params, 'length');
    if (Array.isArray(value)) {
        return value.every(val => minValidator(val, { length }));
    }
    return String(value).length >= Number(length);
};

const minValueValidator = (value, params) => {
    if (isEmpty(value)) {
        return true;
    }
    const min = getSingleParam(params, 'min');
    if (Array.isArray(value)) {
        return value.length > 0 && value.every(val => minValueValidator(val, { min }));
    }
    return Number(value) >= Number(min);
};

const oneOfValidator = (value, list) => {
    if (isEmpty(value)) {
        return true;
    }
    if (Array.isArray(value)) {
        return value.every(val => oneOfValidator(val, list));
    }
    return Array.from(list).some(item => {
        // eslint-disable-next-line
        return item == value;
    });
};

const excludedValidator = (value, list) => {
    if (isEmpty(value)) {
        return true;
    }
    return !oneOfValidator(value, list);
};

const ar = /^[٠١٢٣٤٥٦٧٨٩]+$/;
const en = /^[0-9]+$/;
const numericValidator = (value) => {
    if (isEmpty(value)) {
        return true;
    }
    const testValue = (val) => {
        const strValue = String(val);
        return en.test(strValue) || ar.test(strValue);
    };
    if (Array.isArray(value)) {
        return value.every(testValue);
    }
    return testValue(value);
};

const regexValidator = (value, params) => {
    if (isEmpty(value)) {
        return true;
    }
    let regex = getSingleParam(params, 'regex');
    if (typeof regex === 'string') {
        regex = new RegExp(regex);
    }
    if (Array.isArray(value)) {
        return value.every(val => regexValidator(val, { regex }));
    }
    return regex.test(String(value));
};

const requiredValidator = (value) => {
    if (isNullOrUndefined(value) || isEmptyArray(value) || value === false) {
        return false;
    }
    return !!String(value).trim().length;
};

const sizeValidator = (files, params) => {
    if (isEmpty(files)) {
        return true;
    }
    let size = getSingleParam(params, 'size');
    size = Number(size);
    if (isNaN(size)) {
        return false;
    }
    const nSize = size * 1024;
    if (!Array.isArray(files)) {
        return files.size <= nSize;
    }
    for (let i = 0; i < files.length; i++) {
        if (files[i].size > nSize) {
            return false;
        }
    }
    return true;
};

const urlValidator = (value, params) => {
    var _a;
    if (isEmpty(value)) {
        return true;
    }
    let pattern = getSingleParam(params, 'pattern');
    if (typeof pattern === 'string') {
        pattern = new RegExp(pattern);
    }
    try {
        // eslint-disable-next-line no-new
        new URL(value);
    }
    catch (_b) {
        return false;
    }
    return (_a = pattern === null || pattern === void 0 ? void 0 : pattern.test(value)) !== null && _a !== void 0 ? _a : true;
};

/* eslint-disable camelcase */
const all = {
    alpha_dash: alphaDashValidator,
    alpha_num: alphaNumValidator,
    alpha_spaces: alphaSpacesValidator,
    alpha: alphaValidator,
    between: betweenValidator,
    confirmed: confirmedValidator,
    digits: digitsValidator,
    dimensions: dimensionsValidator,
    email: emailValidator,
    ext: extValidator,
    image: imageValidator,
    integer: integerValidator,
    is_not: isNotValidator,
    is: isValidator,
    length: lengthValidator,
    max_value: maxValueValidator,
    max: maxLengthValidator,
    mimes: mimesValidator,
    min_value: minValueValidator,
    min: minValidator,
    not_one_of: excludedValidator,
    numeric: numericValidator,
    one_of: oneOfValidator,
    regex: regexValidator,
    required: requiredValidator,
    size: sizeValidator,
    url: urlValidator,
};

export { alphaValidator as alpha, alphaDashValidator as alpha_dash, alphaNumValidator as alpha_num, alphaSpacesValidator as alpha_spaces, betweenValidator as between, confirmedValidator as confirmed, all as default, digitsValidator as digits, dimensionsValidator as dimensions, emailValidator as email, extValidator as ext, imageValidator as image, integerValidator as integer, isValidator as is, isNotValidator as is_not, lengthValidator as length, maxLengthValidator as max, maxValueValidator as max_value, mimesValidator as mimes, minValidator as min, minValueValidator as min_value, excludedValidator as not_one_of, numericValidator as numeric, oneOfValidator as one_of, regexValidator as regex, requiredValidator as required, sizeValidator as size, urlValidator as url };
