using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFXAF.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("MANDANT")] // Zamiast [Persistent]
    [Browsable(true)]
    public class Mandant
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MANDANT_ID")]
        [Browsable(false)]
        public virtual int MANDANT_ID { get; set; }

        [Column("MANDANT_KOD")]
        public virtual string MANDANT_KOD { get; set; }

        [Column("MANDANT_OPIS")]
        public virtual string MANDANT_OPIS { get; set; }

        [XafDisplayName("Zakłady")]
        // Właściwość kolekcji jest teraz standardową kolekcją C#
        public virtual ICollection<Zaklady> Zaklady { get; set; } = new List<Zaklady>();
    }
}