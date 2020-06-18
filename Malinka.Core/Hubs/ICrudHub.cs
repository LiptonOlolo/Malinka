using Malinka.Core.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Malinka.Core.Hubs
{
    /// <summary>
    /// Crud Hub.
    /// </summary>
    public interface ICrudHub<T, TArg>
    {
        /// <summary>
        /// Get all items.
        /// </summary>
        /// <returns></returns>
        Task<MalinkaResponse<IEnumerable<T>>> GetAllAsync();

        /// <summary>
        /// Get item by Id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns></returns>
        Task<MalinkaResponse<T>> GetById(int id);

        /// <summary>
        /// Add item.
        /// </summary>
        /// <param name="id">Item id.</param>
        /// <returns></returns>
        Task<MalinkaResponse<bool, TArg>> AddAsync(int id);

        /// <summary>
        /// Remove item.
        /// </summary>
        /// <param name="id">Item id.</param>
        /// <returns></returns>
        Task<MalinkaResponse<bool, TArg>> RemoveAsync(int id);

        /// <summary>
        /// Update item.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <returns></returns>
        Task<MalinkaResponse<bool, TArg>> UpdateAsync(T item);
    }
}
