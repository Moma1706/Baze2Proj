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
    
    public partial class Sudija : Ucesnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sudija()
        {
            this.SePrijavljujes = new HashSet<SePrijavljuje>();
        }
    
        public int BrojUtakmica { get; set; }
        public TipSudije Tip { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SePrijavljuje> SePrijavljujes { get; set; }
    }
}