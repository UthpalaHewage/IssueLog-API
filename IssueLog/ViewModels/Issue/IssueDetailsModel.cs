﻿using IssueLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueLog.ViewModels.Issue
{
    public class IssueDetailsModel
    {
        public int Id { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string CriticalLevel { get; set; } 
        public DateTime DeadLine { get; set; } 
        public int ProjectId { get; set; } 
        public string ProjectName { get; set; } 
        //status
        public string Status { get; set; } 
        //public Project project { get; set; }
    }
}