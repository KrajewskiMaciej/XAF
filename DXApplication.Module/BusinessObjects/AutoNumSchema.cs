using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("AUTO_NUM_SCHEMAT")] // Zamiast [Persistent]
    public class AutoNumSchemat
    {
        // Konstruktor i właściwość Session zostały usunięte.

        [Key] // Oznaczenie jako klucz główny
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Odpowiednik XPO [Key(false)] - baza NIE generuje wartości
        [Column("AUTO_NUM_SCHEMAT_ID")]
        [Appearance("DisableAUTO_NUM_SCHEMAT_ID", Enabled = false, Criteria = "True", Context = "DetailView")]
        [Browsable(true)]
        [XafDisplayName("ID")]
        [ModelDefault("Index", "0")]
        public virtual int AUTO_NUM_SCHEMAT_ID { get; set; }

        [Column("TYP")]
        [XafDisplayName("Typ")]
        [ModelDefault("Index", "2")]
        public virtual short? TYP { get; set; }

        [Column("SEPARATOR")]
        [StringLength(20)] // Zamiast [Size(20)]
        [XafDisplayName("Separator kodu")]
        [ModelDefault("Index", "4")]
        public virtual string SEPARATOR { get; set; }

        [Column("RESET_TYP")]
        [XafDisplayName("Resetowanie")]
        [ModelDefault("Index", "7")]
        public virtual short? RESET_TYP { get; set; }

        [Column("SCHEMAT")]
        [StringLength(100)]
        [XafDisplayName("Schemat")]
        [ModelDefault("Index", "3")]
        public virtual string SCHEMAT { get; set; }

        [Column("INS_DATE")]
        [ModelDefault("DisplayFormat", "dd.MM.yyyy HH:mm")]
        [ModelDefault("EditMask", "dd.MM.yyyy HH:mm")]
        [XafDisplayName("Utworzona dnia")]
        [ModelDefault("Index", "9")]
        public virtual DateTime? INS_DATE { get; set; }

        [Column("INSERTED_BY")]
        [StringLength(50)]
        [XafDisplayName("Utworzona przez")]
        [ModelDefault("Index", "10")]
        public virtual string INSERTED_BY { get; set; }

        [Column("EDI_DATE")]
        [ModelDefault("DisplayFormat", "dd.MM.yyyy HH:mm")]
        [ModelDefault("EditMask", "dd.MM.yyyy HH:mm")]
        [XafDisplayName("Edi date")]
        [Browsable(false)]
        public virtual DateTime? EDI_DATE { get; set; }

        [Column("EDITING")]
        [StringLength(50)]
        [XafDisplayName("Editing")]
        [Browsable(false)]
        public virtual string EDITING { get; set; }

        [Column("LICZBA_CYFR_W_NR_KOL")]
        [XafDisplayName("Liczba cyfr w nr kol.")]
        [ModelDefault("Index", "8")]
        public virtual short? LICZBA_CYFR_W_NR_KOL { get; set; }

        [Column("ZNAK_1")]
        [StringLength(20)]
        [XafDisplayName("Znak")]
        [ModelDefault("Index", "6")]
        public virtual string ZNAK_1 { get; set; }

        [Column("AUTO_NUM_SCHEMAT_KOD")]
        [StringLength(20)]
        [XafDisplayName("Kod")]
        [ModelDefault("Index", "1")]
        public virtual string AUTO_NUM_SCHEMAT_KOD { get; set; }

        [Column("AUTO_NUM_SCHEMAT_OPIS")]
        [StringLength(60)]
        [XafDisplayName("Opis")]
        [ModelDefault("Index", "13")]
        public virtual string AUTO_NUM_SCHEMAT_OPIS { get; set; }

        [Column("SCHEMAT_KOD")]
        [StringLength(100)]
        [XafDisplayName("Schemat kod")]
        [ModelDefault("Index", "11")]
        public virtual string SCHEMAT_KOD { get; set; }

        [Column("SCHEMAT_OPIS")]
        [StringLength(100)]
        [XafDisplayName("Schemat opis")]
        [ModelDefault("Index", "12")]
        public virtual string SCHEMAT_OPIS { get; set; }

        [Column("SEPARATOR_OPIS")]
        [StringLength(20)]
        [XafDisplayName("Separator opis")]
        [ModelDefault("Index", "5")]
        public virtual string SEPARATOR_OPIS { get; set; }
        
        // Metoda OnSaving została usunięta - jej logikę przenosimy do DbContext

        // Konwersja kolekcji
        public virtual ICollection<TypyZamowienia> ZamowieniaTypy { get; set; } = new List<TypyZamowienia>();
    }
}