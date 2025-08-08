using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("ZAKLADY")] // Zamiast [Persistent] na klasie
    public class Zaklady
    {
        // Konstruktor XPO został usunięty. EF Core nie wymaga specjalnego konstruktora.

        [Key] // Standardowy atrybut EF Core dla klucza głównego
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Odpowiednik XPO Key(true) - klucz generowany przez bazę
        [Column("ZAKLADY_ID")] // Zamiast [Persistent] na właściwości
        [Browsable(false)]
        public virtual int Id { get; set; }

        [Column("ZAKLADY_OPIS")]
        [XafDisplayName("Zakład opis")]
        public virtual string Opis { get; set; }

        [Column("ZAKLADY_KOD")]
        [XafDisplayName("Zakład kod")]
        public virtual string Kod { get; set; }

        // --- Konfiguracja relacji w EF Core ---

        [Column("MDT")] // Definiuje nazwę kolumny dla klucza obcego w bazie danych
        public virtual int MandantId { get; set; } // Dodana właściwość przechowująca sam klucz obcy

        [ForeignKey(nameof(MandantId))] // Łączy nawigację 'Mandant' z kluczem obcym 'MandantId'
        [XafDisplayName("Mandant")]
        public virtual Mandant Mandant { get; set; }
    }
}