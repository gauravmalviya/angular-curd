using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bookapi.Data.Entities
{
    public class Book
    {
        [Key]
        public string Id { get; set; } // guid
        public string Name { get; set; }
        public int? NumberOfPages { get; set; }
        public long? DateOfPublication { get; set; }// utc timestamp
        public long? CreateDate { get; set; } // utc timestamp, internal only (not returned by api)
        public long? UpdateDate { get; set; } // utc timestamp, internal only (not returned by api)        
        public virtual IEnumerable<Author> Authors { get; set; } 
        public bool? IsDeleted { get; set; }  
    }
}