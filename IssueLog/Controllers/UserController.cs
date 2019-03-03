using AutoMapper;
using IssueLog.Dtos;
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
    public class UserController : ApiController
    {
        private UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            return _userService.GetAll().Select(Mapper.Map<User, UserDto>); ;
           // return _userService.GetAll();
        }

        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<User, UserDto>(user));
            }
        }
        [HttpPost]
        public IHttpActionResult AddUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var newUser = Mapper.Map<UserDto, User>(userDto);
                var newAddedUser = _userService.AddUser(newUser);
                return Ok(newAddedUser.Id);
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {

            var result = _userService.DeleteById(id);

            return Ok(result);

        }

        [HttpPut]
        public IHttpActionResult EditUser(int id,UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                return Ok( _userService.UpdateById(id, userDto));
            }
        }

        [HttpGet]
        [Route("api/UserTypes")]
        public IHttpActionResult GetAllUserType()
        {
            var model = _userService.UserRoles();

            return  Ok(model);
        }

        [HttpGet]
        [Route("api/User/GetAllProjectManagers")]
        public IHttpActionResult GetAllProjectManagers()
        {
            var projectManagers = _userService.GetAllProjectManagers();

            if (projectManagers == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(projectManagers.Select(user => new SendPersonsInRole
                {
                    Id = user.Id,
                    Name = user.Fname + " " + user.LName

                }));
            }
        }

        [HttpGet]
        [Route("api/User/GetAllProjectLeaders")]
        public IHttpActionResult GetAllProjectLeaders()
        {
            var projectLeaders = _userService.GetAllProjectLeaders();

            if (projectLeaders == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(projectLeaders.Select(user => new SendPersonsInRole
                {
                    Id = user.Id,
                    Name = user.Fname + " " + user.LName

                }));
            }
        }

        [HttpGet]
        [Route("api/User/GetAllClients")]
        public IHttpActionResult GetAllClients()
        {
            var clients = _userService.GetAllClients();

            if (clients == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(clients.Select(user => new SendPersonsInRole
                {
                    Id = user.Id,
                    Name = user.Fname + " " + user.LName

                }));
            }
        }
    }
}
