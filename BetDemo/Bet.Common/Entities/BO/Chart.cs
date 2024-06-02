using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("chart")]
    public class Chart : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Số điểm mùa này
        /// </summary>
        [Column]
        public int Score { get; set; }
        /// <summary>
        /// Số trận đã đá
        /// </summary>
        [Column]
        public int Match { get; set; }
        /// <summary>
        /// Id đội bóng
        /// </summary>
        [Column]
        public int TeamId { get; set; }
        /// <summary>
        /// Tên đội bóng
        /// </summary>
        [Column]
        public string? TeamName { get; set; }
        /// <summary>
        /// Số thẻ vàng của đội bóng
        /// </summary>
        [Column]
        public int YellowCard { get; set; }
        /// <summary>
        /// Số thẻ đỏ của đội bóng
        /// </summary>
        [Column]
        public int RedCard { get; set; }
        /// <summary>
        /// Số phạt góc được hưởng của đội bóng
        /// </summary>
        [Column]
        public int Corner { get; set; }
        /// <summary>
        ///Số phạt góc bị của đội bóng
        /// </summary>
        [Column]
        public int CornerConceded { get; set; }
        /// <summary>
        /// Số Penalty được hưởng của đội bóng
        /// </summary>
        [Column]
        public int Penalty { get; set; }
        /// <summary>
        /// Số Penalty bị của đội bóng
        /// </summary>
        [Column]
        public int PenaltyConceded { get; set; }
        /// <summary>
        /// Tổng số bàn thắng của đội bóng
        /// </summary>
        [Column]
        public int Goal { get; set; }
        /// <summary>
        /// Tổng số bàn thua của đội bóng
        /// </summary>
        [Column]
        public int GoalConceded { get; set; }
        /// <summary>
        /// Đã xóa
        /// </summary>
        [Column]
        public bool Isdelete { get; set; }

    }
}
