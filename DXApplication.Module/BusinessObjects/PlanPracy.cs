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
    [Table("PLAN_PRACY")] // Zamiast [Persistent]
    [XafDefaultProperty(nameof(PLAN_PRACY_OPIS))]
    public class PlanPracy
    {
        // Konstruktor i metoda AfterConstruction zostały usunięte

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Odpowiednik [Key(false)] - aplikacja zarządza kluczem
        [Column("PLAN_PRACY_ID")]
        [Browsable(false)]
        [Appearance("DisablePLAN_PRACY_ID", Enabled = false, Criteria = "True", Context = "DetailView")]
        [XafDisplayName("ID")]
        public virtual int PLAN_PRACY_ID { get; set; }

        // --- Obsługa TrimEnd() dla PLAN_PRACY_KOD ---
        private string _PLAN_PRACY_KOD;

        [Column("PLAN_PRACY_KOD")] // Właściwość mapowana do bazy
        [StringLength(15)] // Zamiast [Size(15)]
        [Browsable(false)] // Ukryta w UI
        public virtual string RawKod
        {
            get => _PLAN_PRACY_KOD;
            set => _PLAN_PRACY_KOD = value;
        }

        [NotMapped] // Właściwość niemacierzysta, widoczna w UI
        [XafDisplayName("Plan pracy kod")]
        [ModelDefault("Index", "0")]
        public virtual string PLAN_PRACY_KOD
        {
            get => RawKod?.TrimEnd();
            set => RawKod = value;
        }


        // --- Obsługa TrimEnd() dla PLAN_PRACY_OPIS ---
        private string _PLAN_PRACY_OPIS;

        [Column("PLAN_PRACY_OPIS")] // Właściwość mapowana do bazy
        [StringLength(50)]
        [Browsable(false)] // Ukryta w UI
        public virtual string RawOpis
        {
            get => _PLAN_PRACY_OPIS;
            set => _PLAN_PRACY_OPIS = value;
        }

        [NotMapped] // Właściwość niemacierzysta, widoczna w UI
        [XafDisplayName("Plan pracy opis")]
        [ModelDefault("Index", "1")]
        public virtual string PLAN_PRACY_OPIS
        {
            get => RawOpis?.TrimEnd();
            set => RawOpis = value;
        }
    }
}