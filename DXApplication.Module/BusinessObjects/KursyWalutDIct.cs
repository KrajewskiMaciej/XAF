using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.ExpressApp.Model;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("SLO_KURSY_WALUTY")]
    public class KursyWalut
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SLO_KURSY_WALUTY_ID")]
        [Browsable(false)]
        public virtual int SLO_KURSY_WALUTY_ID { get; set; }

        // --- Relacja do Waluta (wymagana) ---

        [Column("WALUTA_ID")] // Definicja klucza obcego
        public virtual int WalutaId { get; set; } // int, a nie int?, bo relacja jest wymagana (INNER JOIN)

        [ForeignKey(nameof(WalutaId))] // Połączenie nawigacji z kluczem obcym
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public virtual Waluty Waluta { get; set; }

        // --- Właściwość niemapowana (NonPersistent) ---

        [NotMapped] // Informuje EF Core, aby ignorował tę właściwość przy mapowaniu do bazy
        [XafDisplayName("Kod")] // Zamieniono DevExpress.Xpo.DisplayName na nowszy atrybut
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        public virtual string WalutaKod => Waluta?.WALUTA_KOD;


        // --- Pozostałe właściwości ---

        [Column("KURS_Z_DNIA")]
        [XafDisplayName("Kurs z dnia")]
        public virtual DateTime? KursZDnia { get; set; } // Zmieniono na nullable dla bezpieczeństwa

        [Column("NUMER_TABELI")]
        public virtual string NumerTabeli { get; set; }

        [Column("KURS")]
        public virtual string Kurs { get; set; }

        [Column("DATA_OD")]
        public virtual DateTime? WazneOd { get; set; } // Zmieniono na nullable dla bezpieczeństwa

        [Column("DATA_DO")]
        public virtual DateTime? WazneDo { get; set; } // Zmieniono na nullable dla bezpieczeństwa
    }
}