using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("user")]
    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Tên đầy đủ
        /// <summary>
        [Column]
        public string? FullName { get; set; }

        /// <summary>
        /// Họ đệm
        /// <summary>
        [Column]
        public string? FirstName { get; set; }

        /// <summary>
        /// Tên
        /// <summary>
        [Column]
        public string? LastName { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// <summary>
        [Column]
        public string? UserName { get; set; }

        /// <summary>
        /// Mật khẩu
        /// <summary>
        [Column]
        public string? Password { get; set; }

        /// <summary>
        /// Mật khẩu MD5
        /// <summary>
        [Column]
        public string? PasswordMd5 { get; set; }
        /// <summary>
        /// Refresh Token
        /// <summary>
        [Column]
        public string? RefreshToken { get; set; }
        /// <summary>
        /// Ngày hêt hạn của refresh token
        /// <summary>
        [Column]
        public DateTime RefreshTokenExpiryTime { get; set; }

        /// <summary>
        /// Số điện thoại
        /// <summary>
        [Column]
        public string? Phone { get; set; }

        /// <summary>
        /// Email
        /// <summary>
        [Column]
        public string? Email { get; set; }

        /// <summary>
        /// Loại ngân hàng
        /// <summary>
        [Column]
        public int BankType { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// <summary>
        [Column]
        public string? TypeName { get; set; }

        /// <summary>
        /// Số tài khoản
        /// <summary>
        [Column]
        public string? BankNumber { get; set; }

        /// <summary>
        /// Tên tài khoản ngân hàng
        /// <summary>
        [Column]
        public string? BankName { get; set; }

        /// <summary>
        /// Số tiền hiện có
        /// <summary>
        [Column]
        public float Money { get; set; }

        /// <summary>
        /// Đã kích hoạt
        /// <summary>
        [Column]
        public bool IsActive { get; set; }

        /// <summary>
        /// Đã xóa
        /// <summary>
        [Column]
        public bool IsDelete { get; set; }        
    }
}
