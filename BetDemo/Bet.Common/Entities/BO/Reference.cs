using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("reference")]
    public class Reference
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Bảng giá trị cần mapping
        /// </summary> 
        [Column]
        public string? ForeignTable { get; set; }
        /// <summary>
        /// Bảng giá trị nguồn
        /// </summary> 
        [Column]
        public string? ReferenceTable { get; set; }
        /// <summary>
        /// Tên cột cần mapping
        /// </summary> 
        [Column]
        public string? ForeignField { get; set; }
        /// <summary>
        /// Tên cột có giá trị mapping
        /// </summary> 
        [Column]
        public string? ReferenceField { get; set; }
        /// <summary>
        /// id điều kiện để lấy trường đich id = KeyCondition
        /// </summary> 
        [Column]
        public string? KeyCondition { get; set; }
    }
}
