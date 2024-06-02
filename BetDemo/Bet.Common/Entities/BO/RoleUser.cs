using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("role_user")]
    public class RoleUser : BaseEntity
    {

        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Người dùng
        /// </summary> 
        [Column]
        public int UserId { get; set; }
        /// <summary>
        /// Vai trò
        /// </summary> 
        [Column]
        public int RoleId { get; set; }
    }
}
