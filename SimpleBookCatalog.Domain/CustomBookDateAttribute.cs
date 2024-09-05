using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleBookCatalog.Domain
{
    public class CustomBookDateAttribute : RangeAttribute
    {
        public CustomBookDateAttribute()
            : base(typeof(DateTime),
                   new DateTime(1900, 1, 1).ToString("yyyy-MM-dd"),  
                   DateTime.Now.ToString("yyyy-MM-dd"))              
        {
        }
    }
}
