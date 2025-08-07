using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("VAT_WARTOSCI")]
    [XafDefaultProperty(nameof(Kod))]
    public class VatWartosci
    {
        // Konstruktor i metoda AfterConstruction zostały usunięte

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Odpowiednik XPO [Key(false)]
        [Column("VAT_WARTOSCI_ID")]
        [Browsable(false)]
        public virtual int VatWartosciId { get; set; }

        [Column("VAT_WARTOSCI_KOD")]
        [StringLength(20)] // Zamiast [Size(20)]
        [XafDisplayName("Kod Wartości VAT")]
        public virtual string Kod { get; set; }

        [Column("WARTOSC")]
        [XafDisplayName("Wartość VAT")]
        public virtual decimal? Wartosc { get; set; } // decimal -> decimal? dla bezpieczeństwa

        [Column("VAT_STAWKA")]
        [StringLength(10)] // Zamiast [Size(10)]
        [XafDisplayName("Stawka VAT")]
        public virtual string Stawka { get; set; }

        // --- Konwersja relacji jeden-do-wielu ---
        public virtual ICollection<VatPowiazania> Powiazania { get; set; } = new List<VatPowiazania>();
    }
}