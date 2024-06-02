using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("role")]
    public class Role : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Thời gian trên sân
        /// </summary>
        [Column]
        public int TimeReal { get; set; }
        /// <summary>
        /// Thuộc trận đấu thời theo gian trên sân
        /// </summary>
        [Column]
        public int MatchTimeLineId { get; set; }
        /// <summary>
        /// Số Tỉ giá kèo trên thắng
        /// </summary> 
        [Column]
        public float AboveWinRatio { get; set; }
        /// <summary>
        /// Tỉ giá kèo dưới thắng
        /// </summary> 
        [Column]
        public float BelowWinRatio { get; set; }
        /// <summary>
        /// Tỉ giá tỷ số hòa
        /// </summary> 
        [Column]
        public float DrawRatio { get; set; }
    }
}
