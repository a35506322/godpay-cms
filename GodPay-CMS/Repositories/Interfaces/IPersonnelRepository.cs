using GodPay_CMS.Repositories.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IPersonnelRepository
    {
        public Task<IEnumerable<User>> GetAllPersonnelByStore();
    }
}
