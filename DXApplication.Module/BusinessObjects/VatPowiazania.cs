using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("VAT_POWIAZANIA")]
    public class VatPowiazania
    {
        // Konstruktor XPO został usunięty.
        // Struktura VatPowiazaniaKey i pole CompoundKey zostały usunięte.

        // --- CZĘŚĆ 1: DEFINICJA KOLUMN KLUCZA ZŁOŻONEGO ---
        // Te właściwości tworzą klucz złożony. W EF Core definicję klucza
        // konfiguruje się w DbContext za pomocą Fluent API.

        [Column("VAT_OPISY_ID")]
        [Browsable(false)]
        public virtual int VatOpisyId { get; set; }

        [Column("VAT_SPOSOBY_ID")]
        [Browsable(false)]
        public virtual int VatSposobyId { get; set; }

        [Column("KRAJE_ID")]
        [Browsable(false)]
        public virtual int KrajeId { get; set; }


        // --- CZĘŚĆ 2: WŁAŚCIWOŚCI NAWIGACYJNE DLA KLUCZA ZŁOŻONEGO ---
        // Łączymy właściwości nawigacyjne z odpowiednimi kolumnami klucza obcego.

        [ForeignKey(nameof(VatOpisyId))]
        [Browsable(false)]
        public virtual VatOpisy VatOpisy { get; set; }

        [ForeignKey(nameof(VatSposobyId))]
        [Browsable(false)]
        public virtual VatSposoby VatSposoby { get; set; }

        [ForeignKey(nameof(KrajeId))]
        [Browsable(false)]
        public virtual Kraje Kraje { get; set; }


        // --- CZĘŚĆ 3: POZOSTAŁE RELACJE I POLA ---
        // Relacja do VatWartosci (opcjonalna, na podstawie LEFT JOIN w SQL)
        [Column("VAT_WARTOSCI_ID")]
        [Browsable(false)]
        public virtual int? VatWartosciId { get; set; }

        [ForeignKey(nameof(VatWartosciId))]
        [Browsable(false)]
        public virtual VatWartosci VatWartosci { get; set; }

        // --- CZĘŚĆ 4: WŁAŚCIWOŚCI NIEMAPOWANE (NON-PERSISTENT) ---
        // Logika pozostaje identyczna, ale atrybut zmienia się na [NotMapped].
        [NotMapped]
        [XafDisplayName("VAT kod")]
        public virtual string VatKod => VatOpisy?.Kod;

        [NotMapped]
        [XafDisplayName("VAT opis")]
        public virtual string VatOpis => VatOpisy?.Opis;

        [NotMapped]
        [XafDisplayName("VAT sposób kod")]
        public virtual string VatSposobKod => VatSposoby?.Kod;

        [NotMapped]
        [XafDisplayName("VAT sposób opis")]
        public virtual string VatSposobOpis => VatSposoby?.Opis;

        [NotMapped]
        [XafDisplayName("VAT wartosc")]
        public virtual decimal? Wartosc => VatWartosci?.Wartosc;

        [NotMapped]
        [XafDisplayName("Kraj kod")]
        public virtual string KrajKod => Kraje?.Kod;

        [NotMapped]
        [XafDisplayName("Kraj opis")]
        public virtual string KrajOpis => Kraje?.Opis;
        
        [NotMapped]
        [Browsable(false)]
        public virtual string DisplayMember => $"{VatKod} ({KrajKod}) - {Wartosc}%";
    }
}