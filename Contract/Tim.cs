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
    
    public partial class Tim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tim()
        {
            this.Treners = new HashSet<Trener>();
            this.SeKvalifikujes = new HashSet<SeKvalifikuje>();
            this.Igracs = new HashSet<Igrac>();
        }
    
        public int IdTima { get; set; }
        public string BrojTitula { get; set; }
        public TipTima Tip { get; set; }
        public System.DateTime DatumOsnivanja { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trener> Treners { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeKvalifikuje> SeKvalifikujes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Igrac> Igracs { get; set; }
    }
}
