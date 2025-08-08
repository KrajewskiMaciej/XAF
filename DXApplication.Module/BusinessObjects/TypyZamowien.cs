using DevExpress.Persistent.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
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

        [Column("ZAMOWIENIA_TYP_KOD")]
        public virtual string TypyZamowieniaKod { get; set; }

        [Column("ZAMOWIENIA_TYP_OPIS")]
        public virtual string TypyZamowieniaOpis { get; set; }

        [Column("ZAMOWIENIE_RODZAJ")]
        public virtual string RodzajZam { get; set; }

        // --- Pola wartościowe zamienione na nullowalne dla bezpieczeństwa ---

        [Column("PRODUKCJA")]
        public virtual bool? Produkcja { get; set; }

        [Column("KONTROLUJ_KLUCZ")]
        public virtual bool? KontrolujKlucz { get; set; }

        [Column("KONTROLUJ_KLUCZ_KLIENTA")]
        public virtual bool? KontrolujKluczKlienta { get; set; }

        [Column("NR_ZAM2KLUCZ")]
        public virtual bool? NrZamDoKlucza { get; set; }

        [Column("KONTROLUJ_KOMISJE")]
        public virtual bool? KontrolujKomisje { get; set; }

        [Column("AUTONUMER")]
        public virtual bool? Autonumerowanie { get; set; }

        [Column("AUTO_NUM_SCHEMAT_ID")]
        [Browsable(false)]
        public virtual int? AutoNumSchematId { get; set; } // Klucz obcy (musi być nullable, bo jest LEFT JOIN)

        [ForeignKey(nameof(AutoNumSchematId))]
        public virtual SchematAutonumeracji ShcematAutonum { get; set; } // Właściwość nawigacyjna

        [Column("BOOKING_RULES")]
        public virtual int? RegulyRezerwacji { get; set; }

        [Column("BOOKING_ANONYMOUS_LEVEL")]
        public virtual int? AnonimizacjaRezerwacji { get; set; }


        [Column("WYKLUCZ_Z_MAT_DET_SERIA")]
        public virtual bool? WykluczZMatDetSeria { get; set; }

        
        [Column("KONTROLA_WYSYLKI")]
        public virtual bool? KontrolaWysylki { get; set; }

    }
}