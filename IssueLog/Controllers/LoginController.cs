using AutoMapper;
using IssueLog.Dtos;
using IssueLog.Models;
using IssueLog.Services;
using IssueLog.ViewModels;
using IssueLog.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IssueLog.Controllers
{
    public class LoginController : ApiController
    {
        private UserService _userService;

        public LoginController()
        {
            _userService = new UserService();
        }

        public IHttpActionResult Login(LoginInfo loginInfo)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid");
            }
            else
            {


                var user = _userService.LoggedUser(loginInfo.UserName, loginInfo.Password);

                if (user == null)
                {
                    return NotFound();
                }

                var model = new UserDetailsModel
                {
                    Id = user.Id,
                    Name = user.Fname + " " + user.LName,
                    Email = user.Email,
                    RoleId = user.UserTypeId,
                    RoleName = user.UserType.TypeName
                };

                return Ok(model);


            }

        }
    }
}
