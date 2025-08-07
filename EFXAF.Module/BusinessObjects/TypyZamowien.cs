using DevExpress.Persistent.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFXAF.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("ZAMOWIENIA_TYP")] // Zamiast [Persistent]
    public class TypyZamowienia
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Odpowiednik XPO [Key(true)]
        [Column("ZAMOWIENIA_TYP_ID")]
        [Browsable(false)]
        public virtual int ZamowieniaTypId { get; set; }

        [Column("ZAMOWIENIA_TYP_OPIS")]
        public virtual string Opis { get; set; }

        [Column("ZAMOWIENIE_RODZAJ")]
        public virtual string Rodzaj { get; set; }

        // --- Pola wartościowe zamienione na nullowalne dla bezpieczeństwa ---

        [Column("PRODUKCJA")]
        public virtual bool? Produkcja { get; set; }

        [Column("KONTROLUJ_KLUCZ")]
        public virtual bool? KontrolujKlucz { get; set; }

        [Column("KONTROLUJ_KLUCZ_KLIENTA")]
        public virtual bool? KontrolujKluczKlienta { get; set; }

        [Column("NR_ZAM2KLUCZ")]
        public virtual bool? NrZam2Klucz { get; set; }

        [Column("KONTROLUJ_KOMISJE")]
        public virtual bool? KontrolujKomisje { get; set; }

        [Column("NUMER_START")]
        public virtual int? NumerStart { get; set; }

        [Column("INSERTED_BY")]
        public virtual string InsertedBy { get; set; }

        [Column("INS_DATE")]
        public virtual DateTime? InsertedDate { get; set; } // Już było nullable, co jest poprawne

        [Column("EDITING")]
        public virtual string Editing { get; set; }

        [Column("EDI_DATE")]
        public virtual DateTime? EdiDate { get; set; } // Już było nullable, co jest poprawne

        [Column("SCHEMAT_PRZYKLAD")]
        public virtual string SchematPrzyklad { get; set; }

        [Column("AUTONUMER")]
        public virtual bool? Autonumer { get; set; }

        [Column("ZAMOWIENIA_TYP_KOD")]
        public virtual string ZamowieniaTypKod { get; set; }

        [Column("EDI_KOD")]
        public virtual string EdiKod { get; set; }

        [Column("BOOKING_RULES")]
        public virtual string BookingRules { get; set; }

        [Column("WYKLUCZ_Z_MAT_DET_SERIA")]
        public virtual bool? WykluczZMatDetSeria { get; set; }

        [Column("BOOKING_ANONYMOUS_LEVEL")]
        public virtual int? BookingAnonymousLevel { get; set; }

        [Column("KONTROLA_WYSYLKI")]
        public virtual bool? KontrolaWysylki { get; set; }

        // --- Relacja do AutoNumSchemat (opcjonalna) ---

        [Column("AUTO_NUM_SCHEMAT_ID")]
        public virtual int? AutoNumSchematId { get; set; } // Klucz obcy (musi być nullable, bo jest LEFT JOIN)

        [ForeignKey(nameof(AutoNumSchematId))]
        public virtual AutoNumSchemat AutoNumSchemat { get; set; } // Właściwość nawigacyjna
    }
}