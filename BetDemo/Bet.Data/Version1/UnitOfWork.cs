using Bet.Data.Interfaces;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using static Dapper.SqlMapper;
using Bet.Common;

namespace Bet.Data.Version1
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private string ConnectionString = string.Empty;
        private IDbConnection _dbConnection = null;
        private IConfiguration _configuration = null;
        private IDbTransaction _transaction = null;

        public UnitOfWork(IConfiguration configuration)
        {
            this._configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("MysqlConnectionString");
            this._dbConnection = new MySqlConnection(ConnectionString);
            this._dbConnection.Open();
            this._transaction = _dbConnection.BeginTransaction();

        }

        private void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _dbConnection.BeginTransaction();

            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
            if (_dbConnection != null)
            {
                _dbConnection.Dispose();
                _dbConnection = null;
            }
        }

        /// <summary>
        /// Thực thi QueryFirstOrDefault
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {

                if (_transaction == null)
                    throw new Exception($"The requires a transaction");
                var result = _dbConnection.QueryFirstOrDefault<T>(sql, param: param, commandType: commandType, commandTimeout: commandTimeout, transaction: this._transaction);
                this.Commit();
                return result;
            }
            catch (Exception ex)
            {
                if(_transaction != null)
                {
                    _transaction?.Rollback();
                    _transaction?.Dispose();
                    _transaction = _dbConnection.BeginTransaction();
                }                
                LogCustom.LogError(ex.Message);
                throw ex;
            }            
        }

        /// <summary>
        /// Thực thi QueryAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                if (_transaction == null)
                    throw new Exception($"The requires a transaction");
                var result = _dbConnection.Query<T>(sql, param: param, commandType: commandType, commandTimeout: commandTimeout, transaction: this._transaction);
                this.Commit();
                return result;
            }
            catch (Exception ex)
            {
                this._transaction.Rollback();
                LogCustom.LogError(ex.Message);
                throw ex;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _dbConnection.BeginTransaction();
            }
        }

        /// <summary>
        /// Thực thi QueryAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                if (_transaction == null)
                    throw new Exception($"The requires a transaction");
                var result = await _dbConnection.QueryAsync<T>(sql, param: param, commandType: commandType, commandTimeout: commandTimeout, transaction: this._transaction);
                this.Commit();
                return result;
            }
            catch (Exception ex)
            {
                this._transaction.Rollback();
                LogCustom.LogError(ex.Message);
                throw ex;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _dbConnection.BeginTransaction();
            }
        }

        /// <summary>
        /// Thực thi ExecuteScalarAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<T> ExecuteScalarAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                if (_transaction == null)
                    throw new Exception($"The requires a transaction");
                var result = await _dbConnection.ExecuteScalarAsync<T>(sql, param: param, commandType: commandType, commandTimeout: commandTimeout, transaction: this._transaction);
                this.Commit();
                return result;
            }
            catch (Exception ex)
            {
                this._transaction.Rollback();
                LogCustom.LogError(ex.Message);
                throw ex;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _dbConnection.BeginTransaction();
            }
        }

        /// <summary>
        /// Thực thi ExecuteScalarAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                if (_transaction == null)
                    throw new Exception($"The requires a transaction");
                var result = await _dbConnection.ExecuteAsync(sql, param: param, commandType: commandType, commandTimeout: commandTimeout, transaction: this._transaction);
                this.Commit();
                return result;
            }
            catch (Exception ex)
            {
                this._transaction.Rollback();
                LogCustom.LogError(ex.Message);
                throw ex;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _dbConnection.BeginTransaction();
            }
        }

        /// <summary>
        /// Thực thi QueryMultipleAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<GridReader> QueryMultipleAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                if (_transaction == null)
                    throw new Exception($"The requires a transaction");
                var result = await _dbConnection.QueryMultipleAsync(sql, param: param, commandType: commandType, commandTimeout: commandTimeout, transaction: this._transaction);
                this.Commit();
                return result;
            }
            catch (Exception ex)
            {
                this._transaction.Rollback();
                LogCustom.LogError(ex.Message);
                throw ex;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _dbConnection.BeginTransaction();
            }
        }

        /// <summary>
        /// Thực thi QueryDictionnary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, object>> QueryDictionnaryAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                if (_transaction == null)
                    throw new Exception($"The requires a transaction");
                var result = await _dbConnection.QueryAsync<KeyValuePair<string, object>>(sql, param: param, commandType: commandType, commandTimeout: commandTimeout, transaction: this._transaction);
                this.Commit();
                return result.ToDictionary(pair => pair.Key, pair => pair.Value);
            }
            catch (Exception ex)
            {
                this._transaction.Rollback();
                LogCustom.LogError(ex.Message);
                throw ex;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _dbConnection.BeginTransaction();
            }
        }

    }
}
