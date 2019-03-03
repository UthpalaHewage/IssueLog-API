using IssueLog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IssueLog.Services
{
    public class ProjectService
    {
        private IssueLogDbContext _context;

        public ProjectService()
        {
            _context = new IssueLogDbContext();
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Projects.Include(c=>c.Client).Include(l=>l.ProjectLeader).Include(m=>m.ProjectManager);
        }

        public Project GetById(int id) {
            return _context.Projects.Where(p=>p.Id==id).Include(c => c.Client).Include(l => l.ProjectLeader).Include(m => m.ProjectManager).FirstOrDefault();
        }

        public Project AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }

        public IEnumerable<Project> GetByUserId(int userId)
        {
           var project = _context.Projects.Where(u=>u.ClientId==userId || u.ProjectLeaderId==userId || u.ProjectManagerId==userId)
                .Include(c => c.Client).Include(l => l.ProjectLeader).Include(m => m.ProjectManager).ToList();


            return project;
        }
    }
}