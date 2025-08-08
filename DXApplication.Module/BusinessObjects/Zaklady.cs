using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("ZAKLADY")] // Zamiast [Persistent] na klasie
    public class Zaklady
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ZAKLADY_ID")]
        [Browsable(false)]
        public virtual int Id { get; set; }

        [Column("ZAKLADY_OPIS")]
        [XafDisplayName("Zakład opis")]
        public virtual string Opis { get; set; }

        [Column("ZAKLADY_KOD")]
        [XafDisplayName("Zakład kod")]
        public virtual string Kod { get; set; }

        [Column("MDT")]
        public virtual int MandantId { get; set; }

        [ForeignKey(nameof(MandantId))] // Łączy nawigację 'Mandant' z kluczem obcym 'MandantId'
        [XafDisplayName("Mandant")]
        public virtual Mandant Mandant { get; set; }
    }
}