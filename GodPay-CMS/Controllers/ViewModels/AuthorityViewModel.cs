using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers.ViewModels
{
    public class AuthorityViewModel
    {
        public string FuncClassEnName { get; set; }
        public string FuncClassChName { get; set; }
        public IEnumerable<FunctionViewModel> Functions { get; set; }
    }
}
