using DevExpress.Persistent.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;
using DevExpress.ExpressApp.Model;
using DevExpress.XtraRichEdit.Fields;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("AUTO_KOD_SCHEMATY")] // Zamiast [Persistent]
    public class SchematyAutokodowania
    {
        // Konstruktor XPO został usunięty

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Odpowiednik XPO [Key(true)]
        [Column("AUTO_KOD_SCHEMATY_ID")]
        [XafDisplayName("AutoKodSchemat")]
        [Browsable(true)]
        public virtual int AutoKodSchematID { get; set; }

        [Column("SCHEMAT_KOD")]
        [XafDisplayName("Kod schemat")]
        public virtual string Kod_Schemat { get; set; }

        [Column("SCHEMAT_OPIS")]
        [XafDisplayName("Opis schemat")]
        public virtual string Opis_Schemat { get; set; }

        [Column("TYP")]
        public virtual int? Typ { get; set; }

        [Column("AUTO_KOD_SCHEMATY_KOD")]
        [XafDisplayName("Schemat kodu")]
        public virtual string Schemat_Kodu { get; set; }

        [Column("AUTO_KOD_SCHEMATY_OPIS")]
        [XafDisplayName("Schemat opisu")]
        public virtual string Schemat_Opisu { get; set; }
    }
}