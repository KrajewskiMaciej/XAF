using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("LC_WYDZIALY")] // Zamiast [Persistent]
    public class Wydzialy
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Odpowiednik XPO [Key(true)]
        [Column("LC_WYDZIALY_ID")]
        [Browsable(false)]
        public virtual int Id { get; set; }

        [Column("LC_WYDZIALY_KOD")]
        [XafDisplayName("Wydział kod")]
        public virtual string Kod { get; set; }

        [Column("LC_WYDZIALY_OPIS")]
        [XafDisplayName("Wydział opis")]
        public virtual string Opis { get; set; }

        // --- Pola, które mogą być NULL - zamienione na typy nullowalne ---

        [Column("PODSTAWOWY")]
        [XafDisplayName("Podstawowy")]
        public virtual int? Podstawowy { get; set; } // int -> int? dla bezpieczeństwa

        [Column("BRAMKA")]
        [XafDisplayName("Bramka")]
        public virtual int? Bramka { get; set; } // int -> int? dla bezpieczeństwa

        // --- Relacje zidentyfikowane w skrypcie SQL ---

        // 1. Relacja do Klienci (wymagana)
        [Column("KLIENCI_ID")]
        public virtual int FirmaId { get; set; } // Klucz obcy

        [ForeignKey(nameof(FirmaId))]
        [XafDisplayName("Firma")]
        public virtual Klient Firma { get; set; } // Właściwość nawigacyjna

        // 2. Relacja do Jednostki (opcjonalna)
        [Column("JEDNOSTKI_ID")]
        public virtual int? JednostkiId { get; set; } // Klucz obcy (nullable)

        [ForeignKey(nameof(JednostkiId))]
        public virtual Jednostki Jednostki { get; set; } // Właściwość nawigacyjna

        // 4. Relacja do SysDokZas (opcjonalna)
        [Column("SYS_DOK_ZAS_ID")]
        public virtual int? SysDokZasId { get; set; } // Klucz obcy (nullable)

        [ForeignKey(nameof(SysDokZasId))]
        public virtual Wydruki SysDokZas { get; set; } // Właściwość nawigacyjna
    }


}