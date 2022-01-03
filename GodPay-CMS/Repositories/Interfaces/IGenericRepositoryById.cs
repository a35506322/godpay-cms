using System.Threading.Tasks;

namespace GodPay_CMS.Repositories.Interfaces
{
    public interface IGenericRepositoryById<T,TId> where T : class
    {
        /// <summary>
        /// 查詢ById
        /// </summary>
        /// <param name="id">PK</param>
        /// <returns></returns>
        public Task<T> GetById(TId id);
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id">PK</param>
        /// <returns></returns>

        public Task<bool> Delete(TId id);
    
    }
}
