using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueLog.ViewModels
{
    public class ProjectDetailModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public int ClientId { get; set; } 
        public string ClientName {get;set;} 
        public int ProjectManagerId { get; set; } 
        public string ProjectManagerName { get; set; } 
        public int ProjectLeaderId { get; set; } 
        public string ProjectLeaderName { get; set; } 
    }
}