using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("SYS_DOK_ZAS")] // Zamiast [Persistent] na klasie
    [XafDefaultProperty(nameof(WydrukiOpis))] // Poprawiony atrybut z oryginalnego kodu
    public class Wydruki
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Odpowiednik XPO [Key(true)]
        [Column("SYS_DOK_ZAS_ID")]
        [Browsable(false)]
        public virtual int WydrukID { get; set; }

        // --- Relacja do Kategoria ---
        [Column("RAPORT_KATEGORIA")]
        public virtual int? KategoriaId { get; set; } // Jawna właściwość klucza obcego (nullable dla bezpieczeństwa)

        [ForeignKey(nameof(KategoriaId))]
        public virtual SysDokZasKategoria Kategoria { get; set; } // Właściwość nawigacyjna

        // --- Pozostałe właściwości ---
        [Column("SYS_DOK_ZAS_KOD")]
        public virtual string WydrukiKod { get; set; }

        [Column("SYS_DOK_KOD_OPIS")]
        public virtual string WydrukiOpis { get; set; }

        [Column("RAPORT")]
        public virtual string Raport { get; set; }

        [Column("WIDOCZNY")]
        public virtual short? Widoczny { get; set; } // short -> short?

        [Column("ARCHIWIZUJ")]
        public virtual short? Archiwizuj { get; set; } // short -> short?

        [Column("INSERTED_BY")]
        public virtual string UtworzonyPrzez { get; set; }

        [Column("INS_DATE")]
        public virtual DateTime? DataDodania { get; set; } // DateTime -> DateTime?

        [Column("EDITING")]
        public virtual string EdytowanyPrzez { get; set; }

        [Column("EDI_DATE")]
        public virtual DateTime? DataEdycji { get; set; } // DateTime -> DateTime?
    }
}

