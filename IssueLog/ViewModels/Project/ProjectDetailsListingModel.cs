using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueLog.ViewModels
{
    public class ProjectDetailsListingModel
    {
        public IEnumerable<ProjectDetailModel> ProjectList { get; set; } 
    }
}