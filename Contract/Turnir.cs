//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contract
{
    using System;
    using System.Collections.Generic;
    
    public partial class Turnir
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Turnir()
        {
            this.SePrijavljujes = new HashSet<SePrijavljuje>();
            this.SeKvalifikujes = new HashSet<SeKvalifikuje>();
            this.Sponzors = new HashSet<Sponzor>();
        }
    
        public int IdTurnira { get; set; }
        public TipTurnira Tip { get; set; }
        public string TrenutniSampion { get; set; }
        public string Naziv { get; set; }
        public System.DateTime DatumOsnivanja { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SePrijavljuje> SePrijavljujes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeKvalifikuje> SeKvalifikujes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sponzor> Sponzors { get; set; }
    }
}
