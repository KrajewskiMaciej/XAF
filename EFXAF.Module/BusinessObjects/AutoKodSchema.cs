using DevExpress.Persistent.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.ExpressApp.DC;

namespace EFXAF.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("AUTO_KOD_SCHEMATY")] // Zamiast [Persistent]
    [XafDefaultProperty(nameof(Schemat_Opisu))] // Ustawienie domyślnej właściwości dla XAF
    public class SchematyAutokodowania
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Odpowiednik XPO [Key(true)]
        [Column("AUTO_KOD_SCHEMATY_ID")]
        public virtual int AutoKodSchematID { get; set; }

        [Column("SCHEMAT_KOD")]
        public virtual string Kod_Schemat { get; set; }

        [Column("SCHEMAT_OPIS")]
        public virtual string Opis_Schemat { get; set; }

        [Column("TYP")]
        public virtual int? Typ { get; set; } // int -> int? dla bezpieczeństwa

        [Column("AUTO_KOD_SCHEMATY_KOD")]
        public virtual string Schemat_Kodu { get; set; }

        [Column("AUTO_KOD_SCHEMATY_OPIS")]
        public virtual string Schemat_Opisu { get; set; }
    }
}