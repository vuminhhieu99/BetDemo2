using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bet.Common.Entities.Base;


namespace Bet.Common.Entities.BO
{
    [TableName("permission")]
    public class Permission : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Tên vai trò
        /// </summary> 
        [Column]
        public int RoleId { get; set; }
        /// <summary>
        /// Tên module
        /// </summary> 
        [Column]
        public string? LayoutCode { get; set; }
        /// <summary>
        /// Quyền
        /// </summary> 
        [Column]
        public int Per { get; set; }
    }
}
