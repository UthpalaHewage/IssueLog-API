using IssueLog.Models;
using IssueLog.Services;
using IssueLog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IssueLog.Controllers
{
   
    public class ProjectController : ApiController
    {
        private ProjectService _projectService;
        private UserService _userService;

        public ProjectController()
        {
            _projectService = new ProjectService();
            _userService = new UserService();
        }

        [HttpGet]
        public IEnumerable<ProjectDetailModel> AllProjects()
        {
            return _projectService.GetAll().Select(project=> new ProjectDetailModel {
                Id=project.Id,
                Name=project.Name,
                Description=project.Description,
                ClientId=project.Client.Id,
                ClientName=project.Client.Fname+" " +project.Client.LName,
                ProjectLeaderId = project.ProjectLeaderId,
                ProjectLeaderName = project.ProjectLeader.Fname + " " + project.ProjectLeader.LName,

                ProjectManagerId = project.ProjectManagerId,
                ProjectManagerName = project.ProjectManager.Fname + " " + project.ProjectManager.LName,
            });
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {

            var project = _projectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            else
            {
                var model = new ProjectDetailModel
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    ClientId = project.ClientId,
                    ClientName = project.Client.Fname + " " + project.Client.LName,
                    ProjectManagerId = project.ProjectManagerId,
                    ProjectManagerName = project.ProjectManager.Fname + " " + project.ProjectManager.LName,
                    ProjectLeaderId = project.ProjectLeaderId,
                    ProjectLeaderName = project.ProjectLeader.Fname + " " + project.ProjectLeader.LName,
                };

                return Ok(model);
            }


           
        }

        [HttpPost]
        public IHttpActionResult AddProject(AddProjectDetailsModel newProject)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            else
            {
                var project = new Project
                {
                    Name = newProject.Name,
                    Description = newProject.Description,
                    ClientId = newProject.ClientId,
                    ProjectLeaderId =newProject.ProjectLeaderId,
                    ProjectManagerId = newProject.ProjectManagerId
                };

            return Ok(_projectService.AddProject(project));
            }
           
        }

        //get by User ID
        [HttpGet]
        [Route("api/project/userproject/{id}")]
        public IHttpActionResult GetProjectByUserId(int id)
        {
            var projects = _projectService.GetByUserId(id);

            if (projects == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(projects.Select(project => new ProjectDetailModel
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    ClientId = project.Client.Id,
                    ClientName = project.Client.Fname + " " + project.Client.LName,
                    ProjectLeaderId = project.ProjectLeaderId,
                    ProjectLeaderName = project.ProjectLeader.Fname + " " + project.ProjectLeader.LName,

                    ProjectManagerId = project.ProjectManagerId,
                    ProjectManagerName = project.ProjectManager.Fname + " " + project.ProjectManager.LName,
                }));
            }
        }
            

    }
}
