using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("KRAJE")] // Mapowanie na tabelę KRAJE
    [XafDefaultProperty(nameof(Opis))] // Co ma być domyślnie wyświetlane
    public class Kraje : XPLiteObject
    {
        public Kraje(Session session) : base(session) { }

        // --- KLUCZ GŁÓWNY ---
        [Persistent("KRAJE_ID"), Key(AutoGenerate = true), Browsable(false)]
        private int _id;

        // --- WŁAŚCIWOŚCI MAPOWANE NA KOLUMNY W TABELI KRAJE ---
        // Zakładam istnienie kolumn KRAJE_KOD i KRAJE_OPIS na podstawie wcześniejszych informacji
        private string _kod;
        [Persistent("KRAJE_KOD")]
        [XafDisplayName("Kod Kraju")]
        public string Kod
        {
            get => _kod;
            set => SetPropertyValue(nameof(Kod), ref _kod, value);
        }

        private string _opis;
        [Persistent("KRAJE_OPIS")]
        [XafDisplayName("Nazwa Kraju")]
        public string Opis
        {
            get => _opis;
            set => SetPropertyValue(nameof(Opis), ref _opis, value);
        }

        // --- DRUGA STRONA RELACJI (NAPRAWIA BŁĄD XAF0014) ---
        // Ta właściwość tworzy parę dla asocjacji zdefiniowanej w VatPowiazania.
        // Nazwa w cudzysłowie musi być identyczna w obu klasach.
        [Association("Kraje-VatPowiazania")]
        public XPCollection<VatPowiazania> VatPowiazania
        {
            get { return GetCollection<VatPowiazania>(nameof(VatPowiazania)); }
        }
    }
}