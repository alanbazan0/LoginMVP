using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoginMVP.Core.Interfaces;
using LoginMVP.Core.Models;

namespace LoginMVP.Core.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
		private readonly IUsersRepository usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

		[HttpGet]
		public IActionResult Find(string username, string password)
		{
            return Ok(usersRepository.Find(username,password));
		}
    }
}
