using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace IssueLog.Models
{
    public class User
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

        public virtual ICollection<Project> Client { get; set; } 
        public virtual ICollection<Project> ProjectManager { get; set; } 
        public virtual ICollection<Project> ProjectLeader { get; set; } 

    }
}