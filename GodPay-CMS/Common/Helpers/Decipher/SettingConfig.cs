﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Common.Helpers.Decipher
{
    public class SettingConfig
    {
        public Connectionstring ConnectionSettings { get; set; }
        public string BaseUrl { get; set; }
    }

    public class Connectionstring
    {
        public string IPASS { get; set; }
    }
}