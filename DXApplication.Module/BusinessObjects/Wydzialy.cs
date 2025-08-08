using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Table("LC_WYDZIALY")]
    public class Wydzialy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("LC_WYDZIALY_ID")]
        [Browsable(false)]
        public virtual int Id { get; set; }

        [Column("LC_WYDZIALY_KOD")]
        [XafDisplayName("Wydział kod")]
        public virtual string Kod { get; set; }

        [Column("LC_WYDZIALY_OPIS")]
        [XafDisplayName("Wydział opis")]
        public virtual string Opis { get; set; }

        // --- Relacja do Klienci (Firma) ---

        [Column("KLIENCI_ID")]
        [Browsable(false)] // Ukrycie klucza obcego w UI, ponieważ mamy właściwości poniżej.
        public virtual int FirmaId { get; set; }

        [ForeignKey(nameof(FirmaId))]
        [Browsable(false)]
        public virtual Klient Firma { get; set; }

        // DODANO: Jawne właściwości dla kolumn z powiązanej firmy, widocznych w siatce.
        [NotMapped] // Atrybut zapobiega tworzeniu tej kolumny w bazie danych.
        [XafDisplayName("Firma kod")]
        public virtual string FirmaKod => Firma?.Kod;

        [NotMapped]
        [XafDisplayName("Firma opis")]
        public virtual string FirmaOpis => Firma?.Opis;

                [Column("PODSTAWOWY")]
        [XafDisplayName("Podstawowy")]
        public virtual short? Podstawowy { get; set; }

        [Column("BRAMKA")]
        [XafDisplayName("Bramka")]
        public virtual short? Bramka { get; set; }


        // --- Opcjonalne relacje (pozostawione bez zmian) ---

        [Column("JEDNOSTKI_ID")]
        [Browsable(false)]
        public virtual int? JednostkiId { get; set; }

        [ForeignKey(nameof(JednostkiId))]
        [Browsable(false)]
        public virtual Jednostki Jednostki { get; set; }

        [Column("SYS_DOK_ZAS_ID")]
        [Browsable(false)]
        public virtual int? SysDokZasId { get; set; }

        [ForeignKey(nameof(SysDokZasId))]
        [Browsable(false)]
        public virtual Wydruki SysDokZas { get; set; }
    }
}