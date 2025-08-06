using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Xpo.Metadata; // Dodany using dla [SequenceGenerator]

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("VAT_OPISY")]
    [XafDefaultProperty(nameof(Opis))]
    [OptimisticLocking(false)]
    public class VatOpisy : XPLiteObject
    {
        public VatOpisy(Session session) : base(session) { }

        // --- POPRAWKA: ZMIANA SPOSOBU GENEROWANIA KLUCZA GŁÓWNEGO ---
        private int _VatOpisyId;
        [Key(AutoGenerate = true)] // Zamiast Key(false)
        [Persistent("VAT_OPISY_ID")]
        [Browsable(false)]
        public int VatOpisyId
        {
            get => _VatOpisyId;
            set => SetPropertyValue(nameof(VatOpisyId), ref _VatOpisyId, value);
        }

        private string _Kod;
        [Persistent("VAT_OPISY_KOD"), Size(20)]
        [XafDisplayName("Kod Opisu VAT")]
        public string Kod
        {
            get => _Kod;
            set => SetPropertyValue(nameof(Kod), ref _Kod, value);
        }

        private string _Opis;
        [Persistent("VAT_OPISY_OPIS"), Size(255)]
        [XafDisplayName("Opis VAT")]
        public string Opis
        {
            get => _Opis;
            set => SetPropertyValue(nameof(Opis), ref _Opis, value);
        }

        [Association("VatOpisy-VatPowiazania")]
        public XPCollection<VatPowiazania> Powiazania => GetCollection<VatPowiazania>(nameof(Powiazania));

        // Metoda AfterConstruction() nie jest już potrzebna do generowania ID
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}