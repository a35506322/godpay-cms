using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Common.Helpers
{
    public static class ModelStateHelper
    {
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
                result += $"\"{kvp.Key}\":[{String.Join(',', kvp.Value.Select(v => string.Format("\"{0}\"", v)))}],";
            }
            result = result.TrimEnd(',');
            result += "}";
            return result;
        }
    }
}
