namespace HotelManagement.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    // Lớp thực thể (Entity) đại diện bảng KhachHang trong CSDL
    [Table("KhachHang")]
    public partial class KhachHang
    {
        // Hàm khởi tạo, khởi tạo tập hợp Phiếu thuê liên kết với khách hàng
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            PhieuThues = new HashSet<PhieuThue>();
        }

        // Mã khách hàng (khóa chính), tối đa 5 ký tự (ví dụ: KH001)
        [Key]
        [StringLength(5)]
        public string MaKH { get; set; }

        // Tên khách hàng, bắt buộc, tối đa 50 ký tự
        [Required]
        [StringLength(50)]
        public string TenKH { get; set; }

        // Số điện thoại khách hàng, tối đa 10 ký tự
        [StringLength(10)]
        public string SDT { get; set; }

        // Số CCCD/Passport, ánh xạ tới cột "CCCD/Passport" trong CSDL, bắt buộc, tối đa 12 ký tự
        [Column("CCCD/Passport")]
        [Required]
        [StringLength(12)]
        public string CCCD_Passport { get; set; }

        // Quốc tịch khách hàng, bắt buộc, tối đa 30 ký tự
        [Required]
        [StringLength(30)]
        public string QuocTich { get; set; }

        // Giới tính khách hàng (ví dụ: "Nam", "Nữ"), bắt buộc, tối đa 3 ký tự
        [Required]
        [StringLength(3)]
        public string GioiTinh { get; set; }

        // Địa chỉ email của khách hàng, bắt buộc, tối đa 100 ký tự
        [Required]
        [StringLength(100)]
        public string Email { get; set; } // Khai báo biến Email

        // Cờ đánh dấu xóa mềm (true = đã xóa, false hoặc null = còn sử dụng)
        public bool? DaXoa { get; set; }

        // Tập hợp các phiếu thuê (quan hệ 1-nhiều giữa Khách hàng và Phiếu thuê)
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThue> PhieuThues { get; set; }
    }
}
