using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFXAF.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("KLIENCI")] // Zamiast [Persistent]
    public class Klient
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Odpowiednik XPO [Key(true)]
        [Column("KLIENCI_ID")]
        public virtual int Id { get; set; }

        [Column("KLIENCI_KOD")]
        [XafDisplayName("Firma kod")]
        public virtual string Kod { get; set; }

        [Column("KLIENCI_OPIS")]
        [XafDisplayName("Firma opis")]
        public virtual string Opis { get; set; }

        // --- Konwersja kolekcji (strona "jeden" w relacji 1..N) ---
        public virtual ICollection<Wydzialy> Wydzialy { get; set; } = new List<Wydzialy>();
    }
}