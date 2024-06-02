using Bet.Common.Results;
using Bet.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.Base
{
    public partial class BaseEntity
    {
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public int CreatedId { get; set; }

        /// <summary>
        /// Tên người tạo
        /// </summary>
        public string? CreatedName { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// NGười sửa
        /// </summary>
        public int ModifiedId { get; set; }

        /// <summary>
        /// Tên người sửa
        /// </summary>
        public string? ModifiedName { get; set; }

        public static string BuildQueryInsert()
        {
            string query = string.Empty;
            
            return query;
        }


        public ServiceResult ValidateObject()
        {
            ServiceResult serviceResult = new ServiceResult();
            var properties = this.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propValue = property.GetValue(this);
                // Nếu có attribute là [Required] thì kiểm tra thực hiện bắt buộc nhập
                //IsDefined: kiểm tra loại của thuộc tính: nếu đúng là true
                if (property.IsDefined(typeof(Required), true) && (propValue == null || propValue.ToString() == string.Empty))
                {
                    /// GetCustomAttributes
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as Required).PropertyName;
                        var errorMsg = (requiredAttribute as Required).ErrorMessenger;
                        serviceResult.Error.Add(new ErrorResult()
                        {
                            DevMsg = errorMsg,
                            UserMsg = errorMsg

                        }); ;
                        serviceResult.Status = BetServiceCode.BadRequest;
                    }

                }

                //Nếu có attribute là [MaxLength] thì thực hiện kiểm độ dài
                if (property.IsDefined(typeof(MaxLength), true))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(MaxLength), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as MaxLength).PropertyName;
                        var errorMsg = (requiredAttribute as MaxLength).ErrorMessenger;
                        var length = (requiredAttribute as MaxLength).Length;
                        if (propValue.ToString().Trim().Length > length)
                        {
                            serviceResult.Error.Add(new ErrorResult()
                            {
                                DevMsg = errorMsg,
                                UserMsg = errorMsg

                            }); ;
                            serviceResult.Status = BetServiceCode.BadRequest;
                        }
                    }
                }
                //Nếu có attribute là [FixLength] thì thực hiện kiểm độ dài
                if (property.IsDefined(typeof(FixLength), true))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(FixLength), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as FixLength).PropertyName;
                        var errorMsg = (requiredAttribute as FixLength).ErrorMessenger;
                        var length = (requiredAttribute as FixLength).Length;
                        if (propValue.ToString().Trim().Length == length)
                        {
                            serviceResult.Error.Add(new ErrorResult()
                            {
                                DevMsg = errorMsg,
                                UserMsg = errorMsg

                            }); ;
                            serviceResult.Status = BetServiceCode.BadRequest;
                        }
                    }
                }
            }

            return serviceResult;
        }
    }
}
