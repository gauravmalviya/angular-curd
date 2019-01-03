using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace bookapi.ViewModels
{
    public class NotPatchableAttribute : Attribute { }
    public class BookViewModel
    {
        [Key]
        public string Id { get; set; } // guid
        public string Name { get; set; }
        public int? NumberOfPages { get; set; }
        public long? DateOfPublication { get; set; }// utc timestamp        
        public string[] Authors { get; set; }


        public void Patch(Object u)
        {
            var props = from p in this.GetType().GetProperties()
                        let attr = p.GetCustomAttribute(typeof(NotPatchableAttribute))
                        where attr == null
                        select p;
            foreach (var prop in props)
            {
                var val = prop.GetValue(this, null);
                if (val != null)
                    prop.SetValue(u, val);
            }
        }
    }
}