using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("TAGI")]
    [XafDefaultProperty(nameof(TAGI_KOD))]
    public class Tagi
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Odpowiednik XPO [Key(true)]
        [Column("TAGI_ID")]
        [Browsable(false)]
        public virtual int TAGI_ID { get; set; }

        [Column("TAGI_KOD")]
        [XafDisplayName("Tag kod")] // Zmieniono stary atrybut DisplayName na nowszy
        public virtual string TAGI_KOD { get; set; }

        [Column("TAGI_OPIS")]
        [XafDisplayName("Tag opis")]
        public virtual string TAGI_OPIS { get; set; }

        // UWAGA: Typ 'string' dla kolejności jest nietypowy. Jeśli w bazie są tam tylko liczby,
        // rozważ zmianę typu na 'int?'. Na podstawie definicji XPO, 'string' jest poprawną konwersją.
        [Column("KOLEJNOSC")]
        [XafDisplayName("Kolejność")]
        public virtual string KOLEJNOSC { get; set; }
    }
}