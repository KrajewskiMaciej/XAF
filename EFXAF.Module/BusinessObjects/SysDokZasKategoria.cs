using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFXAF.Module.BusinessObjects
{
    [Table("SYS_DOK_ZAS_KATEGORIA")]
    public class SysDokZasKategoria
    {
        [Key]
        [Column("ID")] // Klucz główny wywnioskowany z klauzuli WHERE podzapytania
        public virtual int Id { get; set; }

        [Column("KATEGORIA")] // Kolumna z opisem wywnioskowana z klauzuli SELECT podzapytania
        public virtual string NazwaKategorii { get; set; }

        // Właściwość nawigacyjna dla strony "jeden" w relacji jeden-do-wielu
        public virtual ICollection<Wydruki> Wydruki { get; set; } = new List<Wydruki>();
    }
}