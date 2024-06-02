using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("sicbo")]
    public class Sicbo : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Thuộc trận đấu thời theo gian trên sân
        /// </summary>
        [Column]
        public int MatchTimeLineId { get; set; }        
        /// <summary>
        /// loại kèo
        /// </summary> 
        [Column]
        public float Type { get; set; }
        /// <summary>
        /// Tên loại kèo
        /// </summary> 
        [Column]
        public string? TypeName { get; set; }
        /// <summary>
        /// Là tài hay xỉu 1: tài, 0 xỉu
        /// </summary> 
        [Column]
        public bool IsAbove { get; set; }
        /// <summary>
        /// Tỷ số ăn
        /// </summary>
        [Column]
        public float Ratio { get; set; }
        /// <summary>
        /// Theo thời điểm này có thắng
        /// </summary>
        [Column]
        public int IsWin { get; set; }
    }
}
