//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserRoleRelation
    {
        public int URRID { get; set; }
        public int UserId { get; set; }
        public int URID { get; set; }
    
        public virtual UserRole UserRole { get; set; }
        public virtual SBP_LoginInfo SBP_LoginInfo { get; set; }
    }
}
