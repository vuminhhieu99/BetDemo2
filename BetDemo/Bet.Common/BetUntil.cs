using Bet.Common.Entities;
using Bet.Common.Entities.BO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
namespace Bet.Common
{
    // Hàm siwr lý nghiệp vụ chương trình
    public static class BetUtil
    {
        public static IConfiguration? _configuration;

        private static string _rootPath;
        public static string RootPath
        {
            get
            {
                return _rootPath;
            }
        }

        /// <summary>
        /// 1 hàm tiêm phụ thuộc cho _configuration Khi bắt đầu chạy trương trình
        /// </summary>
        /// <param name="configuration"></param>
        public static void Contructor(IConfiguration configuration, string rootPath)
        {
            _configuration = configuration;
            _rootPath = rootPath;
        }


        /// <summary>
        /// Lấy tên bảng trong database
        /// </summary>
        /// <param name="layoutCode"></param>
        /// <returns></returns>
        public static string GetTableName(string layoutCode)
        {
            try
            {
                var objectClass = Type.GetType($"Bet.Common.Entities.BO.{layoutCode}").GetCustomAttributes(typeof(TableName), true).FirstOrDefault();
                return (objectClass as TableName).Name;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// Láy query sql
        /// </summary>
        /// <param name="key"></param>
        /// <param name="layoutCode"></param>
        /// <returns></returns>
        public static string GetQuerySql(string key, string layoutCode = "")
        {
            string query = string.Empty;
            if (!String.IsNullOrEmpty(layoutCode))
            {
                query = _configuration.GetSection($"QuerySql:{layoutCode}:{key}").Value;
            }
            else
            {
                query = _configuration.GetSection($"QuerySql:{key}").Value;
            }
            return query;
        }

        /// <summary>
        /// Láy AppSetting
        /// </summary>
        /// <param name="key"></param>
        /// <param name="layoutCode"></param>
        /// <returns></returns>
        public static string GetValueAppSetting(string key, string layoutCode = "")
        {
            string query = string.Empty;
            if (!String.IsNullOrEmpty(layoutCode))
            {
                query = _configuration.GetSection($"{layoutCode}:{key}").Value;
            }
            else
            {
                query = _configuration.GetSection($"{key}").Value;
            }
            return query;
        }


        /// <summary>
        /// Lấy query log 
        /// </summary>
        /// <param name="key"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static string GetLogConfig(string key)
        {
            return _configuration.GetSection($"LogConfig:{key}").Value;
        }

        /// <summary>
        /// Hàm convert MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }
        /// <summary>
        /// Hàm tạo môi trường lưu lại vào DB
        /// </summary>
        /// <param name="action"></param>
        public static void CreateTask(Action action)
        {

            action();
        }
    }


    public static class ExtensionMethod
    {
        public static string GetTableName(this string layoutCode)
        {
            try
            {
                var objectClass = Type.GetType($"Bet.Common.Entities.BO.{layoutCode}").GetCustomAttributes(typeof(TableName), true).FirstOrDefault();
                return (objectClass as TableName).Name;
            }
            catch (Exception ex)
            {
                return "";
            }

        }
    }

}