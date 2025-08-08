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
    [Table("JEDNOSTKI")] // Zamiast [Persistent]
    [XafDefaultProperty(nameof(JEDNOSTKI_OPIS))]
    public class Jednostki
    {
        // Konstruktor i metoda AfterConstruction zostały usunięte.

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Odpowiednik [Key(false)] - aplikacja sama zarządza wartością klucza
        [Column("JEDNOSTKI_ID")]
        [Browsable(false)]
        [Appearance("DisableJEDNOSTKI_ID", Enabled = false, Criteria = "True", Context = "DetailView")]
        [XafDisplayName("ID")]
        public virtual int JEDNOSTKI_ID { get; set; }

        // --- Obsługa TrimEnd() ---
        // Używamy prywatnego pola do mapowania do bazy i publicznej właściwości z logiką
        private string _JEDNOSTKI_KOD;

        [Column("JEDNOSTKI_KOD")]
        [StringLength(15)] // Zamiast [Size(15)]
        [Browsable(false)] // Ukrywamy pole "surowe"
        public virtual string RawKod
        {
            get => _JEDNOSTKI_KOD;
            set => _JEDNOSTKI_KOD = value;
        }

        [NotMapped] // Ta właściwość nie jest mapowana do bazy, jest tylko do użytku UI
        [XafDisplayName("Jednostka kod")]
        [ModelDefault("Index", "0")]
        public virtual string JEDNOSTKI_KOD
        {
            get => RawKod?.TrimEnd();
            set => RawKod = value;
        }

        // --- Powtórzenie wzorca dla drugiej właściwości ---
        private string _JEDNOSTKI_OPIS;
        
        [Column("JEDNOSTKI_OPIS")]
        [StringLength(50)]
        [Browsable(false)]
        public virtual string RawOpis
        {
            get => _JEDNOSTKI_OPIS;
            set => _JEDNOSTKI_OPIS = value;
        }

        [NotMapped]
        [XafDisplayName("Jednostka opis")]
        [ModelDefault("Index", "1")]
        public virtual string JEDNOSTKI_OPIS
        {
            get => RawOpis?.TrimEnd();
            set => RawOpis = value;
        }


        [Column("PRZELICZENIOWA")]
        [XafDisplayName("Przeliczeniowa")]
        [ModelDefault("Index", "2")]
        public virtual bool? PRZELICZENIOWA { get; set; }

        [Column("NIEPODZIELNA")]
        [XafDisplayName("Niepodzielna")]
        [ModelDefault("Index", "3")]
        public virtual bool? NIEPODZIELNA { get; set; }
    }
}