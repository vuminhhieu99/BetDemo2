using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("gold_time_line")]
    public class GoldTimeLine : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Trận đấu
        /// </summary>
        [Column]
        public int MatchId { get; set; }
        /// <summary>
        /// Đội bóng
        /// </summary>
        [Column]
        public int TeamId { get; set; }
        /// <summary>
        /// Tên đội bóng
        /// </summary>
        [Column]
        public string? TeamName { get; set; }
        /// <summary>
        /// Là ghi bàn hay bị thủng lưới 1: ghi bàn; 2: thủng lưới
        /// </summary>
        [Column]
        public bool IsGold { get; set; }
        /// <summary>
        /// Thời gian ghi bàn trong trận
        /// </summary>
        [Column]
        public int Timeline { get; set; }
        /// <summary>
        /// Tên cầu thủ ghi bàn
        /// </summary>
        [Column]
        public string? PlayerName { get; set; }        
    }
}
