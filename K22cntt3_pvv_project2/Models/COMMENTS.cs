//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K22cntt3_pvv_project2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class COMMENTS
    {
        public int CommentID { get; set; }
        public int MaKH { get; set; }
        public int MaPhim { get; set; }
        public string CommentText { get; set; }
        public Nullable<System.DateTime> CommentDate { get; set; }
    
        public virtual KHACH_HANG KHACH_HANG { get; set; }
        public virtual PHIM PHIM { get; set; }
    }
}