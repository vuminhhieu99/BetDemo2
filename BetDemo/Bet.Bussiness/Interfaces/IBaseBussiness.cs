using Bet.Common.Requests;
using Bet.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Bussiness.Interfaces
{
    public interface IBaseBussiness<T>
    {

        /// <summary>
        /// Lấy ra toàn bộ danh sách - kỹ thuật DI
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// create 5/2/2021
        public Task<ServiceResult> GetDataAsync();

        /// <summary>
        /// Lấy danh sách đối tượng theo trang và số bản ghi - kỹ thuật DI
        /// </summary>
        /// <param name="pageRequestBase">trang và bản ghi</param>
        /// <returns>ServiceResult</returns>
        /// create 4/2/2021
        public Task<ServiceResult> GetDataAsync(PageRequestBase pageRequestBase);

        /// <summary>
        /// thêm mới đối tượng - kỹ thuật DI
        /// </summary>
        /// <param name="entity">thông tin nhân viên</param>
        /// <returns>ServiceResult</returns>
        /// update: 3/2/2021
        public Task<ServiceResult> InsertAsync(T entity);

        /// <summary>
        /// cập nhập đối tượng - kỹ thuật DI
        /// </summary>
        /// <param name="entity">thông tin nhân viên</param>
        /// <returns>ServiceResult</returns>

        public Task<ServiceResult> UpdateAsync(T entity);


        /// <summary>
        /// Xóa nhân đối tượng theo id - kỹ thuật DI
        /// </summary>
        /// <param name="id">id của nhân viên</param>
        /// <returns>ServiceResult</returns>

        public Task<ServiceResult> DeleteAsync(string id);

        /// <summary>
        /// Lấy ra 1 đối tượng theo ID  - kỹ thuật DI
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// create 5/2/2021
        public Task<ServiceResult> GetByIdAsync(string id);


        /// <summary>
        /// Vdidate dữ liệu 
        /// </summary>
        /// <param name="serviceResult"></param>
        /// <param name="entity"></param>
        /// create: 8/2/2021
        //public void ValidateObject(ref ServiceResult serviceResult, T entity);
    }
}

