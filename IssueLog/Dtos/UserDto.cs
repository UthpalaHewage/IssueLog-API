using IssueLog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IssueLog.Dtos
{
    public class UserDto
    {
        public int Id { get; set; } 
        [Required]
        public string Fname { get; set; } 
        [Required]
        public string LName { get; set; } 
        [Required]
        public string Email { get; set; } 
        [Required]
        public string Password { get; set; } 
        public UserType UserType { get; set; } 
        [Required]
        public byte UserTypeId { get; set; } 
    }
}