using IssueLog.Models;
using IssueLog.Services;
using IssueLog.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IssueLog.Controllers
{
    public class IssueController : ApiController
    {
        private ProjectService _projectService;
        private UserService _userService;
        private IssueService _issueService;

        public IssueController()
        {
            _projectService = new ProjectService();
            _userService = new UserService();
            _issueService = new IssueService();
        }

        [HttpGet]
        public IEnumerable<IssueDetailsModel> AllIssues()
        {
            return _issueService.GetAll().Select(issue => new IssueDetailsModel
            {
                Id = issue.Id,
                Title = issue.Title,
                Description = issue.Description,
                CriticalLevel = issue.CriticalLevel == true ? "Critical" : "Not Critical",
                DeadLine = issue.DeadLine,
                ProjectId = issue.ProjectId,
                ProjectName = issue.Project.Name,
                //status
                Status = issue.Status == true ? "Completed" : "To be completed"
               // project = issue.Project
            });
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var issue = _issueService.GetById(id);
            if (issue == null)
            {
                return NotFound();
            }
            else
            {
                var model = new IssueDetailsModel
                {
                    Id = issue.Id,
                    Title = issue.Title,
                    Description = issue.Description,
                    CriticalLevel = issue.CriticalLevel == true ? "Critical" : "Not Critical",
                    DeadLine = issue.DeadLine,
                    ProjectId = issue.ProjectId,
                    ProjectName = issue.Project.Name,
                    //Status
                    Status = issue.Status == true ? "Completed" : "To be completed"
                    // project = issue.Project
                };

                return Ok(model);
            }
        }

        [HttpPost]
        public IHttpActionResult AddIssue(AddIssueModel newIssue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var issue = new Issue
                {
                    Title = newIssue.Title,
                    Description = newIssue.Description,
                    CriticalLevel = newIssue.CriticalLevel,
                    DeadLine = newIssue.DeadLine,
                    ProjectId = newIssue.ProjectId,
                    //status
                    Status = newIssue.Status
                };

                return Ok(_issueService.AddIssue(issue));
            }
        }

        //issues by project id
        [HttpGet]
        [Route("api/issue/projectissues/{id}")]

        public IHttpActionResult IssuesByProjectId(int id)
        {
            var issues = _issueService.GetAllByProjectId(id);

            if (issues == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(issues.Select(issue => new IssueDetailsModel
                {
                    Id = issue.Id,
                    Title = issue.Title,
                    Description = issue.Description,
                    CriticalLevel = issue.CriticalLevel == true ? "Critical" : "Not Critical",
                    DeadLine = issue.DeadLine,
                    ProjectId = issue.ProjectId,
                    ProjectName = issue.Project.Name,
                    //status
                    Status = issue.Status == true ? "Completed" : "To be completed"
                    // project = issue.Project
                }));
            }
           
        }


        //editing and updating the submitted issue
        [HttpPut]
        public IHttpActionResult EditIssue(int id, AddIssueModel updatedIssue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_issueService.UpdateById(id, updatedIssue));
            }
        }

    }
}
