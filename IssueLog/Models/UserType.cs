using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IssueLog.Models
{
    public class UserType
    {
        public byte Id { get; set; } 
        [Required]
        public string TypeName { get; set; } 
    }
}