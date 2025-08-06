using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("MANDANT")]
    public class Mandant : XPLiteObject
    {
        public Mandant(Session session) : base(session) { }

        [Key(true)]
        [Persistent("MANDANT_ID")]
        [Browsable(false)]
        public int MANDANT_ID { get; set; }

        [Persistent("MANDANT_KOD")]
        public string MANDANT_KOD { get; set; }

        [Persistent("MANDANT_OPIS")]
        public string MANDANT_OPIS { get; set; }

        [Association("Mandant-Zaklady")]
        [XafDisplayName("Zakłady")]
        public XPCollection<Zaklad> Zaklady
        {
            get { return GetCollection<Zaklad>(nameof(Zaklady)); }
        }
    }
}
