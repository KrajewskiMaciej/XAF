using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("KRAJE")] // Zamiast [Persistent]
    [XafDefaultProperty(nameof(Opis))]
    public class Kraje
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Odpowiednik XPO [Key(AutoGenerate = true)]
        [Column("KRAJE_ID")]
        [Browsable(false)]
        public virtual int Id { get; set; } // Zmieniono nazwę na standardowe 'Id'

        [Column("KRAJE_KOD")]
        [XafDisplayName("Kod Kraju")]
        public virtual string Kod { get; set; }

        [Column("KRAJE_OPIS")]
        [XafDisplayName("Nazwa Kraju")]
        public virtual string Opis { get; set; }

        // --- Konwersja relacji jeden-do-wielu ---
        // Atrybut Association jest usuwany w EF Core, a relacja modelowana jako ICollection
        public virtual ICollection<VatPowiazania> VatPowiazania { get; set; } = new List<VatPowiazania>();
    }
}