//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkTestApp.Modals
{
    using System;
    using System.Collections.Generic;
    
    public partial class tran
    {
        public int tranno { get; set; }
        public Nullable<int> fromacc { get; set; }
        public Nullable<int> toacc { get; set; }
        public Nullable<double> amount { get; set; }
        public string status { get; set; }
    
        public virtual account account { get; set; }
        public virtual account account1 { get; set; }
    }
}
