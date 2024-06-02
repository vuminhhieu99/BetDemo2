using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    /// <summary>
    /// lịch sử tiền vào ra tài khoản
    /// </summary>
    [TableName("history")]
    public class History : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Của người dùng
        /// </summary>
        [Column]
        public int UserId { get; set; }
        /// <summary>
        /// Loại nguồn chuyển vào
        /// </summary>
        [Column]
        public int TypeSource { get; set; }
        /// <summary>
        /// Loại đích chuyển đến
        /// </summary>
        [Column]
        public int TypeDestination { get; set; }
        /// <summary>
        /// Số tiền vào/ra
        /// </summary>
        [Column]
        public float Money { get; set; }
        /// <summary>
        /// Ngày giao dịch
        /// </summary>
        [Column]
        public int TransactionDate { get; set; }
        /// <summary>
        /// Là nạp tiền
        /// </summary>
        [Column]
        public bool IsRecharge { get; set; }
        /// <summary>
        /// Là chuyển thành công
        /// </summary>
        [Column]
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Column]
        public string? Note { get; set; }
    }
}
