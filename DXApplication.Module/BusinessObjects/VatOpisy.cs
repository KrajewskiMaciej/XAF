using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("VAT_OPISY")]
    public class VatOpisy
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Odpowiednik XPO [Key(AutoGenerate = true)]
        [Column("VAT_OPISY_ID")]
        [Browsable(false)]
        public virtual int VatOpisyId { get; set; }

        [Column("VAT_OPISY_KOD")]
        [StringLength(20)] // Zamiast [Size(20)]
        [XafDisplayName("VAT kod")]
        public virtual string Kod { get; set; }

        [Column("VAT_OPISY_OPIS")]
        [StringLength(255)] // Zamiast [Size(255)]
        [XafDisplayName("VAT opis")]
        public virtual string Opis { get; set; }

        public virtual ICollection<VatPowiazania> Powiazania { get; set; } = new List<VatPowiazania>();
    }
}