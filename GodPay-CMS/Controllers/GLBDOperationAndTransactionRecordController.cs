using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Controllers
{
    [Authorize(Roles = "Manager,Store")]
    public class GLBDOperationAndTransactionRecordController : Controller
    {
        public IActionResult TransactionRecord()
        {
            return View();
        }
    }
}
