using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GodPay_CMS.Common.Helpers
{
    public static class ModelStateHelper
    {
        /// <summary>
        /// 轉換物件(ModelStateError)
        /// </summary>
        /// <param name="ModelState"></param>
        /// <returns></returns>
        public static string GetModelStateHelper(this ModelStateDictionary ModelState)
        {
            IEnumerable<KeyValuePair<string, string[]>> errors = ModelState.IsValid ? null :
                ModelState.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray())
                .Where(m => m.Value.Any());
            var stringBuilder = new System.Text.StringBuilder();
            string result = string.Empty;
            result += "{";
            foreach (var kvp in errors)
            {
                result += $"\"{kvp.Key.ToLowerForFirst()}\":[{String.Join(',', kvp.Value.Select(v => string.Format("\"{0}\"", v)))}],";
            }
            result = result.TrimEnd(',');
            result += "}";
            return result;
        }
    }
}
