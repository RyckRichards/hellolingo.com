//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Considerate.Hellolingo.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notify
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public System.DateTime NotifyOn { get; set; }
        public string Medium { get; set; }
        public string Subject { get; set; }
        public string TextBody { get; set; }
        public string HtmlBody { get; set; }
        public byte Status { get; set; }
    
        public virtual NotifyMedium NotifyMedium { get; set; }
        public virtual NotifyStatus NotifyStatus { get; set; }
        public virtual User User { get; set; }
    }
}
