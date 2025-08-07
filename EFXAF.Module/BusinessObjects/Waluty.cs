using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFXAF.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("WALUTA")]
    [XafDefaultProperty(nameof(WALUTA_KOD))]
    public class Waluta
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Odpowiednik XPO [Key(true)]
        [Column("WALUTA_ID")]
        [Browsable(false)]
        public virtual int WALUTA_ID { get; set; }

        [Column("WALUTA_KOD")]
        [XafDisplayName("Waluta Kod")]
        public virtual string WALUTA_KOD { get; set; }

        [Column("WALUTA_OPIS")]
        [XafDisplayName("Waluta Opis")]
        public virtual string WALUTA_OPIS { get; set; }

        // UWAGA: Przechowywanie kursu waluty jako string jest nietypowe.
        // Jeśli to możliwe, rozważ zmianę typu tej kolumny w bazie i właściwości w modelu na decimal? lub double?.
        [Column("KURS")]
        [XafDisplayName("Kurs budżetu")]
        public virtual string KURS { get; set; }

        // --- Konwersja relacji jeden-do-wielu ---
        public virtual ICollection<KursyWalut> KursyWalut { get; set; } = new List<KursyWalut>();
    }
}