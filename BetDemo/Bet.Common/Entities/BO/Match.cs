using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("match")]
    public class Match : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Thời gian bắt đầu trận đấu
        /// </summary>
        [Column]
        public DateTime TimeStart { get; set; }
        /// <summary>
        /// Thuộc mùa giải
        /// </summary>
        [Column]
        public int SeasonId { get; set; }        
        /// <summary>
        /// idkèo trên
        /// </summary>        
        [Column]
        public int AboveId { get; set; }
        /// <summary>
        /// Tên kèo trên
        /// </summary>        
        [Column]
        public string? AboveName { get; set; }
        /// <summary>
        /// Kèo dưới 
        /// </summary>        
        [Column]
        public int BelowId { get; set; }
        /// <summary>
        /// Tên kèo dưới 
        /// </summary> 
        [Column]
        public string? BelowName { get; set; }
        /// <summary>
        /// kèo trên là chủ nhà
        /// </summary> 
        [Column]
        public bool IsAboveHost { get; set; }
        /// <summary>
        /// Tỷ số kèo trên
        /// </summary> 
        [Column]
        public int AboveScore { get; set; }
        /// <summary>
        /// Tỷ số kèo dưới
        /// </summary> 
        [Column]
        public int BelowScore { get; set; }
        /// <summary>
        /// Tỷ số kèo trên hiệp 1
        /// </summary> 
        [Column]
        public int AboveScoreHalfOne { get; set; }
        /// <summary>
        /// Tỷ số kèo dưới hiệp 1
        /// </summary> 
        [Column]
        public int BelowScoreHalfOne { get; set; }
        /// <summary>
        /// Tỷ số kèo trên hiệp 2
        /// </summary> 
        [Column]
        public int AboveScoreHalfTow { get; set; }
        /// <summary>
        /// Tỷ số kèo dưới hiệp 2
        /// </summary> 
        [Column]
        public int BelowScoreHalfTow { get; set; }
        /// <summary>
        /// Tỷ số kèo trên hiệp phụ 1
        /// </summary> 
        [Column]
        public int AboveScoreMuftOne { get; set; }
        /// <summary>
        /// Tỷ số kèo dưới hiệp phụ 1
        /// </summary> 
        [Column]
        public int BelowScoreMuftOne { get; set; }
        /// <summary>
        /// Tỷ số kèo trên hiệp phụ 2
        /// </summary> 
        [Column]
        public int AboveScoreMuftTow { get; set; }
        /// <summary>
        /// Tỷ số kèo dưới hiệp phụ 2
        /// </summary> 
        [Column]
        public int BelowScoreMuftTow { get; set; }
        /// <summary>
        /// Tỷ số luân lưu kèo trên
        /// </summary> 
        [Column]
        public int AboveScoreShootout { get; set; }
        /// <summary>
        /// Tỷ số luân lưu kèo dưới
        /// </summary> 
        [Column]
        public int BelowScoreShootout { get; set; }
        /// <summary>
        /// Số phạt góc kèo trên
        /// </summary> 
        [Column]
        public int AboveCorner { get; set; }
        /// <summary>
        /// Số phạt góc kèo dưới
        /// </summary> 
        [Column]
        public int BelowCorner { get; set; }
        /// <summary>
        /// Số Penalty kèo trên
        /// </summary> 
        [Column]
        public int AbovePenalty { get; set; }
        /// <summary>
        /// Số Penalty kèo dưới
        /// </summary> 
        [Column]
        public int BelowPenalty { get; set; }
        /// <summary>
        /// Số thẻ vàng kèo trên
        /// </summary> 
        [Column]
        public int AboveYellowCard { get; set; }
        /// <summary>
        /// Số thẻ đỏ kèo trên
        /// </summary> 
        [Column]
        public int AboveRedCard { get; set; }
        /// <summary>
        /// Số thẻ vàng kèo dưới
        /// </summary> 
        [Column]
        public int BelowYellowCard { get; set; }
        /// <summary>
        /// Số thẻ đỏ kèo dưới
        /// </summary> 
        [Column]
        public int BelowRedCard { get; set; }
        /// <summary>
        /// Vòng đấu kèo trên
        /// </summary> 
        [Column]
        public float AboveRound { get; set; }
        /// <summary>
        /// Vòng đấu kèo dưới
        /// </summary> 
        [Column]
        public float BelowRound { get; set; }
        /// <summary>
        /// Tên loại đã thắng: 1, above: 0, null:draw
        /// </summary> 
        [Column]
        public bool IsWin { get; set; }
        /// <summary>
        /// Tên loại đã thắng hiệp 1 : 1, above: 0, null:draw
        /// </summary> 
        [Column]
        public bool IsWinOneHalf { get; set; }
        [Column]
        public bool IsDelete { get; set; }
    }
}
