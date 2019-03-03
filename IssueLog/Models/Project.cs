using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueLog.Models
{
    public class Project
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 

        public virtual User Client { get; set; } 
        public int ClientId { get; set; } 

        public virtual User ProjectManager { get; set; } 
        public int ProjectManagerId { get; set; } 

        public virtual User ProjectLeader { get; set; } 
        public int ProjectLeaderId { get; set; } 

        public virtual ICollection<Issue> Issues { get; set; } 


    }
}