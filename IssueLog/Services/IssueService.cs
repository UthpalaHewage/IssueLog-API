using AutoMapper;
using IssueLog.Models;
using IssueLog.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IssueLog.Services
{
    public class IssueService
    {
        private IssueLogDbContext _context;

        public IssueService()
        {
            _context = new IssueLogDbContext();
        }

        public Issue AddIssue(Issue issue)
        {
            _context.Issues.Add(issue);
            _context.SaveChanges();
            return issue;
        }

        public IEnumerable<Issue> GetAll()
        {
            return _context.Issues.Include(p => p.Project);
        }

        public Issue GetById(int id)
        {
            return _context.Issues.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Issue> GetAllByProjectId(int id)
        {
            var issues = _context.Issues.Where(i => i.ProjectId == id).Include(p => p.Project).ToList();

            return issues;
        }

        //editing and updating the submitted issue
        public int UpdateById(int id, AddIssueModel updatedIssue)
        {
            var issueInDb = _context.Issues.FirstOrDefault(u => u.Id == id);

            if (issueInDb == null)
            {
                return 404;
            }
            else
            {
                issueInDb.CriticalLevel = updatedIssue.CriticalLevel;
                issueInDb.DeadLine = updatedIssue.DeadLine;
                issueInDb.Title = updatedIssue.Title;
                issueInDb.Description = updatedIssue.Description;
                //status
                issueInDb.Status = updatedIssue.Status;



                _context.SaveChanges();
                return 200;
            }

        }
    }
}