namespace Test1.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Ban_HoaDon
    {
        [Key]
        [StringLength(10)]
        public string MaBan { get; set; }

        public int? MaHoaDon { get; set; }

        public DateTime? GioVao { get; set; }

        public virtual Ban Ban { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
