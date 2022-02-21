using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Services.DTO.Response
{
    public class TreeTableRsp<T> where T : class
    {
        /// <summary>
        /// PK
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 資料
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 子資料
        /// </summary>
        public List<TreeTableRsp<T>> Children { get;set;}

    }
}
