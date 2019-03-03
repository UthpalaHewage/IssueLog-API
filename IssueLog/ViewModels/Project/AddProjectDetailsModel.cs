using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueLog.ViewModels
{
    public class AddProjectDetailsModel
    { 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public int ClientId { get; set; } 
        public int ProjectManagerId { get; set; } 
        public int ProjectLeaderId { get; set; } 
    }
}