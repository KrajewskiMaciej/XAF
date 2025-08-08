using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("JEZYKI")]
    public class Jezyki
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("JEZYKI_ID")]
        [Browsable(false)]
        public virtual int Id { get; set; }

        [Column("JEZYK_KOD")]
        [XafDisplayName("Język kod")]
        public virtual string Kod { get; set; }

        [Column("JEZYK_OPIS")]
        [XafDisplayName("Język opis")]
        public virtual string Opis { get; set; }
    }
}