interface FieldValidationMetaInfo {
    field: string;
    value: unknown;
    form: Record<string, unknown>;
    rule?: {
        name: string;
        params?: Record<string, unknown> | unknown[];
    };
}
declare type ValidationMessageGenerator = (ctx: FieldValidationMetaInfo) => string;

declare type ValidationMessageTemplate = ValidationMessageGenerator | string;
interface PartialI18nDictionary {
    name?: string;
    messages?: Record<string, ValidationMessageTemplate>;
    names?: Record<string, string>;
    fields?: Record<string, Record<string, ValidationMessageTemplate>>;
}
declare type RootI18nDictionary = Record<string, PartialI18nDictionary>;
declare function localize(dictionary: RootI18nDictionary): ValidationMessageGenerator;
declare function localize(locale: string, dictionary?: PartialI18nDictionary): ValidationMessageGenerator;
/**
 * Sets the locale
 */
declare function setLocale(locale: string): void;
/**
 * Loads a locale file from URL and merges it with the current dictionary
 */
declare function loadLocaleFromURL(url: string): Promise<void>;

export { loadLocaleFromURL, localize, setLocale };
