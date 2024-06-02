using Bet.Common;
using Bet.Common.Entities;
using Bet.Common.Requests;
using Bet.Data.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Data.Version1
{
    public class BaseData<T> : IBaseData<T>
    {
        public IUnitOfWork _unitOfWork;

        public BaseData(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Lấy danh sách theo chuỗi sql
        /// </summary>
        /// <param name="commandText">chuỗi sql</param>
        /// <param name="parameters">tham sô truyền vào</param>
        /// <param name="commandType">kiểu truy vấn</param>
        /// <returns>danh sách đối tượng</returns>
        /// create: 7/2/2021
        public async Task<IEnumerable<T>> GetDataAsync(string commandText = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            if (commandText == null)
            {
                string className = typeof(T).Name;
                var queryString = $"SELECT * FROM {className}";
                return await _unitOfWork.QueryAsync<T>(queryString);
            }
            if (parameters != null)
            {
                return await _unitOfWork.QueryAsync<T>(commandText, param: parameters, commandType: commandType);
            }
            return await _unitOfWork.QueryAsync<T>(commandText, commandType: commandType);
        }

        // <summary>
        /// Lấy danh sách theo chuỗi sql chỉ định đầu ra cụ thể
        /// </summary>
        /// <param name="commandText">chuỗi sql</param>
        /// <param name="parameters">tham sô truyền vào</param>
        /// <param name="commandType">kiểu truy vấn</param>
        /// <returns>danh sách đối tượng</returns>
        /// create: 8/2/2021
        public async Task<IEnumerable<T2>> GetDataAsync<T2>(string commandText = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            if (commandText == null)
            {
                string className = typeof(T2).Name;
                var queryString = $"SELECT * FROM {className}";
                return await _unitOfWork.QueryAsync<T2>(queryString);
            }
            if (parameters != null)
            { 
                return await _unitOfWork.QueryAsync<T2>(commandText, param: parameters, commandType: commandType);
            }
            return await _unitOfWork.QueryAsync<T2>(commandText, commandType: commandType);

        }

        /// <summary>
        /// Lấy danh sách thuộc tính theo số trang và kích thước trang
        /// </summary>
        /// <param name="pageRequestBase">số trang và kích thước trang</param>
        /// <returns>danh sách thuộc tính</returns>
        /// create: 7/2/2021
        public async Task<IEnumerable<T>> GetDataAsync(PageRequestBase pageRequestBase)
        {
            int indexStart = (pageRequestBase.PageIndex - 1) * pageRequestBase.PageSize;
            string className = typeof(T).Name;
            var queryString = $"SELECT * FROM {className} LIMIT {indexStart.ToString()}, {pageRequestBase.PageSize.ToString()}";
            return await _unitOfWork.QueryAsync<T>(queryString);
        }

        /// <summary>
        /// Lấy đối tượng theo id 
        /// </summary>
        /// <param name="id">Id của đối tượng</param>
        /// <returns>Một đối tượng</returns>
        /// create: 7/2/2021
        public async Task<T?> GetByIdAsync(object id)
        {
            string className = typeof(T).Name;
            var queryString = $"SELECT * FROM {className} WHERE Id ='{id.ToString()}'";
            var entites = await _unitOfWork.QueryAsync<T>(queryString);
            return entites.FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entiry">Thông tin đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// create: 7/2/2021
        public async Task<int> InsertAsync(T entiry)
        {
            string className = typeof(T).Name.GetTableName();
            var properties = typeof(T).GetProperties();
            var parameters = new DynamicParameters();
            string sqlPropertyBuider = string.Empty;
            string sqlPropertyParamBuilder = string.Empty;

            foreach (var property in properties)
            {
                if(property.GetCustomAttributes(typeof(Column), true).FirstOrDefault() != null)
                {
                    var propertyName = property.Name;
                    var propertyValue = property.GetValue(entiry);
                    parameters.Add($"@{propertyName}", propertyValue);
                    sqlPropertyBuider += $", {propertyName}";
                    sqlPropertyParamBuilder += $", @{propertyName}";
                } 
            }
            var query = $"INSERT INTO {className}({sqlPropertyBuider.Substring(1)}) VALUES ({sqlPropertyParamBuilder.Substring(1)}); SELECT LAST_INSERT_ID()";
            return await _unitOfWork.ExecuteScalarAsync<int>(query, parameters);

        }

        /// <summary>
        /// Cập nhật đối tượng
        /// </summary>
        /// <param name="entiry">Thông tin đối tượng</param>
        /// <param name="column">Chuỗi cột được update, ,mặc định cập nhật tất cả</param>

        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// create: 7/2/2021   
        public async Task<int> UpdateAsync(T entiry, string? column = null)
        {
            string className = typeof(T).Name.GetTableName();

            var properties = typeof(T).GetProperties().ToList<PropertyInfo>();
            var properId = properties.Find(property => property.GetCustomAttributes(typeof(Key), true).FirstOrDefault() != null);
            string? Id;
            if (properId != null)
            {
                Id = properId.GetValue(entiry).ToString();
            }
            else
            {
                return 0;
            }
            if (column != null)
            {
                var attributionColumn = column.ToLower().Split(',').ToList();
                properties = properties.Where(property => attributionColumn.Contains(property.Name.ToLower())).ToList();
            }             
            var parameters = new DynamicParameters();
            string sqlPropertyBuider = string.Empty;
            
            foreach (var property in properties)
            {
                if (property.GetCustomAttributes(typeof(Column), true).FirstOrDefault() != null && property.GetCustomAttributes(typeof(Key),true).FirstOrDefault() == null)
                {
                    var propertyName = property.Name;
                    var propertyValue = property.GetValue(entiry);
                    parameters.Add($"@{propertyName}", propertyValue);
                    sqlPropertyBuider += $", {propertyName} = @{propertyName}";
                }               
            }
            var query = $"UPDATE {className} SET {sqlPropertyBuider.Substring(1)} WHERE Id = {Id}";

            return await _unitOfWork.ExecuteAsync(query, parameters, commandType: CommandType.Text);

        }

        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <param name="id">id của đối tượng:</param>
        /// <returns>số dòng bị ảnh hưởng</returns>
        /// create: 7/2/2021        
        public async Task<int> DeleteAsync(string id)
        {
            string className = typeof(T).Name;
            var query = $"Proc_Delete{className}";
            var parameters = new DynamicParameters();
            parameters.Add($"@{className}Id", id);
            return await _unitOfWork.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);


        }
        // hàm hủy kết nối
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        /// <summary>
        /// Lấy đối tượng theo id chỉ định đầu ra cụ thể
        /// </summary>
        /// <param name="id">Id của đối tượng</param>
        /// <returns>Một đối tượng</returns>
        /// create: 22/2/2021
        public async Task<T2?> GetById<T2>(object id)
        {
            string className = typeof(T2).Name;
            var queryString = $"SELECT * FROM {className} WHERE {className}Id ='{id.ToString()}'";
            var entites = await _unitOfWork.QueryAsync<T2>(queryString);
            return entites.FirstOrDefault();
        }

        public string? testDI()
        {
            throw new NotImplementedException();
        }  
    }
}
