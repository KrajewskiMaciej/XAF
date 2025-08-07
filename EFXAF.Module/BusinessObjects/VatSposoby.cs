using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("VAT_SPOSOBY")]
    [XafDefaultProperty(nameof(Opis))]
    public class VatSposoby
    {
        // Konstruktor i metoda AfterConstruction zostały usunięte

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Odpowiednik XPO [Key(false)]
        [Column("VAT_SPOSOBY_ID")]
        [Browsable(false)]
        public virtual int VatSposobyId { get; set; }

        [Column("VAT_SPOSOBY_KOD")]
        [StringLength(20)] // Zamiast [Size(20)]
        [XafDisplayName("Kod Sposobu VAT")]
        public virtual string Kod { get; set; }

        [Column("VAT_SPOSOBY_OPIS")]
        [StringLength(255)] // Zamiast [Size(255)]
        [XafDisplayName("Opis Sposobu VAT")]
        public virtual string Opis { get; set; }

        [Column("KONTO_BRUTTO")]
        [StringLength(255)]
        [XafDisplayName("Konto Brutto")]
        public virtual string Brutto { get; set; }

        [Column("KONTO_VAT")]
        [StringLength(255)]
        [XafDisplayName("Konto VAT")]
        public virtual string Konto { get; set; }

        // --- Konwersja relacji jeden-do-wielu ---
        public virtual ICollection<VatPowiazania> Powiazania { get; set; } = new List<VatPowiazania>();
    }
}