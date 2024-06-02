using Bet.Bussiness.Interfaces;
using Bet.Common.Entities;
using Bet.Common.Enum;
using Bet.Common.Requests;
using Bet.Common.Results;
using Bet.Data.Interfaces;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Bet.Common.Entities.Base;
using Bet.Common;

namespace Bet.Bussiness.Version1
{
    public class BaseBussiness<T> : IBaseBussiness<T>
    {
        private IBaseData<T> _baseData;
        //private DbConnection<T> dbConnection;
        public BaseBussiness(IBaseData<T> baseData)
        {
            //dbConnection = new DbConnection<T>();
            _baseData = baseData;
        }

        /// <summary>
        /// Lấy ra toàn bộ danh sách
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// create: 6/2/2021
        public async Task<ServiceResult> GetDataAsync()
        {
            var listEntity = await _baseData.GetDataAsync();
            
            return new ServiceResult()
            {
                Data = listEntity,
                Error = null,
                Status= BetServiceCode.Success

            };
        }

        /// <summary>
        /// Lấy danh sách đối tượng theo trang và số bản ghi
        /// </summary>
        /// <param name="pageRequestBase">trang và bản ghi</param>
        /// <returns>ServiceResult</returns>
        /// create 6/2/2021
        public async Task<ServiceResult> GetDataAsync(PageRequestBase pageRequestBase)
        {

            var listEntiry = await _baseData.GetDataAsync(pageRequestBase);
            var ListPage = new PageResult<T>()
            {
                Items = listEntiry,
                TotalRecord = listEntiry.Count()
            };
            return new ServiceResult()
            {
                Data = ListPage,
                Error = null,
                Status = BetServiceCode.Success
            };
        }

        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity">kiểu thực thể</param>
        /// <returns>ServiceResult</returns>
        /// create: 7/2/2021
        public virtual async Task<ServiceResult> InsertAsync(T entity)
        {
            ServiceResult serviceResult = (entity as BaseEntity).ValidateObject();
            
            if(serviceResult.Status != BetServiceCode.BadRequest)
            {
                var id = await _baseData.InsertAsync(entity);

                if (id > 0)
                {
                    serviceResult.Status = BetServiceCode.Success;
                    serviceResult.Data = id;
                }
                else
                {
                    serviceResult.Status = BetServiceCode.Exception;
                    serviceResult.Error.Add(new ErrorResult()
                    {
                        DevMsg = Properties.Resources.ErrorServive_Employee_Insert,
                        UserMsg = Properties.Resources.ErrorServive_Employee_Insert
                    });
                }
            }            
            return serviceResult;
        }

        /// <summary>
        /// Cập nhật thông tin đối tượng
        /// </summary>
        /// <param name="entity">Kiểu đố tượng</param>
        /// <returns>ServiceResult</returns>
        /// create: 7/2/2021
        public virtual async Task<ServiceResult> UpdateAsync(T entity)
        {
            var effectRow = await _baseData.UpdateAsync(entity);
            ServiceResult serviceResult = new ServiceResult();
            if (effectRow == 1)
            {
                serviceResult.Status = BetServiceCode.Success;
            }
            else
            {
                serviceResult.Status = BetServiceCode.Exception;
                serviceResult.Error.Add(new ErrorResult()
                {
                    DevMsg = Properties.Resources.ErrorServive_Employee_Update,
                    UserMsg = Properties.Resources.ErrorServive_Employee_Update

                });
            }
            return serviceResult;
        }

        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <param name="id">id của đối tượng</param>
        /// <returns>ServiceResult</returns>
        /// create: 7/2/2021
        public virtual async Task<ServiceResult> DeleteAsync(string id)
        {
            ServiceResult serviceResult = new ServiceResult();
            if (await _baseData.DeleteAsync(id) == 1)
            {
                serviceResult.Status = BetServiceCode.Success;
            }
            else
            {
                serviceResult.Status = BetServiceCode.BadRequest;
                serviceResult.Error.Add(new ErrorResult()
                {
                    DevMsg = Properties.Resources.ErrorServive_Employee_EmployeeId_notExist,
                    UserMsg = Properties.Resources.ErrorServive_Employee_EmployeeId_notExist

                });
            }
            return serviceResult;
        }

        /// <summary>
        /// Lấy ra 1 đối tượng theo ID 
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// create 5/2/2021
        public async Task<ServiceResult> GetByIdAsync(string id)
        {
            var result = await _baseData.GetByIdAsync(id);
            ServiceResult serviceResult = new ServiceResult();
            if (result != null)
            {
                serviceResult.Status = BetServiceCode.Success;
            }
            else
            {
                serviceResult.Status = BetServiceCode.Exception;
                serviceResult.Error.Add(new ErrorResult()
                {
                    DevMsg = Properties.Resources.ErrorServive_Employee_GetData,
                    UserMsg = Properties.Resources.ErrorServive_Employee_GetData

                });
            }
            return serviceResult;

        }       
    }
}
