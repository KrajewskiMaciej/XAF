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
    [XafDefaultProperty(nameof(Opis))]
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
        [XafDisplayName("Kod Opisu VAT")]
        public virtual string Kod { get; set; }

        [Column("VAT_OPISY_OPIS")]
        [StringLength(255)] // Zamiast [Size(255)]
        [XafDisplayName("Opis VAT")]
        public virtual string Opis { get; set; }

        // --- Konwersja relacji jeden-do-wielu ---
        public virtual ICollection<VatPowiazania> Powiazania { get; set; } = new List<VatPowiazania>();
    }

    // UWAGA: Aby powyższy kod działał poprawnie, musisz również przekonwertować klasę VatPowiazania.
    // Powinna ona zawierać klucz obcy (np. VatOpisyId) i właściwość nawigacyjną wskazującą z powrotem na klasę VatOpisy.
    //
    // public class VatPowiazania
    // {
    //     // ... inne właściwości
    //
    //     public int VatOpisyId { get; set; } // Klucz obcy
    //     public virtual VatOpisy VatOpisy { get; set; } // Właściwość nawigacyjna
    // }
}