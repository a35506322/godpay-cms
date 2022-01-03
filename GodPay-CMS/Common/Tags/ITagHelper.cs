using GodPay_CMS.Services.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace GodPay_CMS.Common.Tags
{
    [HtmlTargetElement("i",Attributes ="icon")]
    public class ITagHelper:TagHelper
    {
        public string Icon { get; set; }
        private readonly IServiceWrapper _serviceWrapper;
        public Dictionary<string, string> iconDic { get; set; }
        public ITagHelper(IServiceWrapper serviceWrapper) 
        {
            _serviceWrapper = serviceWrapper;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string result = string.Empty;
            result += $"nav-icon icon-xs me-2 ";
            result += _serviceWrapper.itagService.GetIcon(Icon);
            output.Attributes.SetAttribute("class", result);
        }
    }
}
