using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System;
using DevExpress.ExpressApp.Model;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("VAT_POWIAZANIA")]
    [OptimisticLocking(false)]
    [XafDefaultProperty(nameof(DisplayMember))]
    public class VatPowiazania : XPLiteObject
    {
        public VatPowiazania(Session session) : base(session) { }

        // --- RELACJE (KLUCZE OBCE Z TABELI) ---
        [Key, Persistent("VAT_OPISY_ID")]
        [Association("VatOpisy-VatPowiazania")]
        public VatOpisy VatOpisy { get; set; }

        [Key, Persistent("VAT_SPOSOBY_ID")]
        [Association("VatSposoby-VatPowiazania")]
        public VatSposoby VatSposoby { get; set; }

        [Key, Persistent("KRAJE_ID")]
        [Association("Kraje-VatPowiazania")]
        public Kraje Kraje { get; set; }

        private VatWartosci _vatWartosci;
        [Association("VatWartosci-VatPowiazania")]
        [Persistent("VAT_WARTOSCI_ID")]
        public VatWartosci VatWartosci
        {
            get => _vatWartosci;
            set => SetPropertyValue(nameof(VatWartosci), ref _vatWartosci, value);
        }

        // --- POLA AUDYTOWE Z TABELI VAT_POWIAZANIA ---
        // (reszta kodu pozostaje bez zmian)
        private string _insertedBy;
        [Persistent("INSERTED_BY")]
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Wstawiony przez")]
        public string InsertedBy
        {
            get => _insertedBy;
            set => SetPropertyValue(nameof(InsertedBy), ref _insertedBy, value);
        }

        private DateTime? _insDate;
        [Persistent("INS_DATE")]
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Data wstawienia")]
        public DateTime? InsDate
        {
            get => _insDate;
            set => SetPropertyValue(nameof(InsDate), ref _insDate, value);
        }

        private string _inserting;
        [Persistent("INSERTING")]
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Wstawiający")]
        public string Inserting
        {
            get => _inserting;
            set => SetPropertyValue(nameof(Inserting), ref _inserting, value);
        }

        private string _editing;
        [Persistent("EDITING")]
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Edytujący")]
        public string Editing
        {
            get => _editing;
            set => SetPropertyValue(nameof(Editing), ref _editing, value);
        }

        private DateTime? _ediDate;
        [Persistent("EDI_DATE")]
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Data edycji")]
        public DateTime? EdiDate
        {
            get => _ediDate;
            set => SetPropertyValue(nameof(EdiDate), ref _ediDate, value);
        }

        // --- WŁAŚCIWOŚCI NIETRWAŁE (NON-PERSISTENT) DO WYŚWIETLANIA W UI ---
        [NonPersistent]
        [XafDisplayName("VAT kod")]
        public string VatKod => VatOpisy?.Kod;

        [NonPersistent]
        [XafDisplayName("VAT opis")]
        public string VatOpis => VatOpisy?.Opis;

        [NonPersistent]
        [XafDisplayName("VAT sposób kod")]
        public string VatSposobKod => VatSposoby?.Kod;

        [NonPersistent]
        [XafDisplayName("VAT sposób opis")]
        public string VatSposobOpis => VatSposoby?.Opis;

        [NonPersistent]
        [XafDisplayName("VAT wartosc")]
        public decimal? Wartosc => VatWartosci?.Wartosc;

        [NonPersistent]
        [XafDisplayName("Kraj kod")]
        public string KrajKod => Kraje?.Kod;

        [NonPersistent]
        [XafDisplayName("Kraj opis")]
        public string KrajOpis => Kraje?.Opis;

        // --- Właściwość do wyświetlania w polach wyboru itp. ---
        [NonPersistent]
        [Browsable(false)]
        public string DisplayMember => $"{VatKod} ({KrajKod}) - {Wartosc}%";
    }
}