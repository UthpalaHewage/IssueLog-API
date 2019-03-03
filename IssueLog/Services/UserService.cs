using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using IssueLog.Dtos;
using IssueLog.Models;

namespace IssueLog.Services
{
    public class UserService
    {
        private IssueLogDbContext _context;

        public UserService()
        {
            _context = new IssueLogDbContext();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include(u=>u.UserType).ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public int DeleteById(int id)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Id == id);

            if (userInDb == null)
            {
                return 404;
            }
            else
            {
                _context.Users.Remove(userInDb);
                _context.SaveChanges();
                return 200;
            }

        }

        public int UpdateById(int id,UserDto userDto)
        {
            var userInDb = _context.Users.FirstOrDefault(u=>u.Id==id);

            if (userInDb == null)
            {
                return 404;
            }
            else
            {
                //userInDb.Fname = user.Fname;
                //userInDb.LName = user.LName;
                //userInDb.Email = user.Email;
                Mapper.Map(userDto, userInDb);

                _context.SaveChanges();
                return 200;
            }

        }
        
        
        public User LoggedUser(string userName, string password)
        {
            var user =  _context.Users.Where(u => u.Email == userName && u.Password==password).Include(t=>t.UserType).SingleOrDefault();

            return user;

        }


        //to get UserRoles
        public IEnumerable<UserType> UserRoles()
        {
            return _context.UserTypes;
           
        }

        //All Project Managers
        public IEnumerable<User> GetAllProjectManagers()
        {
            return _context.Users.Include(r => r.UserType).Where(u => u.UserType.TypeName == "Project Manager");
        }

        //All Project Leaders
        public IEnumerable<User> GetAllProjectLeaders()
        {
            return _context.Users.Include(r => r.UserType).Where(u => u.UserType.TypeName == "Project Leader");
        }

        //All Clients
        public IEnumerable<User> GetAllClients()
        {
            return _context.Users.Include(r => r.UserType).Where(u => u.UserType.TypeName == "Client");
        }

    }
}