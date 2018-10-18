using System;
using System.ComponentModel.DataAnnotations;

namespace quoting_dojo.Models
{
    public class User
    {
        [Required]
        [MinLength(3)]
        public string name {get;set;}
        [Required]
        [MinLength(3)]
        public string quote {get;set;}
        public string created_at{get;}
        public string updated_at{get;}
    }
}