namespace Nha_Bep.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ban")]
    public partial class Ban
    {
        public string MaBan { get; set; }


        public string TenBan { get; set; }

        public int TrangThai { get; set; }


        public string Vitri { get; set; }

        public virtual Ban_HoaDon Ban_HoaDon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatMon> DatMons { get; set; }
    }
}
