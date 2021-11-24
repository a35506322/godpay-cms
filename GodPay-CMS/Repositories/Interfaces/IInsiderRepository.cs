using GodPay_CMS.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IInsiderRepository : IGenericRepository<Insider>, IGenericRepositoryById<Insider, string>
    {

    }
}
