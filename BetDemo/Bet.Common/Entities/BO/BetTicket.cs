using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("bet_ticket")]
    public class BetTicket : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Mã phiếu
        /// </summary>
        [Column]
        public string? BetTicketCode { get; set; }
        /// <summary>
        /// Mã thanh toán
        /// </summary>
        [Column]
        public int HistoryId { get; set; }
        /// <summary>
        /// Mã thanh toán
        /// </summary>
        [Column]
        public int UserId { get; set; }
        /// <summary>
        /// Thời gian vào cược
        /// </summary>
        [Column]
        public int Timeline { get; set; }
        /// <summary>
        /// Kèo thắng thua
        /// </summary>
        [Column]
        public int BetId { get; set; }
        /// <summary>
        /// kèo tài xỉu
        /// </summary>
        [Column]
        public int SincboId { get; set; }
        /// <summary>
        /// Tên loại kèo
        /// </summary>
        [Column]
        public string? TypeBet { get; set; }
        /// <summary>
        /// Mô tả sự kiện
        /// </summary>
        [Column]
        public string? Discription { get; set; }
        /// <summary>
        /// Là thắng
        /// </summary>
        [Column]
        public bool IsWin { get; set; }
        /// <summary>
        /// Là thắng
        /// </summary>
        [Column]
        public float Money { get; set; }
        /// <summary>
        ///Tỷ số ăn
        /// </summary>
        [Column]
        public float Profit { get; set; }
    }
}
