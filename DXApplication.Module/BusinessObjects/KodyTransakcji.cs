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
    [Table("KODY_TRANSAKCJI")] // Zamiast [Persistent]
    [XafDefaultProperty(nameof(OPIS))]
    public class KodyTransakcji
    {
        // Konstruktor i metoda AfterConstruction zostały usunięte.

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Odpowiednik XPO [Key(false)]
        [Column("KODY_TRANSAKCJI_ID")]
        [Browsable(false)]
        [Appearance("DisableKODY_TRANSAKCJI_ID", Enabled = false, Criteria = "True", Context = "DetailView")]
        [XafDisplayName("ID")]
        public virtual int KODY_TRANSAKCJI_ID { get; set; }

        // --- Obsługa TrimEnd() dla KOD ---
        private string _KOD;

        [Column("KOD")]
        [StringLength(15)] // Zamiast [Size(15)]
        [Browsable(false)]
        public virtual string RawKod
        {
            get => _KOD;
            set => _KOD = value;
        }

        [NotMapped]
        [XafDisplayName("Kod transakcji")]
        [ModelDefault("Index", "0")]
        public virtual string KOD
        {
            get => RawKod?.TrimEnd();
            set => RawKod = value;
        }


        // --- Obsługa TrimEnd() dla OPIS ---
        private string _OPIS;

        [Column("OPIS")]
        [StringLength(50)]
        [Browsable(false)]
        public virtual string RawOpis
        {
            get => _OPIS;
            set => _OPIS = value;
        }

        [NotMapped]
        [XafDisplayName("Kod transakcji opis")]
        [ModelDefault("Index", "1")]
        public virtual string OPIS
        {
            get => RawOpis?.TrimEnd();
            set => RawOpis = value;
        }


        [Column("DEPOZYT")]
        [XafDisplayName("Depozyt")]
        [ModelDefault("Index", "2")]
        public virtual bool? DEPOZYT { get; set; } // bool -> bool? dla bezpieczeństwa
    }
}