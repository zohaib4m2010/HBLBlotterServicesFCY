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
    
    public partial class SP_GetAllNostroBankList_Result
    {
        public long ID { get; set; }
        public string BankName { get; set; }
        public Nullable<decimal> NostroLimit { get; set; }
        public string NostroDescription { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<int> CurId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
