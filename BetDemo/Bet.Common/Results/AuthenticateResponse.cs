using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Results
{
    public class AuthenticateResponse
    {
       public int Id { get; set; }

        /// <summary>
        /// Tên đầy đủ
        /// <summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Họ đệm
        /// <summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Tên
        /// <summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// <summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Số điện thoại
        /// <summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Email
        /// <summary>
        public string? Email { get; set; }

        /// <summary>
        /// Loại ngân hàng
        /// <summary>
        public int BankType { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// <summary>
        public string? TypeName { get; set; }

        /// <summary>
        /// Số tài khoản
        /// <summary>
        public string? BankNumber { get; set; }

        /// <summary>
        /// Tên tài khoản ngân hàng
        /// <summary>
        public string? BankName { get; set; }

        /// <summary>
        /// Số tiền hiện có
        /// <summary>

        public float Money { get; set; }

        /// <summary>
        /// Đã kích hoạt
        /// <summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Token
        /// <summary>
        public string? Token { get; set; }
        /// <summary>
        /// Refresh Token
        /// <summary>
        public string? RefreshToken { get; set; }
        /// <summary>
        /// Ngày hêt hạn của refresh token
        /// <summary>
        public DateTime RefreshTokenExpiryTime { get; set; }

    }
}
