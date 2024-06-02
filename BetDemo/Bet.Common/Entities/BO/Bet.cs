using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("bet")]
    public class Bet : BaseEntity
    {
        [Key]
        public int Id { get; set; }        
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
        /// <summary>
        /// Tên loại đã thắng: 1, above: 0, null:draw
        /// </summary> 
        [Column]
        public bool IsWin { get; set; }
    }
}
